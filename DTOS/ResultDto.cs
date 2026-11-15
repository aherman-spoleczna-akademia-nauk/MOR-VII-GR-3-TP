namespace Mappery_Relacyjno_Obiektowe.DTOS;

public class ResultDto
{
    public bool Success { get; set; }
    public string? Error { get; set; }
    public ErrorType? ErrorType { get; set; }
    public object? Data { get; set; }
}

public enum ErrorType
{
    NO_DATA = 1,
    DUPLICATED = 2
}
