using AutoMapper;
using Listing1.ENTITIES.Model;
using Listing1.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Listing1.WEB.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

        }
    }
}