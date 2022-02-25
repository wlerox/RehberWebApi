using Rehber.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.Entities.DtoModel
{
    public class PersonGetDto
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public virtual ICollection<ContactInfoGetDto> ContactInfos { get; set; }
    }
}
