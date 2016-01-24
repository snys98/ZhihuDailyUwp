using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZhihuDailyUwp.Models
{
    [DataContract]
    public class Story

    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Date { get; set; }//可为null

        [DataMember]
        public bool IsFavorite //是否收藏  不是知乎数据
        { get; set; }

        [DataMember]
        public bool IsMultiPic { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public bool IsToday { get; set; }//是否是当天第一条文章

        [DataMember]
        public bool IsReaded { get; set; }//是否已读

        [DataMember]
        public StoryContent Content { get; set; }
    }
}
