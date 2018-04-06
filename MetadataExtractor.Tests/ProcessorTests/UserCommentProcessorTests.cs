namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;
    using TestBaseClasses;

    [TestFixture]
    public class UserCommentProcessorTests : StringTests<UserCommentProcessor>
    {
        public UserCommentProcessorTests()
            : base(x => x.UserComment, "/app1/ifd/exif/{ushort=37510}")
        { }
    }
}