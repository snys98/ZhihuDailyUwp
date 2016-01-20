using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZhihuDailyUwp.Models
{
    [DataContract]
    public class Editor
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Avatar { get; set; }
        [DataMember]
        public string Motto { get; set; }
        [DataMember]
        public string Introduction { get; set; }
    }
}