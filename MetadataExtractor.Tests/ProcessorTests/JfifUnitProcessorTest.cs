namespace MetadataExtractor.Tests.ProcessorTests
{
    using Enums;
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class JfifUnitProcessorTest :
        EnumTests<JfifUnitProcessor, ResolutionUnit>
    {
        public JfifUnitProcessorTest()
            : base(x => x.ResolutionUnit, "/app0/{ushort=1}")
        { }
    }
}