using BeeApp.Aplication.Services;
using BeeApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BeeApp.MVC.Controllers
{
    public class InspectionController : Controller
    {
        private readonly IInspectionService _inspectionService;
        public InspectionController(IInspectionService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        //BJ: fetch all inspections
        public async Task<IActionResult> Index()
        {
            var inspections = await _inspectionService.GetAll();
            return View(inspections);
        }

        //BJ: create form
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Inspection inspection)
        {
            if(!ModelState.IsValid)
            {
                return View(inspection);
            }
            await _inspectionService.Create(inspection);
            //BJ: redirected to Index
            return RedirectToAction(nameof(Index));

        } 
    }
}
