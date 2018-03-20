using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OOPBasics.Shared;

namespace OOPBasicApp
{
    public class ProgramManager
    {
        private ConsoleMenu consoleMenu;

        /*
        private string pathToReadEncode = @"C:\Users\ciprian.sulu\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\input.txt";
        private string pathToWriteEncode = @"C:\Users\ciprian.sulu\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\encoded.bin";
        private string pathToWriteDecode = @"C:\Users\ciprian.sulu\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\decoded.txt";
        private string inputBinaryPath = @"C:\Users\ciprian.sulu\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\encoded1.bin";*/

        private string pathToReadEncode = @"C:\Users\Cipada\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\input.txt";
        private string pathToWriteEncode = @"C:\Users\Cipada\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\encoded.bin";
        private string pathToWriteDecode = @"C:\Users\Cipada\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\decoded.txt";
        private string inputBinaryPath = @"C:\Users\Cipada\Documents\.NET-Apps\OOPBasicApp\OOPBasicApp\encoded1.bin";

        PluginsManager<IEncoderPlugin> encodersPluginManager = new PluginsManager<IEncoderPlugin>();
        PluginsManager<IDecoderPlugin> decodersPluginManager = new PluginsManager<IDecoderPlugin>();

        public ProgramManager()
        {
            consoleMenu = new ConsoleMenu();
        }

        private void HandlePluginParameters(IEncoderPlugin plugin)
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
        }

        private void HandlePluginParameters(IDecoderPlugin plugin)
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
        }

        public void Initialize()
        {
            encodersPluginManager.LoadPlugins(@"E:\OOPBasics");
            decodersPluginManager.LoadPlugins(@"E:\OOPBasics");
            char optionNo = '1';
            foreach (var encoderPlugin in encodersPluginManager.Plugins)
            {
                consoleMenu.AddItem(new MenuItem { ShortcutChar = optionNo, Text = encoderPlugin.GetName(), ContextObject = encoderPlugin, ItemAction = new MenuItemAction(EncodeAction) });
                optionNo++;
            }

            foreach (var encoderPlugin in decodersPluginManager.Plugins)
            {
                consoleMenu.AddItem(new MenuItem { ShortcutChar = optionNo, Text = encoderPlugin.GetName(), ContextObject = encoderPlugin, ItemAction = new MenuItemAction(DecodeAction) });
                optionNo++;
            }
        }

        public void RunApp()
        {
            consoleMenu.Run();
        }

        public void EncodeAction(object sender, object contextObject)
        {
            IEncoderPlugin encoderPlugin = (IEncoderPlugin)contextObject;
            HandlePluginParameters(encoderPlugin);
            IEncoder encoder = encoderPlugin.GetEncoder();

            TextEncoder textEncoder = new TextEncoder(encoder);
            TextReader textReader = GetInputTextReader(pathToReadEncode);
            StreamEncoder streamEncoder = new StreamEncoder(textEncoder, textReader);
            BinaryWriter binaryWriter = GetOutputBinaryWriter(pathToWriteEncode);
            streamEncoder.Encode(binaryWriter);

            textReader.Close();
            binaryWriter.Close();

            Console.WriteLine("File modified. Press any key to continue.");
            Console.ReadLine();
        }

        public void DecodeAction(object sender, object contextObject)
        {
            IDecoderPlugin decoderPlugin = (IDecoderPlugin)contextObject;
            HandlePluginParameters(decoderPlugin);
            IDecoder decoder = decoderPlugin.GetDecoder();

            BinaryReader binaryReader = GetInputBinaryReader(inputBinaryPath);
            TextWriter textWriter = GetOutputTextWriter(pathToWriteDecode);

            BinaryDecoder binaryDecoder = new BinaryDecoder(decoderPlugin.GetDecoder());
            StreamDecoder streamDecoder = new StreamDecoder(binaryDecoder, binaryReader);
            streamDecoder.Decode(textWriter);
            Console.WriteLine(decoderPlugin.GetName() + " Finished");

            binaryReader.Close();
            textWriter.Close();

            Console.WriteLine("File modified. Press any key to continue.");
            Console.ReadLine();
        }
        public void TestActionToExecute(object sender)
        {
            Console.WriteLine("This is a test");
            Console.ReadLine();
        }



        public void TestPlugins<T>(object sender) where T : IEncoderPlugin
        {
            PluginsManager<T> pluginManager = new PluginsManager<T>();
            pluginManager.LoadPlugins("D:\\OOPBasics");

            List<T> plugins = (List<T>)pluginManager.Plugins;

            int pluginIndex = 0;

            foreach (var currentPlugin in plugins)
            {
                Console.WriteLine(pluginIndex++ + ". " + currentPlugin.GetName());
            }

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int selectedEncoder) && selectedEncoder < plugins.Count)
            {
                IEncoder algorithmEncoder = null;

                IEnumerable<String> encoderParameters = plugins[selectedEncoder].GetRequiredArguments();
                if (encoderParameters != null)
                {
                    IDictionary<string, string> parametersDictionary = new Dictionary<string, string>();
                    foreach (var parameter in encoderParameters)
                    {
                        Console.WriteLine("Please insert value for " + parameter);
                        String parameterInput = Console.ReadLine();
                        parametersDictionary[parameter] = parameterInput;
                    }

                    plugins[selectedEncoder].SetArguments(parametersDictionary);
                    algorithmEncoder = plugins[selectedEncoder].GetEncoder();
                }
                else
                {
                    algorithmEncoder = plugins[selectedEncoder].GetEncoder();
                }

                TextEncoder textEncoder = new TextEncoder(algorithmEncoder);

                TextReader textReader = GetInputTextReader(pathToReadEncode);

                StreamEncoder streamEncoder = new StreamEncoder(textEncoder, textReader);

                BinaryWriter binaryWriter = GetOutputBinaryWriter(pathToWriteEncode);

                streamEncoder.Encode(binaryWriter);

                textReader.Close();
                binaryWriter.Close();

                Console.WriteLine("File modified.");
            }
            else
            {
                Console.WriteLine("Invalid algorithm index given.");
            }


        }

        static BinaryReader GetInputBinaryReader(string inputBinaryPath)
        {
            BinaryReader readFile = null;
            try
            {
                
                FileStream readStream = new FileStream(inputBinaryPath, FileMode.Open);
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

        static TextWriter GetOutputTextWriter(string pathToWriteDecode)
        {
            TextWriter writeFile = null;
            try
            {
                writeFile = new StreamWriter(pathToWriteDecode);
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

        static TextReader GetInputTextReader(String pathToRead)
        {
            TextReader textReader = null;

            try
            {
                textReader = new StreamReader(pathToRead);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(String.Format("Warning! File not found at {0}.\n{1}", pathToRead, e));
            }
            catch (IOException e)
            {
                Console.WriteLine(String.Format("Warning! Unexpected exception.\n{0}", e));
            }

            return textReader;
        }

        static BinaryWriter GetOutputBinaryWriter(String pathToWrite)
        {
            BinaryWriter binaryWriter = null;

            try
            {
                binaryWriter = new BinaryWriter(File.OpenWrite(pathToWrite));
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(String.Format("Warning! The path file is too long {0}.\n{1}", pathToWrite, e));
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Warning! Unexpected exception.\n{0}", e));
            }

            return binaryWriter;
        }

    }
}
