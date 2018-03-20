
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OOPBasics.Shared;

namespace OOPBasicApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu();
            //AppManager appManager = new AppManager();
            //appManager.Initialize();
        }

        public static TextReader GetInputTextReader()
        {
            TextReader readFile = null; 
            try
            {
                string inputPath = @"C:\Users\ciprian.sulu\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\input.txt";
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

        public static BinaryReader GetInputBinaryReader()
        {
            BinaryReader readFile = null;
            try
            {
                string inputPath = @"C:\Users\ciprian.sulu\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\encoded1.bin";
                FileStream readStream = new FileStream(inputPath, FileMode.Open);
                readFile = new BinaryReader(readStream);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File was not found! " + ex.FileName + " Please create the file!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }

            return readFile;
        }

        public static TextWriter GetOutputTextWriter()
        {
            TextWriter writeFile = null;
            try
            {
                string outputPath = @"C:\Users\ciprian.sulu\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\output.txt";
                writeFile = new StreamWriter(outputPath);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Unauthorized acces! Message: " + ex.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return writeFile;
        }

        public static BinaryWriter GetOutputBinaryWriter()
        {
            BinaryWriter writer = null;
            try
            {
                string outputPath = @"C:\Users\ciprian.sulu\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\encoded.bin";
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

            Console.WriteLine("1. Encoder menu: ");
            Console.WriteLine("2. Decoder menu: ");

            int menu = Convert.ToInt32(Console.ReadLine());
            TextReader reader = GetInputTextReader();
            BinaryWriter writer = GetOutputBinaryWriter();
            BinaryReader binaryReader = GetInputBinaryReader();
            TextWriter textWriter = GetOutputTextWriter();

            if (menu == 1)
            {
                PluginsManager<IPlugin> pluginManager = new PluginsManager<IPlugin>();
                pluginManager.LoadPlugins();


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
                        if (arguments.Count != 0)
                        {
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            Console.WriteLine("Enter parameters: ");
                            foreach (var arg in arguments)
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
            }
            else if (menu == 2)
            {
                PluginsManager<IDecoderPlugin> pluginManager = new PluginsManager<IDecoderPlugin>();
                pluginManager.LoadPlugins();


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
                        if (arguments.Count != 0)
                        {
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            Console.WriteLine("Enter parameters: ");
                            foreach (var arg in arguments)
                            {
                                Console.WriteLine(arg + ": ");
                                parameters[arg] = Console.ReadLine();
                            }
                            plugin.SetArguments(parameters);
                        }
                        BinaryDecoder binaryDecoder = new BinaryDecoder(plugin.GetDecoder());
                        StreamDecoder streamDecoder = new StreamDecoder(binaryDecoder, binaryReader);
                        streamDecoder.Decode(textWriter);
                        Console.WriteLine(plugin.GetName() + " Finished");
                        break;
                    }

                    pluginNumber++;
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }
            
            reader.Close();
            writer.Close();
            binaryReader.Close();
            textWriter.Close();
        }

        /*
        public static void Load<T>(TextReader reader, BinaryWriter writer) 
        {
            PluginsManager<T> pluginManager = new PluginsManager<T>();
            pluginManager.LoadPlugins();


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
                    if (arguments.Count != 0)
                    {
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        Console.WriteLine("Enter parameters: ");
                        foreach (var arg in arguments)
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
        }*/
    }
}