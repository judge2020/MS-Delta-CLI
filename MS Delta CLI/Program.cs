using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Delta_CLI
{
    class Program
    {
        public static CLIOptions _cliOptions = new CLIOptions();

        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArgumentsStrict(args, _cliOptions, () =>
            {
                Tools.Print(_cliOptions.GetUsage(), false);
                Environment.Exit(1);
            });
            Tools.Print("Command line arguments parsed successfully");
            FileValidation.ValidateInputFile(_cliOptions.InputFile, _cliOptions.IgnoreSizeLimit);


        }
    }
}
