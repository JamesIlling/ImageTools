namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]

    public class ThumbnailResolutionUnitProcessorTests:EnumTests<ThumbnailResolutionUnitProcessor,ResolutionUnitEnum,ushort>
    {
        public ThumbnailResolutionUnitProcessorTests()
            :base(x=>x.ThumbnailResolutionUnit, "/app1/thumb/{ushort=296}")
        {
        }
    }
}
