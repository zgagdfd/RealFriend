using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RealFriend.User
{
    class UserAvatars
    {
        static List<string> avatars;

        public UserAvatars()
        {
            avatars = LoadPics();
        }

        public string GetAvatar()
        {
            Random random = new Random();
            return avatars[random.Next(avatars.Count)];
        }

        List<string> LoadPics()
        {
            List<string> list = new List<string>();
            list.Add("https://ss0.bdstatic.com/70cFuHSh_Q1YnxGkpoWK1HF6hhy/it/u=4207718151,3909761681&fm=27&gp=0.jpg");
            list.Add("https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=1327145791,1511454155&fm=27&gp=0.jpg");
            list.Add("https://ss1.bdstatic.com/70cFuXSh_Q1YnxGkpoWK1HF6hhy/it/u=3888083289,587176764&fm=27&gp=0.jpg");
            list.Add("https://ss0.bdstatic.com/70cFvHSh_Q1YnxGkpoWK1HF6hhy/it/u=712305315,3942148357&fm=27&gp=0.jpg");
            list.Add("https://ss1.bdstatic.com/70cFuXSh_Q1YnxGkpoWK1HF6hhy/it/u=2660608196,3158838601&fm=27&gp=0.jpg");
            list.Add("https://ss2.bdstatic.com/70cFvnSh_Q1YnxGkpoWK1HF6hhy/it/u=1585403785,3541560371&fm=27&gp=0.jpg");
            list.Add("http://img3.duitang.com/uploads/item/201504/12/20150412H4917_Shzmx.thumb.700_0.jpeg");
            list.Add("http://www.wangmingdaquan.cc/tx36/64.jpg");
            list.Add("http://img4q.duitang.com/uploads/item/201504/12/20150412H1510_mvEzA.thumb.224_0.jpeg");
            list.Add("http://www.wndhw.com/fengjing/touxiang/images/tx002t4.jpg");

            return list;
        }
    }
}
