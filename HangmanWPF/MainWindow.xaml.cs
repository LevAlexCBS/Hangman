using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangmanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] words = { "программа", "макака", "прекрасный", "оладушек" };
        string word;
        char[] ans;
        byte remainingLetters;
        int guestletters;
        private int attempt;

        public MainWindow()
        {
            InitializeComponent();
            GenerateNewWord();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            char guess = txbAnswer.Text[0];

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == guess)
                {
                    ans[i] = guess;
                    remainingLetters--;
                    guestletters += 1;
                }

            }
            if (guestletters == 0)
            {
                attempt += 1;
                ShowFigure(attempt);
                guestletters = 0;
            }
            else
            {
                guestletters = 0;
            }
            if (attempt == 6)
                MessageBox.Show("Game over");
            txtWord.Text = new string(ans);
        }
        private void ShowFigure(int part)
        {
            switch (part)
            {
                case 1:
                    head.Visibility = Visibility.Visible;
                    break;
                case 2:
                    body.Visibility = Visibility.Visible;
                    break;
                case 3:
                    leftarm.Visibility = Visibility.Visible;
                    break;
                case 4:
                    rigtharm.Visibility = Visibility.Visible;
                    break;
                case 5:
                    leftleg.Visibility = Visibility.Visible;
                    break;
                case 6:
                    rigthleg.Visibility = Visibility.Visible;
                    break;
                default:
                    head.Visibility = Visibility.Hidden;
                    body.Visibility = Visibility.Hidden;
                    leftarm.Visibility = Visibility.Hidden;
                    rigtharm.Visibility = Visibility.Hidden;
                    leftleg.Visibility = Visibility.Hidden;
                    rigthleg.Visibility = Visibility.Hidden;
                    break;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShowFigure(0);
            GenerateNewWord();
            attempt = 0;
        }
        private void GenerateNewWord()
        {
            word = words[new Random().Next(1, words.Length)];
            ans = new char[word.Length];
            remainingLetters = (byte)word.Length;
            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = '_';
            }
            txtWord.Text = new string(ans);
        }
    }
}
