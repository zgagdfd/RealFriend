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
    public partial class GameDetail : ContentPage
    {
        public GameDetail()
        {
            InitializeComponent();
            // BindingContext = gameData;
        }

        private async Task ShareGameBtnClicked(Object sender, EventArgs e)
        {
            //分享
            await DisplayAlert("提示", "敬请期待~~", "确定");
        }

        private async Task JoinGameBtnClicked(Object sender, EventArgs e)
        {
            await DisplayAlert("提示", "您已成功加入~~", "确定");

        }

    }
}