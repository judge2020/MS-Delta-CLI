using System;
using CommandLine;
using CommandLine.Text;

namespace MS_Delta_CLI
{
    public class CLIOptions
    {
        [Option('o', "oldfile", Required = true,
            HelpText = "Old file.")]
        public string OldFile { get; set; }

        [Option('n', "newfile", Required = true,
            HelpText = "New file.")]
        public string NewFile { get; set; }

        [Option('d', "destfile", Required = false, DefaultValue = "[].delta",
            HelpText = "Destination file. Can have any extension. [] will be replaced with the NEW file's file name (without extension).")]
        public string DestFile { get; set; }

        [Option("ignoreSizeLimit", DefaultValue = false, 
            HelpText = "Ignore size limit. May cause an unexpected exit if the source or destination file is too large.")]
        public bool IgnoreSizeLimit { get; set; }

        [Option('v', "verbose", DefaultValue = false,
            HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}