using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BeeApp.Aplication.Inspection.Commands.EditInspection;


namespace BeeApp.Aplication.Mappings
{
    public class InspectionMappingProfile : Profile
    {
        public InspectionMappingProfile()
        {
            CreateMap<Domain.Entities.Inspection, EditInspectionCommand>();
        }
    }
}
