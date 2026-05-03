using Dapper;
using NTTRUNG_BaseWebAPI_Domain;
using NTTRUNG_BaseWebAPI_Domain.Interface.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using System.Data.Common;
using MySqlConnector;

namespace NTTRUNG_BaseWebAPI_Infastructurce.Repository.Base
{
    /// <summary>
    /// Lớp cơ sở cho Repository dùng cho các thao tác chỉ đọc (ReadOnly) và thao tác cơ bản (CRUD) với cơ sở dữ liệu.
    /// </summary>
    /// <typeparam name="TEntity">Kiểu dữ liệu của đối tượng Entity</typeparam>
    /// <typeparam name="TModel">Kiểu dữ liệu của đối tượng Model</typeparam>
    /// CreatedBy: NTTrung (14/07/2023)
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private readonly DbConnection _connection;
        protected BaseRepository()
        {
            _connection = new MySqlConnection("Server=localhost;Port=3306;Database=demo_data;Uid=root;Pwd=123456;");
        }
        public virtual string TableName { get; protected set; } = typeof(TEntity).Name;
        public virtual string TableId { get; protected set; } = typeof(TEntity).Name + "Id";
        #region Constructor

        #region Methods
        /// <summary>
        /// Xóa một bản ghi khỏi cơ sở dữ liệu.
        /// </summary>
        /// <param name="entity">Đối tượng cần xóa</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy: NTTrung (14/07/2023)

        public async Task<int> DeleteAsync(string id)
        {

            var parameters = new DynamicParameters();
            var query = new StringBuilder();
            var param = $"@id";
            parameters.Add(param, id);
            query.Append($"Delete From `{TableName}` where {TableName}ID = {param}; ");
            var queryString = query.ToString();

            var result = await _connection.ExecuteAsync(queryString, parameters, commandType: CommandType.Text);
            return result;
        }

        /// </summary>
        /// Tìm kiếm theo chuỗi ids
        /// </summary>
        /// <paran name="id">id</paran>
        /// <returns>Danh sách Đối tượng</returns>
        /// CreatedBy: NTTrung (03/08/2023)
        public async Task<TEntity> GetByIdAsync(string id)
        {
            var parameters = new DynamicParameters();
            var query = new StringBuilder();
            var paramName = "@id"; // Tên tham số

            // 1. Thêm giá trị vào DynamicParameters
            parameters.Add(paramName, id);

            // 2. Build câu lệnh SQL
            query.Append($"SELECT * FROM `{TableName}` WHERE {TableName}ID = {paramName};");
            var queryString = query.ToString();

            // 3. TRUYỀN 'parameters' (không phải paramName) VÀO ĐÂY
            var result = await _connection.QueryFirstOrDefaultAsync<TEntity>(
                queryString,
                parameters, // Sửa ở đây: Truyền đối tượng parameters
                commandType: CommandType.Text
            );

            return result;
        }
        // insert, update, getAll, filter
        #endregion
        #endregion
    }
}
