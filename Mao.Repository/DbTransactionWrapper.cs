using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Mao.Repository
{
    public class DbTransactionWrapper : IDbTransaction
    {
        private readonly IDbTransaction _transaction;
        public DbTransactionWrapper(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public IDbConnection Connection => _transaction.Connection;
        public IsolationLevel IsolationLevel => _transaction.IsolationLevel;
        public void Commit() => _transaction.Commit();
        public void Rollback() => _transaction.Rollback();
        public void Dispose()
        {
            var connection = _transaction.Connection;
            _transaction.Dispose();
            connection.Dispose();
        }
    }
}
