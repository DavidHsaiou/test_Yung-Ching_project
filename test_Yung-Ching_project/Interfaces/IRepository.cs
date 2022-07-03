namespace test_Yung_Ching_project.Interfaces;

public interface IRepository<T>
{
    public Task<List<T>> GetList();

    public Task<T> Create(T model);

    public Task<T> Get();

    public Task<T> Update(T model);

    public Task<bool> Delete(T model);
}