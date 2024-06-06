using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModule.Commands.ColorsEditCommand
{
    internal class ColorsEditRequestHandler : IRequestHandler<ColorsEditRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorsEditRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorsEditRequest request, CancellationToken cancellationToken)
        {
            var color = new Color
            {
                Id=request.Id,
                Name=request.Name,
                HexCode=request.HexCode,
            };

            _colorRepository.Edit(color);

            return color;
        }
    }
}
