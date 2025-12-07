using BrainHub.DomainLayer.Models;
using System.Linq.Expressions;

namespace BrainHub.ServiceLayer.IServices
{
    public interface ISbuService
    {
        IEnumerable<Sbu> GetAll(Expression<Func<Sbu, bool>>? filter = null);
        Sbu? GetById(int id);
        Sbu? Get(Expression<Func<Sbu, bool>>? filter);
        (bool success, string error) AddSbu(Sbu entity);
        (bool success, string error) UpdateSbu(Sbu entity);
        void Delete(int id);
    }
}
