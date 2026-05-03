using NTTRUNG_BaseWebAPI_Domain.Interface.Base;
using NTTRUNG_BaseWebAPI_Infastructurce.Repository.Base;

namespace Cosmetic_App.Service
{
    public class BaseService<TEntity> :IBaseService<TEntity> 
    {
        public virtual string TableName { get; protected set; } = typeof(TEntity).Name;
        public readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task<TEntity> GetByIdAsync(string id)
        {
            return _baseRepository.GetByIdAsync(id);
        }

        public Task<int> DeleteAsync(string id)
        {
            return _baseRepository.DeleteAsync(id);
        }
    }
}
