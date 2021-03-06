﻿using SimpleInjector;
using Taking.Application.Service;
using Taking.Application.Interfaces;
using Taking.Domain.Interfaces.Repository;
using Taking.Domain.Interfaces.Service;
using Taking.Domain.Services;
using Taking.Infra.Data.Context;
using Taking.Infra.Data.Interfaces;
using Taking.Infra.Data.Repository;
using Taking.Infra.Data.UoW;

namespace Taking.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register<ICustomerAppService, CustomerAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<ICustomerService, CustomerService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<TakingContext>(Lifestyle.Scoped);

        }
    }
}
