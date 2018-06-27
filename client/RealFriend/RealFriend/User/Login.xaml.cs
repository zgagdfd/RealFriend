using Newtonsoft.Json;
using RealFriend.User;
using System;
using System.Collections.Generic;
using System.Net.Http;

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
            
            Init();
        }

        void Init()
        {
            BackgroundImage = "login_bac.jpg";

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                await DisplayAlert("提示", "敬请期待~~~", "确定");
            };
            Icon_QQ.GestureRecognizers.Add(tapGestureRecognizer);
            Icon_weixin.GestureRecognizers.Add(tapGestureRecognizer);
            Icon_xinlang.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void LoginBtnClicked(object sender, EventArgs e)
        {
            string username = AccountEntry.Text;
            string password = PasswordEntry.Text;
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                return;
            CheckPass(username, password);
        }

        // 校验账号密码
        async void CheckPass(string username, string pwd)
        {
            string url = "http://real.eastasia.cloudapp.azure.com/user/" + username;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                UserObject uo = JsonConvert.DeserializeObject<UserObject>(content);
                if (Utils.GetMD5(pwd).Equals(uo.passwd))
                {
                    // 存储<username, password>
                    IDictionary<string, object> properties = Application.Current.Properties;
                    properties.Clear();
                    properties.Add("id", "" + uo.id);
                    properties.Add("username", uo.username);
                    properties.Add("password", uo.passwd);
                    properties.Add("avatar",  uo.avatar);
                    await Application.Current.SavePropertiesAsync();

                    // 跳转至主页
                    await Navigation.PushModalAsync(HomePage.Instance);
                    client.Dispose();
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