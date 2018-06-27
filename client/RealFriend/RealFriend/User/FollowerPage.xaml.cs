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
    public partial class FollowerPage : TabbedPage
    {
        public FollowerPage()
        {
            InitializeComponent();
        }

        public static FollowerPage Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested()
            {
            }

            internal static readonly FollowerPage instance = new FollowerPage();
        }
    }
}