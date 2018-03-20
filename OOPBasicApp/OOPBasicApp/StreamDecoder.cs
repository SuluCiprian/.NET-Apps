using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOPBasicApp
{
    class StreamDecoder
    {
        private readonly int dataBufferSize = 1024;
        private BinaryDecoder binaryDecoder;
        private BinaryReader binaryReader;

        public StreamDecoder(BinaryDecoder textDecoder, BinaryReader binaryReader)
        {
            this.binaryDecoder = textDecoder;
            this.binaryReader = binaryReader;
        }

        public void Decode(TextWriter writer)
        {
            byte[] inputBytes = binaryReader.ReadBytes(dataBufferSize);

            while(inputBytes.Length != 0)
            {
                string decodedBytes = binaryDecoder.Decode(inputBytes);
                writer.Write(decodedBytes);
                inputBytes = binaryReader.ReadBytes(dataBufferSize);
            }
            
            
        }
    }
}
