namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class CopyrightProcessorTests : StringTests<CopyrightProcessor>
    {
        public CopyrightProcessorTests()
            : base(x => x.Copyright, "/app1/ifd/{ushort=33432}")
        {}
    }
}