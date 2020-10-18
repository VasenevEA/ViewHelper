using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private void AddToBasket(object sender, EventArgs e)
        {

        }
    }
}