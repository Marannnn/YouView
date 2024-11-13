using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YouViewAPI    //#Duvod proc se pouziva "async" je protoze kod musi pockat na response od api. kdyby to tam nebylo, kod pobezi dal aniz by cekal na odpoved a tim padem by se nic nespustilo.
{
    internal class Program
    {
        static async Task Main(string[] args) // async protoze metoda kterou volam je asynac
        {
            await GetYoutubeData("UCtu2BCnJoFGRBOuIh570QWw"); //pocka na odpoved
        }

        static public async Task GetYoutubeData(string CHANNEL_ID)
        {
            using (HttpClient client = new HttpClient()) //pozivanim nove vytvoreneho hhtp client
            {
                string API_KEY = "HERE YOUR API KEY";
                DateTime published_after_date = DateTime.Now.AddDays(-1); //aktualni cas posunuty o jeden den zpet = vcera
                string PUBLISHED_AFTER = published_after_date.ToString("yyyy-MM-ddTHH:mm:ssZ"); //premeni ho na string v tomto formatu
                string URL = $"https://youtube.googleapis.com/youtube/v3/search?part=snippet&channelId={CHANNEL_ID}&maxResults=5&order=date&publishedAfter={PUBLISHED_AFTER}&type=video&key={API_KEY}"; //url z YouTube Data v3 api dokumentace (experiment)

                HttpResponseMessage response = await client.GetAsync(URL); // odesle pozadavek(request), pocka a pak priradi do "response"

                if (response.IsSuccessStatusCode) //pokud byl uspesny (vrati kod 2xx)
                {
                    Console.WriteLine($"Přijal jsem úspěšně response: {response}");
                    string jsonResponse = await response.Content.ReadAsStringAsync();// response dam do json

                    Load(jsonResponse);

                }
                else //pokud nebyl uspesny
                {
                    Console.WriteLine("Chyba při získávání dat z YouTube");
                }
            }
        }
        static public void Load(string jsonResponse)
        {
            Console.WriteLine("-------------------------------------------------------------");
            VideoConent content = JsonSerializer.Deserialize<VideoConent>(jsonResponse);
            Console.WriteLine(content.items[0].snippet.title);
            Console.WriteLine(content.items[0].snippet.channelTitle);
        }

        class VideoConent
        {
            public Items[] items {  get; set; }
        }

        class Items
        {
            public Snippet snippet {  get; set; }
        }

        class Snippet
        {
            //[JsonPropertyName("title")]
            public string title {  get; set; }
            public string channelTitle { get; set; }
        }
    }
}
