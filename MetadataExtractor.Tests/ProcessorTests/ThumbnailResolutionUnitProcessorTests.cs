namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class ThumbnailResolutionUnitProcessorTests :
        EnumTests<ThumbnailResolutionUnitProcessor, ResolutionUnit>
    {
        public ThumbnailResolutionUnitProcessorTests()
            : base(x => x.ThumbnailResolutionUnit, "/app1/thumb/{ushort=296}")
        { }
    }
}