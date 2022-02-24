using AutoMapper;
using Rehber.Entities.DtoModel;
using Rehber.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.DataAccess.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            //Person mapping
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<PersonDto, Person>().ReverseMap();

            CreateMap<Person, PersonGetDto>().ReverseMap();
            CreateMap<PersonGetDto, Person>().ReverseMap();

            CreateMap<Person, PersonSetDto>().ReverseMap();
            CreateMap<PersonSetDto, Person>().ReverseMap();

            //Information Type mapping
            CreateMap<InfoType, InfoTypeDto>().ReverseMap();
            CreateMap<InfoTypeDto, InfoType>().ReverseMap();

            //Contact İnformation mapping
            CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
            CreateMap<ContactInfoDto, ContactInfo>().ReverseMap();

        }
    }
}
