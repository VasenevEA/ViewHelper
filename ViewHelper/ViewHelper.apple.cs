using Foundation;
using System;
using UIKit;
using Xamarin.Forms;
namespace Plugin.ViewHelper
{
    /// <summary>
    /// Interface for ViewHelper
    /// </summary>
    public class ViewHelperImplementation : IViewHelper
    {
        public Point GetCoordinates(VisualElement element)
        {
            var renderer = Xamarin.Forms.Platform.iOS.Platform.GetRenderer(element);
            var nativeView = renderer.NativeView;
            var rect = nativeView.Superview.ConvertPointToView(nativeView.Frame.Location, null);
            return new Point((int)Math.Round(rect.X), (int)Math.Round(rect.Y));
        }

        public byte[] GetImage(VisualElement element)
        {
            var renderer = Xamarin.Forms.Platform.iOS.Platform.GetRenderer(element);
            var nativeView = renderer.NativeView;
            var img = ImageFromView(nativeView);

            using (NSData imageData = img.AsPNG())
            {
                var myByteArray = new byte[imageData.Length];
                System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myByteArray, 0, Convert.ToInt32(imageData.Length));
                return myByteArray;
            }
        }

        private UIImage ImageFromView(UIView view)
        {
            UIGraphics.BeginImageContextWithOptions(view.Bounds.Size, true, 0);
            view.Layer.RenderInContext(UIGraphics.GetCurrentContext());
            var img = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return img;
        }
    }
}
