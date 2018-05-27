namespace MetadataExtractor.Tests.ProcessorTests.Xmp
{
    using Processors.Xmp;
    using TestBaseClasses;

    public class LensSerialNumberProcessorTests : StringTests<LensSerialNumberProcessor>
    {
        public LensSerialNumberProcessorTests()
            : base(x => x.LensSerialNumber, "/xmp/aux:LensID")
        { }
    }
}