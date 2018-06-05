using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealFriend.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePublish : ContentPage
    {
        string GameKind;
        public GamePublish()
        {
            InitializeComponent();
        }

        private async void InitGameBtnClicked(object sender, EventArgs e)
        {
            GameObject gameData = GetGameObject();
            if (!String.IsNullOrWhiteSpace(gameData.GameName))
            {
                
                // 传输数据


                await this.DisplayAlert("提示", "互动发起成功", "确定");
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                await this.DisplayAlert("提示", "请填写互动名称", "确定");
            }

        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            GameKind = (string)KindPicker.SelectedItem;
        }

        private GameObject GetGameObject()
        {
            GameObject go = new GameObject();
            go.GameName = GameNameEntry.Text;
            go.GamePass = GamePassEntry.Text.GetHashCode().ToString();
            go.GameDate = DatePicker.Date.ToString().Trim();
            go.GameTime = TimePicker.Time.ToString().Trim();
            go.GameInfo = GameInfoEntry.Text.Trim();
            go.GameKind = GameKind;
            return go;
        }
    }
}