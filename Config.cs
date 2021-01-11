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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Core.Containers.Implementation.Commands;
using Core.Containers.Implementation.Services;
using Core.Containers.Interfaces.Services;
using Core.Database.Tables;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Containers
{
    public class Config
    {
        public static void InitializeServices(ref IServiceCollection services)
        {
            // Services
            services.AddScoped<IContainerService, ContainerService>();
        }
    }

    public class CoreContainersProfile : Profile
    {
        public CoreContainersProfile()
        {
            CreateMap<CreateContainerCommand, Container>()
                .ForMember(x => x.Payload, src => src.MapFrom(x => x.PayloadObject.ToString()))
                ;
        }
    }
}