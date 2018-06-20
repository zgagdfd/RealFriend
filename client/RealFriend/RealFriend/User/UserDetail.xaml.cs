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
	public partial class UserDetail : ContentPage
	{
        HttpClient client;
        public UserDetail()
        {
            InitializeComponent();
            SettingBtn.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new Setting());
            };
            GetInfo();
        }



        async void GetInfo()
        {
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/user/msky";
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
            UserId.Text = "" + ll.id;
            Constellation.Text = "射手座";
            Signature.Text = ll.signature;
            HeadImage.Source = ll.avatar;
            Area.Text = "Beijing";
        }


    }
}