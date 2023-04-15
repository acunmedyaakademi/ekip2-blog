namespace filmblog.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    /*d*/

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

