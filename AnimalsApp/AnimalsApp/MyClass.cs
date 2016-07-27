using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AnimalsApp
{

    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class AnimalsViewModel
    {
        public ObservableCollection<Animal> Animals { get; } = new ObservableCollection<Animal>();

        public async Task GetAnimals()
        {
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync("http://testapiapp360.azurewebsites.net/api/values");
                var Items = JsonConvert.DeserializeObject<List<Animal>>(json);
                foreach (var item in Items)
                {
                    Animals.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }

}

