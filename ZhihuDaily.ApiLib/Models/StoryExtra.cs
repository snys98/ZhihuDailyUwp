using System.Runtime.Serialization;

namespace ZhihuDaily.ApiLib.Models
{
    /// <summary>
    /// 文章附加信息
    /// </summary>
    [DataContract]
    public class StoryExtra
    {
        [DataMember]
        public string Comments
        {
            get; set;
        }
        [DataMember]
        public string LongComments
        {
            get; set;
        }
        [DataMember]
        public string ShortComments
        {
            get; set;
        }
        [DataMember]
        public string Polularity
        {
            get; set;
        }
        [DataMember]
        public bool Favorite  //是否收藏  不是知乎数据
        {
            get; set;
        }
    }
}
