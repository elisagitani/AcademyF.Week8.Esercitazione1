using AcademyF.Week8.Esercitazione1.Core.Entities;
using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using AcademyF.Week8.Esercitazione1.MVC.Helpers;
using AcademyF.Week8.Esercitazione1.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyF.Week8.Esercitazione1.MVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly IMainBusinessLayer mainBL;

        public TicketController(IMainBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }

        public IActionResult Index()
        {
            var model=this.mainBL.FetchAllTicketsWithNotes();

            var data = model.ToTicketList();

            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Priorities = MappingExtension.EnumToSelectList<Priority>();
            ViewBag.Categories = GetAvailableCategory();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TicketCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "Error generating model");
                ViewBag.Priorities = MappingExtension.EnumToSelectList<Priority>();
                ViewBag.Categories = GetAvailableCategory();

                return View(model);
            }

            
            var ticket = model.ToTicket();
            var result = this.mainBL.CreateNewTicket(ticket);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, "Error saving model");
                ViewBag.Priorities = MappingExtension.EnumToSelectList<Priority>();
                ViewBag.Categories = GetAvailableCategory();
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddNote(int id)
        {
            if(id<=0)
                return View();

            var ticket = this.mainBL.GetTicketbyId(id);

            NoteCreateView note = new NoteCreateView
            {
                TicketId = ticket.Id,

            };

            return View(note);

        }
        [HttpPost]
        public IActionResult AddNote(int id, NoteCreateView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "Error generating model");
                return View(model);
            }

            var note = model.ToNote();
            var ticket = this.mainBL.GetTicketbyId(id);
            ticket.Notes.Add(note);
            var result = this.mainBL.AddNewNote(note);

          
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, "Error saving model");
                return View(model);
            }

            return RedirectToAction(nameof(Details), new { id});

        }


        public IActionResult Details(int id)
        {
            if (id <= 0)
                return View();

            Ticket item = this.mainBL.GetTicketbyId(id);
            Category c = this.mainBL.GetCategorybyId(item.CategoryId);
            item.Category = c;
            
            TicketDetailsViewModel model = item.ToTicketDetails();

            return View(model);
        }

        public IActionResult Assign(int id)
        {
            if (id <= 0)
                return View();

            Ticket ticket = this.mainBL.GetTicketbyId(id);
            TicketAssignViewModel model = ticket.ToTicketAssign();
            return View(model);

        }

        [HttpPost]
        public IActionResult Assign (int id, TicketAssignViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "Error generating model");
                return View(model);
            }

            var ticket=model.ToTicket();
            var result= this.mainBL.UpdateTicket(ticket);
          
            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, "Error saving model");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CloseJS(int id)
        {
            if (id <= 0)
                return Json(false);

            Ticket t = this.mainBL.GetTicketbyId(id);
            t.ClosingDate = DateTime.Now;
            t.State = State.Closed;
            var result = this.mainBL.UpdateTicket(t);

            return Json(result.Success);

        }

        public IActionResult DeleteJS(int id)
        {
            if (id <= 0)
                return Json(false);

            
            var result = this.mainBL.DeleteTicket(id);

            return Json(result.Success);

        }

        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View();
            Ticket ticket = this.mainBL.GetTicketbyId(id);
            Category c = this.mainBL.GetCategorybyId(ticket.CategoryId);
            ticket.Category = c;
            TicketEditViewModel model = ticket.ToTicketEdit();
            
            ViewBag.Priorities = MappingExtension.EnumToSelectList<Priority>();
            ViewBag.States = MappingExtension.EnumToSelectList<State>();
            ViewBag.Categories = GetAvailableCategory();
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int id, TicketEditViewModel model)
        {
            if (id <= 0)
            {
               
                //model.AvailableCategory = GetAvailableCategory();
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                
                //model.AvailableCategory = GetAvailableCategory();
                return View(model);
            }

            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "Error generating model");
               
                //model.AvailableCategory = GetAvailableCategory();
                return View(model);
            }

            var ticket = model.ToTicket();
            var result = this.mainBL.UpdateTicket(ticket);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, "Error saving model");
                
                //model.AvailableCategory = GetAvailableCategory();
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetAvailableCategory()
        {

            var list=this.mainBL.FetchAllCategories();
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in list)
            {
                listItem.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });

            }

            return listItem;
        }

        private List<SelectListItem> GetAvailablePriority()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem {Text="High", Value="High"},
                new SelectListItem {Text="Normal", Value="Normal"},
                new SelectListItem {Text="Low", Value="Low"},
            };

            return list;
        }

        private List<SelectListItem> GetAvailableState()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                new SelectListItem {Text="Assigned", Value="Assigned"},
                new SelectListItem {Text="New", Value="New"},
                new SelectListItem {Text="Closed", Value="Closed"},
                new SelectListItem {Text="In Resolution", Value="InResolution"},
            };

            return list;
        }
    }
}
