using Newtonsoft.Json;
using RealFriend.Game;
using System;
using System.Collections.Generic;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameListView : ContentView
    {
        public List<GameDetialedData> GameSource { get; set; }

        public GameListView()
        {
            InitializeComponent();
            LoadData();
        }

        async void LoadData()
        {
            // 获得game列表
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/game";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                // Console.Out.WriteLine("请求成功~~~~~~~" + content);
                GameSource = new List<GameDetialedData>();
                List<OnlineGame> GamesList = JsonConvert.DeserializeObject<List<OnlineGame>>(content);
                foreach (var game in GamesList)
                {
                    GameDetialedData gameItem = new GameDetialedData
                    {
                        GameID = game.id + "",
                        GameName = game.name,
                        GameImage = "icon.png",
                        GameInfo = "一起来玩" + game.name + "吧~~~",
                        PublisherAvatar = "icon.png",
                        PuiblisherUserName = "bigliam",

                        PlayersList = new List<FriendData>()
                        {
                            new FriendData{ UserID = game.id + "1", Avatar = "icon.png", UserName = "acmore"},
                            new FriendData{ UserID = game.id + "2", Avatar = "icon.png", UserName = "bigliam"},
                            new FriendData{ UserID = game.id + "3", Avatar = "icon.png", UserName = "xiaoll"},
                            new FriendData{ UserID = game.id + "4", Avatar = "icon.png", UserName = "Ms.Mao"},
                            new FriendData{ UserID = game.id + "5", Avatar = "icon.png", UserName = "Boss Han"}
                        }

                    };
                    GameSource.Add(gameItem);
                }
            }
            else
            {
                Console.Out.WriteLine("请求失败~~~~~~~");
                // await DisplayAlert("提示", "StatusCode：" + content + " ", "确定");
            }
            gameListView.ItemsSource = GameSource;

        }


        void JoinGameBtnClicked(Object sender, EventArgs e)
        {

        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            ListView listView = (ListView)sender;
            listView.SelectedItem = null;
            GameDetialedData gameData = (GameDetialedData)e.SelectedItem;

            NavigationPage gameDetail = new NavigationPage(new GameDetail());
            gameDetail.BindingContext = gameData;
            await Navigation.PushModalAsync(gameDetail);
        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            GameSource.Clear();
            LoadData();
            list.IsRefreshing = false;
        }
    }

    public class OnlineGame
    {
        public int id { set; get; }
        public string name { set; get; }
    }

    public class GameDetialedData
    {
        public string GameID { set; get; }
        public ImageSource GameImage { set; get; }
        public string GameName { set; get; }
        public string GameInfo { set; get; }
        public List<FriendData> PlayersList { set; get; }
        public string PuiblisherUserName { set; get; }
        public ImageSource PublisherAvatar { get; set; }
    }
}