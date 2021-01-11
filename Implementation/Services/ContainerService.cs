// /********************************************************************************
//  * Copyright (c) 2020,2021 Beawre Digital SL
//  *
//  * This program and the accompanying materials are made available under the
//  * terms of the Eclipse Public License 2.0 which is available at
//  * http://www.eclipse.org/legal/epl-2.0.
//  *
//  * SPDX-License-Identifier: EPL-2.0 3
//  *
//  ********************************************************************************/

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