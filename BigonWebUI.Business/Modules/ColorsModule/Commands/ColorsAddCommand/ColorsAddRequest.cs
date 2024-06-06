using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModule.Commands.ColorsAddCommand
{
    public class ColorsAddRequest:IRequest<Color>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
