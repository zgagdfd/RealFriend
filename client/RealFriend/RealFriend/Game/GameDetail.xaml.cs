using Newtonsoft.Json;
using RealFriend.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameDetail : ContentPage
    {
        GameDetialedData Data;

        public GameDetail(GameDetialedData gameData)
        {
            Data = gameData;
            InitializeComponent();
            BindingContext = Data;
        }

        private async void ShareGameBtnClicked(Object sender, EventArgs e)
        {
            //分享
            await DisplayAlert("提示", "敬请期待~~", "确定");

        }

        private async void GameBeginBtnClicked(Object sender, EventArgs e)
        {
            IDictionary<string, object> properties = Application.Current.Properties;
            var curUserID = int.Parse((string)properties["id"]);
            if (Data.Participants.Contains(curUserID))
            {
                await DisplayAlert("提示", "您已加入，不能重复加入哦~~", "确定");
                return;
            }

            // put 更新
            GameData data = null;
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/game/" + Data.GameID;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<GameData>(content);
            }
            else
            {
                await DisplayAlert("提示", "StatusCode：" + content + " ", "确定");
            }
            if (data != null)
            {
                data.participants.Add(curUserID);
                var json = JsonConvert.SerializeObject(data);
                response = await client.PutAsync(new Uri(url), new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    // PUT更新成功
                    await DisplayAlert("提示", "恭喜您，成功加入互动~~", "确定");
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("提示", "StatusCode：" + responseString + " ", "确定");
                }
            }
            client.Dispose();
            
        }


    }
}