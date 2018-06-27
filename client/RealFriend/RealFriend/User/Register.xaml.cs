using Newtonsoft.Json;
using RealFriend.User;
using System;
using System.Net.Http;
using System.Text;

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
            BackgroundImage = "login_bac.jpg";
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
            if (String.IsNullOrEmpty(userData.username))
            {
                await DisplayAlert("提示", "用户名不能为空", "确定");
                return;
            }
            string url = "http://real.eastasia.cloudapp.azure.com/user/";
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
                    await Navigation.PushModalAsync(new Login());
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
            user.username = UserName.Text;
            user.passwd = Utils.GetMD5(Password.Text);
            user.nickname = NickName.Text;
            user.gender = Gender.SelectedItem.Equals("男") ? "boy" : "girl";
            user.email = Email.Text;
            user.phone = phoneNum;
            if (String.IsNullOrEmpty(Avatar.Text))
            {
                UserAvatars avatars = new UserAvatars();
                user.avatar = avatars.GetAvatar();
            }
            else
                user.avatar = Avatar.Text;
            user.signature = Signature.Text;
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