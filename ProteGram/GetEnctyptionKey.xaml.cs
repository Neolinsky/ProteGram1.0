using ProteGram.Core;
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
using System.Windows.Shapes;

namespace ProteGram
{
    /// <summary>
    /// Логика взаимодействия для GetEnctyptionKey.xaml
    /// </summary>
    public partial class GetEnctyptionKey : Window
    {
        public GetEnctyptionKey()
        {
            InitializeComponent();
        }

        public static TextBox KeyField;
        
        private void Confirmkey_Click(object sender, RoutedEventArgs e)
        {
            KeyField = EncryptionKeyKield;
            
            if(KeyField.Text != "" && KeyField.Text.Length == 16)
            {
                AesOperation.secret = KeyField.Text;
                MainWindow.Encryption = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please Enter your 16 symbols Key");
            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GenerateNewKey_OnClick(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            
            var allowedCharacters = "0123456789#!qwertyuiopasdfghjklzxcvbnm$%QWERTYUIOPLKJHGFDSAZXCVBNM-_-";
            var key = string.Empty;

            for (var i = 0; i < 16; i++)
            {
                key = key + allowedCharacters[rng.Next(0, allowedCharacters.Length - 1)].ToString();
            }
            
            KeyField = EncryptionKeyKield;
            KeyField.Text = key;
        }
    }
}
