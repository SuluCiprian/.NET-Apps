
using System;
using System.IO;

namespace OOPBasicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            byte rand = (byte)rnd.Next(128);


            EnigmaEncoder byteEncoder = new EnigmaEncoder(100, 250, rand);
            CaesarEncoder numberEncoder = new CaesarEncoder();
            TextEncoder textEncoder = new TextEncoder(numberEncoder);

            TextReader reader = GetInputTextReader();
            BinaryWriter writer = GetOutputBinaryWriter();

            StreamEncoder streamEncoder = new StreamEncoder(textEncoder, reader);
            streamEncoder.Encode(writer);

            reader.Close();
            writer.Close();
        }
        public static TextReader GetInputTextReader()
        {
            TextReader readFile = null; 
            try
            {
                string inputPath = @"C:\Users\ciprian.sulu\source\repos\OOPBasicApp\OOPBasicApp\input.txt";
                readFile = new StreamReader(inputPath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File was not found! " + ex.FileName + "Please create the file!");
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
                string outputPath = @"C:\Users\ciprian.sulu\source\repos\OOPBasicApp\OOPBasicApp\encoded.bin";
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
    }
}