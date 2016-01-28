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
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;
using ZhihuDaily.ApiLib.Models;

namespace ZhihuDaily.ApiLib
{
    public class ZhihuDailyApiClient
    {
        private const string BaseUrl = "http://news-at.zhihu.com/api/4";

        /// <summary>
        /// 启动图片
        /// </summary>
        private static string _startImageUrl = $"{BaseUrl}/start-image/{{0}}"; //0 图片尺寸:1920*1080

        /// <summary>
        /// 主题列表
        /// </summary>
        private static string _themesUrl = $"{BaseUrl}/themes";

        /// <summary>
        /// 首页最新文章（包含头条文章）
        /// </summary>
        private static string _latestStoriesUrl = $"{BaseUrl}/stories/latest";

        /// <summary>
        /// 首页分页文章（按日期）
        /// </summary>
        private static string _beforeStoriesUrl = $"{BaseUrl}/stories/before/{{0}}"; //0日期 20151209

        /// <summary>
        /// 文章内容
        /// </summary>
        private static string _storyUrl = $"{BaseUrl}/story/{{0}}"; //0 文章id

        /// <summary>
        /// 主题文章
        /// </summary>
        private static string _themeUrl = $"{BaseUrl}/theme/{{0}}"; //0 主题id

        /// <summary>
        /// 根据id获取主题文章
        /// </summary>
        private static string _beforeThemeStoriesUrl = $"{BaseUrl}/theme/{{0}}/before/{{1}}"; //0 主题编号 1 文章id

        /// <summary>
        /// 主编详细资料
        /// </summary>
        private static string _editorProfileUrl = $"{BaseUrl}/editor/{{0}}/profile-page/android"; //0 主编id

        /// <summary>
        /// 文章额外信息（评论数、推荐数等）
        /// </summary>
        private static string _storyExtraUrl = $"{BaseUrl}/story-extra/{{0}}"; //0 文章id

        /// <summary>
        /// 文章的推荐人
        /// </summary>
        private static string _recommendersUrl = $"{BaseUrl}/story/{{0}}/recommenders"; //文章id

        /// <summary>
        /// 长评论
        /// </summary>
        private static string _longCommentsUrl = $"{BaseUrl}/story/{{0}}/long-comments"; //0 文章id

        /// <summary>
        /// 分页获取长评论
        /// </summary>
        private static string _beforeLongCommentsUrl = $"{BaseUrl}/story/{{0}}/long-comments/before/{{1}}";
            //0 文章id  1 评论id

        /// <summary>
        /// 短评论
        /// </summary>
        private static string _shortCommentsUrl = $"{BaseUrl}/story/{{0}}/short-comments"; //0 文章id

        /// <summary>
        /// 分页获取短评论
        /// </summary>
        private static string _beforeShortCommentsUrl = $"{BaseUrl}/story/{{0}}/short-comments/before/{{1}}"; //0 文章id  1 评论id 

        /// <summary>
        /// 异步获取启动闪屏图片
        /// </summary>
        /// <param name="first">屏幕分辨率的第一个,例如1920</param>
        /// <param name="second">屏幕分辨率的第二个,例如1080</param>
        /// <returns></returns>
        [Cached("start_image.json",CacheType.Image)]
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
        [Cached("themes.json",CacheType.Data)]
        public async Task<List<Theme>> GetThemeListAsync()
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
        /// <summary>
        /// 根据文章id获取文章内容
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<StoryContent> GetStoryContentAsync(int storyId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_storyUrl, storyId));
                var storyContent = await httpContent.ToObject<StoryContent>();
                return storyContent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据主题id获取主题(以及最新主题文章)
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public async Task<Theme> GetThemeAsync(int themeId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_themeUrl, themeId));
                var theme = await httpContent.ToObject<Theme>();
                return theme;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据主题id和分界点文章id获取以往的主题文章s
        /// </summary>
        /// <param name="themeId"></param>
        /// <param name="lastStoryId">作为分割点的文章的id?</param>
        /// <returns></returns>
        public async Task<List<Story>> GetBeforeThemeStoriesAsync(int themeId, int lastStoryId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_beforeThemeStoriesUrl, themeId, lastStoryId));
                var stories = await httpContent.ToObject<List<Story>>();
                return stories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取编辑者信息
        /// </summary>
        /// <param name="editorId"></param>
        /// <returns></returns>
        public async Task<Editor> GetEditorProfileAsync(int editorId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_editorProfileUrl, editorId));
                var editor = await httpContent.ToObject<Editor>();
                return editor;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取文章额外信息
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<StoryExtra> GetStoryExtraAsync(string storyId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_storyExtraUrl, storyId));
                var storyExtra = await httpContent.ToObject<StoryExtra>();
                return storyExtra;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取文章的推荐者
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<List<Recommender>> GetRecommendersAsync(string storyId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_recommendersUrl, storyId));
                var recommender = await httpContent.ToObject<List<Recommender>>();
                return recommender;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取文章短评论
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<List<StoryComment>> GetShortCommentsAsync(string storyId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_shortCommentsUrl, storyId));
                var comments = await httpContent.ToObject<List<StoryComment>>();
                return comments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取文章长评论
        /// </summary>
        /// <param name="storyId"></param>
        /// <returns></returns>
        public async Task<List<StoryComment>> GetLongCommentsAsync(string storyId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_longCommentsUrl, storyId));
                var comments = await httpContent.ToObject<List<StoryComment>>();
                return comments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据最后一条评论的id分页获取文章短评论
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="lastCommentId"></param>
        /// <returns></returns>
        public async Task<List<StoryComment>> GetBeforeShortComments(string storyId, string lastCommentId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_beforeShortCommentsUrl, storyId, lastCommentId));
                var comments = await httpContent.ToObject<List<StoryComment>>();
                return comments;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 根据最后一条评论的id分页获取文章长评论
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="lastCommentId"></param>
        /// <returns></returns>
        public async Task<List<StoryComment>> GetBeforeLongComments(string storyId, string lastCommentId)
        {
            try
            {
                var httpContent = await new ApiBaseService().Get(string.Format(_beforeLongCommentsUrl, storyId, lastCommentId));
                var comments = await httpContent.ToObject<List<StoryComment>>();
                return comments;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}