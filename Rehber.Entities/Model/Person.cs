using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rehber.Entities.Model
{
    public class Person
    {
        [Key]
        public string UID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public virtual ICollection<ContactInfo> ContactInfos{ get; set; }
    }
}
