﻿using CommandLine;

namespace ImageTools.Options
{
    [Verb("Test",Hidden = true)]
    public class TestOptions
    {
        [Option ('f',"folder",Default = "e:\\")]
        public string Folder { get; set; }

    }
}
