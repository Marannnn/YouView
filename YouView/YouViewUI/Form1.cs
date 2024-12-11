using System.Text.Json;
using System.Xml;

namespace YouViewUI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// TODO: userControl(video), click on tags Label
        /// CURR: USER CONTROL = SHOWING VIDEO INFO (NAME, CHANNEL, TAG)
        /// done: show tags in layoutPanel,  load json channels into list
        ///     basic GUI, save channels into json file
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

            foreach (var channel in channelList) //projdu jednotlive instance v listu channelList
            {
                //vytvori label pro dany tag
                #region Tag Label
                Label tag_label = new Label()
                {

                    Text = channel.Tag,
                };
                tags_flowLayoutPanel.Controls.Add(tag_label);
                #endregion

                #region Video User Control
                Video_userControl videoUserControl = new Video_userControl();
                videoUserControl.
                videos_flowLayoutPanel.Controls.Add(videoUserControl);

                #endregion
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        //buttons
        private void AddChannelButton_Click(object sender, EventArgs e)
        {
            AddChannel(ChannelID_textbox.Text, ChannelName_textbox.Text, ChannelTag_textbox.Text);
            ChannelID_textbox.Text = "";
            ChannelName_textbox.Text = "";
            ChannelTag_textbox.Text = "";
        }

        private void reload_button_Click(object sender, EventArgs e)
        {
            LoadChannels();
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
                int loadChannelCount = 0;
                string jsonString = File.ReadAllText(path); //precte data a preda je do jsonString stringu ( ty pak Json deserializuje)
                //MessageBox.Show(jsonString);
                var tmpChannelList = JsonSerializer.Deserialize<List<Channel>>(jsonString); //deserializuju data (typu List, s objektem classy Channel) do listu(var) channels. Takze mi vznikne novy List tmpChannelList, ktery bude mit ty dane objekty classy Channel
                //MessageBox.Show(deserializedJson.ToString());

                foreach (var channel in tmpChannelList) //projdu jednotliv
                {
                    channelList.Add(channel); //jednotlive je pridam do channelListu
                    loadChannelCount++;
                }
                MessageBox.Show($"Na�etl jsem: {loadChannelCount} ulo�en�ch kan�l�");
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
