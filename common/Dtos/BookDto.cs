namespace Common.Dtos
{
    public record BookDto(int Id, string Name, string Description, string? Url = null);
}
