using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePublish : ContentPage
    {

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

                HttpClient client = new HttpClient();

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

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            // GameKind = (string)KindPicker.SelectedItem;
        }

        private GameData GetGameData()
        {
            // List<SelectableData<FriendData>> players = GamePublishViewModel.SelectedData.Where(x => x.IsSelected).ToList();

            GameData data = new GameData
            {
                name = GameNameEntry.Text
                /*
                // 加上活动的发起者
                PulblisherUserName = ...
                PlayerList = players,
                GamePass = GamePassEntry.Text,
                GameDate = DatePicker.Date,
                GameTime = TimePicker.Time,
                GameInfo = GameInfoEntry.Text,
                GameKind = (string)KindPicker.SelectedItem
                */
            };
            return data;
        }

    }
}