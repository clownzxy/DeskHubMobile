using DeskHubMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeskHubMobile.ViewModels
{
    public class UserViewModel
    {
        private ObservableCollection<User> userList = new ObservableCollection<User>();
        string maindir = AppDomain.CurrentDomain.BaseDirectory;
        string fileName = "Users.txt";

        public User CurrentUser { get; set; }

        public UserViewModel()
        {
            ConvertToUserList();
        }

        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set { userList = value; }
        }

        public void AddUser(User user)
        {
            userList.Add(user);
            SaveToFile();
        }

        public void SaveToFile()
        {
#if ANDROID
            var json = string.Empty;
            json = JsonSerializer.Serialize(userList);
            var docdocamaw = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads);
            //var docdocamaw = Android.App.Application.Context.

            File.WriteAllText($"{docdocamaw.AbsoluteFile.Path}/Users.txt", json);
#endif
        }


        public void ConvertToUserList()
        {
            if (File.Exists(maindir + fileName))
            {
                string jsonData = File.ReadAllText(maindir + fileName);
                userList = JsonSerializer.Deserialize<ObservableCollection<User>>(jsonData);
            }
        }

        public User GetUserByUsername(string username)
        {
            return userList.FirstOrDefault(user => user.Username == username);
        }

    }
}

