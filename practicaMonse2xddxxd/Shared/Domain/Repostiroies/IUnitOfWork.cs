namespace practicaMonse2xddxxd.Shared.Domain.Repostiroies;

public interface IUnitOfWork
{
    Task CompleteAsync();
}