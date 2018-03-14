using System;

namespace OOPBasicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = @"C:\Users\Cipada\source\repos\OOPBasicApp\OOPBasicApp\input.txt";
            string outputPath = @"C:\Users\Cipada\source\repos\OOPBasicApp\OOPBasicApp\encoded.bin";

            StreamEncoder streamEncoder = new StreamEncoder(inputPath, outputPath);
            streamEncoder.Encode();
        }
    }
}
