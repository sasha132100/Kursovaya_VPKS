using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kursovaya_VPKS.Classes;
using Microsoft.Data.Sqlite;

namespace Kursovaya_VPKS.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EmailTextBox.Text = "User1";
            PasswordTextBox.Password = "123321";
        }

        private string LoginMethod(string email, string password)
        {
            string login = null;
            if (email.Length == 0 || password.Length == 0)
                return "Не все поля заполнены!";
            using (var db = new myDocxAppContext())
            {
                Users user = (from u in db.Users where u.Login == email select u).FirstOrDefault();
                if (user == null)
                    return "Пользователя с такой почтой не существует!";
                if (user.Password != password)
                    return "Неверный пароль!";
                SystemContext.User = user;
                login = user.Login;
            }
            return $"Добро пожаловать, {login}!";
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string result = LoginMethod(EmailTextBox.Text, PasswordTextBox.Password);
            if (result == $"Добро пожаловать, {EmailTextBox.Text}!")
            {
                SystemContext.isGuest = "No";
                DocumentViewingWindow documentViewingWindow = new DocumentViewingWindow();
                this.Close();
                documentViewingWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show(result, "Результат", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Close();
            registerWindow.ShowDialog();
        }

        private void GuestLogInTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SystemContext.isGuest = "Yes";
            /*DocumentViewingWindow documentViewingWindow = new DocumentViewingWindow();
            this.Close();
            documentViewingWindow.ShowDialog();*/
            MessageBox.Show("В разработке");
        }
    }
}
