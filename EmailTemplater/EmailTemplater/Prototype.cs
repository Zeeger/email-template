using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EmailTemplater
{
    static class Prototype
    {

        static string winDir = System.Environment.GetEnvironmentVariable("windir");

        static string sourceFilename = "newtemplate.oft";
        static string targetFilename = "newtemplate_replaced.oft";

        static Encoding fileEncoding = Encoding.Default;

        static void WriteFileWithReplacedValue()
        {
            WriteFileWithReplacedValue();
            List<string> fileContents = ReadFileToStringList();

            fileContents = ReplaceArgumentsInFile(fileContents);

            //WriteFileToScreen(fileContents);

            WriteFileToDisk(fileContents);
        }

        static void WriteFileToDisk(List<string> fileContents)
        {
            var stream = new FileStream(targetFilename, FileMode.CreateNew);
            var writer = new StreamWriter(stream, fileEncoding);

            foreach (var x in fileContents)
            {
                writer.WriteLine(x);
            }

            writer.Close();
        }

        static List<string> ReplaceArgumentsInFile(List<string> fileContents)
        {
            var replacedFileContents = new List<string>();

            foreach (var x in fileContents)
            {
                replacedFileContents.Add(x.Replace("<ARG01>", "humperdink"));
            }

            return replacedFileContents;
        }

        static List<string> ReadFileToStringList()
        {
            var stream = new FileStream(sourceFilename, FileMode.Open);

            List<string> fileContents = new List<string>();

            StreamReader reader = new StreamReader(stream, fileEncoding);

            do
            {
                fileContents.Add(reader.ReadLine());
            }
            while (reader.Peek() != -1);

            reader.Close();
            stream.Close();

            return fileContents;
        }

        static void WriteFileToScreen(List<string> fileContents)
        {
            foreach (var x in fileContents)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }
    }
}
