using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace RealFriend.Game
{
    public class PickFriendViewModel
    {
        public List<SelectableData<FriendData>> DataList { get; set; }

        public PickFriendViewModel(List<SelectableData<FriendData>> data)
        {
            DataList = data;
        }

        public List<SelectableData<FriendData>> GetNewData()
        {
            var list = new List<SelectableData<FriendData>>();
            // 将所有的ListItem传回去，但是只显示IsSelected == true的Item
            foreach (var data in DataList)
                list.Add(new SelectableData<FriendData>()
                {
                    Data = data.Data.Clone(),
                    IsSelected = data.IsSelected
                });

            return list;
        }

        public ICommand FinishCommand
        {
            get
            {
                return new Command(async () =>
                {
                    GamePublishViewModel.SelectedData = GetNewData();
                    await PublishHelp.PublishPage.PopAsync();
                });
            }
        }
    }
}