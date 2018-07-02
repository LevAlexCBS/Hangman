using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangmanMVC.Models
{
    public class Hangman
    {
        string[] words = { "программа", "макака", "прекрасный", "оладушек" };
        public string word;
        char[] ans;
        int guestletters;

        public int CurrentAttempt { get; private set; } = 6;
        public char[] Answer { get { return ans; } }
        public byte RemainingLetters { get; private set; }
        public Hangman()
        {
            GenerateNewWord();
        }
        private void GenerateNewWord()
        {
            word = words[new Random().Next(1, words.Length)];
            ans = new char[word.Length];
            RemainingLetters = (byte)word.Length;
            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = '_';
            }
        }
        public bool CheckLetter(char letter)
        {
            CurrentAttempt--;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    ans[i] = letter;
                    RemainingLetters--;
                }
            }
            if (RemainingLetters == 0)
            {
                Reset();
            }
            return true;
        }

        private void Reset()
        {
            CurrentAttempt = 6;
            GenerateNewWord();
        }

        public string GetImage()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bitMap = new Bitmap(HttpContext.Current.Server.MapPath("~/App_Data/gioco_impiccato_0.bmp")))
                {
                   // RectangleF rectf = new RectangleF(70, 90, 90, 50);

                    Graphics g = Graphics.FromImage(bitMap);

                    //g.SmoothingMode = SmoothingMode.AntiAlias;
                   // g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    switch (CurrentAttempt)
                    {
                        case 5:
                            g.DrawEllipse(new Pen(Brushes.MediumVioletRed), 130, 40, 50, 50);
                            break;
                        case 4:
                            g.DrawEllipse(new Pen(Brushes.MediumVioletRed), 130, 40, 50, 50);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 90, 155, 160);
                            break;
                        case 3:
                            g.DrawEllipse(new Pen(Brushes.MediumVioletRed), 130, 40, 50, 50);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 90, 155, 160);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 120, 130, 90);
                            break;
                        case 2:
                            g.DrawEllipse(new Pen(Brushes.MediumVioletRed), 130, 40, 50, 50);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 90, 155, 160);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 120, 130, 90);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 120, 180, 90);
                            break;
                        case 1:
                            g.DrawEllipse(new Pen(Brushes.MediumVioletRed), 130, 40, 50, 50);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 90, 155, 160);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 120, 130, 90);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 120, 180, 90);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 160, 175, 190);
                            break;
                        case 0:
                            g.DrawEllipse(new Pen(Brushes.MediumVioletRed), 130, 40, 50, 50);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 90, 155, 160);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 120, 130, 90);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 120, 180, 90);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 160, 175, 190);
                            g.DrawLine(new Pen(Brushes.MediumVioletRed), 155, 160, 135, 190);
                            break;
                        default:
                            Reset();
                            break;
                    }
                    
                    

                    g.Flush();
                    bitMap.Save(ms, ImageFormat.Png);
                    return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}