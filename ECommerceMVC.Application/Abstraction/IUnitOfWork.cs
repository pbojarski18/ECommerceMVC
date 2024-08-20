using System.Data;

namespace ECommerceMVC.Application.Abstraction;

public interface IUnitOfWork
{
    Task<IDbTransaction> BeginTransactionAsync();

}
