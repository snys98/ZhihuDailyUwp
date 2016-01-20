using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZhihuDailyUwp.Models
{
    [DataContract]
    public class StoryContent
    {
        [DataMember]
        public string Body
        {
            get; set;
        }
        [DataMember]
        public string CSS
        {
            get; set;
        }
        [DataMember]
        public string Id
        {
            get; set;
        }
        [DataMember]
        public string Image
        {
            get; set;
        }
        [DataMember]
        public string ImageSource
        {
            get; set;
        }
        [DataMember]
        public string ShareURL
        {
            get; set;
        }
        [DataMember]
        public string Title
        {
            get; set;
        }
        [DataMember]
        public bool Readed
        {
            get; set;
        }
        [DataMember]
        public ObservableCollection<string> RecommnderAvatars
        {
            get; set;
        }
    }
}
