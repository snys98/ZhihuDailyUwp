using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ZhihuDaily.ApiLib.Models
{
    /// <summary>
    /// 主题文章
    /// </summary>
    [DataContract]
    public class LatestThemeStories
    {
        [DataMember]
        public string Background
        {
            get; set;
        }
        [DataMember]
        public string Description
        {
            get; set;
        }
        [DataMember]
        public string Image
        {
            get; set;
        }
        [DataMember]
        public string Image_Source
        {
            get; set;
        }
        [DataMember]
        public string Name
        {
            get; set;
        }
        [DataMember]
        public ObservableCollection<Story> Stories
        {
            get; set;
        }
        [DataMember]
        public ObservableCollection<Editor> Editors
        {
            get; set;
        }
    }
}
