namespace MetadataExtractor.Tests.ProcessorTests
{
    using System.Collections;
    using System.Linq;
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors.Exif;

    [TestFixture]
    public class FlashProcessorTest : ErrorableProcessorTests<FlashProcessor>
    {
        public FlashProcessorTest()
            : base("/app1/ifd/exif/{ushort=37385}")
        { }

        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueNotWrittenToMetadata(ushort value)
        {
            var metadata = new Metadata();

            Processor.Process(metadata, value);

            metadata.FlashFired.Should().BeNull();
            metadata.FlashFunction.Should().BeNull();
            metadata.RedEyeReduction.Should().BeNull();
            metadata.StrobeReturn.Should().BeNull();
            metadata.FiringMode.Should().BeNull();
        }

        [TestCaseSource(nameof(InvalidValue))]
        public void InvalidValueLogged(ushort value)
        {
            var testLogger = Processor?.Log as TestLog;
            Assert.NotNull(testLogger);
            var metadata = new Metadata();

            Processor.Process(metadata, value);

            testLogger.Messages.Count.Should().Be(1);
            var logEntry = testLogger.Messages.FirstOrDefault();
            Assert.NotNull(logEntry);
            logEntry.Level.Should().Be("Warning");
            logEntry.Message.Should().Be(string.Format(Processor.Error, value));
        }

        [TestCase((ushort) 0x0000, false, true, false, StrobeReturn.NoStrobeReturn, FiringMode.Unknown)]
        [TestCase((ushort) 0x0001, true, true, false, StrobeReturn.NoStrobeReturn, FiringMode.Unknown)]
        [TestCase((ushort) 0x0005, true, true, false, StrobeReturn.StrobeReturnNotDetected, FiringMode.Unknown)]
        [TestCase((ushort) 0x0007, true, true, false, StrobeReturn.StrobeReturnDetected, FiringMode.Unknown)]
        [TestCase((ushort) 0x0008, false, true, false, StrobeReturn.NoStrobeReturn, FiringMode.CompulsoryFiring)]
        [TestCase((ushort) 0x0009, true, true, false, StrobeReturn.NoStrobeReturn, FiringMode.CompulsoryFiring)]
        [TestCase((ushort) 0x000D, true, true, false, StrobeReturn.StrobeReturnNotDetected, FiringMode.CompulsoryFiring)]
        [TestCase((ushort) 0x000F, true, true, false, StrobeReturn.StrobeReturnDetected, FiringMode.CompulsoryFiring)]
        [TestCase((ushort) 0x0010, false, true, false, StrobeReturn.NoStrobeReturn, FiringMode.CompulsorySuppression)]
        [TestCase((ushort) 0x0014, false, true, false, StrobeReturn.StrobeReturnNotDetected, FiringMode.CompulsorySuppression)]
        [TestCase((ushort) 0x0018, false, true, false, StrobeReturn.NoStrobeReturn, FiringMode.Auto)]
        [TestCase((ushort) 0x0019, true, true, false, StrobeReturn.NoStrobeReturn, FiringMode.Auto)]
        [TestCase((ushort) 0x001d, true, true, false, StrobeReturn.StrobeReturnNotDetected, FiringMode.Auto)]
        [TestCase((ushort) 0x001f, true, true, false, StrobeReturn.StrobeReturnDetected, FiringMode.Auto)]
        [TestCase((ushort) 0x0020, false, false, false, StrobeReturn.NoStrobeReturn, FiringMode.Unknown)]
        [TestCase((ushort) 0x0030, false, false, false, StrobeReturn.NoStrobeReturn, FiringMode.CompulsorySuppression)]
        [TestCase((ushort) 0x0041, true, true, true, StrobeReturn.NoStrobeReturn, FiringMode.Unknown)]
        [TestCase((ushort) 0x0045, true, true, true, StrobeReturn.StrobeReturnNotDetected, FiringMode.Unknown)]
        [TestCase((ushort) 0x0047, true, true, true, StrobeReturn.StrobeReturnDetected, FiringMode.Unknown)]
        [TestCase((ushort) 0x0049, true, true, true, StrobeReturn.NoStrobeReturn, FiringMode.CompulsoryFiring)]
        [TestCase((ushort) 0x004D, true, true, true, StrobeReturn.StrobeReturnNotDetected, FiringMode.CompulsoryFiring)]
        [TestCase((ushort) 0x004F, true, true, true, StrobeReturn.StrobeReturnDetected, FiringMode.CompulsoryFiring)]
        [TestCase((ushort) 0x0050, false, true, true, StrobeReturn.NoStrobeReturn, FiringMode.CompulsorySuppression)]
        [TestCase((ushort) 0x0058, false, true, true, StrobeReturn.NoStrobeReturn, FiringMode.Auto)]
        [TestCase((ushort) 0x0059, true, true, true, StrobeReturn.NoStrobeReturn, FiringMode.Auto)]
        [TestCase((ushort) 0x005D, true, true, true, StrobeReturn.StrobeReturnNotDetected, FiringMode.Auto)]
        [TestCase((ushort) 0x005F, true, true, true, StrobeReturn.StrobeReturnDetected, FiringMode.Auto)]
        public void ValidDataWrittenToMetadata(ushort value, bool flashFired, bool flashFunction, bool redEyeReduction,
            StrobeReturn strobeReturn, FiringMode firingMode)
        {
            var metadata = new Metadata();
            Processor.Process(metadata, value);
            metadata.FlashFired.Should().Be(flashFired);
            metadata.FlashFunction.Should().Be(flashFunction);
            metadata.RedEyeReduction.Should().Be(redEyeReduction);
            metadata.StrobeReturn.Should().Be(strobeReturn);
            metadata.FiringMode.Should().Be(firingMode);
        }

        private static IEnumerable InvalidValue()
        {
            yield return new TestCaseData((ushort) 0xff);
        }

        [Test]
        public void NoValueStoredIfPropertyIsNull()
        {
            var metadata = new Metadata();

            Processor.Process(metadata, null);
            metadata.FlashFired.Should().BeNull();
            metadata.FlashFunction.Should().BeNull();
            metadata.RedEyeReduction.Should().BeNull();
            metadata.StrobeReturn.Should().BeNull();
            metadata.FiringMode.Should().BeNull();
        }
    }
}