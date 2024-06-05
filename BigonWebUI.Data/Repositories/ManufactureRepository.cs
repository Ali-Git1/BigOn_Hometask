using BigonApp.Infrastructure.Commons.Abstracts;
using BigonApp.Infrastructure.Commons.Concretes;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Data.Repositories
{
    public class ManufactureRepository : Repository<Manufacture>, IManufactureRepository
    {
        public ManufactureRepository(DbContext db) : base(db)
        {
        }
    }
}
