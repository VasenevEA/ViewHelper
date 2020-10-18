using Xamarin.Forms;

namespace Plugin.ViewHelper
{
    public interface IViewHelper
    {
        Point GetCoordinates(VisualElement element);
        byte[] GetImage(VisualElement element);
    }
}
