using Android.Content;
using Android.Service.Controls;
using QA.CustomControl;
using QA.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Entry = Android.OS.DropBoxManager.Entry;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace QA.Droid.Renderer
{
	public class CustomEntryRenderer : EntryRenderer
	{
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
              
            }
        }
    }
}

