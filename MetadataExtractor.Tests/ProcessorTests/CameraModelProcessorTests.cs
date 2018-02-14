namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class CameraModelProcessorTests : StringTests<CameraModelProcessor>
    {
        public CameraModelProcessorTests()
            : base(0x0110, "CameraModel")
        {}
    }
}