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
        public static CLIOptions CliOptions = new CLIOptions();

        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArgumentsStrict(args, CliOptions);
            Tools.Print("Command line arguments parsed successfully!");
            DeltaCore.CompressOperation(CliOptions);
        }
    }
}
