using Microsoft.EntityFrameworkCore;
using test_Yung_Ching_project.Data;
using test_Yung_Ching_project.Interfaces;
using test_Yung_Ching_project.Models;

namespace test_Yung_Ching_project.Repositories;

public class ItemRepo: IRepository<ItemModel>
{
    private readonly ApplicationDbContext _context;

    public ItemRepo(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<List<ItemModel>> GetList()
    {
        if (_context.ItemModel is null) throw new Exception("Entity set 'ApplicationDbContext.ItemModel'  is null.");
        return await _context.ItemModel.ToListAsync();
    }

    public ItemModel Create(ItemModel model)
    {
        throw new NotImplementedException();
    }

    public ItemModel Get()
    {
        throw new NotImplementedException();
    }

    public ItemModel Update(ItemModel model)
    {
        throw new NotImplementedException();
    }

    public bool Delete(ItemModel model)
    {
        throw new NotImplementedException();
    }
}