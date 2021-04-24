using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Converter.Models
{
    class Parser
    {
        List<Valute> Valutes { get; set; }

        public static async Task<ObservableCollection<Valute>> TakeData()
        {
            using (var httpClient = new HttpClient())
            {
                ObservableCollection<Valute> Valutes = new ObservableCollection<Valute>();

                var json = await httpClient.GetStringAsync(@"https://www.cbr-xml-daily.ru/daily_json.js");

                JObject parser = JObject.Parse(json);

                IList<JToken> results = parser["Valute"].Children().ToList();

                foreach (JToken result in results)
                {
                    string output = JsonConvert.SerializeObject(result.First).Replace(@"\", "");
                    var valute = JsonConvert.DeserializeObject<Valute>(output);
                    Valutes.Add(valute);
                }

                return Valutes;
            }
        }
    }
}
