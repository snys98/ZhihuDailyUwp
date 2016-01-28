using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ZhihuDaily.ApiLib.Models
{
    /// <summary>
    /// 主题
    /// </summary>
    [DataContract]
    public class Theme
    {
        [DataMember]
        public string ID
        {
            get; set;
        }
        [DataMember]
        public string Description
        {
            get; set;
        }
        [DataMember]
        public string Name
        {
            get; set;
        }
        [DataMember]
        public string Thumbnail
        {
            get; set;
        }
        public List<Story> Stories
        {
            get; set;
        }

        public string Background { get; set; }
        public string Image { get; set; }
        public Editor Editors { get; set; }
        public string Image_Source { get; set; }
    }
}
