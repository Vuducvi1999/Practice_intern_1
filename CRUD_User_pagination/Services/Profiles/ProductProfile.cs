using AutoMapper;
using Domain.Dtos.Pagination;
using Domain.Dtos.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ReadProduct>().ReverseMap();
            CreateMap<ProductEntity, PatchProduct>().ReverseMap();
            CreateMap<ProductEntity, PutProduct>().ReverseMap();
            CreateMap<PagingInfo, ReadPaging>().ReverseMap();
        }
    }
}
