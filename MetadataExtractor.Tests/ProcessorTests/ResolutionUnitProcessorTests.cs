namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using Processors;

    class ResolutionUnitProcessorTests : EnumTest<ResolutionUnitProcessor, ResolutionUnitEnum,ushort>
    {
        public ResolutionUnitProcessorTests()
            :base(x=>x.ResolutionUnit, "/app1/ifd/{ushort=296}")
        {
        }
    }
}
