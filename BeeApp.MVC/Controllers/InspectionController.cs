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
            //BJ: redirected to
            return RedirectToAction(nameof(Create));

        } 
    }
}
