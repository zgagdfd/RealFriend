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
	public partial class ActivityPublish : ContentPage
	{
		public ActivityPublish ()
		{
			InitializeComponent ();
            image1.Source = "https://b-ssl.duitang.com/uploads/item/201408/24/20140824213852_vuyKB.jpeg";
            image2.Source = "https://b-ssl.duitang.com/uploads/item/201408/24/20140824213852_vuyKB.jpeg";
        }
	}
}