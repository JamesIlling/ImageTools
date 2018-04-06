namespace MetadataExtractor.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class MetadataItemTests
    {
        [Test]
        public void CanUpdateQuery()
        {
            var item = new MetadataItem("type", "query");
            item.Query.Should().Be("query");
            item.Query = "test";
            item.Query.Should().Be("test");
        }

        [Test]
        public void ConstructorPopulatesVariables()
        {
            var item = new MetadataItem("type", "query");
            item.Type.Should().Be("type");
            item.Query.Should().Be("query");
        }
    }
}