using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Data.Html;
using Windows.Data.Json;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;
using ZhihuDailyUwp.Models;

namespace ZhihuDaily.ApiLib
{
    public class ZhihuDailyApiClient
    {
        public StorageFolder ImgCacheFolder
            =>
                ApplicationData.Current.LocalFolder.CreateFolderAsync("image_cache",
                    CreationCollisionOption.OpenIfExists).GetResults();
        public StorageFolder DataCacheFolder
            =>
                ApplicationData.Current.LocalFolder.CreateFolderAsync("data_cache",
                    CreationCollisionOption.OpenIfExists).GetResults();
        private const string BaseUrl = "http://news-at.zhihu.com/api/4";

        /// <summary>
        /// 启动图片
        /// </summary>
        internal static string _startImageUrl = $"{BaseUrl}/start-image/{{0}}"; //0 图片尺寸:1920*1080

        /// <summary>
        /// 主题列表
        /// </summary>
        internal static string _themesUrl = $"{BaseUrl}/themes";

        /// <summary>
        /// 首页最新文章（包含头条文章）
        /// </summary>
        internal static string _latestStoriesUrl = $"{BaseUrl}/stories/latest";

        /// <summary>
        /// 首页分页文章（按日期）
        /// </summary>
        internal static string _beforeStoriesUrl = $"{BaseUrl}/stories/before/{{0}}"; //0日期 20151209

        /// <summary>
        /// 文章内容
        /// </summary>
        internal static string _storyContentUrl = $"{BaseUrl}/story/{{0}}"; //0 文章id

        /// <summary>
        /// 主题文章
        /// </summary>
        internal static string _topicStoriesUrl = $"{BaseUrl}/theme/{{0}}"; //0 主题id

        /// <summary>
        /// 分页获取主题文章
        /// </summary>
        internal static string _beforeThemeStoriesUrl = $"{BaseUrl}/theme/{{0}}/before/{{1}}"; //0 主题编号 1 文章id

        /// <summary>
        /// 主编详细资料
        /// </summary>
        internal static string _editorProfileUrl = $"{BaseUrl}/editor/{{0}}/profile-page/android"; //0 主编id

        /// <summary>
        /// 文章额外信息（评论数、推荐数等）
        /// </summary>
        internal static string _storyExtraUrl = $"{BaseUrl}/story-extra/{{0}}"; //0 文章id

        /// <summary>
        /// 文章的推荐人
        /// </summary>
        internal static string _recommendersUrl = $"{BaseUrl}/story/{{0}}/recommenders"; //文章id

        /// <summary>
        /// 长评论
        /// </summary>
        internal static string _longCommentsUrl = $"{BaseUrl}/story/{{0}}/long-comments"; //0 文章id

        /// <summary>
        /// 分页获取长评论
        /// </summary>
        internal static string _beforeLongCommentsUrl = $"{BaseUrl}/story/{{0}}/long-comments/before/{{1}}";
            //0 文章id  1 评论id

        /// <summary>
        /// 短评论
        /// </summary>
        internal static string _shortCommentsUrl = $"{BaseUrl}/story/{{0}}/short-comments"; //0 文章id

        /// <summary>
        /// 分页获取短评论
        /// </summary>
        internal static string _beforeShortCommentsUrl = $"{BaseUrl}/story/{{0}}/short-comments/before/{{1}}"; //0 文章id  1 评论id 

        /// <summary>
        /// 异步获取启动闪屏图片
        /// </summary>
        /// <param name="first">屏幕分辨率的第一个,例如1920</param>
        /// <param name="second">屏幕分辨率的第二个,例如1080</param>
        /// <returns></returns>
        public async Task<StartImage> GetStartImageAsync(int first = 1920,int second = 1080)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(String.Format(_startImageUrl, $"{first}*{second}"));
                var startImage = await httpContent.ToObject<StartImage>();
                return startImage;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取话题列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Theme>> GetThemesAsync()
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(_themesUrl);
                var themes = await httpContent.ToObject<List<Theme>>();
                return themes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取首页最新文章（包含头条文章）
        /// </summary>
        /// <returns></returns>
        public async Task<LatestStories> GetLatestStoriesAsync()
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(_latestStoriesUrl);
                var latestStories = await httpContent.ToObject<LatestStories>();
                return latestStories;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 根据指定日期获取当日文章列表
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        public async Task<List<Story>> GetBeforeStoriesAsync(DateTime targetDate)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_beforeStoriesUrl, targetDate.ToString("yyyyMMdd")));
                var stories = await httpContent.ToObject<List<Story>>();
                return stories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StoryContent> GetStoryContentAsync(int storyId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_storyContentUrl, storyId));
                var storyContent = await httpContent.ToObject<StoryContent>();
                return storyContent;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}