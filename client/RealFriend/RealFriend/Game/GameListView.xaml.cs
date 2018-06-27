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
        public List<GameDetailedData> GameSource { get; set; }

        public GameListView()
        {
            InitializeComponent();
            BackgroundColor = Color.FromHex("#EEEEEE");
            LoadData();
        }

        async void LoadData()
        {
            // 获得game列表
            string url = "http://real.eastasia.cloudapp.azure.com/game";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                // Console.Out.WriteLine("请求成功~~~~~~~" + content);
                GameSource = new List<GameDetailedData>();
                List<GameData> GamesList = JsonConvert.DeserializeObject<List<GameData>>(content);
                foreach (var game in GamesList)
                {
                    GameDetailedData gameItem = new GameDetailedData
                    {
                        GameID = game.id,
                        GameName = game.name,
                        GameIntro = String.IsNullOrEmpty(game.introduction) ? "一起来玩" + game.name + "吧~~~" : game.introduction,
                        StartTime = game.start_time,
                        InitiatorID = game.initiator,
                        Participants = game.participants
                    };
                    string[] labels = gameItem.StartTime.Split('T');
                    string time = labels[0] + " ";
                    time += labels[1].Split(':')[0] + ":" + labels[1].Split(':')[1];
                    gameItem.GameDetailLabel = gameItem.GameName + "(开始时间：" + time + ")";

                    // gameImage
                    Images imgs = new Images();
                    gameItem.GameImage = imgs.GetImage(gameItem.GameName);
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
            GameDetailedData gameData = (GameDetailedData)e.SelectedItem;

            List<FriendData> playersList = new List<FriendData>();

            // 获得user列表
            string url = "http://real.eastasia.cloudapp.azure.com/user";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                List<UserObject> userObjects = JsonConvert.DeserializeObject<List<UserObject>>(content);
                foreach (var user in userObjects)
                {
                    if (user.id == gameData.InitiatorID)
                    {
                        gameData.InitiatorAvatar = user.avatar;
                        gameData.InitiatorName = user.username;
                    }
                    if (gameData.Participants.Contains(user.id))
                    {
                        FriendData data = new FriendData
                        {
                            Avatar = user.avatar,
                            UserName = user.username,
                            UserID = user.id
                        };
                        playersList.Add(data);
                    }
                }
            }
            else
            {
                Console.Out.WriteLine("请求失败~~~~~~~");
                // await DisplayAlert("提示", "StatusCode：" + content + " ", "确定");
            }
            client.Dispose();
            gameData.PlayersList = playersList;

            NavigationPage gameDetail = new NavigationPage(new GameDetail(gameData));
            // gameDetail.BindingContext = gameData;
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

    public class GameDetailedData
    {
        public int GameID { set; get; }
        public string GameName { set; get; }
        public int InitiatorID { set; get; }
        public List<int> Participants { get; set; }
        public bool Is_private { get; set; }
        public string StartTime { set; get; }
        public string Type { set; get; }
        public string GameIntro { set; get; }

        // GameDetail需要用的结构
        public string GameDetailLabel { set; get; }
        public string InitiatorName { set; get; }
        public ImageSource InitiatorAvatar { get; set; }
        public List<FriendData> PlayersList { set; get; }
        public ImageSource GameImage { set; get; }

    }
}