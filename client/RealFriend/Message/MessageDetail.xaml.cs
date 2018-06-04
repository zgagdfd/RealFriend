using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessageDetail : ContentPage
	{
		public MessageDetail ()
		{
			InitializeComponent ();
            messageDetailList.ItemsSource = loadData();
        }

        private List<MessageDetailData> loadData()
        {
            List<MessageDetailData> messages = new List<MessageDetailData>();
            messages.Add(new MessageDetailData("You have been our VIP member"));
            messages.Add(new MessageDetailData("the authorities ended my field of mining limestone hard labor , so I was in the prison courtyard to do something "));
            messages.Add(new MessageDetailData("is really a liberation . So I can read a book all day , write a letter "));
            messages.Add(new MessageDetailData("discuss issues with like-minded persons , or prepare some legal documents. "));
            messages.Add(new MessageDetailData("The location of the prison on Robben Island , I also use the free time to develop the two hobbies : vegetables and tennis."));
            return messages;
        }
    }

    public class MessageDetailData
    {
        public MessageDetailData(String msg)
        {
            Msg = msg;
        }

        public String Msg { get; private set; }
    }
}