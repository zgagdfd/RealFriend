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
        public MessageDetail(MessageData Message)
        {
            InitializeComponent();
            BindingContext = Message;
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