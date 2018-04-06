namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using Processors;
    using TestBaseClasses;

    internal class ResolutionUnitProcessorTests : EnumTests<ResolutionUnitProcessor, ResolutionUnit>
    {
        public ResolutionUnitProcessorTests()
            : base(x => x.ResolutionUnit, "/app1/ifd/{ushort=296}")
        {}
    }
}