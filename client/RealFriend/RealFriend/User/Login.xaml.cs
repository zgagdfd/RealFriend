using Newtonsoft.Json;
using RealFriend.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtnClicked(object sender, EventArgs e)
        {
            string acc = AccountEntry.Text.Trim();
            string pwd = PasswordEntry.Text;
            if (String.IsNullOrEmpty(acc) || String.IsNullOrEmpty(pwd))
                return;
            CheckPass(acc, pwd);
        }

        // 校验账号密码
        async void CheckPass(string account, string pwd)
        {
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/user/" + account;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                UserObject uo = JsonConvert.DeserializeObject<UserObject>(content);
                client.Dispose();
                string rightPas = uo.passwd;
                var cryp = Utils.GetMD5(pwd);
                if (cryp.Equals(rightPas))
                {
                    // 存储账号密码
                    IDictionary<string, object> properties = Application.Current.Properties;
                    properties.Clear();
                    properties.Add(account, cryp);
                    await Application.Current.SavePropertiesAsync();
                    // 跳转至主页
                    await Navigation.PushModalAsync(HomePage.Instance);
                }
                else
                {
                    await this.DisplayAlert("提示", "密码错误，请重新输入", "确定");
                }
            }
            else
                // 账号不存在？
                await DisplayAlert("提示", "StatusCode：" + content + " ", "确定");
        }

        // 创建账户
        async void RegisterBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
        }

        // 忘记密码
        async void ForgetPwdBtnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("提示", "敬请期待~~~", "确定");
        }
    }
}