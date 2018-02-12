﻿namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ContrastProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ContrastProcessor {Log = new TestLog()};

        [TestCase((ushort) 0x0000, ContrastEnum.Normal)]
        [TestCase((ushort) 0x0001, ContrastEnum.Soft)]
        [TestCase((ushort) 0x0002, ContrastEnum.Hard)]
        [TestCase((ushort) 0x0005, null)]
        public void MetadataFieldPopulated(ushort value, ContrastEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty {Id = _processor.Id, Value = ExifTypeHelper.GetShort(value)};
            _processor.Process(metadata, property);
            metadata.Contrast.Should().BeEquivalentTo(result);
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0xA408);
        }

        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(0x005) };
            var log = ((TestLog)((ContrastProcessor)_processor).Log).Messages;
            log.Clear();
            _processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(ContrastProcessor.Error, 0x005));
        }
    }
}