using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModule.Commands.ColorsRemoveCommand
{
    
    public class ColorsRemoveRequest:IRequest<IEnumerable<Color>>
    {
        public int Id { get; set; }
    }
}
