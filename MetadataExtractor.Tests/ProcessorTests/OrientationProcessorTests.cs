namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class OrientationProcessorTests : EnumTests<OrientationProcessor,OrientationEnum,ushort>
    {
        public OrientationProcessorTests()
            :base(x=>x.Orientation,"/app1/ifd/{uint=274}")
        {
        }
    }
}
