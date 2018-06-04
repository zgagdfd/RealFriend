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
	public partial class GameListView : ContentView
	{
		public GameListView ()
		{
			InitializeComponent ();
            gameListView.ItemsSource = LoadData();
        }

        private List<GameData> LoadData()
        {
            List<GameData> list = new List<GameData>();
            for (int num = 1; num <= 100; num++)
            {
                ImageSource source = "icon.png";
                string name = String.Format("汉庭 {0} 日游", num);
                string desc = String.Format("已有 {0} 人参加", num);
                list.Add(new GameData(source, name, desc));
            }
            return list;
        }

        private void JoinGameBtnClicked() {
        }
    }

    public class GameData
    {
        public GameData(ImageSource imageSource, string name, string desc)
        {
            GameImageSource = imageSource;
            GameName = name;
            GameDesc = desc;
        }

        public ImageSource GameImageSource { private set; get; }
        public string GameName { private set; get; }
        public string GameDesc { private set; get; }
    }
}