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
		public GameDetail ()
		{
			InitializeComponent ();
            LoadData();
		}

        private void LoadData()
        {
            GameName.Text = "Number 10";

            GameImage.Source = "icon.png";
            GameInfo.Text = "This is a good Game!" + "\n" + "enjoy it~";
            InitiatorImage.Source = "icon.png";
            InitiatorName.Text = "acmore";

            ImageSource[] sources = new ImageSource[6];
            for (int j = 0; j < 6; j++)
            {
                sources[j] = "icon.png";
            }

            Player0.Source = sources[0];
            Player1.Source = sources[1];
            Player2.Source = sources[2];
            Player3.Source = sources[3];
            Player4.Source = sources[4];
            Player5.Source = sources[5];
        }

        private void ShareGameBtnClicked() {
        }

        private void StartGameBtnClicked() {
        }
    }
}