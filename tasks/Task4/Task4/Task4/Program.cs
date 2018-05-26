using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            IAttend[] attends = new IAttend[]
                {
            new Concert("Godsmack", "17.11.2018", "Arena Wien", 34),
            new Concert("Lamb of God", "11.11.2018", "Stadthalle Wien", 54),
            new TicketID(10, 37.90M),
            new TicketID(11, 55.90M),
                };

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            settings.Formatting = Formatting.Indented;

            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(System.IO.File.Open("jsonFile.json", System.IO.FileMode.Create)))
            {

                streamWriter.Write(JsonConvert.SerializeObject(attends, settings));
                streamWriter.Flush();

            }

            string json = System.IO.File.ReadAllText("jsonFile.json");

            IAttend[] readCreatures = JsonConvert.DeserializeObject<IAttend[]>(json, settings);

            Console.WriteLine(json);
          
        }
    }
}
