using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealFriend
{
	public partial class MainPage : ContentPage
	{
        private string correctPwd;

        public MainPage()
        {
            InitializeComponent();
            CheckPwd();
        }

        private async void CheckPwd()
        {
            IDictionary<string, object> properties = Application.Current.Properties;

            // 验证密码是否已经修改
            var kv = properties.First();
            await GetPwdAsync(kv.Key);
            if (String.IsNullOrEmpty(correctPwd) || !String.Equals((string)kv.Value, correctPwd))
            {
                await DisplayAlert("提示", "密码已更改，请重新登录~~", "确定");
                await Navigation.PushModalAsync(new Login());
            }
            else
            {
                await Navigation.PushModalAsync(HomePage.Instance);
            }
        }

        private async Task GetPwdAsync(string acc)
        {
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/user/";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url + acc));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                UserObject user = JsonConvert.DeserializeObject<UserObject>(content);
                correctPwd = user.passwd;
            }
            client.Dispose();
        }
    }
}
