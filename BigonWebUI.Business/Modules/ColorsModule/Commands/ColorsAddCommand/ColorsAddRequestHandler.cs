using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModule.Commands.ColorsAddCommand
{
    internal class ColorsAddRequestHandler : IRequestHandler<ColorsAddRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorsAddRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorsAddRequest request, CancellationToken cancellationToken)
        {
            var color = new Color
            {
                Name = request.Name,
                HexCode = request.HexCode,
            };

            _colorRepository.Add(color);

            return color;
        }
    }


}
