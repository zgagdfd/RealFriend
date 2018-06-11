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
	public partial class TabbedView : ContentView
	{
        public TabbedView()
        {
            InitializeComponent();
            HomePageBtn.Clicked += async (sender, args) => {
                await Navigation.PushModalAsync(new HomePage());
            };
            FriendPageBtn.Clicked += async (sender, args) => {
                await Navigation.PushModalAsync(new FriendPage());
            };
            MessagePageBtn.Clicked += async (sender, args) => {
                await Navigation.PushModalAsync(new MessagePage());
            };
            UserPageBtn.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new UserDetail());
            };
        }
	}
}