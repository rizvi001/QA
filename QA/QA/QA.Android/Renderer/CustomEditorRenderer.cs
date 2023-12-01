

using System;
using Android.Content;
using QA.CustomControl;
using QA.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace QA.Droid.Renderer
{
	public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
        }
    }
}

