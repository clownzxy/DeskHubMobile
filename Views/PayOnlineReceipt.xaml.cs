using DeskHubMobile.ViewModels;
using DeskHubMobile.Models;
using System.Text.RegularExpressions;

namespace DeskHubMobile.Views;

public partial class PayOnlineReceipt : ContentPage
{
    User user = new User();
    private bool buttonClicked = true;
    public PayOnlineReceipt()
    {
        InitializeComponent();
    }

    //public PayOnlineReceipt(string roomID, string roomType, double roomRate, string paycode,string creditCard, string email) : this()
    //{
    //    roomIDEntry.Text = roomID;
    //    roomTypeEntry.Text = roomType;
    //    roomRateEntry.Text = roomRate.ToString();
    //    txtPayCode.Text = paycode;
    //    txtCreditCard.Text = creditCard;
    //    txtEmail.Text = email;
    //}

    //private void OnCreditCardEntryTextChanged(object sender, TextChangedEventArgs e)
    //{
    //    if (!string.IsNullOrWhiteSpace(e.NewTextValue))
    //    {
    //        string cleanedText = new string(e.NewTextValue.Where(char.IsDigit).ToArray());
    //        if (cleanedText.Length > 4)
    //        {
    //            cleanedText = cleanedText.Insert(4, "-");
    //        }
    //        if (cleanedText.Length > 9)
    //        {
    //            cleanedText = cleanedText.Insert(9, "-");
    //        }
    //        if (cleanedText.Length > 14)
    //        {
    //            cleanedText = cleanedText.Insert(14, "-");
    //        }
    //        if (cleanedText.Length > 19)
    //        {
    //            cleanedText = cleanedText.Substring(0, 19);
    //        }

    //        txtCreditCard.Text = cleanedText;

    //    }
    //}
    //private async void OnbtnProceedPayment(object sender, EventArgs e)
    //{
    //    if (buttonClicked)
    //    {
    //        buttonClicked = true;
    //        string roomID = roomIDEntry.Text;
    //        string roomType = roomTypeEntry.Text;
    //        string roomRate = roomRateEntry.Text;
    //        string payCode = txtPayCode.Text;
    //        string email = txtEmail.Text;
    //        string paymentDetails = $"Room ID: {roomID}\nRoom Type: {roomType}\nRoom Rate: {roomRate}\nPayment Code: {payCode}";

    //        if (string.IsNullOrWhiteSpace(roomID) || string.IsNullOrWhiteSpace(roomType) || string.IsNullOrWhiteSpace(roomRate) || string.IsNullOrWhiteSpace(payCode) || string.IsNullOrWhiteSpace(email))
    //        {
    //            await DisplayAlert("Empty Payment Details", "Please enter the payment details properly.", "OK");
    //        }

    //        else
    //        {
    //            bool paymentConfirmed = await DisplayAlert("Confirm Payment", $"Viewing Payment Details:\n{paymentDetails}\nContact Details: {email}\n\nProceed with payment?", "Yes", "No");
    //            if (paymentConfirmed)
    //            {
    //                await DisplayAlert("Payment Successful", "Payment successful!", "OK");

    //                    Application.Current.MainPage = new HomePage();
                    
    //            }
                
    //        }
    //    }
    //}


    //private void OnEmailTextChanged(object sender, TextChangedEventArgs e)
    //{
    //    string email = e.NewTextValue;
    //    bool isValid = IsEmailValid(email);
    //    if (!isValid)
    //    {
    //        txtEmail.TextColor = Colors.Red;
    //    }
    //    else
    //    {
    //        txtEmail.TextColor = Colors.Black;
    //    }
    //}
    //private bool IsEmailValid(string email)
    //{
    //    string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
    //    return Regex.IsMatch(email, pattern);
    //}
}