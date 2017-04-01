using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using TuristAppV5.Model;

namespace TuristAppV5.Viewmodel
{
    class PersistenceFacade
    {
        private static string jsonFileName = "SavedVariablesAsJson.dat";

        public static async void SaveKategorilisteAsJsonAsync(ObservableCollection<ObservableCollection<Kategoriliste>> _collectionOfKategoriliste)
        {
            string kategorilisteJsonString = JsonConvert.SerializeObject(_collectionOfKategoriliste);
            SerializeKategorilisteFileAsync(kategorilisteJsonString, jsonFileName);
        }
        public static async Task<ObservableCollection<ObservableCollection<Kategoriliste>>> LoadKategorilisteFromJsonAsync()
        {

            string kategorilisteJsonString = await DeSerializeKategorilisteFileAsync(jsonFileName);
            if (kategorilisteJsonString != null)
            {
                return
                    (ObservableCollection<ObservableCollection<Kategoriliste>>)JsonConvert.DeserializeObject(kategorilisteJsonString, typeof(ObservableCollection<ObservableCollection<Kategoriliste>>));
            }
            return null;
        }
        public static async void SerializeKategorilisteFileAsync(string KategorilisteString, string fileName)
        {
            StorageFile localFile =
                await
                    ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                        CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, KategorilisteString);
        }
        public static async Task<string> DeSerializeKategorilisteFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
    }
}
