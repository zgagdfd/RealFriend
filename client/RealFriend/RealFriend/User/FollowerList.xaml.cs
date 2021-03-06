﻿using System;
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
    public partial class FollowerList : ContentView
    {
        public FollowerList()
        {
            InitializeComponent();
            followerList.ItemsSource = LoadData();
        }

        private List<FolloweeData> LoadData()
        {
            List<FolloweeData> list = new List<FolloweeData>();
            string url = "http://real.eastasia.cloudapp.azure.com/user/msky/followers/";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            string statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                List<Followee> msky = JsonConvert.DeserializeObject<List<Followee>>(result);
                foreach (Followee item in msky)
                {
                    //头像链接暂时API未提供，  title不需要，api需给出发送者姓名，先暂时用type代替显示
                    String imageUrl2 = "http://image.tupian114.com/20140417/09122960.png";
                    FolloweeData data = new FolloweeData(item.nickname, item.avatar, item.signature, imageUrl2);
                    list.Add(data);
                }
            }
            return list;
        }
    }

    public class FollowerData
    {

        public FollowerData(string nickname, String avatar, String signature, String imageUrl2)
        {

            Username = nickname;
            ImageUrl = avatar;
            Signature = signature;
            ImageUrl2 = imageUrl2;
        }

        //public Color Color { private set; get; }
        public string Username { private set; get; }
        public string Desc { private set; get; }
        public string Signature { private set; get; }
        public String ImageUrl { get; private set; }
        public String ImageUrl2 { get; private set; }
    }
    public class Follower
    {

        public string nickname { get; set; }
        public string avatar { get; set; }
        public string signature { get; set; }
    }
}