using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using chatbot.Models;

namespace chatbot.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MemDbContext _context;

        public MessagesController(MemDbContext context)
        {
            _context = context;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Messages.ToListAsync());
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMessage = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cMessage == null)
            {
                return NotFound();
            }

            return View(cMessage);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] cMessage cMessage)
        {
            if (ModelState.IsValid)
            {
                cMessage.Question = cMessage.Question.ToUpper();
                _context.Add(cMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cMessage);
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMessage = await _context.Messages.FindAsync(id);
            if (cMessage == null)
            {
                return NotFound();
            }
            return View(cMessage);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] cMessage cMessage)
        {
            if (id != cMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cMessage.Question = cMessage.Question.ToUpper();
                    _context.Update(cMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cMessageExists(cMessage.Id))
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
            return View(cMessage);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cMessage = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cMessage == null)
            {
                return NotFound();
            }

            return View(cMessage);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cMessage = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(cMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cMessageExists(int id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
