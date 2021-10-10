using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.NetCore.Business;
using MVC.NetCore.Commons;
using MVC.NetCore.IDataServices;
using MVC.NetCore.Models;
using Newtonsoft.Json.Linq;

namespace MVC.NetCore.Controllers
{
    public class PersonalContactController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly PersonalContactBusiness _personalContactService;

        public PersonalContactController(IPersonalContactDataService personalContactDataService, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _personalContactService = new PersonalContactBusiness(personalContactDataService);
        }

        // GET: PersonalContact
        public async Task<IActionResult> Index()
        {
            return View(await _personalContactService.GetAllAsync());
        }

        // GET: PersonalContact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContactModel = await _personalContactService.FindAsync(id);
            if (personalContactModel == null)
            {
                return NotFound();
            }

            return View(personalContactModel);
        }

        // GET: PersonalContact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Title")] PersonalContactModel personalContactModel)
        {
            if (ModelState.IsValid)
            {
                if(personalContactModel.Id == 0)
                {
                    await _personalContactService.CreatePersonalContactAsync(personalContactModel);

                    // Create a json file
                    JObject obj = (JObject)JToken.FromObject(personalContactModel);
                    string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "json");
                    string fileName = Guid.NewGuid().ToString() + ".json";
                    FileExtenstions.CreateJsonFile(uploadDir, fileName, obj);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(personalContactModel);
        }

        // GET: PersonalContact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContactModel = await _personalContactService.FindAsync(id);
            if (personalContactModel == null)
            {
                return NotFound();
            }

            return View(personalContactModel);
        }

        // POST: PersonalContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Title")] PersonalContactModel personalContactModel)
        {
            if (id != personalContactModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _personalContactService.CreatePersonalContactAsync(personalContactModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    int? existedId = id;
                    personalContactModel = await _personalContactService.FindAsync(existedId);
                    if (personalContactModel == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personalContactModel);
        }

        // GET: PersonalContact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContactModel = await _personalContactService.FindAsync(id);
            if (personalContactModel == null)
            {
                return NotFound();
            }

            return View(personalContactModel);
        }

        // POST: PersonalContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personalContactService.DeletePersonalContactAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
