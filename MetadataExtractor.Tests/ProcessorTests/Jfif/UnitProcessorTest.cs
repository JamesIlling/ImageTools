namespace MetadataExtractor.Tests.ProcessorTests.Jfif
{
    using Enums;
    using NUnit.Framework;
    using Processors.Jfif;
    using TestBaseClasses;

    [TestFixture]
    public class UnitProcessorTest :
        EnumTests<UnitProcessor, ResolutionUnit>
    {
        public UnitProcessorTest()
            : base(x => x.ResolutionUnit, "/app0/{ushort=1}")
        { }
    }
}