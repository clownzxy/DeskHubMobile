using DeskHubMobile.ViewModels;
using DeskHubMobile.Models;

namespace DeskHubMobile.Views;

public partial class LoginPageTwo : ContentPage
{
    UserViewModel userViewModel = new UserViewModel();

    public LoginPageTwo()
	{
		InitializeComponent();
		BindingContext = this;
	}

    private async void OnbtnSignUpClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());

    }

    private async void OnClickedBtnLogin(object sender, EventArgs e)
    {
        string username = txtusernameEntry.Text;
        string password = txtpasswordEntry.Text;

        UserViewModel userViewModel = new UserViewModel();

        User user = userViewModel.GetUserByUsername(username);
        

        if (user == null)
        {
            await DisplayAlert("Login Failed", "User does not exist.", "OK");
        }
        else if (user != null && user.Password == password)
        {

                await DisplayAlert("Login Successful", "You have successfully logged in.", "OK");
                var clientHome = new HomePage(user);
                Application.Current.MainPage = clientHome;

                ClearEntryFields();
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
        }
    }

    private void ClearEntryFields()
    {
        txtusernameEntry.Text = "";
        txtpasswordEntry.Text = "";
    }

    private string FilterNonAlphaNumeric(string input)
    {
        return System.Text.RegularExpressions.Regex.Replace(input, "[^a-zA-Z0-9]", "");
    }

    private void OnUsernameEntryChanged(object sender, TextChangedEventArgs e)
    {
        string username = e.NewTextValue;
        string numericText = FilterNonAlphaNumeric(username);
        txtusernameEntry.Text = numericText;
    }

    private void OnPasswordEntryChanged(object sender, TextChangedEventArgs e)
    {
        string password = e.NewTextValue;
        string numericText = FilterNonAlphaNumeric(password);
        txtpasswordEntry.Text = numericText;
    }
}