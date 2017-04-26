using System;
using System.IO;
using System.Text;

namespace Lista_5.Caesar
{
    class CaesarStream : Stream
    {
        private Stream stream;
        private int v;

        public CaesarStream(Stream stream, int v)
        {
            this.stream = stream;
            this.v = v;
        }

        public override void Flush()
        {
            stream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var realCount = stream.Read(buffer, offset, count);
            for (var i = 0; i < realCount; ++i)
            {
                buffer[i + offset] = (byte) (buffer[i + offset] + v);
            }
            return realCount;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            for (var i = 0; i < count; ++i)
            {
                buffer[i + offset] = (byte) (buffer[i + offset] + v);
            }
            stream.Write(buffer, offset, count);
        }

        public override bool CanRead => stream.CanRead;

        public override bool CanSeek => stream.CanSeek;

        public override bool CanWrite => stream.CanWrite;

        public override long Length => stream.Length;

        public override long Position
        {
            get { return stream.Position; }
            set { stream.Position = value; }
        }
    }

    class CaesarExerciseShow
    {
        public static void Do()
        {
            var fileToWrite = File.Create(@"R:\Code\POO\Lista 5\Lista 5\Lista 5\Caesar\output.txt");
            var caeToWrite = new CaesarStream(fileToWrite, 1);

            caeToWrite.Write(Encoding.ASCII.GetBytes("Marchewka"), 0, "Marchewka".Length);
            FileStream fileToRead = File.Open(@"R:\Code\POO\Lista 5\Lista 5\Lista 5\Caesar\input.txt", FileMode.Open);
            CaesarStream caeToRead = new CaesarStream(fileToRead, 0);

            byte[] x = new byte[40];
            caeToRead.Read(x, 0, 30);
            Console.WriteLine(Encoding.ASCII.GetString(x));
        }
    }
}
