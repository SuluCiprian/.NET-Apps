
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOPBasicApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu();
        }

        public static TextReader GetInputTextReader()
        {
            TextReader readFile = null; 
            try
            {
                //string inputPath = @"C:\Users\ciprian.sulu\source\repos\OOPBasicApp\OOPBasicApp\input.txt";
                string inputPath = @"E:\input.txt";
                readFile = new StreamReader(inputPath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File was not found! " + ex.FileName + " Please create the file!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }

            return readFile;
        }

        public static BinaryWriter GetOutputBinaryWriter()
        {
            BinaryWriter writer = null;
            try
            {
                //string outputPath = @"C:\Users\ciprian.sulu\source\repos\OOPBasicApp\OOPBasicApp\encoded.bin";
                string outputPath = @"E:\encoded.bin";
                writer = new BinaryWriter(File.Open(outputPath, FileMode.Create));
            }
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine("Unauthorized acces! Message: " + ex.Message);
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            
            return writer;
        }

        public static void Menu()
        {
            PluginsManager pluginManager = new PluginsManager();
            pluginManager.LoadPlugins();

            TextReader reader = GetInputTextReader();
            BinaryWriter writer = GetOutputBinaryWriter();
            int pluginNumber = 0, option = 0;

            foreach (var plugin in pluginManager.Plugins)
            {
                Console.WriteLine(++pluginNumber + ". " + plugin.GetName());
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter your option:");

            option = Convert.ToInt32(Console.ReadLine());
            pluginNumber = 1;

            foreach (var plugin in pluginManager.Plugins)
            {
                if (option == pluginNumber)
                {
                    List<string> arguments = (List<string>)plugin.GetRequiredArguments();
                    if(arguments.Count != 0)
                    {
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        Console.WriteLine("Enter parameters: ");
                        foreach(var arg in arguments)
                        {
                            Console.WriteLine(arg + ": ");
                            parameters[arg] = Console.ReadLine();
                        }
                        plugin.SetArguments(parameters);
                    }
                    TextEncoder textEncoder = new TextEncoder(plugin.GetEncoder());
                    StreamEncoder streamEncoder = new StreamEncoder(textEncoder, reader);
                    streamEncoder.Encode(writer);
                    Console.WriteLine(plugin.GetName() + " Finished");
                    break;
                }
                
                pluginNumber++;
            }
            reader.Close();
            writer.Close();
        }
    }
}