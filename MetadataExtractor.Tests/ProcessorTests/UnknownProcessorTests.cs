namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class UnknownProcessorTests : UnsupportedProcessorTests<UnknownProcessor>
    {
        public UnknownProcessorTests()
            : base("/unknown/{}")
        { }
    }
}