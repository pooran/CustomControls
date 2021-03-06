using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Xamarin.Forms.CustomControls.Droid
{
    using System.IO;
    using System.Threading.Tasks;
    using Android.Graphics;

    public static class ViewExtensions
    {
        public static Android.Graphics.Bitmap ToBitmap(this Android.Views.View view)
        {
            var bitmap = Bitmap.CreateBitmap(view.Width, view.Height, Bitmap.Config.Argb8888);
            using (var c = new Canvas(bitmap))
            {
                view.Draw(c);
            }

            return bitmap;
        }

        public static async Task StreamToPng(this Android.Views.View view, Stream stream)
        {
            await view.ToBitmap().CompressAsync(Bitmap.CompressFormat.Png, 100, stream);
        }
    }
}