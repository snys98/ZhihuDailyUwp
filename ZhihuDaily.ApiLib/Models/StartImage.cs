using System.Runtime.Serialization;

namespace ZhihuDaily.ApiLib.Models
{
    /// <summary>
    /// 启动图片
    /// </summary>
    [DataContract]
    public class StartImage
    {
        [DataMember]
        public string ImageUrl
        {
            get; set;
        }
        [DataMember]
        public string ImageText
        {
            get; set;
        }
    }
}
