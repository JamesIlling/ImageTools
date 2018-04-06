namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ResolutionUnitProcessorTests : EnumTests<ResolutionUnitProcessor, ResolutionUnit>
    {
        public ResolutionUnitProcessorTests()
            : base(x => x.ResolutionUnit, "/app1/ifd/{ushort=296}")
        { }
    }
}