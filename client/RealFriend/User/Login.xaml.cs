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
	public partial class Login : ContentPage
	{
        string Acc { get; set; }
        string Pwd { get; set; }

        public Login ()
		{
			InitializeComponent ();
		}

        // 检查输入框是否为空
        void CheckEmpty(object sender, EventArgs e)
        {
            Acc = AccountEntry.Text;
            Pwd = PasswordEntry.Text;
            if (!string.IsNullOrWhiteSpace(Acc) && !string.IsNullOrWhiteSpace(Pwd))
            {
                LoginBtn.IsEnabled = true;
            }
            else
            {
                LoginBtn.IsEnabled = false;
            }
        }

        private void LoginBtnClicked(object sender, EventArgs e)
        {
            CheckPass(Acc, Pwd);
        }

        // 校验账号密码
        async void CheckPass(string account, string pwd)
        {
            if (account.Equals("123") && pwd.Equals("123"))
            {
                // 跳转至主页
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                await this.DisplayAlert("提示", "账号或密码错误，请重新输入", "确定");
            }

        }

        // 创建账户
        async void RegisterBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Register());
        }

        // 忘记密码
        async void ForgetPwdBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgetPassword());
        }
    }
}