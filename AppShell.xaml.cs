﻿using DeskHubMobile.Views;

namespace DeskHubMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(LoginPageTwo), typeof(LoginPageTwo));
            Routing.RegisterRoute(nameof(RoomPage), typeof(RoomPage));
            Routing.RegisterRoute(nameof(PayOnline), typeof(PayOnline));
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));

        }
    }
}
