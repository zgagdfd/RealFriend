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
	public partial class MessageListView : ContentView
	{
		public MessageListView ()
		{
			InitializeComponent ();
            messageListView.ItemsSource = LoadMessageData();
        }

        private List<MessageData> LoadMessageData()
        {
            List<MessageData> list = new List<MessageData>();
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
                    String imageUrl = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE1Mu3b?ver=5c31";
                    MessageData data = new MessageData(imageUrl, name, stringBuilder.ToString());
                    list.Add(data);
                }
            }
            return list;
        }
    }

    public class MessageData
    {

        public MessageData(String imageUrl, string name, string desc)
        {
            ImageUrl = imageUrl;
            Name = name;
            Desc = desc + "when reports came into London Zoo that a wild puma had been spotted 45 miles away from London...";
            Time = DateTime.Now.ToString("HH:mm");
        }

        public String ImageUrl { private set; get; }
        public string Name { private set; get; }
        public string Desc { private set; get; }
        public string Time { private set; get; }
    }
}