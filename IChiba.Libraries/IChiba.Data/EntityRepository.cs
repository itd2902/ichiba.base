using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using IChiba.Core;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Tools;

namespace IChiba.Data
{
    /// <summary>
    /// Represents the Entity repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly DataConnection _dataConnection;
        private ITable<TEntity> _entities;

        #endregion

        #region Ctor

        public EntityRepository(DataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual TEntity GetById(object id)
        {
            return Entities.FirstOrDefault(e => e.Id == (string)id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FirstOrDefaultAsync(e => e.Id == (string)id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual int Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return _dataConnection.Insert(entity);
        }

        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return await _dataConnection.InsertAsync(entity);
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual long Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var result = 0L;
            using (var transaction = new TransactionScope())
            {
                var status = _dataConnection.BulkCopy(new BulkCopyOptions(), entities);
                result = status.RowsCopied;
                transaction.Complete();
            }

            return result;
        }

        public virtual async Task<long> InsertAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var result = 0L;
            using (var transaction = new TransactionScope())
            {
                var status = await _dataConnection.BulkCopyAsync(new BulkCopyOptions(), entities);
                result = status.RowsCopied;
                transaction.Complete();
            }

            return result;
        }

        /// <summary>
        /// Loads the original copy of the entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Copy of the passed entity</returns>
        public virtual TEntity LoadOriginalCopy(TEntity entity)
        {
            return _dataConnection.GetTable<TEntity>()
                .FirstOrDefault(e => e.Id == entity.Id);
        }

        public virtual async Task<TEntity> LoadOriginalCopyAsync(TEntity entity)
        {
            return await _dataConnection.GetTable<TEntity>()
                .FirstOrDefaultAsync(e => e.Id == entity.Id);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual int Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return _dataConnection.Update(entity);
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return await _dataConnection.UpdateAsync(entity);
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual int Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var result = 0;
            foreach (var entity in entities)
            {
                result += Update(entity);
            }

            return result;
        }

        public virtual async Task<int> UpdateAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var result = 0;
            foreach (var entity in entities)
            {
                result += await UpdateAsync(entity);
            }

            return result;
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual int Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return _dataConnection.Delete(entity);
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return await _dataConnection.DeleteAsync(entity);
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual int Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            return _dataConnection.GetTable<TEntity>()
                .Where(e => e.Id.In(entities.Select(x => x.Id)))
                .Delete();
        }

        public virtual async Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            return await _dataConnection.GetTable<TEntity>()
                .Where(e => e.Id.In(entities.Select(x => x.Id)))
                .DeleteAsync();
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _dataConnection.GetTable<TEntity>()
                .Where(predicate)
                .Delete();
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return await _dataConnection.GetTable<TEntity>()
                .Where(predicate)
                .DeleteAsync();
        }

        public virtual int Delete(IEnumerable<object> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            return _dataConnection.GetTable<TEntity>()
                .Where(e => e.Id.In(ids))
                .Delete();
        }

        public virtual async Task<int> DeleteAsync(IEnumerable<object> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            return await _dataConnection.GetTable<TEntity>()
                .Where(e => e.Id.In(ids))
                .DeleteAsync();
        }

        /// <summary>
        /// Executes command using System.Data.CommandType.StoredProcedure command type
        /// and returns results as collection of values of specified type
        /// </summary>
        /// <param name="storeProcedureName">Store procedure name</param>
        /// <param name="dataParameters">Command parameters</param>
        /// <returns>Collection of query result records</returns>
        public virtual IList<TEntity> EntityFromSql(string storeProcedureName, params DataParameter[] dataParameters)
        {
            var command = new CommandInfo(_dataConnection, storeProcedureName, dataParameters?.ToArray() ?? Array.Empty<DataParameter>());
            var rez = command.QueryProc<TEntity>()?.ToList();
            UpdateOutputParameters(_dataConnection, dataParameters);
            return rez ?? new List<TEntity>();
        }

        public virtual async Task<IList<TEntity>> EntityFromSqlAsync(string storeProcedureName, params DataParameter[] dataParameters)
        {
            var command = new CommandInfo(_dataConnection, storeProcedureName, dataParameters?.ToArray() ?? Array.Empty<DataParameter>());
            var rez = (await command.QueryProcAsync<TEntity>())?.ToList();
            UpdateOutputParameters(_dataConnection, dataParameters);
            return rez ?? new List<TEntity>();
        }

        /// <summary>
        /// Truncates database table
        /// </summary>
        /// <param name="resetIdentity">Performs reset identity column</param>
        public virtual int Truncate(bool resetIdentity = false)
        {
            return _dataConnection.GetTable<TEntity>().Truncate(resetIdentity);
        }

        public virtual async Task<int> TruncateAsync(bool resetIdentity = false)
        {
            return await _dataConnection.GetTable<TEntity>().TruncateAsync(resetIdentity);
        }

        #endregion

        #region Properties

        public virtual DataConnection DataConnection => _dataConnection;

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual ITable<TEntity> Entities => _entities ?? (_entities = _dataConnection.GetTable<TEntity>());

        #endregion

        #region Utils

        private void UpdateOutputParameters(DataConnection dataConnection, DataParameter[] dataParameters)
        {
            if (dataParameters is null || dataParameters.Length == 0)
                return;

            foreach (var dataParam in dataParameters.Where(p => p.Direction == ParameterDirection.Output))
            {
                UpdateParameterValue(dataConnection, dataParam);
            }
        }

        private void UpdateParameterValue(DataConnection dataConnection, DataParameter parameter)
        {
            if (dataConnection is null)
                throw new ArgumentNullException(nameof(dataConnection));

            if (parameter is null)
                throw new ArgumentNullException(nameof(parameter));

            if (dataConnection.Command is IDbCommand command &&
                command.Parameters.Count > 0 &&
                command.Parameters.Contains(parameter.Name) &&
                command.Parameters[parameter.Name] is IDbDataParameter param)
            {
                parameter.Value = param.Value;
            }
        }

        #endregion
    }
}
