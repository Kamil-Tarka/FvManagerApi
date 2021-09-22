using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FvManagerApi.Entities;
using FvManagerApi.Exceptions;
using FvManagerApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace FvManagerApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly FvManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyService(FvManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateCompanyDto dto)
        {
            var companyEntity = _mapper.Map<Company>(dto);
            _dbContext.Company.Add(companyEntity);
            _dbContext.SaveChanges();

            return companyEntity.Id;
        }

        public void Delete(int companyId)
        {
            var company = _dbContext.Company.FirstOrDefault(c => c.Id == companyId);

            if (company is null)
            {
                throw new NotFoundException("Company not found");
            }

            _dbContext.Company.Remove(company);
            _dbContext.SaveChanges();
        }

        public List<CompanyDto> GetAll()
        {
            var companies = _mapper.Map<List<CompanyDto>>(_dbContext.Company);

            return companies;
        }

        public CompanyDto GetById(int companyId)
        {
            var company = _dbContext.Company.FirstOrDefault(c => c.Id == companyId);

            if (company is null)
            {
                throw new NotFoundException("Company not found");
            }

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public void Update(int companyId, UpdateCompanyDto dto)
        {
            var company = _dbContext.Company.FirstOrDefault(c => c.Id == companyId);

            if (company is null)
            {
                throw new NotFoundException("Company not found");
            }

            if (dto.Name is not null && company.Name!=dto.Name)
            {
                company.Name = dto.Name;
            }
            if(company.Nip!=dto.Nip)
            {
                company.Nip = dto.Nip;
            }
            if(company.IsPhisicalPerson!=dto.IsPhisicalPerson)
            {
                company.IsPhisicalPerson = dto.IsPhisicalPerson;
            }
            if(dto.City is not null && company.City!=dto.City)
            {
                company.City = dto.City;
            }
            if(dto.Street is not null && company.Street!=dto.Street)
            {
                company.Street = dto.Street;
            }
            if(dto.PostalCode is not null && company.PostalCode!=dto.PostalCode)
            {
                company.PostalCode = dto.PostalCode;
            }

            _dbContext.SaveChanges();
        }
    }
}
