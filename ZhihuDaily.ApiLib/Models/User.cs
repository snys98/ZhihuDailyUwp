using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZhihuDailyUwp.Models
{
    [DataContract]
    public class User
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