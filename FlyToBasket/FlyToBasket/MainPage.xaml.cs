using FlyToBasket.Pages;
using System;
using Xamarin.Forms;

namespace FlyToBasket
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToViewToImage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ViewToImagePage());
        }

        private void GoToAddToBasket(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddToBasketPage());
        }
    }
}
