namespace CleanArchitecture.Domain;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
}
