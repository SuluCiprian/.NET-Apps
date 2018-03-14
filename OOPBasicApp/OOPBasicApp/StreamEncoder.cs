using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOPBasicApp
{
    class StreamEncoder
    {
        private TextEncoder textEncoder;
        private string inputPath;
        private string outputPath;

        public StreamEncoder(string inputPath, string outputPath)
        {
            this.inputPath = inputPath;
            this.outputPath = outputPath;
        }
      
        public void Encode()
        {
            textEncoder = new TextEncoder();
            if (File.Exists(inputPath))
            {
                string text = System.IO.File.ReadAllText(inputPath);
                byte[] result = textEncoder.Encode(text);
                

                using (FileStream stream = new FileStream(outputPath, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(result);
                        writer.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesnt exist!");
            }
        }
        
    }
}
