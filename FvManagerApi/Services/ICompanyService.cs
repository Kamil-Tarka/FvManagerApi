using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;
using FvManagerApi.Models.Query;

namespace FvManagerApi.Services
{
    public interface ICompanyService
    {
        public int Create(CreateCompanyDto dto);
        public CompanyDto GetById(int companyId);
        public PagetResult<CompanyDto> GetAll(CompanyQuery companyQuery);
        public void Delete(int companyId);
        public void Update(int companyId, UpdateCompanyDto dto);
    }
}
