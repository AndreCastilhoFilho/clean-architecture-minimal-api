namespace CleanArchitecture.Application.Shared.UserCQRS;

public sealed record UserResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
}
