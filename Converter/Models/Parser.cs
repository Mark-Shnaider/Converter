using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Converter.Models
{
    class Parser
    {
        public static ObservableCollection<Valute> TakeData()
        {
            using (var webClient = new WebClient())
            {
                ObservableCollection<Valute> Valutes = new ObservableCollection<Valute>();

                var json = webClient.DownloadString(@"https://www.cbr-xml-daily.ru/daily_json.js");

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
