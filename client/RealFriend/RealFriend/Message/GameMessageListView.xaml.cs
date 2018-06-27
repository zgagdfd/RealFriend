using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using RealFriend.Game;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameMessageListView : ContentView
    {
        public GameMessageListView()
        {
            InitializeComponent();
            gameMessageListView.ItemsSource = LoadMessageData();
            GameDetialedData random_game = get_a_game();
            gameMessageListView.ItemTapped += async (sender, args) => {
                await Navigation.PushModalAsync(new GameDetail(random_game));
            };
        }


        private GameDetialedData get_a_game()
        {
            // 获得game列表
            string url = "http://real.eastasia.cloudapp.azure.com/game";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            List<GameData> GamesList = JsonConvert.DeserializeObject<List<GameData>>(content);
            int i = new Random().Next(0, GamesList.Count);
            GameData game_temp = GamesList[i];


            url = "http://real.eastasia.cloudapp.azure.com/user";
             client = new HttpClient();
            response = client.GetAsync(url).Result;
            content = response.Content.ReadAsStringAsync().Result;
            GameDetialedData gameData = new GameDetialedData();
            gameData.Type = game_temp.type;
            gameData.GameName = game_temp.name;
            gameData.GameID = game_temp.id;
            gameData.InitiatorID = game_temp.initiator;
            gameData.Participants = game_temp.participants;
            gameData.GameIntro = game_temp.introduction;
            gameData.Is_private = game_temp.is_private;
            gameData.StartTime = game_temp.start_time;
            Images imgs = new Images();
            gameData.GameImage = imgs.GetImage(game_temp.name);
            List<FriendData> playersList = new List<FriendData>();
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
            gameData.PlayersList = playersList;
            return gameData;
        }


        private List<MessageData> LoadMessageData()
        {
            List<MessageData> list = new List<MessageData>();
            string url = "http://real.eastasia.cloudapp.azure.com/message";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            string statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                List<message> test_message = JsonConvert.DeserializeObject<List<message>>(result);
                foreach (message item in test_message)
                {
                    string[] avatas = {"https://ss0.bdstatic.com/70cFuHSh_Q1YnxGkpoWK1HF6hhy/it/u=4207718151,3909761681&fm=27&gp=0.jpg",
                    "https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=1327145791,1511454155&fm=27&gp=0.jpg",
                    "https://ss1.bdstatic.com/70cFuXSh_Q1YnxGkpoWK1HF6hhy/it/u=3888083289,587176764&fm=27&gp=0.jpg",
                    "https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=712305315,3942148357&fm=27&gp=0.jpg",
                    "https://ss1.bdstatic.com/70cFuXSh_Q1YnxGkpoWK1HF6hhy/it/u=2660608196,3158838601&fm=27&gp=0.jpg",
                        "https://ss2.bdstatic.com/70cFvnSh_Q1YnxGkpoWK1HF6hhy/it/u=1585403785,3541560371&fm=27&gp=0.jpg"};
                    string[] names = { "bigliam", "fushuai", "ABC", "jay", "刘昊然", "玺", "旭旭", "msky", "acmore" };
                    if(item.type == "game"){
                        int i = new Random().Next(0, avatas.Length);
                        int j = new Random().Next(0, names.Length);
                        string avata = avatas[i];
                        string name = names[j];
                        //头像链接暂时API未提供，  title不需要，api需给出发送者姓名，先暂时用type代替显示
                        MessageData data = new MessageData(avata, name, item.content);
                        list.Add(data);
                    }

                }
            }
            return list;

        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list_tmp = (ListView)sender;
            gameMessageListView.ItemsSource = LoadMessageData();
            list_tmp.IsRefreshing = false;
        }
    }

}
