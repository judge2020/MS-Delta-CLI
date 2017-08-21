using System;
using CommandLine;
using CommandLine.Text;

namespace MS_Delta_CLI
{
    public class CLIOptions
    {
        [Option('i', "input", Required = true,
            HelpText = "Input file to be processed.")]
        public string InputFile { get; set; }

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