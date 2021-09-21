using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FvManagerApi
{
    public class FvManagerSeeder
    {
        private readonly FvManagerDbContext _dbContext;

        public FvManagerSeeder(FvManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                var pendingMIgrations = _dbContext.Database.GetPendingMigrations();

                if (pendingMIgrations != null && pendingMIgrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if(!_dbContext.Role.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Role.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if(!_dbContext.PaymentType.Any())
                {
                    var paymentTypes = GetPaymentTypes();
                    _dbContext.PaymentType.AddRange(paymentTypes);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }

        private IEnumerable<PaymentType> GetPaymentTypes()
        {
            var paymentTypes = new List<PaymentType>()
            {
                new PaymentType()
                {
                    Name = "Gotówka"
                },
                new PaymentType()
                {
                    Name = "Przelew"
                },
                new PaymentType()
                {
                    Name="Karta płatnicza"
                },
                new PaymentType()
                {
                    Name="Blik"
                }
            };

            return paymentTypes;
        }
    }
}
