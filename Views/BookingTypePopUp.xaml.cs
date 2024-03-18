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

	public BookingTypePopUp()
	{
		InitializeComponent();
    }

    public BookingTypePopUp(string roomID, string roomType, double roomRate, string paycode) : this()
    {
        roomIdglobal = roomID;
        roomTypeglobal = roomType;
        roomRateglobal = roomRate;
        paycodeglobal = paycode;
    }

    public void UpdateViewModel()
    {
        roomViewModel = new RoomViewModel();
        BindingContext = roomViewModel;
    }

    

    private async void PayOnlineBtnClicked(object sender, EventArgs e)
    {
        //var button = (Button)sender;
        //var selectedRoom = (Room)button.BindingContext;

        string paycode = GeneratePayCode();
        Application.Current.MainPage = new PayOnline(roomIdglobal, roomTypeglobal, roomRateglobal, paycodeglobal);
    }

    private async void PayOnsiteBtnClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var selectedRoom = (Room)button.BindingContext;

        string paycode = GeneratePayCode();
        Application.Current.MainPage = new PayOnline(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate, paycode);
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