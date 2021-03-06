using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FvManagerApi.Entities;
using FvManagerApi.Exceptions;
using FvManagerApi.Models;
using FvManagerApi.Models.Query;
using Microsoft.EntityFrameworkCore;

namespace FvManagerApi.Services
{
    public class InvoiceService : IInvoiceService
    {

        private readonly FvManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public InvoiceService(FvManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateInvoiceDto dto)
        {
            var invoiceEntity = _mapper.Map<Invoice>(dto);

            if (invoiceEntity.InvoicePossitions.Any())
            {
                var lastInvoiceInMonth = _dbContext.Invoice
                    .Where(i => i.DateOfInvoice.Month == DateTime.Now.Month && i.DateOfInvoice.Year == DateTime.Now.Year)
                    .OrderBy(i => i.DateOfInvoice)
                    .LastOrDefault(i => i.DateOfInvoice.Month == DateTime.Now.Month);

                if (lastInvoiceInMonth is not null)
                {
                    var lastInvoiceNumber = int.Parse(lastInvoiceInMonth.InvoiceNumber.Split("/")[0]);
                    invoiceEntity.InvoiceNumber = $"{lastInvoiceNumber + 1}/{DateTime.Now.Month.ToString("d2")}/{DateTime.Now.Year}";
                }
                else
                {
                    invoiceEntity.InvoiceNumber = $"{1}/{DateTime.Now.Month.ToString("d2")}/{DateTime.Now.Year}";
                }

                _dbContext.Invoice.Add(invoiceEntity);
                _dbContext.SaveChanges();
            }

            return invoiceEntity.Id;
        }

        public void Delete(int invoiceId)
        {
            var invoice = _dbContext.Invoice
                .Include(i => i.InvoicePossitions)
                .FirstOrDefault(i => i.Id == invoiceId);

            if (invoice is null)
            {
                throw new NotFoundException("Invoice not found");
            }

            _dbContext.Invoice.Remove(invoice);
            _dbContext.SaveChanges();
        }

        public PagetResult<InvoiceDto> GetAll(InvoiceQuery invoiceQuery)
        {
            var baseQuery = _dbContext.Invoice
                .Include(i => i.InvoicePossitions)
                .ThenInclude(ip => ip.Porduct)
                .Include(i => i.Seller)
                .Include(i => i.Buyer)
                .Include(i => i.PaymentType)
                .Where(i => invoiceQuery.SearchDateFrom == null || i.DateOfInvoice >= DateTime.Parse(invoiceQuery.SearchDateFrom))
                .Where(i => invoiceQuery.SearchDateTo == null || i.DateOfInvoice < DateTime.Parse(invoiceQuery.SearchDateTo).AddDays(1))
                .Where(i => invoiceQuery.SearchNumber == null || i.InvoiceNumber.Contains(invoiceQuery.SearchNumber));

            if (!string.IsNullOrEmpty(invoiceQuery.SortBy))
            {

                var columnsSekectors = new Dictionary<string, Expression<Func<Invoice, object>>>
                {
                    { nameof(Invoice.InvoiceNumber), i => i.InvoiceNumber },
                    { nameof(Invoice.DateOfInvoice), i => i.DateOfInvoice }
                };

                var selectedColumn = columnsSekectors[invoiceQuery.SortBy];

                baseQuery = invoiceQuery.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var invoices = baseQuery
                .Skip(invoiceQuery.PageSize * (invoiceQuery.PageNumber - 1))
                .Take(invoiceQuery.PageSize)
                .ToList();

            var invoicesDto = _mapper.Map<List<InvoiceDto>>(invoices);

            var result = new PagetResult<InvoiceDto>(invoicesDto, baseQuery.Count(), invoiceQuery.PageSize, invoiceQuery.PageNumber);

            return result;
        }

        public InvoiceDto GetById(int invoiceId)
        {
            var invoiceEntity = _dbContext.Invoice
                .Include(i => i.InvoicePossitions)
                .ThenInclude(ip => ip.Porduct)
                .Include(i => i.Seller)
                .Include(i => i.Buyer)
                .Include(i => i.PaymentType)
                .FirstOrDefault(i => i.Id == invoiceId);

            if (invoiceEntity is null)
            {
                throw new NotFoundException("Invoice not found");
            }

            var invoiceDto = _mapper.Map<InvoiceDto>(invoiceEntity);

            return invoiceDto;
        }

        public void Update(int invoiceId, UpdateInvoiceDto dto)
        {
            var invoice = _dbContext.Invoice
                .Include(i => i.InvoicePossitions)
                .FirstOrDefault(i => i.Id == invoiceId);

            if (invoice is null)
            {
                throw new NotFoundException("Invoice not found");
            }

            if (dto.PaymentTypeId > 0 && dto.PaymentTypeId != invoice.PaymentTypeId)
            {
                invoice.PaymentTypeId = dto.PaymentTypeId;
            }
            if (dto.SellerId > 0 && dto.SellerId != invoice.SellerId)
            {
                invoice.SellerId = dto.SellerId;
            }
            if (dto.BuyerId > 0 && dto.BuyerId != invoice.BuyerId)
            {
                invoice.BuyerId = dto.BuyerId;
            }

            if (dto.InvoicePossitions.Any())
            {
                invoice.InvoicePossitions = _mapper.Map<List<InvoicePossition>>(dto.InvoicePossitions);
            }

            _dbContext.SaveChanges();
        }
    }
}
