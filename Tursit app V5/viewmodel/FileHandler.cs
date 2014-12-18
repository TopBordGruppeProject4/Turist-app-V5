using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using Tursit_app_V5.model;

namespace Tursit_app_V5.viewmodel
{
   public class FileHandler
    {
        private static string FileName = "Users.dat";

        public static async void Save(ObservableCollection<User> users)
        {
            string userData = JsonConvert.SerializeObject(users);
            SerializeSaveGameAsync(userData, FileName);
        }

        public static async void SerializeSaveGameAsync(string userDataJsonString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, userDataJsonString);
        }

        public static async Task<ObservableCollection<User>> Load()
        {
            string usersData = await DeserializeFavoritAsync(FileName);
            if (usersData != null)
            {
                return (ObservableCollection<User>)JsonConvert.DeserializeObject(usersData, typeof(ObservableCollection<User>));
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
