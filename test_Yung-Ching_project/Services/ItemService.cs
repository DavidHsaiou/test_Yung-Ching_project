using test_Yung_Ching_project.Models;
using test_Yung_Ching_project.Repositories;

namespace test_Yung_Ching_project.Services;

public class ItemService : IItemService
{
    private readonly ItemRepo _itemRepo;

    public ItemService(ItemRepo itemRepo)
    {
        _itemRepo = itemRepo ?? throw new ArgumentNullException(nameof(itemRepo));
    }

    public async Task<List<ItemModel>> GetList()
    {
        return await _itemRepo.GetList();
    }

    public async Task<ItemModel> GetDetail(int id)
    {
        return await _itemRepo.Get(id);
    }

    public Task Create(ItemModel model)
    {
        return _itemRepo.Create(model);
    }

    public Task Edit(ItemModel model)
    {
        return _itemRepo.Update(model);
    }

    public Task Remove(int id)
    {
        return _itemRepo.Delete(id);
    }
}