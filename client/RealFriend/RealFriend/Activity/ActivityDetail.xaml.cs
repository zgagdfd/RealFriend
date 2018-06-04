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
	public partial class ActivityDetail : ContentPage
	{
		public ActivityDetail ()
		{
			InitializeComponent ();
            topImg.Source = "https://b-ssl.duitang.com/uploads/item/201509/24/20150924095457_meNQG.jpeg";
            topTitle.Text = "优秀的小哥哥请大家吃饭啦";
            topTime.Text = "2018.3.25 12:30 -- 2018.3.25 20:20";

            initiatorImg.Source = "https://b-ssl.duitang.com/uploads/item/201408/24/20140824213852_vuyKB.jpeg";
            personName.Text = "Little Longlong";

            person1.Source = "https://b-ssl.duitang.com/uploads/item/201408/24/20140824213852_vuyKB.jpeg";
            person2.Source = "https://b-ssl.duitang.com/uploads/item/201408/24/20140824213852_vuyKB.jpeg";
            person3.Source = "https://b-ssl.duitang.com/uploads/item/201408/24/20140824213852_vuyKB.jpeg";
            person4.Source = "https://b-ssl.duitang.com/uploads/item/201408/24/20140824213852_vuyKB.jpeg";

            activityDesc.Text = "由于小锅锅心情好，所以请大家吃饭";
            view1.Source = "https://b-ssl.duitang.com/uploads/item/201509/24/20150924095457_meNQG.jpeg";
            view2.Source = "https://b-ssl.duitang.com/uploads/item/201509/24/20150924095457_meNQG.jpeg";

            location.Text = "大兴工业区";
            store.Text = "海底捞（大兴技术学院店）";

            comment1.Text = "我同意";
            comment2.Text = "我同意";
            comment3.Text = "我同意";
        }
	}
}