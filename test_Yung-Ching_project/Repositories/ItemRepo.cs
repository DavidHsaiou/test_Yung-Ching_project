using Microsoft.EntityFrameworkCore;
using test_Yung_Ching_project.Data;
using test_Yung_Ching_project.Exceptions;
using test_Yung_Ching_project.Models;

namespace test_Yung_Ching_project.Repositories;

public class ItemRepo
{
    private readonly ApplicationDbContext _context;

    public ItemRepo(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<List<ItemModel>> GetList(int size = 20, int offset = 0)
    {
        if (_context.ItemModel is null) throw new EmptyException("Entity set 'ApplicationDbContext.ItemModel'  is null.");
        return await _context.
            ItemModel
            .OrderByDescending(m => m.CreateTime)
            .Take(size)
            .Skip(offset)
            .ToListAsync();
    }
    
    public async Task<ItemModel> Get(int id)
    {
        if (_context.ItemModel is null) throw new ItemNotFoundException("Entity set ItemModel is null");
        var result = await _context
            .ItemModel
            .FindAsync(id);
        if (result is not null)
            return result;
        
        throw new ItemNotFoundException($"Entity ItemModel id:{id} not exist");
    }

    public async Task Create(ItemModel model)
    {
        if (_context.ItemModel is null) throw new Exception("Entity set ItemModel is null");
        await _context.ItemModel.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task Update(ItemModel model)
    {
        if (_context.ItemModel is null) throw new Exception("Entity set ItemModel is null");
        try
        {
            _context.ItemModel.Update(model);
        } 
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemModelExists(model.Id))
                throw new ItemNotFoundException();
            throw;
        }
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        if (_context.ItemModel is null) throw new Exception("Entity set ItemModel is null");

        var model = await Get(id);
        _context.ItemModel.Remove(model);
        await _context.SaveChangesAsync();
    }

    private bool ItemModelExists(int id)
    {
        return (_context.ItemModel?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}