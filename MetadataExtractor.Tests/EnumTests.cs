namespace MetadataExtractor.Tests
{
    using System.Linq;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;

    public abstract class EnumTests<T> : ProcessorTests<T> where T : IErrorableMetaDataElementProcessor
    {
        public EnumTests(int id, string result)
            : base(id, result)
        {}

        [Test]
        public void UnknownValueIsLogged()
        {
            const ushort testValue = 0x90;
            var metadata = new Metadata();
            var property = new ExifProperty {Id = Processor.Id, Value = ExifTypeHelper.GetShort(testValue) };
            var log = ((TestLog) ((T) Processor).Log).Messages;
            log.Clear();
            Processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(((T) Processor).Error, testValue));
        }
    }
}