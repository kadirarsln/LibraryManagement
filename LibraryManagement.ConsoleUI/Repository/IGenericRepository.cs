using LibraryManagement.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI.Repository
{
    public interface IGenericRepository<TEntity, TId>
        where TEntity : Entity<TId>, new()
    {
        List<TEntity> GetAll();
        TEntity GetById(TId id);
        TEntity Add(TEntity item);
        TEntity? Update(TEntity item);
        TEntity? Remove(TId id);
    }
}
