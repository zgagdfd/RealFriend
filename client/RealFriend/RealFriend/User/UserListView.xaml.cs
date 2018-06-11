using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListView : ContentView
    {
        public UserListView()
        {
            InitializeComponent();
            friendlistView.ItemsSource = LoadData();
        }

        private List<UserData> LoadData()
        {
            List<UserData> list = new List<UserData>();
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/user/msky/followees/";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            string statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                List<Friend> msky = JsonConvert.DeserializeObject<List<Friend>>(result);
                foreach (Friend item in msky)
                {
                    //头像链接暂时API未提供，  title不需要，api需给出发送者姓名，先暂时用type代替显示
                    String imageUrl2 = "http://image.tupian114.com/20140417/09122960.png";
                    UserData data = new UserData(item.nickname, item.avatar, imageUrl2);
                    list.Add(data);
                }
            }
            return list;
        }
    }

    public class UserData
    {

        public UserData(string nickname, String avatar, String imageUrl2)
        {

            Username = nickname;
            ImageUrl = avatar;
            ImageUrl2 = imageUrl2;
        }

        //public Color Color { private set; get; }
        public string Username { private set; get; }
        public string Desc { private set; get; }
        public String ImageUrl { get; private set; }
        public String ImageUrl2 { get; private set; }
    }
    public class Friend
    {

        public string nickname { get; set; }
        public string avatar { get; set; }
    }
}