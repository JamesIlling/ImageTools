using System.Linq;

namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using FluentAssertions;
    using Logging;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class FlashProcessorTests : ProcessorTests<FlashProcessor>
    {
        public FlashProcessorTests()
            :base(0x9209,string.Empty)
        {
        }

        [TestCase((ushort)0x0000, false,true,false,StrobeReturnEnum.NoStrobeReturn,FiringModeEnum.Unknown)]
        [TestCase((ushort)0x0001, true, true, false, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.Unknown)]
        [TestCase((ushort)0x0005, true, true, false, StrobeReturnEnum.StrobeReturnNotDetected, FiringModeEnum.Unknown)]
        [TestCase((ushort)0x0007, true, true, false, StrobeReturnEnum.StrobeReturnDetected, FiringModeEnum.Unknown)]
        [TestCase((ushort)0x0008, false, true, false, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.CompulsoryFiring)]
        [TestCase((ushort)0x0009, true, true, false, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.CompulsoryFiring)]
        [TestCase((ushort)0x000D, true, true, false, StrobeReturnEnum.StrobeReturnNotDetected, FiringModeEnum.CompulsoryFiring)]
        [TestCase((ushort)0x000F, true, true, false, StrobeReturnEnum.StrobeReturnDetected, FiringModeEnum.CompulsoryFiring)]
        [TestCase((ushort)0x0010, false, true, false, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.CompulsorySuppression)]
        [TestCase((ushort)0x0014, false, true, false, StrobeReturnEnum.StrobeReturnNotDetected, FiringModeEnum.CompulsorySuppression)]
        [TestCase((ushort)0x0018, false, true, false, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.Auto)]
        [TestCase((ushort)0x0019, true, true, false, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.Auto)]
        [TestCase((ushort)0x001d, true, true, false, StrobeReturnEnum.StrobeReturnNotDetected, FiringModeEnum.Auto)]
        [TestCase((ushort)0x001f, true, true, false, StrobeReturnEnum.StrobeReturnDetected, FiringModeEnum.Auto)]
        [TestCase((ushort)0x0020, false, false, false, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.Unknown)]
        [TestCase((ushort)0x0030, false, false, false, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.CompulsorySuppression)]
        [TestCase((ushort)0x0041, true, true, true, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.Unknown)]
        [TestCase((ushort)0x0045, true, true, true, StrobeReturnEnum.StrobeReturnNotDetected, FiringModeEnum.Unknown)]
        [TestCase((ushort)0x0047, true, true, true, StrobeReturnEnum.StrobeReturnDetected, FiringModeEnum.Unknown)]
        [TestCase((ushort)0x0049, true, true, true, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.CompulsoryFiring)]
        [TestCase((ushort)0x004D, true, true, true, StrobeReturnEnum.StrobeReturnNotDetected, FiringModeEnum.CompulsoryFiring)]
        [TestCase((ushort)0x004F, true, true, true, StrobeReturnEnum.StrobeReturnDetected, FiringModeEnum.CompulsoryFiring)]
        [TestCase((ushort)0x0050, false, true, true, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.CompulsorySuppression)]
        [TestCase((ushort)0x0058, false, true, true, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.Auto)]
        [TestCase((ushort)0x0059, true, true, true, StrobeReturnEnum.NoStrobeReturn, FiringModeEnum.Auto)]
        [TestCase((ushort)0x005D, true, true, true, StrobeReturnEnum.StrobeReturnNotDetected, FiringModeEnum.Auto)]
        [TestCase((ushort)0x005F, true, true, true, StrobeReturnEnum.StrobeReturnDetected, FiringModeEnum.Auto)]
        public void MetadataFieldPopulated(ushort value, bool flashFired, bool flashFunction, bool redEyeReduction, StrobeReturnEnum strobeReturn, FiringModeEnum firingMode)
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = Processor.Id, Value = ExifTypeHelper.GetShort(value) };
            Processor.Process(metadata, property);
            metadata.FlashFired.Should().Be(flashFired);
            metadata.FlashFunction.Should().Be(flashFunction);
            metadata.RedEyeReduction.Should().Be(redEyeReduction);
            metadata.StrobeReturn.Should().Be(strobeReturn);
            metadata.FiringMode.Should().Be(firingMode);
        }

        [Test]
        public void UnknownValueIsLogged()
        {
            var metadata = new Metadata();
            var property = new ExifProperty { Id = Processor.Id, Value = ExifTypeHelper.GetShort(0x0002) };
            var log = ((TestLog)((FlashProcessor)Processor).Log).Messages;
            log.Clear();
            Processor.Process(metadata, property);

            log.Count.Should().Be(1);
            var message = log.First();
            message.Level.Should().Be("Warning");
            message.Message.Should().Be(string.Format(FlashProcessor.StrobeReturnError, 0x0002));
        }
    }
}
