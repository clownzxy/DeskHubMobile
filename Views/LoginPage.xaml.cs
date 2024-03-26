namespace DeskHubMobile.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnClickedBtnLogin(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new LoginPageTwo());
    }

	private async void OnClickedBtnSignUp(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new SignUpPage());
    }
}