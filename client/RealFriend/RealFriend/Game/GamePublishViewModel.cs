using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace RealFriend.Game
{
    class GamePublishViewModel : BaseViewModel
    {
        // 所有的ListItem
        public static List<SelectableData<FriendData>> SelectedData { get; set; }

        // 要显示的ListItem（IsSelected == true）
        public List<SelectableData<FriendData>> DataSource { get; set; }

        public GamePublishViewModel()
        {
            SelectedData = new List<SelectableData<FriendData>>();
            // 朋友列表
            for (int i = 1; i < 21; i++)
            {
                SelectableData<FriendData> data = new SelectableData<FriendData>
                {
                    Data = new FriendData
                    {
                        Avatar = "icon.png",
                        UserID = "" + i,
                        UserName = "Friend" + i
                    }
                };
                SelectedData.Add(data);
            }
        }

        public void OnAppearing()
        {
            // 只显示IsSelected == true的Item
            DataSource = SelectedData.Where(x => x.IsSelected).ToList();
            OnPropertyChanged(nameof(DataSource));
        }

        public ICommand SelectCommand
        {
            get
            {
                return new Command(() =>
                {
                    PublishHelp.PublishPage.PushAsync(new PickFriend(SelectedData));
                });
            }

        }
    }
}