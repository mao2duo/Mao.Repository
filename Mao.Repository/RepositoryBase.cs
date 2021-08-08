using Dapper;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mao.Repository
{
    public abstract class RepositoryBase : IRepository
    {
        public abstract string ConnectionString { get; }
        public abstract IDbConnection CreateConnection();

        protected virtual Compiler Compiler => throw new NotImplementedException();

        #region For Dapper
        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        public virtual int Execute(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.Execute(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.Execute(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        public virtual object ExecuteScalar(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.ExecuteScalar(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.ExecuteScalar(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        public virtual T ExecuteScalar<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.ExecuteScalar<T>(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Execute parameterized SQL and return an System.Data.IDataReader.
        /// </summary>
        public virtual IDataReader ExecuteReader(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.ExecuteReader(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.ExecuteReader(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Return a sequence of dynamic objects with properties matching the columns.
        /// </summary>
        public virtual IEnumerable<dynamic> Query(string sql, object param, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.Query(sql, param, transaction, buffered, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.Query(sql, param, transaction, buffered, commandTimeout);
            }
        }
        /// <summary>
        /// Executes a query, returning the data typed as T.
        /// </summary>
        public virtual IEnumerable<T> Query<T>(string sql, object param, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.Query<T>(sql, param, transaction, buffered, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.Query<T>(sql, param, transaction, buffered, commandTimeout);
            }
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QueryFirst(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QueryFirst(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QueryFirst(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QueryFirst<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QueryFirst<T>(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QueryFirst<T>(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QueryFirstOrDefault(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QueryFirstOrDefault(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QueryFirstOrDefault(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QueryFirstOrDefault<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QuerySingle(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QuerySingle(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QuerySingle(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QuerySingle<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QuerySingle<T>(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QuerySingle<T>(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QuerySingleOrDefault(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QuerySingleOrDefault(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QuerySingleOrDefault(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QuerySingleOrDefault<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout);
            }
        }
        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        public virtual SqlMapper.GridReader QueryMultiple(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction != null)
            {
                return transaction.Connection.QueryMultiple(sql, param, transaction, commandTimeout);
            }
            using (var conn = CreateConnection())
            {
                return conn.QueryMultiple(sql, param, transaction, commandTimeout);
            }
        }
        #endregion
        #region For SqlKata To Dapper
        #region Func<Query, Query> To Query
        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        public virtual int Execute(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.Execute(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        public virtual object ExecuteScalar(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteScalar(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        public virtual T ExecuteScalar<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteScalar<T>(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL and return an System.Data.IDataReader.
        /// </summary>
        public virtual IDataReader ExecuteReader(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteReader(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Return a sequence of dynamic objects with properties matching the columns.
        /// </summary>
        public virtual IEnumerable<dynamic> Query(Func<Query, Query> queryFunc, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null)
        {
            return this.Query(Compiler.Compile(queryFunc(new Query())), transaction, buffered, commandTimeout);
        }
        /// <summary>
        /// Executes a query, returning the data typed as T.
        /// </summary>
        public virtual IEnumerable<T> Query<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null)
        {
            return this.Query<T>(Compiler.Compile(queryFunc(new Query())), transaction, buffered, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QueryFirst(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirst(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QueryFirst<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirst<T>(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QueryFirstOrDefault(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirstOrDefault(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QueryFirstOrDefault<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirstOrDefault<T>(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QuerySingle(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingle(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QuerySingle<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingle<T>(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QuerySingleOrDefault(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingleOrDefault(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QuerySingleOrDefault<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingleOrDefault<T>(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        public virtual SqlMapper.GridReader QueryMultiple(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryMultiple(Compiler.Compile(queryFunc(new Query())), transaction, commandTimeout);
        }
        #endregion
        #region Query To SqlResult
        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        public virtual int Execute(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.Execute(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        public virtual object ExecuteScalar(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteScalar(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        public virtual T ExecuteScalar<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteScalar<T>(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL and return an System.Data.IDataReader.
        /// </summary>
        public virtual IDataReader ExecuteReader(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteReader(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Return a sequence of dynamic objects with properties matching the columns.
        /// </summary>
        public virtual IEnumerable<dynamic> Query(Query query, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null)
        {
            return this.Query(Compiler.Compile(query), transaction, buffered, commandTimeout);
        }
        /// <summary>
        /// Executes a query, returning the data typed as T.
        /// </summary>
        public virtual IEnumerable<T> Query<T>(Query query, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null)
        {
            return this.Query<T>(Compiler.Compile(query), transaction, buffered, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QueryFirst(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirst(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QueryFirst<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirst<T>(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QueryFirstOrDefault(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirstOrDefault(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QueryFirstOrDefault<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirstOrDefault<T>(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QuerySingle(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingle(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QuerySingle<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingle<T>(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QuerySingleOrDefault(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingleOrDefault(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QuerySingleOrDefault<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingleOrDefault<T>(Compiler.Compile(query), transaction, commandTimeout);
        }
        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        public virtual SqlMapper.GridReader QueryMultiple(Query query, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryMultiple(Compiler.Compile(query), transaction, commandTimeout);
        }
        #endregion
        #region SqlResult To Dapper
        /// <summary>
        /// Execute parameterized SQL.
        /// </summary>
        public virtual int Execute(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.Execute(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        public virtual object ExecuteScalar(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteScalar(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        public virtual T ExecuteScalar<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteScalar<T>(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Execute parameterized SQL and return an System.Data.IDataReader.
        /// </summary>
        public virtual IDataReader ExecuteReader(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.ExecuteReader(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Return a sequence of dynamic objects with properties matching the columns.
        /// </summary>
        public virtual IEnumerable<dynamic> Query(SqlResult sqlResult, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null)
        {
            return this.Query(sqlResult.Sql, sqlResult.NamedBindings, transaction, buffered, commandTimeout);
        }
        /// <summary>
        /// Executes a query, returning the data typed as T.
        /// </summary>
        public virtual IEnumerable<T> Query<T>(SqlResult sqlResult, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null)
        {
            return this.Query<T>(sqlResult.Sql, sqlResult.NamedBindings, transaction, buffered, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QueryFirst(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirst(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QueryFirst<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirst<T>(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QueryFirstOrDefault(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirstOrDefault(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QueryFirstOrDefault<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryFirstOrDefault<T>(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QuerySingle(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingle(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QuerySingle<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingle<T>(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Return a dynamic object with properties matching the columns.
        /// </summary>
        public virtual dynamic QuerySingleOrDefault(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingleOrDefault(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Executes a single-row query, returning the data typed as T.
        /// </summary>
        public virtual T QuerySingleOrDefault<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QuerySingleOrDefault<T>(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        public virtual SqlMapper.GridReader QueryMultiple(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return this.QueryMultiple(sqlResult.Sql, sqlResult.NamedBindings, transaction, commandTimeout);
        }
        #endregion
        #endregion
        #region Entity
        public virtual string GetTableName(Type type)
        {
            string tableName = type.Name;
            var tableAttribute = type.GetCustomAttribute<TableAttribute>();
            if (tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name))
            {
                tableName = tableAttribute.Name;
            }
            return tableName;
        }
        public virtual string GetColumnName(PropertyInfo property)
        {
            string columnName = property.Name;
            var columnAttribute = property.GetCustomAttribute<System.ComponentModel.DataAnnotations.Schema.ColumnAttribute>();
            if (columnAttribute != null && !string.IsNullOrEmpty(columnAttribute.Name))
            {
                columnName = columnAttribute.Name;
            }
            return columnName;
        }
        private IEnumerable<KeyValuePair<string, object>> GetColumnNamedBindings<TModel>(IEnumerable<PropertyInfo> properties, TModel model)
        {
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    yield return new KeyValuePair<string, object>(this.GetColumnName(property), property.GetValue(model));
                }
            }
        }

        protected virtual IEnumerable<PropertyInfo> GetColumnProperties(Type type)
        {
            return type.GetProperties()
                .Where(x => !x.IsDefined(typeof(NotMappedAttribute)));
        }
        protected virtual IEnumerable<PropertyInfo> GetKeyProperties(Type type)
        {
            return this.GetColumnProperties(type)
                .Where(x => x.IsDefined(typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));
        }
        protected virtual IEnumerable<PropertyInfo> GetDatabaseGeneratedProperties(Type type, params DatabaseGeneratedOption[] options)
        {
            return this.GetColumnProperties(type)
                .Where(x => x.GetCustomAttribute<DatabaseGeneratedAttribute>() is DatabaseGeneratedAttribute databaseGenerated
                    && options != null && options.Contains(databaseGenerated.DatabaseGeneratedOption));
        }
        protected virtual IEnumerable<PropertyInfo> GetComputedProperties(Type type)
        {
            return this.GetDatabaseGeneratedProperties(type, DatabaseGeneratedOption.Computed);
        }
        protected virtual PropertyInfo GetIdentityProperty(Type type)
        {
            return this.GetDatabaseGeneratedProperties(type, DatabaseGeneratedOption.Identity).SingleOrDefault();
        }

        public virtual int Count<TModel>(string whereName, object whereValue, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.QueryFirst<int>(q => q
                .From(tableName)
                .Where(whereName, whereValue)
                .AsCount(),
                transaction);
        }
        public virtual int Count<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.QueryFirst<int>(q => q
                .From(tableName)
                .Where(whereColumns)
                .AsCount(),
                transaction);
        }
        public virtual TModel SelectFirstOrDefault<TModel>(string whereName, object whereValue, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.QueryFirstOrDefault<TModel>(q => q
                .From(tableName)
                .Where(whereName, whereValue)
                .Take(1),
                transaction);
        }
        public virtual TModel SelectFirstOrDefault<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.QueryFirstOrDefault<TModel>(q => q
                .From(tableName)
                .Where(whereColumns)
                .Take(1),
                transaction);
        }
        public virtual TModel SelectFirstOrDefault<TModel>(string whereName, object whereValue, string sortName, ListSortDirection sortDirection, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.QueryFirstOrDefault<TModel>(q =>
            {
                q = q.From(tableName)
                    .Where(whereName, whereValue);
                switch (sortDirection)
                {
                    case ListSortDirection.Ascending:
                    default:
                        q = q.OrderBy(sortName);
                        break;
                    case ListSortDirection.Descending:
                        q = q.OrderByDesc(sortName);
                        break;
                }
                return q.Take(1);
            }, transaction);
        }
        public virtual TModel SelectFirstOrDefault<TModel>(string whereName, object whereValue, IEnumerable<KeyValuePair<string, ListSortDirection>> sortColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.QueryFirstOrDefault<TModel>(q =>
            {
                q = q.From(tableName)
                    .Where(whereName, whereValue);
                foreach (var sortColumn in sortColumns)
                {
                    switch (sortColumn.Value)
                    {
                        case ListSortDirection.Ascending:
                        default:
                            q = q.OrderBy(sortColumn.Key);
                            break;
                        case ListSortDirection.Descending:
                            q = q.OrderByDesc(sortColumn.Key);
                            break;
                    }
                }
                return q.Take(1);
            }, transaction);
        }
        public virtual TModel SelectFirstOrDefault<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, string sortName, ListSortDirection sortDirection, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.QueryFirstOrDefault<TModel>(q =>
            {
                q = q.From(tableName)
                    .Where(whereColumns);
                switch (sortDirection)
                {
                    case ListSortDirection.Ascending:
                    default:
                        q = q.OrderBy(sortName);
                        break;
                    case ListSortDirection.Descending:
                        q = q.OrderByDesc(sortName);
                        break;
                }
                return q.Take(1);
            }, transaction);
        }
        public virtual TModel SelectFirstOrDefault<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IEnumerable<KeyValuePair<string, ListSortDirection>> sortColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.QueryFirstOrDefault<TModel>(q =>
            {
                q = q.From(tableName)
                    .Where(whereColumns);
                foreach (var sortColumn in sortColumns)
                {
                    switch (sortColumn.Value)
                    {
                        case ListSortDirection.Ascending:
                        default:
                            q = q.OrderBy(sortColumn.Key);
                            break;
                        case ListSortDirection.Descending:
                            q = q.OrderByDesc(sortColumn.Key);
                            break;
                    }
                }
                return q.Take(1);
            }, transaction);
        }
        public virtual IEnumerable<TModel> Select<TModel>(string whereName, object whereValue, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Query<TModel>(q => q
                .From(tableName)
                .Where(whereName, whereValue),
                transaction);
        }
        public virtual IEnumerable<TModel> Select<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Query<TModel>(q => q
                .From(tableName)
                .Where(whereColumns),
                transaction);
        }
        public virtual IEnumerable<TModel> Select<TModel>(string whereName, object whereValue, string sortName, ListSortDirection sortDirection, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Query<TModel>(q =>
            {
                q = q.From(tableName)
                    .Where(whereName, whereValue);
                switch (sortDirection)
                {
                    case ListSortDirection.Ascending:
                    default:
                        q = q.OrderBy(sortName);
                        break;
                    case ListSortDirection.Descending:
                        q = q.OrderByDesc(sortName);
                        break;
                }
                return q;
            }, transaction);
        }
        public virtual IEnumerable<TModel> Select<TModel>(string whereName, object whereValue, IEnumerable<KeyValuePair<string, ListSortDirection>> sortColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Query<TModel>(q =>
            {
                q = q.From(tableName)
                    .Where(whereName, whereValue);
                foreach (var sortColumn in sortColumns)
                {
                    switch (sortColumn.Value)
                    {
                        case ListSortDirection.Ascending:
                        default:
                            q = q.OrderBy(sortColumn.Key);
                            break;
                        case ListSortDirection.Descending:
                            q = q.OrderByDesc(sortColumn.Key);
                            break;
                    }
                }
                return q;
            }, transaction);
        }
        public virtual IEnumerable<TModel> Select<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, string sortName, ListSortDirection sortDirection, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Query<TModel>(q =>
            {
                q = q.From(tableName)
                    .Where(whereColumns);
                switch (sortDirection)
                {
                    case ListSortDirection.Ascending:
                    default:
                        q = q.OrderBy(sortName);
                        break;
                    case ListSortDirection.Descending:
                        q = q.OrderByDesc(sortName);
                        break;
                }
                return q;
            }, transaction);
        }
        public virtual IEnumerable<TModel> Select<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IEnumerable<KeyValuePair<string, ListSortDirection>> sortColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Query<TModel>(q =>
            {
                q = q.From(tableName)
                    .Where(whereColumns);
                foreach (var sortColumn in sortColumns)
                {
                    switch (sortColumn.Value)
                    {
                        case ListSortDirection.Ascending:
                        default:
                            q = q.OrderBy(sortColumn.Key);
                            break;
                        case ListSortDirection.Descending:
                            q = q.OrderByDesc(sortColumn.Key);
                            break;
                    }
                }
                return q;
            }, transaction);
        }
        public virtual int Insert<TModel>(TModel model, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            var insertProperties = this.GetColumnProperties(typeof(TModel))
                .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity));
            if (!insertProperties.Any())
            {
                throw new NotSupportedException();
            }
            var namedBindings = this.GetColumnNamedBindings(insertProperties, model);
            return this.Execute(q => q
                .From(tableName)
                .AsInsert(namedBindings),
                transaction);
        }
        public virtual int Insert<TModel>(TModel model, out decimal identity, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            var insertProperties = this.GetColumnProperties(typeof(TModel))
                .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity));
            if (!insertProperties.Any())
            {
                throw new NotSupportedException();
            }
            var namedBindings = this.GetColumnNamedBindings(insertProperties, model);
            identity = this.QueryFirst<decimal>(q => q
                .From(tableName)
                .AsInsert(namedBindings, true),
                transaction);
            throw new NotImplementedException();
        }
        public virtual int Insert<TModel>(IEnumerable<TModel> models, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            var insertProperties = this.GetColumnProperties(typeof(TModel))
                .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity))
                .ToList();
            if (!insertProperties.Any())
            {
                throw new NotSupportedException();
            }
            Query query = new Query(tableName);
            foreach (var model in models)
            {
                var namedBindings = this.GetColumnNamedBindings(insertProperties, model);
                query = query.AsInsert(namedBindings);
            }
            return this.Execute(query, transaction);
        }
        public virtual int Insert<TModel>(IEnumerable<TModel> models, out IEnumerable<decimal> identities, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }
        public virtual int Update<TModel>(TModel model, IDbTransaction transaction = null)
        {
            var keyProperties = this.GetKeyProperties(typeof(TModel)).ToList();
            if (!keyProperties.Any())
            {
                throw new NotSupportedException();
            }
            string tableName = this.GetTableName(typeof(TModel));
            var updateProperties = this.GetColumnProperties(typeof(TModel))
                .Except(keyProperties)
                .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity));
            var namedBindings = this.GetColumnNamedBindings(updateProperties, model);
            return this.Execute(q => q
                .From(tableName)
                .Where(this.GetColumnNamedBindings(keyProperties, model))
                .AsUpdate(namedBindings),
                transaction);
        }
        public virtual int Update<TModel>(TModel model, IEnumerable<string> updateColumnNames, IDbTransaction transaction = null)
        {
            if (updateColumnNames != null && updateColumnNames.Any())
            {
                var keyProperties = this.GetKeyProperties(typeof(TModel));
                if (!keyProperties.Any())
                {
                    throw new NotSupportedException();
                }
                string tableName = this.GetTableName(typeof(TModel));
                var updateProperties = this.GetColumnProperties(typeof(TModel))
                    .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity))
                    .Where(x => updateColumnNames.Any(y => string.Equals(x.Name, y, StringComparison.OrdinalIgnoreCase)));
                if (!updateProperties.Any())
                {
                    throw new NotSupportedException();
                }
                var namedBindings = this.GetColumnNamedBindings(updateProperties, model);
                return this.Execute(q => q
                    .From(tableName)
                    .Where(this.GetColumnNamedBindings(keyProperties, model))
                    .AsUpdate(namedBindings),
                    transaction);
            }
            return 0;
        }
        public virtual int Update<TModel>(IEnumerable<TModel> models, IDbTransaction transaction = null)
        {
            var keyProperties = this.GetKeyProperties(typeof(TModel)).ToList();
            if (!keyProperties.Any())
            {
                throw new NotSupportedException();
            }
            string tableName = this.GetTableName(typeof(TModel));
            var updateProperties = this.GetColumnProperties(typeof(TModel))
                .Except(keyProperties)
                .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity))
                .ToList();
            if (!updateProperties.Any())
            {
                throw new NotSupportedException();
            }
            Func<int> execute = () =>
            {
                int count = 0;
                foreach (var model in models)
                {
                    var namedBindings = this.GetColumnNamedBindings(updateProperties, model);
                    count += this.Execute(q => q
                        .From(tableName)
                        .Where(this.GetColumnNamedBindings(keyProperties, model))
                        .AsUpdate(namedBindings),
                        transaction);
                }
                return count;
            };
            if (transaction == null)
            {
                using (var conn = this.CreateConnection())
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    int count = execute.Invoke();
                    transaction.Commit();
                    return count;
                }
            }
            return execute.Invoke();
        }
        public virtual int Update<TModel>(IEnumerable<TModel> models, IEnumerable<string> updateColumnNames, IDbTransaction transaction = null)
        {
            var keyProperties = this.GetKeyProperties(typeof(TModel)).ToList();
            if (!keyProperties.Any())
            {
                throw new NotSupportedException();
            }
            string tableName = this.GetTableName(typeof(TModel));
            var updateProperties = this.GetColumnProperties(typeof(TModel))
                .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity))
                .Where(x => updateColumnNames.Any(y => string.Equals(x.Name, y, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            if (!updateProperties.Any())
            {
                throw new NotSupportedException();
            }
            Func<int> execute = () =>
            {
                int count = 0;
                foreach (var model in models)
                {
                    var namedBindings = this.GetColumnNamedBindings(updateProperties, model);
                    count += this.Execute(q => q
                        .From(tableName)
                        .Where(this.GetColumnNamedBindings(keyProperties, model))
                        .AsUpdate(namedBindings),
                        transaction);
                }
                return count;
            };
            if (transaction == null)
            {
                using (var conn = this.CreateConnection())
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    int count = execute.Invoke();
                    transaction.Commit();
                    return count;
                }
            }
            return execute.Invoke();
        }
        public virtual int Update<TModel>(string updateName, object updateValue, string whereName, object whereValue, IDbTransaction transaction = null)
        {
            return this.Update<TModel>(new[] { new KeyValuePair<string, object>(updateName, updateValue) }, whereName, whereValue, transaction);
        }
        public virtual int Update<TModel>(string updateName, object updateValue, IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null)
        {
            return this.Update<TModel>(new[] { new KeyValuePair<string, object>(updateName, updateValue) }, whereColumns, transaction);
        }
        public virtual int Update<TModel>(IEnumerable<KeyValuePair<string, object>> updateColumns, string whereName, object whereValue, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Execute(q => q
                .From(tableName)
                .Where(whereName, whereValue)
                .AsUpdate(updateColumns),
                transaction);
        }
        public virtual int Update<TModel>(IEnumerable<KeyValuePair<string, object>> updateColumns, IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Execute(q => q
                .From(tableName)
                .Where(whereColumns)
                .AsUpdate(updateColumns),
                transaction);
        }
        public virtual int UpdateIgnore<TModel>(TModel model, IEnumerable<string> ignoreColumnNames, IDbTransaction transaction = null)
        {
            var keyProperties = this.GetKeyProperties(typeof(TModel));
            if (!keyProperties.Any())
            {
                throw new NotSupportedException();
            }
            string tableName = this.GetTableName(typeof(TModel));
            var updateProperties = this.GetColumnProperties(typeof(TModel))
                .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity))
                .Where(x => !ignoreColumnNames.Any(y => string.Equals(x.Name, y, StringComparison.OrdinalIgnoreCase)));
            if (!updateProperties.Any())
            {
                throw new NotSupportedException();
            }
            var namedBindings = this.GetColumnNamedBindings(updateProperties, model);
            return this.Execute(q => q
                .From(tableName)
                .Where(this.GetColumnNamedBindings(keyProperties, model))
                .AsUpdate(namedBindings),
                transaction);
        }
        public virtual int UpdateIgnore<TModel>(IEnumerable<TModel> models, IEnumerable<string> ignoreColumnNames, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            var keyProperties = this.GetKeyProperties(typeof(TModel)).ToList();
            if (!keyProperties.Any())
            {
                throw new NotSupportedException();
            }
            var updateProperties = this.GetColumnProperties(typeof(TModel))
                .Except(this.GetDatabaseGeneratedProperties(typeof(TModel), DatabaseGeneratedOption.Computed, DatabaseGeneratedOption.Identity))
                .Where(x => !ignoreColumnNames.Any(y => string.Equals(x.Name, y, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            if (!updateProperties.Any())
            {
                throw new NotSupportedException();
            }
            Func<int> execute = () =>
            {
                int count = 0;
                foreach (var model in models)
                {
                    var namedBindings = this.GetColumnNamedBindings(updateProperties, model);
                    count += this.Execute(q => q
                        .From(tableName)
                        .Where(this.GetColumnNamedBindings(keyProperties, model))
                        .AsUpdate(namedBindings),
                        transaction);
                }
                return count;
            };
            if (transaction == null)
            {
                using (var conn = this.CreateConnection())
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    int count = execute.Invoke();
                    transaction.Commit();
                    return count;
                }
            }
            return execute.Invoke();
        }
        public virtual int Delete<TModel>(TModel model, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            var keyProperties = this.GetKeyProperties(typeof(TModel));
            if (!keyProperties.Any())
            {
                throw new NotSupportedException();
            }
            return this.Execute(q => q
                .From(tableName)
                .Where(this.GetColumnNamedBindings(keyProperties, model))
                .AsDelete(),
                transaction);
        }
        public virtual int Delete<TModel>(IEnumerable<TModel> models, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            var keyProperties = this.GetKeyProperties(typeof(TModel)).ToList();
            if (!keyProperties.Any())
            {
                throw new NotSupportedException();
            }
            Query query = new Query(tableName);
            foreach (var model in models)
            {
                query.OrWhere(q => q
                    .Where(this.GetColumnNamedBindings(keyProperties, model)));
            }
            query = query.AsDelete();
            return this.Execute(query, transaction);
        }
        public virtual int Delete<TModel>(string whereName, object whereValue, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Execute(q => q
                .From(tableName)
                .Where(whereName, whereValue)
                .AsDelete(),
                transaction);
        }
        public virtual int Delete<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null)
        {
            string tableName = this.GetTableName(typeof(TModel));
            return this.Execute(q => q
                .From(tableName)
                .Where(whereColumns)
                .AsDelete(),
                transaction);
        }
        #endregion
    }
}
