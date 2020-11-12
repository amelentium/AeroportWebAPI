using Dapper;
using SkillManagement.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace SkillManagement.DataAccess.Core
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        protected IConnectionFactory _connectionFactory;
        private readonly string _tableName;
        private readonly bool _isSoftDelete;

        public GenericRepository(IConnectionFactory connectionFactory, string tableName, bool isSoftDelete)
        {
            _connectionFactory = connectionFactory;
            _tableName = tableName;
            _isSoftDelete = isSoftDelete;
        }

        public TEntity Add(TEntity entity)
        {
            var stringOfColumns = string.Join(", ", GetColumns());
            var stringOfProperties = string.Join(", ", GetProperties(entity));
            var query = "SP_InsertRecordToTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                var Id = db.Query<TId>(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_propertiesString = stringOfProperties },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return Get(Id);
            }
        }

        public TEntity Get(TId Id)
        {
            var query = "SP_GetRecordByIdFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<TEntity>(query,
                    new { P_tableName = _tableName, P_Id = Id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = "SP_GetAllRecordsFromTable";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return db.Query<TEntity>(query,
                    new { P_tableName = _tableName },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public TEntity Update(TEntity entity, TId Id)
        {
            var columns = GetColumns();
            var properties = GetProperties(entity);
            columns = columns.Zip(properties, (column, property) => column + " = " + property);
            var stringOfColumns = string.Join(", ", columns);
            
            using (var db = _connectionFactory.GetSqlConnection)
            {
                var query = "SP_UpdateRecordInTable";

                return db.Query<TEntity>(
                    sql: query,
                    param: new { P_tableName = _tableName, P_columnsString = stringOfColumns, P_Id = Id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public TEntity Delete(TId Id)
        {
            if (_isSoftDelete)
            {
                var columns = GetColumns();
                var isActiveColumnUpdateString = columns.Where(e => e == "IsActive").Select(e => $"{e} = 0").FirstOrDefault();

                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var query = "SP_UnActivateRecordStatementInTable";

                    var UnActivateStatement = db.Query<string>(
                        sql: query,
                        param: new { P_tableName = _tableName, P_columnsString = isActiveColumnUpdateString, P_Id = Id },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return db.Query<TEntity>(
                        sql: UnActivateStatement,
                        param: Id,
                        commandType: CommandType.Text).FirstOrDefault();
                }
            }
            else
            {
                using (var db = _connectionFactory.GetSqlConnection)
                {
                    var query = "SP_DeleteRecordFromTable";
                    return db.Query<TEntity>(
                        sql: query,
                        param: new { P_tableName = _tableName, P_Id = Id },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
        }
        
        private IEnumerable<string> GetColumns()
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && e.Name != "Duration" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        private IEnumerable<string> GetProperties(TEntity entity)
        {
            return typeof(TEntity)
                    .GetProperties()
                    .Where(e => e.Name != "Id" && e.Name != "Duration" && !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => '\'' + e.GetValue(entity).ToString() + '\'');
        }
    }
}
