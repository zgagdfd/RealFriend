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
    public partial class Register : ContentPage
    {
        string phoneNum;

        public Register()
        {
            InitializeComponent();
        }

        async void CancelRegisterBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void NextBtnClicked(object sender, EventArgs e)
        {
            string verificationCode = VerificationCodeEntry.Text;
            // 验证码校验
            if (!String.IsNullOrEmpty(verificationCode)
                && verificationCode.Trim().Equals("1234"))
            {
                PhoneStackLayout.IsVisible = false;
                InfoStackLayout.IsVisible = true;
                PosLayout.IsVisible = false;
            }
            else
            {
                await DisplayAlert("提示", "验证码输入错误, 请重新输入", "确定");
            }
        }

        async void RegisterBtnClicked(object sender, EventArgs e)
        {
            UserObject userData = GetUserObject();
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/user/";
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(new Uri(url + userData.username));

            if (responseMessage.IsSuccessStatusCode)
                await DisplayAlert("提示", "此用户名已存在, 请重新输入", "确定");
            else
            {
                var jsonData = JsonConvert.SerializeObject(userData);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                responseMessage = await client.PostAsync(new Uri(url + "create"), content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    await DisplayAlert("提示", "注册成功", "确定");
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    var responseString = await responseMessage.Content.ReadAsStringAsync();
                    await DisplayAlert("提示", "StatusCode：" + responseString + " ", "确定");
                }
            }
            client.Dispose();
        }

        private UserObject GetUserObject()
        {
            UserObject user = new UserObject();
            user.username = UserName.Text.Trim();
            user.passwd = Utils.GetMD5(Password.Text);
            user.nickname = NickName.Text.Trim();
            user.gender = Gender.SelectedItem.Equals("男") ? "boy" : "girl";
            user.email = Email.Text.Trim();
            user.phone = phoneNum.Trim();
            user.avatar = Avatar.Text.Trim();
            user.signature = Signature.Text.Trim();
            return user;
        }

        void SendCodeBtnClicked(object sender, EventArgs e)
        {
            // 发送验证码
            VerificationCodeEntry.IsEnabled = true;
            SendCodeBtn.IsEnabled = false;
        }

        void CheckPhoneNum(object sender, EventArgs e)
        {
            phoneNum = PhoneNumEntry.Text.Trim();
            if (phoneNum.Length == 11)
            {
                SendCodeBtn.IsEnabled = true;
                VeriCodeStackLayout.IsVisible = true;
                NextBtn.IsVisible = true;
            }
            else
            {
                SendCodeBtn.IsEnabled = false;
            }
        }
    }
}