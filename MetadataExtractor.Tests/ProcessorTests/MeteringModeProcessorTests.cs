namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class MeteringModeProcessorTests : EnumTests<MeteringModeProcessor, MeteringMode>
    {
        public MeteringModeProcessorTests()
            : base(x => x.MeteringMode, "/app1/ifd/exif/{ushort=37383}")
        {}
    }
}