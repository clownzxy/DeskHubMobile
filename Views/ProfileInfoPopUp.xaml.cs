using CommunityToolkit.Maui.Views;
using DeskHubMobile.Models;

namespace DeskHubMobile.Views;

public partial class ProfileInfoPopUp : Popup
{
	public ProfileInfoPopUp(User user)
	{
		InitializeComponent();
		NameLabelTxt.Text = $"{user.FirstName} {user.MiddleName} {user.LastName}";
		EmailLabelTxt.Text = user.Email;
		PhoneLabelTxt.Text = user.Phone;
		GenderLabelTxt.Text = user.Gender;
		AddressLabelTxt.Text = user.Address;
		BirthdayLabelTxt.Text = user.Birthday.ToString();
	}
}