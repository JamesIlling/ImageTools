using MetadataExtractor.Tests.TestBaseClasses;

namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using Processors;

    internal class ResolutionUnitProcessorTests : EnumTests<ResolutionUnitProcessor, ResolutionUnitEnum, ushort>
    {
        public ResolutionUnitProcessorTests()
            : base(x => x.ResolutionUnit, "/app1/ifd/{ushort=296}")
        {}
    }
}