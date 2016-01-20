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
        private static string _baseUrl = "http://news-at.zhihu.com/api/4";
        /// <summary>
        /// 启动图片
        /// </summary>
        private static string _startImageUrl = $"{_baseUrl}/start-image/{0}";  //0 图片尺寸:1920*1080
        /// <summary>
        /// 主题列表
        /// </summary>
        private static string _topicsUrl = $"{_baseUrl}/themes";
        /// <summary>
        /// 首页最新文章（包含头条文章）
        /// </summary>
        private static string _latestStoriesUrl = $"{_baseUrl}/stories/latest";
        /// <summary>
        /// 首页分页文章（按日期）
        /// </summary>
        private static string _pastStoriesUrl = $"{_baseUrl}/stories/before/{0}";  //0日期 20151209
        /// <summary>
        /// 文章内容
        /// </summary>
        private static string _StoryContent = $"{_baseUrl}/story/{0}";  //0 文章id
        /// <summary>
        /// 主题文章
        /// </summary>
        private static string _topicStories = $"{_baseUrl}/theme/{0}";  //0 主题id
        /// <summary>
        /// 分页获取主题文章
        /// </summary>
        private static string BeforeThemeStories = $"{_baseUrl}/theme/{0}/before/{1}";  //0 主题编号 1 文章id
        /// <summary>
        /// 主编详细资料
        /// </summary>
        private static string EditorProfile = $"{_baseUrl}/editor/{0}/profile-page/android";  //0 主编id
        /// <summary>
        /// 文章额外信息（评论数、推荐数等）
        /// </summary>
        private static string StoryExtra = $"{_baseUrl}/story-extra/{0}";  //0 文章id
        /// <summary>
        /// 文章的推荐人
        /// </summary>
        private static string Recommenders = $"{_baseUrl}/story/{0}/recommenders";  //文章id
        /// <summary>
        /// 长评论
        /// </summary>
        private static string LongComments = $"{_baseUrl}/story/{0}/long-comments";  //0 文章id
        /// <summary>
        /// 分页获取长评论
        /// </summary>
        private static string BeforeLongComments = $"{_baseUrl}/story/{0}/long-comments/before/{1}"; //0 文章id  1 评论id
        /// <summary>
        /// 短评论
        /// </summary>
        private static string ShortComments = $"{_baseUrl}/story/{0}/short-comments";  //0 文章id
        /// <summary>
        /// 分页获取短评论
        /// </summary>
        private static string BeforeShortComments = $"{_baseUrl}/story/{0}/short-comments/before/{1}";  //0 文章id  1 评论id
        /// <summary>
        /// ??
        /// </summary>
        private static string Quotation = "http://files.cnblogs.com/files/xiaozhi_5638/ZhihuDaily_Quotation.zip";

    }
}
