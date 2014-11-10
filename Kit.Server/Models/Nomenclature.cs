using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Kit.Server.Models
{
    [Serializable]
    public class Nomenclature
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Version { get; set; }
    }
}