using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Enumerable = System.Linq.Enumerable;
using ByteSizeLib;

namespace MS_Delta_CLI
{
    public static class Tools
    {
        public static bool Over32Megabytes(string filepath)
        {
            return ByteSize.FromBytes(new FileInfo(filepath).Length).MegaBytes <= 32;
        }

        public static void RequireTrue(bool required, string errorMessage, bool fatal = true)
        {
            if(!required)
            {
                Print(errorMessage, false);
                if(fatal)
                    Environment.Exit(1);
            }
        }

        public static void Print(string message, bool verbose = true)
        {
            if(Program._cliOptions.LastParserState == null)
            {
                Console.WriteLine(message);
                return;
            }
            if(verbose && !Program._cliOptions.Verbose)
            {
                return;
            }
            Console.WriteLine(message);
        }
    }
}