namespace MetadataExtractor.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media.Imaging;
    using Enums;

    public class CfaPatternProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41730}";


        public void Process(Metadata metadata, object property)
        {
            if (property != null && property is BitmapMetadataBlob data)
            {
                var grid = data.GetBlobValue();

                var height = BitConverter.ToUInt16(grid, 0);
                var width = BitConverter.ToUInt16(grid, 2);

                if (!GridSizeIsValid(grid, height, width))
                {
                    height = ToOtherEndianess(height);
                    width = ToOtherEndianess(width);
                }

                if (GridSizeIsValid(grid, height, width))
                {
                    metadata.ColourFilterArrayPattern = BuildArray(grid, height, width);
                }
            }
        }

        private static ColourFilterArray[,] BuildArray(IReadOnlyList<byte> grid, ushort height, ushort width)
        {
            var array = new ColourFilterArray[height, width];
            for (var row = 0; row < height; row++)
            {
                for (var column = 0; column < width; column++)
                {
                    array[row, column] = (ColourFilterArray) grid[4 + row * width + column];
                }
            }
            return array;
        }

        private static bool GridSizeIsValid(IReadOnlyCollection<byte> grid, ushort height, ushort width)
        {
            return height * width + 4 == grid.Count;
        }

        private static ushort ToOtherEndianess(ushort value)
        {
            return BitConverter.ToUInt16(BitConverter.GetBytes(value).Reverse().ToArray(), 0);
        }
    }
}