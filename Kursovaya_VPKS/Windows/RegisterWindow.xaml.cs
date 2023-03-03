﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kursovaya_VPKS.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        string registerMethod(string email, string password, string confirmPas)
        {
            if (email.Length < 5 || email.Length == 0)
                return "Логин должен содержать от 5 символов!";
            if (password.Length < 8 || password.Length == 0)
                return "Минимальный размер пароля: 8 символов!";
            if (password != confirmPas)
                return "Пароли не соответсвуют друг другу!";
            using (var db = new myDocxAppContext())
            {
                Users user = (from u in db.Users where u.Login == email select u).FirstOrDefault<Users>();
                if (user != null)
                    return "Пользователь с таким логином уже существует!";
                db.Users.Add(new Users() { Login = email, Password = password, PremiumStatus = "No", Syncing = "No" });
                db.SaveChanges();
            }
            return "Регистрация прошла успешно!";
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string result = registerMethod(EmailTextBox.Text, PasswordTextBox.Password, ConfirmPasswordTextBox.Password);
            MessageBox.Show(result, "Результат", MessageBoxButton.OK, MessageBoxImage.Warning);
            if (result == "Регистрация прошла успешно!")
                BackToMainWindowButton_Click(this, new RoutedEventArgs());
        }

        private void BackToMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
