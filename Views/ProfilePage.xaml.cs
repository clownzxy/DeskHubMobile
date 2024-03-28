using CommunityToolkit.Maui.Views;
using DeskHubMobile.Models;
using static System.Runtime.CompilerServices.RuntimeHelpers;



namespace DeskHubMobile.Views;


public partial class ProfilePage : ContentPage
{
    User userInfo = new User();

	public ProfilePage(User user)
	{
		InitializeComponent();
        ProfileNameBtnText.Text = $"{user.FirstName} {user.MiddleName} {user.LastName}";
        ProfileEmailBtnText.Text = user.Email.ToString();
        userInfo = user;
        BindingContext = user;
    }

    private async void ProfileBtnOnClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new ProfileInfoPopUp(userInfo));

    }

    private async void ImageButtonLogoOnClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new HomePage(userInfo);

    }


}