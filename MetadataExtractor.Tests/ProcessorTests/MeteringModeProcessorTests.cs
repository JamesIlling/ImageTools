using MetadataExtractor.Tests.TestBaseClasses;

namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class MeteringModeProcessorTests : EnumTests<MeteringModeProcessor, MeteringModeEnum, ushort>
    {
        public MeteringModeProcessorTests()
            : base(x => x.MeteringMode, "/app1/ifd/exif/{ushort=37383}")
        {}
    }
}