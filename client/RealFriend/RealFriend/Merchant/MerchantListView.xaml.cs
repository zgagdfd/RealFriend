using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MerchantListView : ContentView
	{
		public MerchantListView ()
		{
			InitializeComponent ();
            merchantListView.ItemsSource = LoadMerchantData();
        }

        private List<MerchantData> LoadMerchantData()
        {
            List<MerchantData> list = new List<MerchantData>();
            string url = "http://real.chinanorth.cloudapp.chinacloudapi.cn/merchant";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            string statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                List<Merchant> merchants_result = JsonConvert.DeserializeObject<List<Merchant>>(result);
                foreach (Merchant item in merchants_result)
                {
                    string image_url = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE1Mu3b?ver=5c31";
                    Random random = new Random();
                    int OrderQty = random.Next(500);
                    double Grade = random.NextDouble() * 5;
                    int AvgConsumption = random.Next(15, 200);
                    String Contact = "18141912818";
                    //String Location = "北大东南门对面计算机研究所大楼2层";
                    string location = item.info;
                    string merchant_name = item.name;

                    MerchantData data = new MerchantData(image_url, merchant_name, OrderQty, Grade, AvgConsumption, Contact, location);
                }
            }





            return list;




            //StringBuilder stringBuilder = new StringBuilder();
            //foreach (FieldInfo info in typeof(Color).GetRuntimeFields())
            //{
            //    if (info.IsPublic && info.IsStatic && info.FieldType == typeof(Color))
            //    {
            //        string name = info.Name;
            //        stringBuilder.Clear();
            //        int index = 0;
            //        foreach (char c in name)
            //        {
            //            if (index != 0 && Char.IsUpper(c))
            //            {
            //                stringBuilder.Append(' ');
            //            }
            //            stringBuilder.Append(c);
            //            ++index;
            //        }
            //        string url = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE1Mu3b?ver=5c31";
            //        Random random = new Random();
            //        int OrderQty = random.Next(500);
            //        double Grade = random.NextDouble() * 5;
            //        int AvgConsumption = random.Next(15, 200);
            //        String Contact = "18141912818";
            //        String Location = "北大东南门对面计算机研究所大楼2层";
            //        MerchantData data = new MerchantData(url, name, OrderQty, Grade, AvgConsumption, Contact, Location);
            //        list.Add(data);
            //    }
            //}
            //return list;
        }
    }

    public class MerchantData
    {
        public MerchantData(String imageUrl, String brandName, int orderQty, double grade, int avgConsumption, String contact, String location)
        {
            ImageUrl = imageUrl;
            BrandName = brandName;
            OrderQty = orderQty;
            Grade = grade;
            AvgConsumption = avgConsumption;
            Contact = contact;
            Location = location;
        }
        public String ImageUrl { get; private set; }
        public String BrandName { get; private set; }
        public int OrderQty { get; private set; }
        public double Grade { get; private set; }
        public int AvgConsumption { get; private set; }
        public String Contact { get; private set; }
        public String Location { get; private set; }
    }

    public class Merchant{
        public string name { get; set; }
        public string image { get; set; }
        public string info { get; set; }
        public string introduction { get; set; }
        public int id { get; set; }
    }


}