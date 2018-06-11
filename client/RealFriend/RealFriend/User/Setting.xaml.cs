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
	public partial class Setting : ContentPage
	{
        HttpClient client;

        public Setting ()
		{
			InitializeComponent ();
            ReturnButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new UserDetail());
            };
            QuitBtn.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new Login());
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
            UserId.Text = ll.id;
            Gender.Text = ll.gender;
            Signature.Text = ll.signature;
            HeadImage.Source = ll.avatar;
            Date.Text = "1991-1-1";
        }

    }
}