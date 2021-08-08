using Dapper;
using SqlKata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace Mao.Repository
{
    public interface IRepository
    {
        string ConnectionString { get; }
        IDbConnection CreateConnection();

        #region For Dapper
        int Execute(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        object ExecuteScalar(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        T ExecuteScalar<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        IDataReader ExecuteReader(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<dynamic> Query(string sql, object param, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null);
        IEnumerable<T> Query<T>(string sql, object param, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null);
        dynamic QueryFirst(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        T QueryFirst<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QueryFirstOrDefault(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        T QueryFirstOrDefault<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QuerySingle(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        T QuerySingle<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QuerySingleOrDefault(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        T QuerySingleOrDefault<T>(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        SqlMapper.GridReader QueryMultiple(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        #endregion
        #region For SqlKata To Dapper
        int Execute(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        object ExecuteScalar(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        T ExecuteScalar<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        IDataReader ExecuteReader(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<dynamic> Query(Func<Query, Query> queryFunc, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null);
        IEnumerable<T> Query<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null);
        dynamic QueryFirst(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        T QueryFirst<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QueryFirstOrDefault(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        T QueryFirstOrDefault<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QuerySingle(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        T QuerySingle<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QuerySingleOrDefault(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        T QuerySingleOrDefault<T>(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        SqlMapper.GridReader QueryMultiple(Func<Query, Query> queryFunc, IDbTransaction transaction = null, int? commandTimeout = null);
        int Execute(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        object ExecuteScalar(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        T ExecuteScalar<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        IDataReader ExecuteReader(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<dynamic> Query(Query query, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null);
        IEnumerable<T> Query<T>(Query query, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null);
        dynamic QueryFirst(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        T QueryFirst<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QueryFirstOrDefault(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        T QueryFirstOrDefault<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QuerySingle(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        T QuerySingle<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QuerySingleOrDefault(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        T QuerySingleOrDefault<T>(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        SqlMapper.GridReader QueryMultiple(Query query, IDbTransaction transaction = null, int? commandTimeout = null);
        int Execute(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        object ExecuteScalar(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        T ExecuteScalar<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        IDataReader ExecuteReader(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<dynamic> Query(SqlResult sqlResult, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null);
        IEnumerable<T> Query<T>(SqlResult sqlResult, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null);
        dynamic QueryFirst(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        T QueryFirst<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QueryFirstOrDefault(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        T QueryFirstOrDefault<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QuerySingle(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        T QuerySingle<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        dynamic QuerySingleOrDefault(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        T QuerySingleOrDefault<T>(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        SqlMapper.GridReader QueryMultiple(SqlResult sqlResult, IDbTransaction transaction = null, int? commandTimeout = null);
        #endregion
        #region Entity
        string GetTableName(Type type);
        string GetColumnName(PropertyInfo property);
        int Count<TModel>(string whereName, object whereValue, IDbTransaction transaction = null);
        int Count<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null);
        TModel SelectFirstOrDefault<TModel>(string whereName, object whereValue, IDbTransaction transaction = null);
        TModel SelectFirstOrDefault<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null);
        TModel SelectFirstOrDefault<TModel>(string whereName, object whereValue, string sortName, ListSortDirection sortDirection, IDbTransaction transaction = null);
        TModel SelectFirstOrDefault<TModel>(string whereName, object whereValue, IEnumerable<KeyValuePair<string, ListSortDirection>> sortColumns, IDbTransaction transaction = null);
        TModel SelectFirstOrDefault<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, string sortName, ListSortDirection sortDirection, IDbTransaction transaction = null);
        TModel SelectFirstOrDefault<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IEnumerable<KeyValuePair<string, ListSortDirection>> sortColumns, IDbTransaction transaction = null);
        IEnumerable<TModel> Select<TModel>(string whereName, object whereValue, IDbTransaction transaction = null);
        IEnumerable<TModel> Select<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null);
        IEnumerable<TModel> Select<TModel>(string whereName, object whereValue, string sortName, ListSortDirection sortDirection, IDbTransaction transaction = null);
        IEnumerable<TModel> Select<TModel>(string whereName, object whereValue, IEnumerable<KeyValuePair<string, ListSortDirection>> sortColumns, IDbTransaction transaction = null);
        IEnumerable<TModel> Select<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, string sortName, ListSortDirection sortDirection, IDbTransaction transaction = null);
        IEnumerable<TModel> Select<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IEnumerable<KeyValuePair<string, ListSortDirection>> sortColumns, IDbTransaction transaction = null);
        int Insert<TModel>(TModel model, IDbTransaction transaction = null);
        int Insert<TModel>(TModel model, out decimal identity, IDbTransaction transaction = null);
        int Insert<TModel>(IEnumerable<TModel> models, IDbTransaction transaction = null);
        int Insert<TModel>(IEnumerable<TModel> models, out IEnumerable<decimal> identities, IDbTransaction transaction = null);
        int Update<TModel>(TModel model, IDbTransaction transaction = null);
        int Update<TModel>(TModel model, IEnumerable<string> updateColumnNames, IDbTransaction transaction = null);
        int Update<TModel>(IEnumerable<TModel> models, IDbTransaction transaction = null);
        int Update<TModel>(IEnumerable<TModel> models, IEnumerable<string> updateColumnNames, IDbTransaction transaction = null);
        int Update<TModel>(string updateName, object updateValue, string whereName, object whereValue, IDbTransaction transaction = null);
        int Update<TModel>(string updateName, object updateValue, IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null);
        int Update<TModel>(IEnumerable<KeyValuePair<string, object>> updateColumns, string whereName, object whereValue, IDbTransaction transaction = null);
        int Update<TModel>(IEnumerable<KeyValuePair<string, object>> updateColumns, IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null);
        int UpdateIgnore<TModel>(TModel model, IEnumerable<string> ignoreColumnNames, IDbTransaction transaction = null);
        int UpdateIgnore<TModel>(IEnumerable<TModel> models, IEnumerable<string> ignoreColumnNames, IDbTransaction transaction = null);
        int Delete<TModel>(TModel model, IDbTransaction transaction = null);
        int Delete<TModel>(IEnumerable<TModel> models, IDbTransaction transaction = null);
        int Delete<TModel>(string whereName, object whereValue, IDbTransaction transaction = null);
        int Delete<TModel>(IEnumerable<KeyValuePair<string, object>> whereColumns, IDbTransaction transaction = null);
        #endregion
    }
}
