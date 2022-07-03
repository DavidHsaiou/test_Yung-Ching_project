using Microsoft.EntityFrameworkCore;

namespace test_Yung_Ching_project.Models;

[Keyless]
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}