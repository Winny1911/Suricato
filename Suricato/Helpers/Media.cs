using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Suricato.Helpers
{
    public class Media
    {
        public string BynaryToBase64Image(Stream PhotoBinary)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PhotoBinary.CopyTo(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public ImageSource Base64ToImage(string Base64Image)
        {
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(Base64Image)))
            {
                return ImageSource.FromStream(() => ms);
            }
        }
    }
}
