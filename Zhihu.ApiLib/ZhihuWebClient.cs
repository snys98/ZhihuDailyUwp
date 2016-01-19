using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Data.Html;
using Windows.Web.Http;

namespace Zhihu.ApiLib
{
    public class ZhihuWebClient
    {
        public readonly string BaseUri = "http://www.zhihu.com";

        private string GetCsrfCode()
        {
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetAsync(new Uri(BaseUri));
            return HtmlFormatHelper.CreateHtmlFormat(result.GetResults().Content.ReadAsStringAsync().GetResults());
        }
        private string GetCaptcha()
        {
            throw new NotImplementedException();
        }

        public void Login()
        {
            GetCsrfCode();
            GetCaptcha();
        }
    }
}
