using System.ComponentModel.DataAnnotations;

namespace test_Yung_Ching_project.Models;

public class ItemModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Memo { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime CreateTime { get; set; }
}