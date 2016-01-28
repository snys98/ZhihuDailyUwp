using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ZhihuDaily.ApiLib.Models
{
    /// <summary>
    /// 首页最近文章
    /// </summary>
    [DataContract]
    public class LatestStories
    {
        [DataMember]
        public string Date
        {
            get; set;
        }
        [DataMember]
        public ObservableCollection<Story> Stories
        {
            get; set;
        }
        [DataMember]
        public ObservableCollection<Story> Top_Stories
        {
            get; set;
        }
    }
}
