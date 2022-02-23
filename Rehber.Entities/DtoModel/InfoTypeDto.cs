using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rehber.Entities.DtoModel
{
    public class InfoTypeDto
    {
        [Required]
        public int InfoTypeID { get; set; }
        [Required]
        public string InfoTypeName { get; set; }
    }
}
