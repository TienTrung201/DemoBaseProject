using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTRUNG_BaseWebAPI_Domain.Interface.Base
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <paran name="entity">Thông tin chi tiết bản ghi xóa</paran>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy: NTTrung (14/07/2023)
        Task<int> DeleteAsync(string id);
        
        Task<TEntity> GetByIdAsync(string id);
        
    }
}
