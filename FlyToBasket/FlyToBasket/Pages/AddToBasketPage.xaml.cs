using Plugin.ViewHelper;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyToBasket.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddToBasketPage : ContentPage
    {
        public AddToBasketPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void AddToBasket(object sender, EventArgs e)
        {
            var element = (sender as Element);
            while (element.Parent != null && !(element is Frame))
                element = element.Parent;

            if (element == null)
                return;

            var frame = element as Frame;

            var framePosition = CrossViewHelper.Current.GetCoordinates(frame);
            var frameImageData = CrossViewHelper.Current.GetImage(frame);

            var basketPosition = CrossViewHelper.Current.GetCoordinates(basket);

            var image = new Image
            {
                Scale = 0.9,
                TranslationX = framePosition.X,
                TranslationY = framePosition.Y - 20,
                Source = ImageSource.FromStream(() => new MemoryStream(frameImageData))
            };

            var targetScale = 0.3;

            absoluteLayout.Children.Add(image);

            await image.TranslateTo(basketPosition.X - image.Width * targetScale, basket.Y - image.Height * targetScale);
            await image.ScaleTo(targetScale);

            absoluteLayout.Children.Remove(image);

            Counter++;
            OnPropertyChanged(nameof(Counter));
        }

        public int Counter { get; set; }
    }
}