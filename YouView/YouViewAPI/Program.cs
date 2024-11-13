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
            await GetYoutubeData("UCtu2BCnJoFGRBOuIh570QWw"); //Počká na odpověď
        }

        static public async Task GetYoutubeData(string CHANNEL_ID)
        {
            using (HttpClient client = new HttpClient()) //používáním: http clientu
            {
                string API_KEY = "HERE YOUR API KEY";
                DateTime published_after_date = DateTime.Now.AddDays(-1); //aktuální čas posunutý o den vzůdu(včera)
                string PUBLISHED_AFTER = published_after_date.ToString("yyyy-MM-ddTHH:mm:ssZ"); //přemění ho na string formát
                string URL = $"https://youtube.googleapis.com/youtube/v3/search?part=snippet&channelId={CHANNEL_ID}&maxResults=5&order=date&publishedAfter={PUBLISHED_AFTER}&type=video&key={API_KEY}"; //url z YouTube Data v3 api dokumentace (experiment)

                HttpResponseMessage response = await client.GetAsync(URL); // odešle požadavek, počká, a pak ho přiřadí do "response" (ve HttpResponse classe)

                if (response.IsSuccessStatusCode) //pokud byl úspěšný (vrati kod 2xx)
                {
                    Console.WriteLine($"Přijal jsem úspěšně response: {response}"); //vypíše response
                    string jsonResponse = await response.Content.ReadAsStringAsync();// response dám do json

                    Load(jsonResponse);

                }
                else //pokud nebyl úspěšný
                {
                    Console.WriteLine("Chyba při získávání dat z YouTube");
                }
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
    }
}
