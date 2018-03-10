namespace MetadataExtractor.Processors
{
    using System;
    using System.Windows.Media.Imaging;
    using Enums;

    public class CfaPatternProcessor : ISupportQueries
    {
        public string Query => "/app1/ifd/exif/{ushort=41730}";


        public void Process(Metadata metadata, object property)
        {
            var grid = ((BitmapMetadataBlob) property).GetBlobValue();
            var height = BitConverter.ToUInt16(grid, 0);
            var width = BitConverter.ToUInt16(grid, 2);
            var array = new ColourFilterArrayEnum[height, width];
            for (var row = 0; row < height; row++)
            {
                for (var column = 0; column < width; column++)
                {
                    array[row, column] = (ColourFilterArrayEnum) grid[4 + (row * width) + column];
                }
            }
            metadata.ColourFilterArrayPattern = array;
        }
    }
}