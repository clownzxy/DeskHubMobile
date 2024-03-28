using DeskHubMobile.ViewModels;
using DeskHubMobile.Models;
using System.Text;
using CommunityToolkit.Maui.Views;

namespace DeskHubMobile.Views;

public partial class HomePage : ContentPage
{
    RoomViewModel roomViewModel = new RoomViewModel();
    User userRecord= new User();


    public HomePage()
    {
        InitializeComponent();
        this.Title = "DeskHub";
    }

    public HomePage(User user)
    {
        InitializeComponent();
        userRecord = user;
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
        DateTime dateIn = pkrDateIn.Date;
        DateTime dateOut = pkrDateOut.Date;
        TimeSpan timeIn = pkrTimeIn.Time;
        TimeSpan timeOut = pkrTimeOut.Time;

        if (timeIn > timeOut && dateIn > dateOut)
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

    DateTime AddTimeToDate(DateTime date, TimeSpan time)
    {
        return date.Add(time);
    }

    //private void ReserveBtnClicked(object sender, EventArgs e)
    //{
    //    var button = (Button)sender;
    //    var selectedRoom = (Room)button.BindingContext;

        string paycode = GeneratePayCode();
        Application.Current.MainPage = new PayOnline(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate, paycode, AddTimeToDate(pkrDateIn.Date, pkrTimeIn.Time), AddTimeToDate(pkrDateOut.Date, pkrTimeOut.Time));

    //    //this.ShowPopup(new BookingTypePopUp(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate,paycode));
    //}

    private void RentBtnClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var selectedRoom = (Room)button.BindingContext;

        string paycode = GeneratePayCode();
        //Application.Current.MainPage = new PayOnline(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate, paycode);

        this.ShowPopup(new BookingTypePopUp(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate, paycode, AddTimeToDate(pkrDateIn.Date, pkrTimeIn.Time), AddTimeToDate(pkrDateOut.Date, pkrTimeOut.Time)));
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

    //////////////////

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Choose Action", "Cancel", null, "Reserve", "Book Now");

        // Check the chosen action
        if (action == "Reserve")
        {
            // Handle reserve action
            await DisplayAlert("Reservation", "Your reservation has been placed.", "OK");
        }
        else if (action == "Book Now")
        {
            // Handle book now action
            await DisplayAlert("Booking", "Your booking has been confirmed.", "OK");
        }
    }

    private async void ProfileImageBtnOnCLicked(object sender, EventArgs e)
    {
         //await Navigation.PushAsync(new ProfilePage(userRecord));
        Application.Current.MainPage = new ProfilePage(userRecord);

    }




}