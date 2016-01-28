using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ZhihuDaily.ApiLib.Models
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
        public string Share_URL
        {
            get; set;
        }
        [DataMember]
        public string Js
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
        [DataMember]
        public Theme Theme
        {
            get; set;
        }

        public StoryType Type { get; set; }
        public string Ga_Prefix { get; set; }
    }

    public enum StoryType
    {
        Type1=1,
        Type2=2,
    }
}
