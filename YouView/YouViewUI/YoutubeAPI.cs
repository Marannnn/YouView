using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace YouViewUI
{
    internal class YoutubeAPI
    {
        public List<string> resultList = new List<string>();
        public async Task Find(string CHANNEL_ID) //async - bude cekat na odpoved. Muzu pozuvat await 
        {

            using (HttpClient client = new HttpClient()) 
            {
                string API_KEY = "//HERE YOUR API KEY//";
                DateTime published_after_date = DateTime.Now.AddDays(-1); //curr day - 1 (vcera)
                string PUBLISHED_AFTER = published_after_date.ToString("yyyy-MM-ddTHH:mm:ssZ"); //predelam na pozadovany format
                string URL = $"https://youtube.googleapis.com/youtube/v3/search?part=snippet&channelId={CHANNEL_ID}&maxResults=5&order=date&publishedAfter={PUBLISHED_AFTER}&type=video&key={API_KEY}"; //z youtube experiment = provede ten search

                HttpResponseMessage response = await client.GetAsync(URL); //poslu request z URL (diky await, program pocka na odpoved), odpoved ulozim do response typu HttpResponseMessage

                if (response.IsSuccessStatusCode) //pokud kod je 2xx
                {
                    string jsonResponse  = await response.Content.ReadAsStringAsync(); //dam do json
                    
                    //deserializace
                    VideoConent videoContent = JsonSerializer.Deserialize<VideoConent>(jsonResponse);

                    for (int i = 0; i < videoContent.items.Length; i++)
                    {
                        resultList.Append(videoContent.items[i].snippet.videoTitle);
                    }

                }
                else //jiny status code
                {
                    MessageBox.Show(response.ToString());
                }
            }
        }


        //CLASSY potrebne k deserializaci
        class VideoConent //celkový obsah json souboru (nahoře v hierarchii)
        {
            public Items[] items { get; set; } //vytvoří array instanci items která handle/uje objekt items v json souboru
        }

        class Items //sem odkazuje VideoContent
        {
            public Snippet snippet { get; set; } //vytvoří instanci snippet která handle/uje objekt snippet v json souboru
        }

        class Snippet //sem odkazuje Items
        {
            //[JsonPropertyName("title")]
            public string videoTitle { get; set; } //json soubor sem přiřadí title
            public string channelTitle { get; set; } //json soubor sem přiřadí channelTitle
        }
    }
}
