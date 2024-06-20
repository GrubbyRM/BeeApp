using BeeApp.Aplication.Inspection.Commands.CreateInspection;
using BeeApp.Aplication.Inspection.Queries.GetAllInspections;
using BeeApp.Aplication.Inspection.Queries.GetInspectionById;
using AutoMapper;
using BeeApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BeeApp.Aplication.Inspection.Commands.EditInspection;
using Microsoft.AspNetCore.Authorization;

namespace BeeApp.MVC.Controllers
{
    public class InspectionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public InspectionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //BJ: fetch all inspections
        public async Task<IActionResult> Index()
        {
            var inspections = await _mediator.Send(new GetAllInspectionsQuery());
            return View(inspections);
        }

        //BJ: create new inspection
        [Authorize]
        public IActionResult Create()
        {
            
            return View();
        }

        //BJ: inspection detailed view
        [Route("Inspection/{inspectionId}/Details")]
        public async Task<IActionResult> Details(int inspectionId)
        {
            var inspection = await _mediator.Send(new GetInspectionByIdQuery(inspectionId));
            return View(inspection);
        }

        [Route("Inspection/{inspectionId}/Edit")]
        public async Task<IActionResult> Edit(int inspectionId)
        {
            var inspection = await _mediator.Send(new GetInspectionByIdQuery(inspectionId));

            EditInspectionCommand model = _mapper.Map<EditInspectionCommand>(inspection);

            return View(model);
        }

        [HttpPost]
        [Route("Inspection/{inspectionId}/Edit")]
        public async Task<IActionResult> Edit(int inspectionId, EditInspectionCommand command)
        {
            //BJ: temporary fix to avoid  update inspection error
            command.Id = inspectionId;

            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            //BJ: redirected to Index
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateInspectionCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            //BJ: redirected to Index
            return RedirectToAction(nameof(Index));

        } 
    }
}
