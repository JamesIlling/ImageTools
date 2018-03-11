namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class CameraModelProcessorTests : StringTests<CameraModelProcessor>
    {
        public CameraModelProcessorTests()
            : base(x => x.CameraModel, "/app1/ifd/{ushort=272}")
        {}
    }
}