using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_Yung_Ching_project.Exceptions;
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
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var detail = await _service.GetDetail(id.Value);
                return View(detail);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
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
                await _service.Create(itemModel);
                return RedirectToAction(nameof(Index));
            }
            
            return View(itemModel);
        }

        // GET: ItemsBagEntity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var itemModel = await _service.GetDetail(id.Value);
                return View(itemModel);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
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
                    await _service.Edit(itemModel);
                }
                catch (ItemNotFoundException)
                {
                    return NotFound();
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemModel);
        }

        // GET: ItemsBagEntity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var itemModel = await _service.GetDetail(id.Value);
                return View(itemModel);
            }
            catch (ItemNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST: ItemsBagEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ItemNotFoundException ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
