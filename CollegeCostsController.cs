using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.ExistingDb.Models;

namespace EFGetStarted.AspNetCore.ExistingDb.Controllers
{
    public class CollegeCostsController : Controller
    {
        private readonly collegeContext _context;

        public CollegeCostsController(collegeContext context)
        {
            _context = context;
        }


        //​public ActionResult Index(string searchString)
        //{
        //    var Thecollege = from m in _context.CollegeCost select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        Thecollege = Thecollege.Where(s => s.College.Contains(searchString));
        //    }

        //    return View(Thecollege);
        //}




        // GET: CollegeCosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeCost.ToListAsync());
        }

        // GET: CollegeCosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeCost = await _context.CollegeCost
                .FirstOrDefaultAsync(m => m.CollegeId == id);
            if (collegeCost == null)
            {
                return NotFound();
            }

            return View(collegeCost);
        }

        // GET: CollegeCosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollegeCosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("College,TuitionInState,TuitionOutOfState,RoomBoard,CollegeId")] CollegeCost collegeCost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collegeCost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collegeCost);
        }

        // GET: CollegeCosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeCost = await _context.CollegeCost.FindAsync(id);
            if (collegeCost == null)
            {
                return NotFound();
            }
            return View(collegeCost);
        }

        // POST: CollegeCosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("College,TuitionInState,TuitionOutOfState,RoomBoard,CollegeId")] CollegeCost collegeCost)
        {
            if (id != collegeCost.CollegeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collegeCost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeCostExists(collegeCost.CollegeId))
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
            return View(collegeCost);
        }

        // GET: CollegeCosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeCost = await _context.CollegeCost
                .FirstOrDefaultAsync(m => m.CollegeId == id);
            if (collegeCost == null)
            {
                return NotFound();
            }

            return View(collegeCost);
        }

        // POST: CollegeCosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collegeCost = await _context.CollegeCost.FindAsync(id);
            _context.CollegeCost.Remove(collegeCost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeCostExists(int id)
        {
            return _context.CollegeCost.Any(e => e.CollegeId == id);
        }
    }
}
