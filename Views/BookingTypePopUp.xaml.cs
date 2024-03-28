using CommunityToolkit.Maui.Views;
using DeskHubMobile.Models;
using System.Text;
using DeskHubMobile.ViewModels;

namespace DeskHubMobile.Views;

public partial class BookingTypePopUp : Popup
{
    RoomViewModel roomViewModel = new RoomViewModel();

    String roomIdglobal;
    String roomTypeglobal;
    double roomRateglobal;
    String paycodeglobal;
    DateTime dateInglobal;
    DateTime dateOutglobal;

	public BookingTypePopUp()
	{
		InitializeComponent();
    }

    public BookingTypePopUp(string roomID, string roomType, double roomRate, string paycode, DateTime dateIn, DateTime dateOut) : this()
    {
        roomIdglobal = roomID;
        roomTypeglobal = roomType;
        roomRateglobal = roomRate;
        paycodeglobal = paycode;
        dateInglobal = dateIn;
        dateOutglobal = dateOut;
    }

    public void UpdateViewModel()
    {
        roomViewModel = new RoomViewModel();
        BindingContext = roomViewModel;
    }

    DateTime AddTimeToDate(DateTime date, TimeSpan time)
    {
        return date.Add(time);
    }

    private async void PayOnlineBtnClicked(object sender, EventArgs e)
    {
        //var button = (Button)sender;
        //var selectedRoom = (Room)button.BindingContext;

        string paycode = GeneratePayCode();
        await CloseAsync();
        //await Navigation.PushAsync(new SignUpPage());

        Application.Current.MainPage = new PayOnline(roomIdglobal, roomTypeglobal, roomRateglobal, paycodeglobal, dateInglobal, dateOutglobal);
    }




    private async void PayOnsiteBtnClicked(object sender, EventArgs e)
    {


        string paycode = GeneratePayCode();
        await CloseAsync();
        Application.Current.MainPage = new PayOnsite(roomIdglobal, roomTypeglobal, roomRateglobal, paycodeglobal);
    }

    public string GeneratePayCode()
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder paycode = new StringBuilder();
        Random random = new Random();

        for (int i = 0; i < 16; i++)
        {
            int index = random.Next(characters.Length);
            paycode.Append(characters[index]);
        }
        return "PAY" + paycode.ToString();
    }
}