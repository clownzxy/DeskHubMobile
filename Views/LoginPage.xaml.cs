namespace DeskHubMobile.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnClickedSignUpBtn(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }
}