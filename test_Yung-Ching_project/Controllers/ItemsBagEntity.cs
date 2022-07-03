using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_Yung_Ching_project.Data;
using test_Yung_Ching_project.Models;
using test_Yung_Ching_project.Services;

namespace test_Yung_Ching_project.Controllers
{
    public class ItemsBagEntity : Controller
    {
        private readonly ItemService _service;

        public ItemsBagEntity(ItemService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: ItemsBagEntity
        public async Task<IActionResult> Index()
        {
            try
            {
               return View(await _service.GetList());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // GET: ItemsBagEntity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // GET: ItemsBagEntity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemsBagEntity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Memo,CreateTime")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemModel);
        }

        // GET: ItemsBagEntity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }
            return View(itemModel);
        }

        // POST: ItemsBagEntity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Memo,CreateTime")] ItemModel itemModel)
        {
            if (id != itemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemModelExists(itemModel.Id))
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
            return View(itemModel);
        }

        // GET: ItemsBagEntity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemModel == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // POST: ItemsBagEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ItemModel'  is null.");
            }
            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel != null)
            {
                _context.ItemModel.Remove(itemModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemModelExists(int id)
        {
          return (_context.ItemModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
