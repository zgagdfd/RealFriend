namespace RealFriend.Game
{
    public class SelectableData<T>
    {
        public SelectableData()
        {
        }

        public T Data { get; set; }

        public bool IsSelected { get; set; }
    }
}