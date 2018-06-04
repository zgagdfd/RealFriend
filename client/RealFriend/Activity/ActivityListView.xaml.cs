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
	public partial class ActivityListView : ContentView
	{
		public ActivityListView ()
		{
			InitializeComponent ();
            activityListView.ItemsSource = LoadData();
        }

        private List<ActivityData> LoadData()
        {
            List<ActivityData> activity_list = new List<ActivityData>();
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
                    Color color = (Color)info.GetValue(null);
                    ActivityData activityData = new ActivityData(color, name, stringBuilder.ToString(), stringBuilder.ToString());
                    activity_list.Add(activityData);
                }
            }
            return activity_list;
        }

        public class ActivityData
        {
            public ActivityData(Color color, string name, string content, string time)
            {
                Color = color;
                Name = name;
                Content = content;
                Time = time;
            }

            public Color Color { private set; get; }
            public string Name { private set; get; }
            public string Content { private set; get; }
            public string Time { private set; get; }

        }
    }
}