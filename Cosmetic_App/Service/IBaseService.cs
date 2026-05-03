namespace Cosmetic_App.Service
{
    public interface IBaseService<Entity>
    {
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <paran name="id">id bản ghi</paran>
        /// <returns</returns>
        /// CreatedBy: NTTrung (14/07/2023)
        Task<int> DeleteAsync(string id);
        /// <summary>
        /// Lấy bản ghi theo Id
        /// Không thấy bắn ra lỗi luôn
        /// </summary>
        /// <paran name="id">Định danh bản ghi</paran>
        /// <returns>Bản ghi</returns>
        /// CreatedBy: NTTrung (14/07/2023)
        Task<Entity> GetByIdAsync(string id);
        //
    }
}
