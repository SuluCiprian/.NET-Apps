using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace OOPBasicApp
{
    class StreamEncoder
    {
        private TextEncoder textEncoder;
        private TextReader textReader;

        public StreamEncoder(TextEncoder textEncoder, TextReader textReader)
        {
            this.textEncoder = textEncoder;
            this.textReader = textReader;            
        }

        public void Encode(BinaryWriter writer)
        {
            string inputText = textReader.ReadLine();
            while (!String.IsNullOrEmpty(inputText))
            {
                byte[] encodedBytes = textEncoder.Encode(inputText);
                writer.Write(encodedBytes);
                inputText = textReader.ReadLine();
            } 
        }       

    }
}