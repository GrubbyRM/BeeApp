using BeeApp.Aplication.Inspection.Commands.CreateInspection;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeeApp.Aplication.Mappings;

namespace BeeApp.Aplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InspectionMappingProfile));
            services.AddMediatR(typeof(CreateInspectionCommand));

            services.AddValidatorsFromAssemblyContaining<InspectionValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
