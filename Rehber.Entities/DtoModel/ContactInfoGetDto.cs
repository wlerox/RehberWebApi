using Rehber.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.Entities.DtoModel
{
    public class ContactInfoGetDto
    {
        public int ContactInfoID { get; set; }
        public InfoTypeDto InfoType { get; set; }
        public String InfoContent { get; set; }
    }
}
