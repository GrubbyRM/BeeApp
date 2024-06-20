using BeeApp.Aplication.Inspection.Commands.CreateInspection;
using BeeApp.Aplication.Inspection.Queries.GetAllInspections;
using BeeApp.Aplication.Inspection.Queries.GetInspectionById;
using BeeApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeeApp.MVC.Controllers
{
    public class InspectionController : Controller
    {
        private readonly IMediator _mediator;
        public InspectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //BJ: fetch all inspections
        public async Task<IActionResult> Index()
        {
            var inspections = await _mediator.Send(new GetAllInspectionsQuery());
            return View(inspections);
        }

        //BJ: create form
        public IActionResult Create()
        {
            return View();
        }

        [Route("Inspection/{inspectionId}/Details")]
        public async Task<IActionResult> Details(int inspectionId)
        {
            var inspection = await _mediator.Send(new GetInspectionByIdQuery(inspectionId));
            return View(inspection);
        }

        [HttpPost]
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
