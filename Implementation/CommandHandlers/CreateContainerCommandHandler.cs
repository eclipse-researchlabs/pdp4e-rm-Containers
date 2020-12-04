using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Containers.Implementation.Commands;
using Core.Database;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Containers.Implementation.CommandHandlers
{
    public class CreateContainerCommandHandler : IRequestHandler<CreateContainerCommand, Core.Database.Tables.Container>
    {
        private IDatabaseContext _databaseContext;
        private IMapper _mapper;

        public CreateContainerCommandHandler(IDatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public Task<Core.Database.Tables.Container> Handle(CreateContainerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Core.Database.Tables.Container>(request);
            var root = _databaseContext.Container.Where(x => x.RootId == entity.RootId).OrderByDescending(x => x.Version).FirstOrDefault();
            if (root != null)
            {
                entity.Version = root.Version + 1;
                var newPayload = JObject.Parse(entity.Payload);
                var oldPayload = JObject.Parse(root.Payload);

                foreach (var item in newPayload.Children<JProperty>())
                {
                    if (string.IsNullOrEmpty(item.Value.ToString())) continue;
                    if (oldPayload.ContainsKey(item.Name))
                        oldPayload.SelectToken(item.Name).Replace(newPayload.SelectToken(item.Name));
                    else
                        oldPayload.Add(item);
                }
                entity.Payload = JsonConvert.SerializeObject(oldPayload);
            }
            entity.Id = Guid.NewGuid();
            _databaseContext.Container.Add(entity);
            _databaseContext.SaveChanges();
            Debug.WriteLine("Finished container create handle!" + entity.Id.ToString());
            return Task.FromResult(entity);
        }
    }
}
