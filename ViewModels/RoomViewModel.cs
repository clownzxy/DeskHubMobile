﻿using DeskHubMobile.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;


namespace DeskHubMobile.ViewModels
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Room> roomList = new ObservableCollection<Room>();
        string maindir = AppDomain.CurrentDomain.BaseDirectory; //change to FileSystem.Current.AppDataDirectory;
        string fileName = "Room.txt";

        public event PropertyChangedEventHandler PropertyChanged;
        public RoomViewModel()
        {
            roomList = new ObservableCollection<Room>();
           ConvertToRoomList();
            //ConvertToRoomListWindows();
        }

        public ObservableCollection<Room> RoomList
        {
            get { return roomList; }
            set
            {
                if (roomList != value)
                {
                    roomList = value;
                    OnPropertyChanged(nameof(RoomList));
                }
            }
        }

        public void AddRoom(Room room)
        {
            roomList.Add(room);
            SaveToFile();
        }

        public void RemoveRoom(Room room)
        {
            roomList.Remove(room);
            SaveToFile();
        }

        public void EditRoom(Room updatedRoom)
        {
            var existingRoom = roomList.FirstOrDefault(r => r.RoomID == updatedRoom.RoomID);

            if (existingRoom != null)
            {
                existingRoom.RoomName = updatedRoom.RoomName;
                existingRoom.Branch = updatedRoom.Branch;
                existingRoom.IsAvailable = updatedRoom.IsAvailable;
                OnPropertyChanged(nameof(RoomList));
                SaveToFile();
            }
        }


        public void SaveToFile()
        {
            var json = string.Empty;
            json = JsonSerializer.Serialize(roomList);
            File.WriteAllText(maindir + fileName, json);
        }

        public void ConvertToRoomList()
        {
#if ANDROID
        var docdocamaw = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDcim);
            if (File.Exists($"{docdocamaw.AbsoluteFile.Path}/Room.txt"))
            {
                string jsonData = File.ReadAllText($"{docdocamaw.AbsoluteFile.Path}/Room.txt");
                roomList = JsonSerializer.Deserialize<ObservableCollection<Room>>(jsonData);
            }
#endif
        }

        public void ConvertToRoomListWindows()
        {
            string maindir = AppDomain.CurrentDomain.BaseDirectory; //change to FileSystem.Current.AppDataDirectory;

            if (File.Exists(maindir + fileName))
            {
                string jsonData = File.ReadAllText(maindir + fileName);
                roomList = JsonSerializer.Deserialize<ObservableCollection<Room>>(jsonData);
            }
        }

        protected virtual void OnPropertyChanged(string RoomList)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(RoomList));
        }

        public Room GetRoomByID(string ID)
        {
            return roomList.FirstOrDefault(room => room.RoomID == ID);
        }

    }
}
