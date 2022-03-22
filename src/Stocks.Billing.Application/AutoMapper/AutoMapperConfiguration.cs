﻿using AutoMapper;

namespace Stocks.Billing.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(p =>
            {
                p.AddProfile(new ViewModelToDomainProfile());
                p.AddProfile(new DomainToViewModelProfile());
            });
        }
    }
}
