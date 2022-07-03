using Microsoft.EntityFrameworkCore;
using test_Yung_Ching_project.Data;
using test_Yung_Ching_project.Exceptions;
using test_Yung_Ching_project.Models;
using test_Yung_Ching_project.Repositories;
using test_Yung_Ching_project.Services;

namespace UnitTest;

public class Tests
{
    private IItemService _itemService;
    
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbSet = new ApplicationDbContext(options);
        var itemRepo = new ItemRepo(dbSet);
        _itemService = new ItemService(itemRepo);
        
        // test data
        _itemService.Create(new ItemModel()
        {
            Id = 1,
            Name = "a",
            CreateTime = DateTime.Now,
            Memo = "test data 1"
        });
        
        _itemService.Create(new ItemModel()
        {
            Id = 2,
            Name = "b",
            CreateTime = DateTime.Now,
            Memo = "test data 2"
        });
    }

    [Test]
    public async Task Test_New_Data()
    {
        var newData = new ItemModel()
        {
            Id = 999,
            CreateTime = DateTime.Now,
            Memo = "Hello world",
            Name = "abc"
        };
        await _itemService.Create(newData);

        var result = await _itemService.GetDetail(999);
        Assert.AreEqual(result, newData);
    }

    [Test]
    public async Task Test_ReadData()
    {
        var result = await _itemService.GetDetail(1);
        Assert.AreEqual(result.Name, "a");
    }

    [Test]
    public async Task Tast_UpdateData()
    {
        var getData = await _itemService.GetDetail(1);
        getData.Name = "new data";
        await _itemService.Edit(getData);

        getData = await _itemService.GetDetail(1);
        Assert.AreEqual(getData.Name, "new data");
    }

    [Test]
    public async Task Test_DeleteData()
    {
        await _itemService.Remove(1);
        try
        {
            var getData = await _itemService.GetDetail(1);
        }
        catch (ItemNotFoundException)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }
}