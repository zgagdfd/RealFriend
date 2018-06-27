using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RealFriend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityMessageListView : ContentView
    {
        public ActivityMessageListView()
        {
            InitializeComponent();
            actMessageListView.ItemsSource = LoadMessageData();
            actMessageListView.ItemTapped += async (sender, args) => {
                await Navigation.PushModalAsync(new ActivityDetail());
            };
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
                    string[] avatas = {"https://ss0.bdstatic.com/70cFuHSh_Q1YnxGkpoWK1HF6hhy/it/u=4207718151,3909761681&fm=27&gp=0.jpg",
                    "https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=1327145791,1511454155&fm=27&gp=0.jpg",
                    "https://ss1.bdstatic.com/70cFuXSh_Q1YnxGkpoWK1HF6hhy/it/u=3888083289,587176764&fm=27&gp=0.jpg",
                    "https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=712305315,3942148357&fm=27&gp=0.jpg",
                    "https://ss1.bdstatic.com/70cFuXSh_Q1YnxGkpoWK1HF6hhy/it/u=2660608196,3158838601&fm=27&gp=0.jpg",
                        "https://ss2.bdstatic.com/70cFvnSh_Q1YnxGkpoWK1HF6hhy/it/u=1585403785,3541560371&fm=27&gp=0.jpg"};

                    string[] names = { "bigliam", "fushuai", "ABC", "jay", "刘昊然", "玺", "旭旭", "msky", "acmore" };
                    if(item.type == "activity"){
                        int i = new Random().Next(0, avatas.Length);
                        int j = new Random().Next(0, names.Length);
                        string avata = avatas[i];
                        string name = names[j];
                        //头像链接暂时API未提供，  title不需要，api需给出发送者姓名，先暂时用type代替显示
                        MessageData data = new MessageData(avata, name, item.content);
                        list.Add(data);
                    }

                }
            }
            return list;

        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list_tmp = (ListView)sender;
            actMessageListView.ItemsSource = LoadMessageData();
            list_tmp.IsRefreshing = false;
        }
    }
}
