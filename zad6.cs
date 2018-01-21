using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IO
{




    class zad6
    {


        static void myAsyncCallback(IAsyncResult state)
        {
            string result = System.Text.Encoding.UTF8.GetString((byte[])((object[])state.AsyncState)[1]);
            FileStream fs= (FileStream)((object[])state.AsyncState)[0];
            fs.Close();
            Console.Write(result);

        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("plik.txt", FileMode.Open);
            byte[] buffer = new byte[1024];
            IAsyncResult result = fs.BeginRead(buffer, 0, buffer.Length, myAsyncCallback, new object[] { fs, buffer });

        }

    }
}