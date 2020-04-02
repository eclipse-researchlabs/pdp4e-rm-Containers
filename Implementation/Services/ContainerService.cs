using Core.Database.Tables;
using MediatR;
using System.Threading.Tasks;
using Core.Containers.Implementation.Commands;
using Core.Containers.Interfaces.Services;

namespace Core.Containers.Implementation.Services
{
    public class ContainerService : IContainerService
    {
        private IMediator _mediator;

        public ContainerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Container> Create(CreateContainerCommand command) => await _mediator.Send(command);
        public bool Delete(DeleteContainerCommand command) => _mediator.Send(command).Result;

    }
}
