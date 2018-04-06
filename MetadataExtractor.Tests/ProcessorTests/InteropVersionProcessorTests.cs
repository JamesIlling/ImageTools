using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetadataExtractor.Tests.ProcessorTests
{
    using NUnit.Framework;
    using Processors;

    [TestFixture]
   public  class InteropVersionProcessorTests : SeparatedStringProcessorTests<InteropVersionProcessor>
    {
        public InteropVersionProcessorTests()
            :base(x=>x.InteropVersion, "/app1/ifd/exif/interop/{ushort=2}")
        {
            
        }
    }
}
