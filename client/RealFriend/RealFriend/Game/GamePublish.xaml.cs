using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePublish : ContentPage
    {
        HttpClient client;

        public GamePublish()
        {
            InitializeComponent();
            BindingContext = new GamePublishViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((GamePublishViewModel)BindingContext).OnAppearing();
        }

        async void PublishGameBtnClicked(object sender, EventArgs e)
        {
            GameData gameData = GetGameData();
            if (!String.IsNullOrWhiteSpace(gameData.name))
            {
                // 传输数据
                var json = JsonConvert.SerializeObject(gameData);
                string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/game/create";

                client = new HttpClient();

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(new Uri(url), content);

                if (response.IsSuccessStatusCode)
                {
                    await this.DisplayAlert("提示", "互动发起成功", "确定");
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("提示", "StatusCode：" + responseString + " ", "确定");
                }

            }
            else
            {
                await this.DisplayAlert("提示", "请填写互动名称", "确定");
            }

        }

        private GameData GetGameData()
        {
            IDictionary<string, object> properties = Application.Current.Properties;
            int curUserID = int.Parse((string)properties["id"]);
            GameData data = new GameData
            {
                name = GameNameEntry.Text.ToUpper(),
                initiator = curUserID,
                start_time = DatePicker.Date.ToShortDateString().Replace('/', '-')
                                + "T"
                                + TimePicker.Time,
                is_private = String.Equals((string)PrivatePicker.SelectedItem, "是") ? true : false
            };
            data.introduction = String.IsNullOrWhiteSpace(GameIntroEntry.Text) ? "一起来玩" + data.name + "吧~~~" : GameIntroEntry.Text;

            switch ((string)TypePicker.SelectedItem)
            {
                case "室  内": data.type = "indoor"; break;
                case "室  外": data.type = "outdoor"; break;
                case "线  上": data.type = "online"; break;
            }

            List<SelectableData<FriendData>> players = GamePublishViewModel.SelectedData.Where(x => x.IsSelected).ToList();
            List<int> participants = new List<int>();
            foreach (var player in players)
            {
                participants.Add(player.Data.UserID);
            }
            if(!participants.Contains(curUserID))
                participants.Add(curUserID);

            data.participants = participants;
            return data;
        }

        async Task<int> GetID(string username)
        {
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/user/" + username;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                UserObject uo = JsonConvert.DeserializeObject<UserObject>(content);
                return await Task.FromResult(uo.id);
            }
            return await Task.FromResult(0);
        }
    }
}