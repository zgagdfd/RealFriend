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
    public partial class PickFriend : ContentPage
    {

        public PickFriend(List<SelectableData<FriendData>> data)
        {
            InitializeComponent();
            BindingContext = new PickFriendViewModel(data);
        }


        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            ListView listView = (ListView)sender;
            listView.SelectedItem = null;
        }

        async void CancelBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            list.IsRefreshing = false;
        }
    }
}