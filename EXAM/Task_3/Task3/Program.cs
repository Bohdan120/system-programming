using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static async Task Main()
        {
            string filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Files");

           
            string[] fileNames = Directory.GetFiles(filesDirectory);

            List<Task<Dictionary<string, int>>> tasks = new List<Task<Dictionary<string, int>>>();
            foreach (string fileName in fileNames)
            {
                tasks.Add(ProcessFileAsync(fileName));
            }

        
            await Task.WhenAll(tasks);

         
            Dictionary<string, int> finalResult = new Dictionary<string, int>();
            foreach (var taskResult in tasks.Select(t => t.Result))
            {
                foreach (var kvp in taskResult)
                {
                    if (finalResult.ContainsKey(kvp.Key))
                    {
                        finalResult[kvp.Key] += kvp.Value;
                    }
                    else
                    {
                        finalResult[kvp.Key] = kvp.Value;
                    }
                }
            }

           
            WriteResultToFile(finalResult, "final_result.txt");

            Console.WriteLine("Завершено!\nРезультат записано у файл bin\\Debug\\final_result.txt ");
        }

        static async Task<Dictionary<string, int>> ProcessFileAsync(string fileName)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] words = line.Split(' ');

                    foreach (string word in words)
                    {
                        if (wordCount.ContainsKey(word))
                        {
                            wordCount[word]++;
                        }
                        else
                        {
                            wordCount[word] = 1;
                        }
                    }
                }
            }

            return wordCount;
        }

        static void WriteResultToFile(Dictionary<string, int> result, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var kvp in result)
                {
                    writer.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}

