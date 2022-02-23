using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rehber.Entities.Model
{
    public class ContactInfo
    {
        [Key]
        public int ContactInfoID { get; set; }
        [ForeignKey("InfoType")]
        public int InfoTypeID { get; set; }
        public InfoType InfoType { get; set; }
        public String InfoContent { get; set; }
        [ForeignKey("Person")]
        public string PersonUID { get; set; }
        public Person Person { get; set; }
    }
}
