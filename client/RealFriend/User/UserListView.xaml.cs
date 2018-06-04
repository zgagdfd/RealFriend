using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserListView : ContentView
	{
		public UserListView()
		{
			InitializeComponent ();
            friendlistView.ItemsSource = LoadData();
        }

        private List<UserData> LoadData()
        {
            List<UserData> list = new List<UserData>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (FieldInfo info in typeof(Color).GetRuntimeFields())
            {
                if (info.IsPublic && info.IsStatic && info.FieldType == typeof(Color))
                {
                    string name = info.Name;
                    stringBuilder.Clear();
                    int index = 0;
                    foreach (char c in name)
                    {
                        if (index != 0 && Char.IsUpper(c))
                        {
                            stringBuilder.Append(' ');
                        }
                        stringBuilder.Append(c);
                        ++index;
                    }
                    string url = "http://imgsrc.baidu.com/forum/w=580/sign=1588b7c5d739b6004dce0fbfd9503526/7bec54e736d12f2eb97e1a464dc2d56285356898.jpg";
                    string url2 = "http://pic.58pic.com/58pic/14/36/21/28q58PICAiI_1024.png";
                    // color = (Color) info.GetValue(null);
                    UserData data = new UserData(name, stringBuilder.ToString(), url, url2);

                    list.Add(data);
                }
            }
            return list;
        }
    }

    public class UserData
    {

        public UserData(string name, string desc, String imageUrl, String imageUrl2)
        {
            Name = name;
            Desc = desc;
            ImageUrl = imageUrl;
            ImageUrl2 = imageUrl2;
        }

        //public Color Color { private set; get; }
        public string Name { private set; get; }
        public string Desc { private set; get; }
        public String ImageUrl { get; private set; }
        public String ImageUrl2 { get; private set; }
    }
}