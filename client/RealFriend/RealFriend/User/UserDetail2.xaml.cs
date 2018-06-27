using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetail2 : ContentPage
	{
        HttpClient client;
        public UserDetail2()
        {
            InitializeComponent();
            SettingBtn.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new Setting());
            };
            followee.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new FolloweePage());
            };
            follower.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new FollowerPage());
            };
            Activity.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new UserDetail());
            };
            GetInfo();
        }



        async void GetInfo()
        {
            string url = "http://real.eastasia.cloudapp.azure.com/user/msky/";
            string jsonText = await FetchWeatherAsync(url);
            if (!String.IsNullOrEmpty(jsonText))
                ParseAndDisplay(jsonText);
        }

        private async Task<string> FetchWeatherAsync(string url)
        {
            client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return content;
            }
            await DisplayAlert("提示", "StatusCode：" + content + " ", "确定");
            return null;
        }

        private void ParseAndDisplay(string jsonText)
        {
            //JsonText.Text = jsonText;
            UserObject ll = JsonConvert.DeserializeObject<UserObject>(jsonText);
            UserName.Text = ll.nickname;
            UserId.Text = "ID：" + ll.id;
            followee.Text = "关注";
            Signature.Text = ll.signature;
            HeadImage.Source = ll.avatar;
            follower.Text = "粉丝";
        }


    }
}