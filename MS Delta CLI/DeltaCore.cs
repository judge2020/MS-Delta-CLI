using System;
using System.ComponentModel;
using System.IO;
using DeltaCompressionDotNet.MsDelta;
using DeltaCompressionDotNet.PatchApi;

namespace MS_Delta_CLI
{
    public static class DeltaCore
    {
        public static void CompressOperation(CLIOptions cliOptions)
        {
            FileValidation.ValidateInputFile(cliOptions.OldFile, cliOptions.IgnoreSizeLimit);
            Tools.Print("Old file is valid!");
            FileValidation.ValidateInputFile(cliOptions.OldFile, cliOptions.IgnoreSizeLimit);
            Tools.Print("New file is valid!");
            Tools.TrueOrDie(FileValidation.AreDifferentFiles(cliOptions.OldFile, cliOptions.NewFile), "Files are different sizes!");
            Tools.Print("Both files valid, delta encoding NOW.");
            var result = PerformCompress(cliOptions.OldFile, cliOptions.NewFile, cliOptions.DestFile, cliOptions.IgnoreSizeLimit);
            Tools.TrueOrDie(false, result);
        }

        public static string PerformCompress(string oldfile, string newfile, string destfile, bool IgnoreSizeLimit)
        {
            try
            {
                if(IgnoreSizeLimit)
                {
                    var dest = destfile.Replace("[]", Path.GetFileNameWithoutExtension(newfile));
                    var compression = new MsDeltaCompression();
                    compression.CreateDelta(oldfile, newfile, dest);
                    return dest;
                }
                else
                {
                    var dest = destfile.Replace("[]", Path.GetFileNameWithoutExtension(newfile));
                    var compression = new PatchApiCompression();
                    compression.CreateDelta(oldfile, newfile, dest);
                    return dest;
                }
            }
            catch (Win32Exception ex)
            {
                Tools.TrueOrDie(false, "Error when creating delta. Native error code " + ex.NativeErrorCode);
                return "";
            }

        }
    }
}