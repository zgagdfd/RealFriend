using Xamarin.Forms;

namespace RealFriend.Game
{
    public class FriendData
    {
        public ImageSource Avatar { set; get; }
        public string UserName { set; get; }
        public int UserID { set; get; }

        public FriendData Clone()
        {
            return new FriendData
            {
                UserID = UserID,
                Avatar = Avatar,
                UserName = UserName,
            };
        }
    }
}
