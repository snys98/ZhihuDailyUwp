using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;
using UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding;

namespace ZhihuDaily.ApiLib
{
    internal class ApiBaseService
    {
        internal async Task<IHttpContent> Get(string url)
        {
            try
            {
                var response = (await new HttpClient().GetAsync(new Uri(url)));
                return response?.Content;
            }
            catch
            {
                Debug.WriteLine($"Get请求地址:'{url}'时失败!");
                return null;
            }
        }

        internal async Task<IHttpContent> Post(string url,string body)
        {
            try
            {
                var response = (await new HttpClient().PostAsync(new Uri(url),new HttpStringContent(body,UnicodeEncoding.Utf8, "application/json; charset=utf-8")));
                return response?.Content;
            }
            catch
            {
                Debug.WriteLine($"Post请求地址:'{url}'时失败!");
                return null;
            }
        }
    }

    internal static class HttpContentExtension
    {
        internal static async Task<string> ToHtml(this IHttpContent httpContent)
        {
            return await httpContent.ReadAsStringAsync();
        }

        internal static async Task<JsonObject> ToJsonObject(this IHttpContent httpContent)
        {
            return JsonObject.Parse(await httpContent.ReadAsStringAsync());
        }

        internal static async Task<WriteableBitmap> ToWriteableBitmap(this IHttpContent httpContent)
        {
            IBuffer buffer = await httpContent.ReadAsBufferAsync();
            if (buffer != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {

                    var stream2Write = stream.AsStreamForWrite();

                    await stream2Write.WriteAsync(buffer.ToArray(), 0, (int)buffer.Length);

                    await stream2Write.FlushAsync();
                    stream.Seek(0);

                    await bitmapImage.SetSourceAsync(stream);

                    var writeableBitmap = new WriteableBitmap(bitmapImage.PixelWidth, bitmapImage.PixelHeight);
                    stream.Seek(0);
                    await writeableBitmap.SetSourceAsync(stream);

                    return writeableBitmap;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
