using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "中文测试乱码";
            Encoding GB18030Encoding = Encoding.GetEncoding(54936);
            Encoding Windows1252Encoding = Encoding.GetEncoding(1252);
            var byteData = GB18030Encoding.GetBytes(str);
            string tStr = "";
            if (byteData != null)
            {
                for (int i = 0; i < byteData.Length; i++)
                {
                    tStr += byteData[i].ToString("X2");
                }
            }
            Console.WriteLine(tStr);

            string GB18030EncodingStr = GB18030Encoding.GetString(byteData);
            Console.WriteLine(GB18030EncodingStr);

            string Windows1252EncodingStr = Windows1252Encoding.GetString(byteData);
            Console.WriteLine(Windows1252EncodingStr);
            var covertData = Encoding.UTF8.GetBytes(Windows1252EncodingStr);

            var t1 = Encoding.Convert(Encoding.UTF8, Windows1252Encoding, covertData);
            var t2 = Encoding.Convert(GB18030Encoding, Encoding.UTF8, t1);
            var t3 = Encoding.UTF8.GetString(t2);
            Console.WriteLine(t3);



            string returnStr = "";
            if (covertData != null)
            {
                for (int i = 0; i < covertData.Length; i++)
                {
                    returnStr += covertData[i].ToString("X2");
                }
            }
            Console.WriteLine(returnStr);
        }

    }





}
