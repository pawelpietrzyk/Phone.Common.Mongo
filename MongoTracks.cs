using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Mongo
{
    
    [DataContract]
    public class TrackMongo : MongoDocument
    {
        [DataMember(Name = "begin")]
        public string Begin { get; set; }
        [DataMember(Name = "end")]
        public string End { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    public class TracksMongo : List<TrackMongo>
    {

    }
}
