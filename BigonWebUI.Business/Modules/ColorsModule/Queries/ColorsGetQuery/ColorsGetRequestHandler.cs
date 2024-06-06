using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;

namespace BigonApp.Business.Modules.ColorsModule.Queries.ColorsGetQuery
{
    internal class ColorsGetRequestHandler : IRequestHandler<ColorsGetRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorsGetRequestHandler(IColorRepository colorRepository)
        {
           _colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorsGetRequest request, CancellationToken cancellationToken)
        {
           return _colorRepository.Get(e=>e.Id==request.Id&e.DeletedBy==null);

        }
    }
}
