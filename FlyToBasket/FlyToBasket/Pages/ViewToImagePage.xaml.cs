using Plugin.ViewHelper;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlyToBasket.Pages
{
    public partial class ViewToImagePage : ContentPage
    {
        bool isCancelled;

        public ViewToImagePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            isCancelled = false;
            Task.Run(async () =>
            {
                while (!isCancelled)
                {
                    await Task.Delay(1000);
                    Device.BeginInvokeOnMainThread(() => label.Text = DateTime.Now.ToString());
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isCancelled = true;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            var imageBytes = CrossViewHelper.Current.GetImage(frame);
            image.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
    }
}