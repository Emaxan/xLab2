using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using xLab2.Models;

[assembly: Xamarin.Forms.Dependency(typeof(xLab2.MockDataStore))]
namespace xLab2
{
    public class MockDataStore : IDataStore<City>
    {
        List<City> items;
        public Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public MockDataStore()
        {
            items = new List<City>();

            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync("http://res.cloudinary.com/djj1tu4qa/raw/upload/v1524141202/cities.json").Result;
                var cl = (List<CityList>)new DataContractJsonSerializer(typeof(List<CityList>)).ReadObject(
                    GenerateStreamFromString(result));
                foreach (var list in cl)
                {
                    var res = client.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?id={list.id}&units=metric&APPID=1835776f43559c5fefafaeacb03ea900").Result;
                    var wi = (WeatherInfo)new DataContractJsonSerializer(typeof(WeatherInfo)).ReadObject(
                        GenerateStreamFromString(res));
                    items.Add(new City
                    {
                        Description = list.description,
                        Id = list.id,
                        Lat = list.coord.lat,
                        Lon = list.coord.lon,
                        Name = list.name,
                        bgPhoto = list.bgphoto,
                        smPhoto = list.smphoto,
                        Temperature = wi.main.temp,
                        Speed = wi.wind.speed,
                        Direction = wi.wind.deg
                    });
                }
            }
        }

        public async Task<bool> AddItemAsync(City item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(City item)
        {
            var _item = items.FirstOrDefault(arg => arg.Id == item.Id);
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = items.FirstOrDefault(arg => arg.Id == id);
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<City> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<City>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
