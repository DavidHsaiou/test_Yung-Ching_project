using test_Yung_Ching_project.Models;

namespace test_Yung_Ching_project.Repositories;

public interface IItemRepo
{
    Task<List<ItemModel>> GetList(int size = 20, int offset = 0);
    Task<ItemModel> Get(int id);
    Task Create(ItemModel model);
    Task Update(ItemModel model);
    Task Delete(int id);
}