using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZhihuDailyUwp.Models
{
    /// <summary>
    /// 启动图片
    /// </summary>
    [DataContract]
    public class StartImage
    {
        [DataMember]
        public string ImageURL
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
