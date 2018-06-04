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
    public partial class MessagePage : TabbedPage
    {
        public MessagePage() {
            InitializeComponent();
        }

        public static MessagePage Instance {
            get {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested()
            {
            }

            internal static readonly MessagePage instance = new MessagePage();
        }
    }
}