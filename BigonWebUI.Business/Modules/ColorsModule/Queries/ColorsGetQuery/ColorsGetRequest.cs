using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModule.Queries.ColorsGetQuery
{
    public class ColorsGetRequest:IRequest<Color>
    {
        public int Id { get; set; }
    }
}
