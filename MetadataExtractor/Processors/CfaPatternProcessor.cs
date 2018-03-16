namespace MetadataExtractor.Processors
{
    using System;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Enums;

    public class CfaPatternProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41730}";


        public void Process(Metadata metadata, object property)
        {
            if (property != null)
            {
                if (property is BitmapMetadataBlob data)
                {
                    var grid = data.GetBlobValue();

                    var height = BitConverter.ToUInt16(grid, 0);
                    var width = BitConverter.ToUInt16(grid, 2);

                    if (height * width + 4 != grid.Length)
                    {
                        height = BitConverter.ToUInt16(BitConverter.GetBytes(height).Reverse().ToArray(), 0);
                        width = BitConverter.ToUInt16(BitConverter.GetBytes(width).Reverse().ToArray(), 0);
                    }

                    if (height * width + 4 == grid.Length)
                    {
                        var array = new ColourFilterArrayEnum[height, width];
                        for (var row = 0; row < height; row++)
                        {
                            for (var column = 0; column < width; column++)
                            {
                                array[row, column] = (ColourFilterArrayEnum) grid[4 + row * width + column];
                            }
                        }
                        metadata.ColourFilterArrayPattern = array;
                    }
                }
            }
        }
    }
}