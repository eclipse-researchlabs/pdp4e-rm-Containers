using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Containers.Implementation.Commands;
using Core.Database.Tables;

namespace Core.Containers.Interfaces.Services
{
    public interface IContainerService
    {
        Task<Container> Create(CreateContainerCommand command);
        bool Delete(DeleteContainerCommand command);
    }
}
