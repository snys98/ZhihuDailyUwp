using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Data.Html;
using Windows.Web.Http;

namespace ZhihuDaily.ApiLib
{
    public class ZhihuDailyWebClient
    {
        private const string BaseUrl = "http://news-at.zhihu.com/api/4";
        /// <summary>
        /// 启动图片
        /// </summary>
        private static string _startImageUrl = $"{BaseUrl}/start-image/{0}";  //0 图片尺寸:1920*1080
        /// <summary>
        /// 主题列表
        /// </summary>
        private static string _topicsUrl = $"{BaseUrl}/themes";
        /// <summary>
        /// 首页最新文章（包含头条文章）
        /// </summary>
        private static string _latestStoriesUrl = $"{BaseUrl}/stories/latest";
        /// <summary>
        /// 首页分页文章（按日期）
        /// </summary>
        private static string _beforeStoriesUrl = $"{BaseUrl}/stories/before/{0}";  //0日期 20151209
        /// <summary>
        /// 文章内容
        /// </summary>
        private static string _storyContentUrl = $"{BaseUrl}/story/{0}";  //0 文章id
        /// <summary>
        /// 主题文章
        /// </summary>
        private static string _topicStoriesUrl = $"{BaseUrl}/theme/{0}";  //0 主题id
        /// <summary>
        /// 分页获取主题文章
        /// </summary>
        private static string _beforeThemeStoriesUrl = $"{BaseUrl}/theme/{0}/before/{1}";  //0 主题编号 1 文章id
        /// <summary>
        /// 主编详细资料
        /// </summary>
        private static string _editorProfileUrl = $"{BaseUrl}/editor/{0}/profile-page/android";  //0 主编id
        /// <summary>
        /// 文章额外信息（评论数、推荐数等）
        /// </summary>
        private static string _storyExtraUrl = $"{BaseUrl}/story-extra/{0}";  //0 文章id
        /// <summary>
        /// 文章的推荐人
        /// </summary>
        private static string _recommendersUrl = $"{BaseUrl}/story/{0}/recommenders";  //文章id
        /// <summary>
        /// 长评论
        /// </summary>
        private static string _longCommentsUrl = $"{BaseUrl}/story/{0}/long-comments";  //0 文章id
        /// <summary>
        /// 分页获取长评论
        /// </summary>
        private static string _beforeLongCommentsUrl = $"{BaseUrl}/story/{0}/long-comments/before/{1}"; //0 文章id  1 评论id
        /// <summary>
        /// 短评论
        /// </summary>
        private static string _shortCommentsUrl = $"{BaseUrl}/story/{0}/short-comments";  //0 文章id
        /// <summary>
        /// 分页获取短评论
        /// </summary>
        private static string _beforeShortCommentsUrl = $"{BaseUrl}/story/{0}/short-comments/before/{1}";  //0 文章id  1 评论id
    }
}