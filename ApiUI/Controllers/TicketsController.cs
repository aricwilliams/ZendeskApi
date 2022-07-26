using ApiUI.Models;
using ApiUI.Repository.iRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUI.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly iTicketsRepository _ticketRepo;

        public TicketsController(iTicketsRepository ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        ///
        public IActionResult Index()
        {
            //we will load ticket with api, obect is empty
            return View(new Tickets() { });
        }
        ///
        public async Task<IActionResult> GetAllTickets()
        {
            //loading data table in js
            return Json(new { data = await _ticketRepo.GetAllAsync(StaticInfo.APIBaseURL) });
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            Tickets obj = new Tickets();

            if (id == null)
            {
                //this will be true for Insert/Create
                return View(obj);
            }

            //Flow will come here for update
            obj = await _ticketRepo.GetAsync(StaticInfo.APIBaseURL, id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Tickets obj)
        {
            if (ModelState.IsValid)
            {
               await _ticketRepo.CreateAsync(StaticInfo.APIBaseURL, obj);
            }
            else
            {
                return View(obj);
            }
            return RedirectToAction(nameof(Index));
        }

        ///
       

    }
}
