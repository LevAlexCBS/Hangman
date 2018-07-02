using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] words = { "программа", "макака", "прекрасный", "оладушек" };

            //string word = words[new Random().Next(1, words.Length)];
            //char[] ans = new char[word.Length];

            //for (int i = 0; i < ans.Length; i++)
            //{
            //    ans[i] = '_';
            //}

            //byte remainingLetters = (byte)word.Length;

            //while (remainingLetters > 0)
            //{
            //    Console.WriteLine("Введите букву:");
            //    char guess = Console.ReadKey().KeyChar;

            //    for (int i = 0; i < word.Length; i++)
            //    {
            //        if (word[i] == guess)
            //        {
            //            ans[i] = guess;
            //            remainingLetters--;
            //        }
            //    }
            //    Console.WriteLine();
            //    for (int i = 0; i < ans.Length; i++)
            //    {
            //        Console.Write(ans[i] + " ");
            //    }
            //    Console.WriteLine();
            //}

            Bitmap bmp = new Bitmap("gioco_impiccato_0.bmp");

            RectangleF rectf = new RectangleF(70, 90, 90, 50);

            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("yourText", new Font("Tahoma", 8), Brushes.Black, rectf);
            g.DrawEllipse(new Pen(Brushes.MediumVioletRed), 130, 40, 50, 50);
            g.Flush();

            bmp.Save("1.BMP");
            Console.ReadKey();
        }
    }
}
