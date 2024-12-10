using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YouViewAPI    //#Duvod proc se pouziva "async" je protoze kod musi pockat na response od api. kdyby to tam nebylo, kod pobezi dal aniz by cekal na odpoved a tim padem by se nic nespustilo.
{
    //TODO: SHOW ONLY TAG VIDEOS, LOAD CHANNELS,SAVE SHOWN VIDEOS to save quota, ADD OPTION TO SHOW QUOTA
    //CURR: SAVE CHANNELS TO JSON
    internal class Program
    {
        static List<Channel> channelList = new List<Channel>();
        static async Task Main(string[] args) // async protoze metoda kterou volam je asynac
        {

            LoadChanels();

            bool repeat = true;
            Console.WriteLine("This app was made by Martin 'Maran' Hrubeš \n");
            while (repeat == true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1)Add channel, 2)Delete channel, 3) List all added channels with their tags, 4) SEE ALL NEW VIDEOS \n");
                string operation = Console.ReadLine();

                switch (operation) 
                {
                    case "1":
                        Console.WriteLine("Channel ID: ");
                        string channelId = Console.ReadLine();

                        if (channelId != null) //jestli uživatel zadal channelId ( jestli tam něco je )
                        {
                            Console.WriteLine("Add channel title(for managing data in file, wont affect the program): ");
                            string title = Console.ReadLine();
                            if (title != null)
                            {
                                Console.WriteLine("Add tag: ");
                                string tag = Console.ReadLine();
                                if (tag != null)
                                {
                                    Channel channel = new Channel();
                                    channel.Title = title;
                                    channel.Id = channelId;
                                    channel.Tag = tag;
                                    channelList.Add(channel);

                                    string jsonString = JsonSerializer.Serialize(channel);
                                    string filePath = Path.Combine(Environment.CurrentDirectory, "data.json");
                                    File.AppendAllText(filePath, jsonString + Environment.NewLine);
                                    Console.WriteLine("Channel succesfuly added and saved into json file \n");
                                }
                                else
                                {
                                    Console.WriteLine("Put a tag!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Put a channel title!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You didn't put in channel id");
                        }

                        Console.WriteLine("Do you want to continue? Y/N");
                        if (Console.ReadLine() == "Y")
                        {
                            continue;
                        }
                        else
                        {
                            repeat = false;
                            
                        }
                        break; //Přidat kanál

                    case "2":
                        Console.WriteLine("What channel do you want to delete?(channel title): ");
                        string channelTitle = Console.ReadLine();
                        if (channelTitle != null) //pokud uzivatel neco napsal
                        {
                            var desiredChannel = channelList.Find(t => t.Title == channelTitle);
                            if (desiredChannel != null) //pokud channel existuje a program ho nasel
                            {
                                channelList.Remove(desiredChannel); //smazu kanal z listu ktery list nasel pres "Find"
                                Console.WriteLine("Channel succesfuly removed \n");
                                Console.WriteLine("Do you want to continue? Y/N");
                                if (Console.ReadLine() == "Y")
                                {
                                    continue;
                                }
                                else
                                {
                                    repeat = false;

                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Non existent channel title");
                            }    
                        }
                        break; //Smazat kanál
                    case "3": //Zobrazit všechny kanály
                        foreach (var channel in channelList)
                        {
                            Console.WriteLine($"{channel.Title} \n  {channel.Tag} \n    {channel.Id} \n -------------------------------------");
                        }
                        break;
                    case "4": //Zobrazit všechna videa
                        for(int i = 0;i < channelList.Count;i++) 
                        {
                            await GetYoutubeData(channelList[i].Id);
                            Console.WriteLine(channelList[i].Tag);
                            Console.WriteLine("------------------------------------- \n");
                        }
                        break;
                    default:
                        Console.WriteLine("Please select between 1 and 4");
                        break;
                }


            }
            

        }

        static public async Task GetYoutubeData(string CHANNEL_ID)
        {
            using (HttpClient client = new HttpClient()) //používáním: http clientu
            {
                string API_KEY = "//HERE YOUR API KEY//"; 
                DateTime published_after_date = DateTime.Now.AddDays(-1); //aktuální čas posunutý o den vzůdu(včera)
                string PUBLISHED_AFTER = published_after_date.ToString("yyyy-MM-ddTHH:mm:ssZ"); //přemění ho na string formát
                string URL = $"https://youtube.googleapis.com/youtube/v3/search?part=snippet&channelId={CHANNEL_ID}&maxResults=5&order=date&publishedAfter={PUBLISHED_AFTER}&type=video&key={API_KEY}"; //url z YouTube Data v3 api dokumentace (experiment)

                HttpResponseMessage response = await client.GetAsync(URL); // odešle požadavek, počká, a pak ho přiřadí do "response" (ve HttpResponse classe)

                if (response.IsSuccessStatusCode) //pokud byl úspěšný (vrati kod 2xx)
                {
                    //Console.WriteLine($"Přijal jsem úspěšně response: {response}"); //vypíše response
                    string jsonResponse = await response.Content.ReadAsStringAsync();// response dám do json
                    Load(jsonResponse);

                }
                else //pokud nebyl úspěšný
                {
                    Console.WriteLine("Chyba při získávání dat z YouTube");
                    Console.WriteLine(response);
                }
            }
        }
        static public void LoadChanels()
        {
            string filePath = (@"E:\Documents\Programming\cSharp\YouView\YouView\YouView\YouViewAPI\bin\Debug\net8.0\data.json");
            string jsonString = File.ReadAllText(filePath);
            channelList = JsonSerializer.Deserialize<List<Channel>>(jsonString);
            /////////////////////////////////////////////////////////////////TADY
            foreach (Channel channel in channelList) 
            {
                Console.WriteLine(channel.Title);
            }
        }

        static public void Load(string jsonResponse)
        {
            Console.WriteLine("-------------------------------------------------------------");
            VideoConent content = JsonSerializer.Deserialize<VideoConent>(jsonResponse); //deserializace s použitím classy VideoContent
            Console.WriteLine(content.items[0].snippet.title); //vypíšu jméno videa
            Console.WriteLine(content.items[0].snippet.channelTitle); //vypíšu jméno kanálu
            
        }

        class VideoConent //celkový obsah json souboru (nahoře v hierarchii)
        {
            public Items[] items {  get; set; } //vytvoří array instanci items která handle/uje objekt items v json souboru
        }

        class Items //sem odkazuje VideoContent
        {
            public Snippet snippet {  get; set; } //vytvoří instanci snippet která handle/uje objekt snippet v json souboru
        }

        class Snippet //sem odkazuje Items
        {
            //[JsonPropertyName("title")]
            public string title {  get; set; } //json soubor sem přiřadí title
            public string channelTitle { get; set; } //json soubor sem přiřadí channelTitle
        }

        public class Channel
        {
            public string Title { get; set; }
            public string Id { get; set; }
            public string Tag { get; set; }
        }
    }
}
