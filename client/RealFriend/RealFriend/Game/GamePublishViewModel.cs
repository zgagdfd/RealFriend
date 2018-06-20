using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
            GetUsersAsync();
            System.Threading.Thread.Sleep(1000);
        }

        private async Task GetUsersAsync()
        {
            SelectedData = new List<SelectableData<FriendData>>();
            // 获得user列表
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/user";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                List<UserObject> userObjects = JsonConvert.DeserializeObject<List<UserObject>>(content);
                foreach (var user in userObjects)
                {
                    SelectableData<FriendData> data = new SelectableData<FriendData>
                    {
                        Data = new FriendData
                        {
                            Avatar = user.avatar,
                            UserID = user.id,
                            UserName = user.username
                        }
                    };
                    SelectedData.Add(data);
                }
            }
            else
            {
                Console.Out.WriteLine("请求失败~~~~~~~" + content);
                // await DisplayAlert("提示", "StatusCode：" + content + " ", "确定");
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