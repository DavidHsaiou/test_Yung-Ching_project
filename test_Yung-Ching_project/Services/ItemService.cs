using test_Yung_Ching_project.Interfaces;
using test_Yung_Ching_project.Models;
using test_Yung_Ching_project.Repositories;

namespace test_Yung_Ching_project.Services;

public class ItemService: IService
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
    
}