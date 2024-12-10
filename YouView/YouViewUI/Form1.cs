using System.Text.Json;
using System.Xml;

namespace YouViewUI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// TODO: load json channels into list
        /// done: basic GUI, save channels into json file
        /// </summary>
        /// 

        List<Channel> channelList = new List<Channel>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadChannels();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void AddChannelButton_Click(object sender, EventArgs e)
        {
            AddChannel(ChannelID_textbox.Text, ChannelName_textbox.Text, ChannelTag_textbox.Text);
            ChannelID_textbox.Text = "";
            ChannelName_textbox.Text = "";
            ChannelTag_textbox.Text = "";
        }


        //custom metody
        public void AddChannel(string id, string name, string tag)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(tag)) //pokud nejsou null nebo empty ("")
            {
                Channel channel = new Channel() //vytvorim novou instanci classy Channel a priradim vlastnosti(properties)
                {
                    Id = id,
                    Name = name,
                    Tag = tag
                };
                channelList.Add(channel); //pridam do listu channelList

                //serializace
                string path = Path.Combine(Environment.CurrentDirectory, "Data.json");
                string jsonString = JsonSerializer.Serialize(channelList, new JsonSerializerOptions { WriteIndented = true }); //pracuje s channelListem. serializuje do stringu s WriteIntended jako true ( nastavi spravny format [] = soubor jako array)
                File.WriteAllText(path, jsonString); //prepise soubor
                MessageBox.Show($"Channel {name} added");
                
            }
            else //pokud je null nebo empty
            {
                MessageBox.Show("Please enter id,name and tag");
            }
        }

        public void LoadChannels()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Data.json");
            if (File.Exists(path)) //pokud soubor data.json existuje
            {
                string jsonString = File.ReadAllText(path); //precte data a preda je do jsonString stringu ( ty pak Json deserializuje)
                MessageBox.Show(jsonString);
                //string[] data = jsonString.Split("},");
                //foreach (string name in data)
                //{
                //    MessageBox.Show(name);
                //}
                channelList.Add(JsonSerializer.Deserialize<Channel>(jsonString));
                //MessageBox.Show(channel.Name.ToString());
            }
        }


        //custom classy
        class Channel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Tag { get; set; }
        }

    }
}
