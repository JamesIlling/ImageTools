﻿namespace MetadataExtractor.Tests.ProcessorTests
{
    using System;
    using System.Collections;
    using System.Linq;
    using DependencyFactory;
    using FluentAssertions;
    using NUnit.Framework;
    using Processors;

    [TestFixture]
    public class LensSpecificationProcessorTests : ProcessorTests<LensSpecificationProcessor>
    {
        public LensSpecificationProcessorTests()
            : base("/app1/ifd/exif/{ushort=42034}")
        {}

        private static Func<Metadata, decimal?> GetMinFocalLength { get; set; }
        private static Func<Metadata, decimal?> GetMaxFocalLength { get; set; }
        private static Func<Metadata, decimal?> GetMinAperture { get; set; }
        private static Func<Metadata, decimal?> GetMaxAperture { get; set; }

        [Test]
        [TestCaseSource(nameof(Metadata))]
        public void NoValueStoredIfPropertyIsNull(Func<Metadata, decimal?> getMetadata)
        {
            var processor = DependencyInjection.Resolve<LensSpecificationProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, null);

            getMetadata(metadata).Should().BeNull();
        }

        [Test]
        [TestCaseSource(nameof(ValidData))]
        public void ValidValueWrittenToMetadata(Func<Metadata, decimal?> getMetadata, long[] input, decimal? expected)
        {
            var processor = DependencyInjection.Resolve<LensSpecificationProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, input);

            var result = getMetadata(metadata);
            result.Should().Be(expected);
        }

        [Test]
        [TestCaseSource(nameof(SignData))]
        public void SignsCancelOutCorrectly(Func<Metadata, decimal?> getMetadata, long[] input, decimal? expected)
        {
            var processor = DependencyInjection.Resolve<LensSpecificationProcessor>();
            var metadata = new Metadata();

            processor.Process(metadata, input);

            var result = getMetadata(metadata);
            result.Should().Be(expected);
        }

        public static IEnumerable Metadata()
        {
            ConfigureMetadata();
            yield return new TestCaseData(GetMaxAperture);
            yield return new TestCaseData(GetMinAperture);
            yield return new TestCaseData(GetMaxFocalLength);
            yield return new TestCaseData(GetMinFocalLength);
        }

        public static IEnumerable ValidData()
        {
            ConfigureMetadata();
            int[] numerators = { 1, 2, 1, int.MaxValue , int.MaxValue };
            int[] denominators = { 1, 1, 2, int.MaxValue ,1};
            decimal?[] expected = {1, 2, 0.5m,1, int.MaxValue };

            for (var i = 0; i < numerators.Length; i++)
            {
                var numerator = numerators[i];
                var denominator = denominators[i];
                var data = new[]
                {
                    GetRational(numerator, denominator), GetRational(numerator, denominator),
                    GetRational(numerator, denominator), GetRational(numerator, denominator)
                };

                yield return new TestCaseData(GetMaxAperture, data, expected[i]);
                yield return new TestCaseData(GetMinAperture, data, expected[i]);
                yield return new TestCaseData(GetMaxFocalLength, data, expected[i]);
                yield return new TestCaseData(GetMinFocalLength, data, expected[i]);
            }
        }

        public static void ConfigureMetadata()
        {
            GetMaxAperture = x => x.MaxFStop;
            GetMinAperture = x => x.MinFStop;
            GetMaxFocalLength = x => x.MaxFocalLength;
            GetMinFocalLength = x => x.MinFocalLength;
        }

        public static IEnumerable SignData()
        {
            ConfigureMetadata();

            int[] numerators = { 1, 1, -1, -1  };
            int[] denominators = { 1, -1, 1, -1};
            decimal?[] expected = { 1, -1, -1, 1};

            for (var i = 0; i < numerators.Length; i++)
            {
                var numerator = numerators[i];
                var denominator = denominators[i];
                var data = new[]
                {
                    GetRational(numerator, denominator), GetRational(numerator, denominator),
                    GetRational(numerator, denominator), GetRational(numerator, denominator)
                };

                yield return new TestCaseData(GetMaxAperture, data, expected[i]);
                yield return new TestCaseData(GetMinAperture, data, expected[i]);
                yield return new TestCaseData(GetMaxFocalLength, data, expected[i]);
                yield return new TestCaseData(GetMinFocalLength, data, expected[i]);
            }
        }

        private static long GetRational(int numerator, int denominator)
        {
            var component = BitConverter.GetBytes(numerator).ToList();
            component.AddRange(BitConverter.GetBytes(denominator));
            var input = BitConverter.ToInt64(component.ToArray(), 0);
            return input;
        }
    }
}