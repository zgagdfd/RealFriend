using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RealFriend.Game
{
    class Images
    {
        static Dictionary<string, ImageSource> imgs;

        public Images()
        {
            imgs = LoadPics();
        }

        public ImageSource GetImage(string gameName)
        {
            return imgs.ContainsKey(gameName) ? imgs[gameName] : "splash.png";
        }

        private Dictionary<string, ImageSource> LoadPics()
        {
            Dictionary<string, ImageSource> images = new Dictionary<string, ImageSource>();
            images.Add("英雄联盟", "https://tse4.mm.bing.net/th?id=OIP.CF1ysSo0kHxuo9IkHSeZ7wHaEK&pid=Api");
            images.Add("绝地求生", "http://img.pc841.com/2017/1214/20171214041640258.jpg");
            images.Add("CSGO", "https://tse2.mm.bing.net/th?id=OIP.NTe-QoERwfRhOqsOuP-2WgHaEo&pid=Api");
            images.Add("守望先锋", "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1529420371725&di=d6beec873672a6215da34b06e5fcb65b&imgtype=0&src=http%3A%2F%2Fi1.17173cdn.com%2F2fhnvk%2FYWxqaGBf%2Fcms3%2FzbUidobllhzszii.png");
            images.Add("穿越火线", "http://pic5.duowan.com/cf/0804/73491512854/73491640051.jpg");
            images.Add("王者荣耀", "http://pic.pc6.com/up/2017-8/201781520643343975609540.jpg");
            images.Add("DOTA2", "https://tse3.mm.bing.net/th?id=OIP.Yc2efIcIT9TwIywHEgr0GAHaEo&pid=Api");
            images.Add("狼人杀", "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1529420308299&di=af5d3ad90c72bab82c2dd44d7a949c56&imgtype=0&src=http%3A%2F%2Fpic.uzzf.com%2Fup%2F2017-10%2F201710031217459690016.png");
            images.Add("QQ飞车", "http://speed.tgbus.com/UploadFiles_9381/201203/2012031310290995.jpg");
            images.Add("QQ炫舞", "http://img3.cache.netease.com/photo/0031/2011-02-11/6SK2QS2V0RBT0031.jpg");
            images.Add("阴阳师", "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1529420577936&di=ed4063eb4d36c7a70d764e5edd3b7907&imgtype=0&src=http%3A%2F%2Fimg.zcool.cn%2Fcommunity%2F01fc8957ea7bff0000012e7ef7e29e.jpg");
            images.Add("拳皇", "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1529420746031&di=c9e9ce244ec4c2fc820ae9f6bd85b2d5&imgtype=0&src=http%3A%2F%2Fi0.hdslb.com%2Fbfs%2Farchive%2F47460db25623684ea263067178834b64d03df378.jpg");
            images.Add("梦幻西游", "http://a3.att.hudong.com/32/29/01200000033865115812986243232.jpg");
            images.Add("使命召唤", "http://i3.img.969g.com/news/imgx2014/01/17/264_134813_b039b_lit.jpg");
            return images;
        }
    }
}
