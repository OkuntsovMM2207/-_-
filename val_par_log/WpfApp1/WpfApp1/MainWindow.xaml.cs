using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получить введенные данные
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Password;

            // Проверить валидность имени пользователя
            bool usernameIsValid = Regex.IsMatch(username, @"^\w{6,16}$");

            // Проверить валидность пароля
            bool passwordIsValid = Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,20}$");

            // Отобразить сообщения об ошибках
            if (!usernameIsValid)
            {
                MessageBox.Show("Логин должен содержать от 6 до 16 символов (буквы, цифры или подчеркивания).");
            }
            if (!passwordIsValid)
            {
                MessageBox.Show("Пароль должен содержать от 8 до 20 символов символов, включая строчные буквы, прописные буквы, цифры и хотя бы один из следующих символов: @, $, !, %, *, #, ?, &.");
            }
        }
    }

    // Библиотека классов ValidatorLibrary
    public class ValidatorLibrary
    {
        public interface IValidator
        {
            bool Validate(string? validateObject);
        }

        public class LoginValidator : IValidator
        {
            public bool Validate(string? validateObject)
            {
                return Regex.IsMatch(validateObject, @"^\w{6,16}$");
            }
        }

        public class PasswordValidator : IValidator
        {
            public bool Validate(string? validateObject)
            {
                return Regex.IsMatch(validateObject, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,20}$");
            }
        }
    }
}