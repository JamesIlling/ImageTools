namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class ExposureProgramProcessorTests
    {
        private readonly IMetaDataElementProcessor _processor = new ExposureProgramProcessor { Log = new TestLog() };

        [TestCase((ushort)0x0000, ExposureProgramEnum.NotDefined)]
        [TestCase((ushort)0x0001, ExposureProgramEnum.Manual)]
        [TestCase((ushort)0x0002, ExposureProgramEnum.Program)]
        [TestCase((ushort)0x0003, ExposureProgramEnum.AperturePriority)]
        [TestCase((ushort)0x0004, ExposureProgramEnum.ShutterPriority)]
        [TestCase((ushort)0x0005, ExposureProgramEnum.Creative)]
        [TestCase((ushort)0x0006, ExposureProgramEnum.Action)]
        [TestCase((ushort)0x0007, ExposureProgramEnum.Portrait)]
        [TestCase((ushort)0x0008, ExposureProgramEnum.Landscape)]
        [TestCase((ushort)0x0009, ExposureProgramEnum.Bulb)]
        [TestCase((ushort)0x000A, null)]

        public void MetadataFieldPopulated(ushort value, ExposureProgramEnum? result)
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(value) };
            _processor.Process(metadata, property);
            metadata.ExposureProgram.Should().BeEquivalentTo(result);
        }

        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = _processor.Id, Value = ExifTypeHelper.GetShort(0x00A) };
            var log = ((TestLog)((ExposureProgramProcessor)_processor).Log).Messages;
            log.Clear();
            _processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(ExposureProgramProcessor.Error, 0x00A));
        }

        [Test]
        public void IndexMatchesExifSpecification()
        {
            _processor.Id.Should().Be(0x8822);
        }
    }
}
