using DeskHubMobile.ViewModels;
using DeskHubMobile.Models;
using System.Text;
using CommunityToolkit.Maui.Views;

namespace DeskHubMobile.Views;

public partial class HomePage : ContentPage
{
    RoomViewModel roomViewModel = new RoomViewModel();

    public HomePage()
	{
		InitializeComponent();
        this.Title = "DeskHub";
	}

    public HomePage(User user)
    {
        InitializeComponent();
        BindingContext = user;
    }

    public void UpdateViewModel()
    {
        roomViewModel = new RoomViewModel();
        BindingContext = roomViewModel;
    }

    private void OnbtnCheckAvailability_Clicked(object sender, EventArgs e)
    {
        DisplayAvailableRooms();
    }

    private async void DisplayAvailableRooms()
    {
        UpdateViewModel();
        TimeSpan timeIn = pkrTimeIn.Time;
        TimeSpan timeOut = pkrTimeOut.Time;

        if (timeIn > timeOut)
        {
            await DisplayAlert("Invalid Selection", "Time In cannot be later than Time Out.", "OK");
        }
        else
        {
            if (timeIn == TimeSpan.Zero || timeOut == TimeSpan.Zero)
            {
                await DisplayAlert("Invalid Selection", "Please select a time in both Time In and Time Out.", "OK");
            }
            else
            {
                var availableRooms = roomViewModel.RoomList.Where(room => room.IsAvailable).ToList();

                if (availableRooms.Count == 0)
                {
                    await DisplayAlert("No Available Rooms", "There are no available rooms.", "OK");
                    return;
                }

                listRooms.ItemsSource = availableRooms;
                listRooms.IsVisible = availableRooms.Any();
            }
        }
    }

    private void ReserveBtnClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var selectedRoom = (Room)button.BindingContext;

        string paycode = GeneratePayCode();
        Application.Current.MainPage = new PayOnline(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate, paycode);

        //this.ShowPopup(new BookingTypePopUp(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate,paycode));
    }
    
    private void RentBtnClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var selectedRoom = (Room)button.BindingContext;

        string paycode = GeneratePayCode();
        //Application.Current.MainPage = new PayOnline(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate, paycode);

        this.ShowPopup(new BookingTypePopUp(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate,paycode));
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