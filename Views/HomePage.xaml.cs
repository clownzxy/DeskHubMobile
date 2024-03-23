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

        this.ShowPopup(new BookingTypePopUp(selectedRoom.RoomID, selectedRoom.RoomType, selectedRoom.Rate, paycode));
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

    private async void OnBookButtonClicked(object sender, EventArgs e)
    {
        // Create the frame with buttons
        Frame reservationFrame = new Frame
        {
            BackgroundColor = Color.FromRgba(255, 255, 255, 200), // Set the alpha value to 200 for semi-transparency
            Padding = 10,
            CornerRadius = 10,
            WidthRequest = 300,
            HeightRequest = 150,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.End,
            TranslationY = 300, // Start it off the screen
            Content = new StackLayout
            {
                Children = {
                new Button {
                    Text = "Reserve",
                    BackgroundColor = Color.FromRgb(37, 147, 107),
                    TextColor = Color.FromRgb(0, 0, 0),
                    CornerRadius = 10,
                    Margin = new Thickness(0, 0, 0, 10)
                },
                new Button {
                    Text = "Book Now",
                    BackgroundColor = Color.FromRgb(37, 147, 107),
                    TextColor =  Color.FromRgb(0, 0, 0),
                    CornerRadius = 10
                }
            }
            }
        };

        // Add the frame to the page
        Content = new AbsoluteLayout
        {
            BackgroundColor = Color.FromRgba(0, 0, 0, 150), // Set the alpha value to 150 for semi-transparency
            Children = {
            reservationFrame
        }
        };

        // Slide the frame into view with animation
        await reservationFrame.TranslateTo(0, 0, 250, Easing.SinInOut);
    }




}