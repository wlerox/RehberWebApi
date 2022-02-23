using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rehber.Entities.Model
{
    public class InfoType
    {
        [Key]
        public int InfoTypeID { get; set; }
        public string InfoTypeName { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
