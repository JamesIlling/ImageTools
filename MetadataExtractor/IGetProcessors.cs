﻿namespace MetadataExtractor
{
    using System.Collections.Generic;

    public interface IGetProcessors
    {
        List<IMetaDataElementProcessor> GetAll();
    }
}