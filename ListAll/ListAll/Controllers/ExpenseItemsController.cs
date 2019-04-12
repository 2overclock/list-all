using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListAll.Data;
using ListAll.Models;

namespace ListAll.Controllers
{
    public class ExpenseItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExpenseItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExpenseItem.Include(e => e.List);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExpenseItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseItem = await _context.ExpenseItem
                .Include(e => e.List)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseItem == null)
            {
                return NotFound();
            }

            return View(expenseItem);
        }

        // GET: ExpenseItems/Create
        public IActionResult Create()
        {
            ViewData["ListId"] = new SelectList(_context.List, nameof(List.Id), nameof(List.Name));
            return View();
        }

        // POST: ExpenseItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,ExpenseDate,Id,ListId,Name,Description")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                expenseItem.Id = Guid.NewGuid();
                _context.Add(expenseItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListId"] = new SelectList(_context.List, nameof(List.Id), nameof(List.Name), expenseItem.ListId);
            return View(expenseItem);
        }

        // GET: ExpenseItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseItem = await _context.ExpenseItem.FindAsync(id);
            if (expenseItem == null)
            {
                return NotFound();
            }
            ViewData["ListId"] = new SelectList(_context.List, nameof(List.Id), nameof(List.Name), expenseItem.ListId);
            return View(expenseItem);
        }

        // POST: ExpenseItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Amount,ExpenseDate,Id,ListId,Name,Description")] ExpenseItem expenseItem)
        {
            if (id != expenseItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseItemExists(expenseItem.Id))
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
            ViewData["ListId"] = new SelectList(_context.List, nameof(List.Id), nameof(List.Name), expenseItem.ListId);
            return View(expenseItem);
        }

        // GET: ExpenseItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseItem = await _context.ExpenseItem
                .Include(e => e.List)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseItem == null)
            {
                return NotFound();
            }

            return View(expenseItem);
        }

        // POST: ExpenseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var expenseItem = await _context.ExpenseItem.FindAsync(id);
            _context.ExpenseItem.Remove(expenseItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseItemExists(Guid id)
        {
            return _context.ExpenseItem.Any(e => e.Id == id);
        }
    }
}
