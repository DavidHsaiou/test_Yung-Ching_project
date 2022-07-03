using test_Yung_Ching_project.Models;

namespace test_Yung_Ching_project.Services;

public interface IItemService
{
    Task<List<ItemModel>> GetList();
    Task<ItemModel> GetDetail(int id);
    Task Create(ItemModel model);
    Task Edit(ItemModel model);
    Task Remove(int id);
}