using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FvManagerApi.Entities;
using FvManagerApi.Models;

namespace FvManagerApi.MappingProfile
{
    public class FvManagerMappingProfile : Profile
    {
        public FvManagerMappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<Invoice, InvoiceDto>();

            CreateMap<CreateInvoicePossitionDto, InvoicePossition>();
            CreateMap<InvoicePossition, InvoicePossitionDto>();
            CreateMap<UpdateInvoicePossitionDto, InvoicePossition>();
            
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<Company, CompanyDto>();

        }
    }
}
