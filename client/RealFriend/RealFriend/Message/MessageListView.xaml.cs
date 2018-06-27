using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageListView : ContentView
    {
        
        public MessageListView()
        {
            InitializeComponent();
            messageListView.ItemsSource = LoadMessageData();
                           
        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            ListView listView = (ListView)sender;
            listView.SelectedItem = null;
            MessageData messageData = (MessageData)e.SelectedItem;
            NavigationPage messageDetail = new NavigationPage(new MessageDetail(messageData));
            // gameDetail.BindingContext = gameData;
            await Navigation.PushModalAsync(messageDetail);
        }



        private List<MessageData> LoadMessageData()
        {
            List<MessageData> list = new List<MessageData>();
            string url = "http://real.eastasia.cloudapp.azure.com/message";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            string statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                List<message> test_message = JsonConvert.DeserializeObject<List<message>>(result);
                foreach (message item in test_message)
                {
                    if(item.type == "system"){
                        //头像链接暂时API未提供，  title不需要，api需给出发送者姓名，先暂时用type代替显示
                        String imageUrl = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE1Mu3b?ver=5c31";
                        MessageData data = new MessageData(imageUrl, "系统消息", item.content);
                        list.Add(data);
                    }

                }
            }
            return list;

        }
        void OnRefresh(object sender, EventArgs e)
        {
            var list_tmp = (ListView)sender;
            messageListView.ItemsSource = LoadMessageData();
            list_tmp.IsRefreshing = false;
        }
    }

    public class MessageData
    {
        public MessageData(String imageUrl, string name, string desc)
        {
            ImageUrl = imageUrl;
            Name = name;
            Desc = desc;
            Time = DateTime.Now.ToString("HH:mm");
        }

        public String ImageUrl { private set; get; }
        public string Name { private set; get; }
        public string Desc { private set; get; }
        public string Time { private set; get; }
    }


    public class message
    {
        public string content { get; set; }
        public string create_time { get; set; }
        public string type { get; set; }
    }


}