using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend.Game
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PublishHelp : ContentPage
	{
        public static NavigationPage PublishPage = new NavigationPage(new GamePublish());

        public PublishHelp ()
		{
			InitializeComponent ();
		}

        async Task PublishBtnClicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(PublishPage);
        }

    }
}