
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PhoneInputAppWPF
{
    public partial class MainWindow : Window
    {
        private string phoneNumber = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DigitButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();

            phoneNumber += buttonText;
            PhoneNumberTextBox.Text = phoneNumber;
        }

        private void CallButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsPhoneNumberValid(phoneNumber))
            {
                MessageBox.Show($"Вызов  {phoneNumber}..."); // Симулируем вызов
            }
            else
            {
                MessageBox.Show("Недопустимый формат номера.Укажите корректный формат.");
            }
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                phoneNumber = phoneNumber.Substring(0, phoneNumber.Length - 1);
                PhoneNumberTextBox.Text = phoneNumber;
            }
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {

            return (phoneNumber.StartsWith("+7") && (phoneNumber.Length == 12 || phoneNumber.Length == 11)) ||
                   (phoneNumber.StartsWith("8") && (phoneNumber.Length == 11 || phoneNumber.Length == 10));
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (char.IsDigit((char)e.Key) || e.Key == System.Windows.Input.Key.Add)
            {
                phoneNumber += e.Key.ToString().Last();
                PhoneNumberTextBox.Text = phoneNumber;
            }
            else if (e.Key == System.Windows.Input.Key.Enter)
            {
            }
        }
    }
}