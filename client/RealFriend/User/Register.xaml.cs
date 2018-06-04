using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
        string verificationCode;
        string phoneNum;

        public Register ()
		{
			InitializeComponent ();
		}

        async void CancelRegisterBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void RegisterBtnClicked(object sender, EventArgs e)
        {
            // 验证码校验
            if (verificationCode.Equals("1234"))
            {
                await DisplayAlert("提示", "恭喜您注册成功", "确定");
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("提示", "验证码输入错误, 请重新输入", "确定");
            }
        }

        void SendCodeBtnClicked(object sender, EventArgs e)
        {
            // 发送验证码
            VerificationCodeEntry.IsEnabled = true;
            SendCodeBtn.IsEnabled = false;
            SendCodeBtn.Text = "30s倒计时";
        }

        bool isPhoneNumCorrect = false;
        void CheckPhoneNum(object sender, EventArgs e)
        {
            phoneNum = PhoneNumEntry.Text;
            if (phoneNum.Length == 11)
            {
                SendCodeBtn.IsEnabled = true;
                isPhoneNumCorrect = true;
                VeriCodeStackLayout.IsVisible = true;
                RegisterBtn.IsVisible = true;
            }
            else
            {
                SendCodeBtn.IsEnabled = false;
                isPhoneNumCorrect = false;
            }
        }

        void CheckVeriCode(object sender, EventArgs e)
        {
            verificationCode = VerificationCodeEntry.Text;
            if (isPhoneNumCorrect && verificationCode.Length == 4)
            {
                RegisterBtn.IsEnabled = true;
            }
            else
                RegisterBtn.IsEnabled = false;
        }
    }
}