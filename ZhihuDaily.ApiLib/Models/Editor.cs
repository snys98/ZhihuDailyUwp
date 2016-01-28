using System.Runtime.Serialization;

namespace ZhihuDaily.ApiLib.Models
{
    [DataContract]
    public class Editor
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Avatar { get; set; }
        [DataMember]
        public string Bio { get; set; }
        [DataMember]
        public string Url { get; set; }
    }
}