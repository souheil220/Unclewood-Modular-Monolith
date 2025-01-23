namespace Unclewood.Modules.Ingredients.Application.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}