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

        async Task PostBtnClicked(Object sender, EventArgs e)
        {
            UserObject userObject = GetUserObject();
            var json = JsonConvert.SerializeObject(userObject);

            string url = "http://real.eastasia.cloudapp.azure.com/user/msky/";

            client = new HttpClient();

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(new Uri(url), content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("提示", "修改成功", "确定");
                await Navigation.PushModalAsync(new UserDetail());
            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                await DisplayAlert("提示", "StatusCode：" + responseString + " ", "确定");

            }
            client.Dispose();
        }
        private void ParseAndDisplay(string jsonText)
        {
            //JsonText.Text = jsonText;
            UserObject ll = JsonConvert.DeserializeObject<UserObject>(jsonText);
            NickName.Text = ll.nickname;
            UserId.Text = "" + ll.id;
            Gender.Text = ll.gender;
            Signature.Text = ll.signature;
            HeadImage.Source = ll.avatar;
            Date.Text = "1991-1-1";
        }

        private UserObject GetUserObject()
        {
            UserObject user = new UserObject();
            user.username = NickName.Text;
            //user.passwd = Password.Text;
            //user.nickname = NickName.Text;
            user.gender = Gender.Text;
            //user.email = EmailTxt.Text;
            //user.phone = PhoneTxt.Text;
            //user.avatar = HeadImage.Source;
            user.signature = Signature.Text;
            return user;
        }

    }
}