using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rehber.Entities.DtoModel
{
    public class ContactInfoSetDto
    {
        [Required]
        public int InfoTypeID { get; set; }
        [Required]
        public String InfoContent { get; set; }
        [Required]
        public string PersonUID { get; set; }
    }
}
