using System.IO;

namespace MS_Delta_CLI
{
    public static class FileValidation
    {
        public static void ValidateInputFile(string filepath, bool ignoreSizeLimit)
        {
            //Doesn't contain illegal characters in file path
            Tools.RequireTrue(File.Exists(filepath), "Input file does not exist");
            Tools.Print("Input file exists");
            //Isn't a directory (may impliment recursion later)
            Tools.RequireTrue(!Directory.Exists(filepath), "Input file is a directory, which currently isn't supported.");
            Tools.Print("Input file is not a directory.");
            //Check the file isn't over 32 MB (memory size limit for Delta) and that they didn't want to ignore this.
            Tools.RequireTrue(Tools.Over32Megabytes(filepath) && !ignoreSizeLimit, "Input file is over 32 MB and may cause memory issues. pass --ignoreSizeLimit to ignore this message.");

        }
    }
}