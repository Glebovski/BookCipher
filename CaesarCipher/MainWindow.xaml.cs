using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CaesarCipher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ABCEng = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890,.()!@#$%^&*_-+=~`";
        private string ABCUkr = " абвгдеєжзиіїйклмнопрстуфхцчшщьюяАБВГДЕЄЖЗИІЇКЛМНОПРСТУФХЦЧШЩЬЮЯ1234567890,.()!@#$%^&*_-+=~`";
        private string Abc;
        public MainWindow()
        {
            InitializeComponent();
        }
        Cipher cezar = new Cipher();

        public char[,] Initialazing()
        {
            string text = filearea.Text;
            string key = Move.Text.ToLower();
            int m = Move.LineCount;
            int n = 0;
            if (key.Length % m != 0)
                n = key.Length / m + 1;
            else n = key.Length / m;
            int letter = 0;
            
            char[,] poem = new char[m,n] ;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (letter == key.Length)
                        poem[i, j] = ' ';
                    else poem[i, j] = key[letter];
                    letter++;
                }
            }
            return poem;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text Files | *.txt";
            dialog.FilterIndex=1;
            if (dialog.ShowDialog()==true)
            filearea.Text= File.ReadAllText(dialog.FileName);
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            FileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text Files | *.txt";
            if (dialog.ShowDialog() == true)
                File.WriteAllText(dialog.FileName,filearea.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                char[,] key = Initialazing();
                filearea.Text = cezar.Encrypt(filearea.Text, key);
            }
            catch {
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                char[,] key = Initialazing();
                char[] decoded = filearea.Text.Replace(",","").Replace("/","").Replace(" ","").ToArray();
                filearea.Text = cezar.Decrypt(decoded, key);
            }
            catch { }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Made by Zadachin Gleb, TM-51, #9");
        }
    }
}
