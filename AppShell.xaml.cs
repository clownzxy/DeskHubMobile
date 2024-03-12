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
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
           // Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
            Routing.RegisterRoute(nameof(RoomPage), typeof(RoomPage));

        }
    }
}
