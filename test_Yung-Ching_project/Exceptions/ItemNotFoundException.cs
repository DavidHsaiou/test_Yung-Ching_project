namespace test_Yung_Ching_project.Exceptions;

public class ItemNotFoundException: Exception
{
    public ItemNotFoundException()
    {
    }
    public ItemNotFoundException(string msg): base(msg)
    {
    }
}