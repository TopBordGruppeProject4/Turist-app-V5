using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using Tursit_app_V5.model;

namespace TursitAppV4.Model
{
   public class FileHandler
    {
        private static string FileName = "Users.dat";

        public static async void Save(ObservableCollection<User> users)
        {
            string playerDataAsJson = JsonConvert.SerializeObject(users);
            SerializeSaveGameAsync(playerDataAsJson, FileName);
        }

        public static async void SerializeSaveGameAsync(string playerDataJsonString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, playerDataJsonString);
        }

        public static async Task<ObservableCollection<User>> Load()
        {
            string favoritData = await DeserializeFavoritAsync(FileName);
            if (favoritData != null)
            {
                return (ObservableCollection<User>)JsonConvert.DeserializeObject(favoritData, typeof(ObservableCollection<User>));
            }
            return null;
        }

        private static async Task<string> DeserializeFavoritAsync(string fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
