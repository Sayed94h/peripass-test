
using System.IO;

namespace PeripassTest.FileHandler
{
    internal class FileReader
    {

        private readonly string _filePath;
        internal FileReader(string path)
        {
            _filePath = path;
        }

        internal List<string> GetContent()
        {
            List<string> content = new();
            string? line;
            try
            {
                StreamReader reader = new(_filePath);

                line = reader.ReadLine();
                
                // because the content of input.txt is duplicated,
                // I think that the second half of the content is not necessary

                string? firstLine = line;

                while (line != null)
                {
                    // stop reading the file when it reaches the second half of the content
                    // you can read the entire file and then remove duplicates but in my opinion it is better not to read the duplicates
                    if (content.Count > 1 && line == firstLine)
                    {
                        break;
                    }

                    content.Add(line);
                    line = reader.ReadLine();
                }

                reader.Close();
                Console.WriteLine("\nReading job successfully Done...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError reading file: {ex.Message}");
            }

            return content;
        }
    }
}
