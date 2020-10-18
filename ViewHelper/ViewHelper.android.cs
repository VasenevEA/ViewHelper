using Android.Graphics;
using System.IO;
using Xamarin.Forms;

namespace Plugin.ViewHelper
{
    /// <summary>
    /// Interface for ViewHelper
    /// </summary>
    public class ViewHelperImplementation : IViewHelper
    {
        public Xamarin.Forms.Point GetCoordinates(VisualElement element)
        {
            var renderer = Xamarin.Forms.Platform.Android.Platform.GetRenderer(element);
            var nativeView = renderer.View;
            var location = new int[2];
            var density = nativeView.Context.Resources.DisplayMetrics.Density;

            nativeView.GetLocationOnScreen(location);
            return new Xamarin.Forms.Point(location[0] / density, location[1] / density);
        }

        public byte[] GetImage(VisualElement element)
        {
            var renderer = Xamarin.Forms.Platform.Android.Platform.GetRenderer(element);
            var nativeView = renderer.View;
            var Image = GetBitmapFromView(nativeView);

            using (var stream = new MemoryStream())
            {
                Image.Compress(Bitmap.CompressFormat.Png, 0, stream);
                return stream.ToArray();
            }
        }

        public Bitmap GetBitmapFromView(Android.Views.View view)
        {
            Bitmap bitmap = Bitmap.CreateBitmap(view.Width, view.Height, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bitmap);
            view.Draw(canvas);
            return bitmap;
        }
    }
}
