using Microsoft.Win32;
using System.Diagnostics;
using System.Linq;

namespace FindWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            var registryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop");
            var value = registryKey.GetValue("TranscodedImageCache");

            if (value is byte[] cache)
            {
                var bytes = cache.Skip(24).Where(c => c > 0).ToArray();
                var path = System.Text.Encoding.ASCII.GetString(bytes);

                Process.Start("explorer.exe", $"/select,{path}");
            }
        }
    }
}
