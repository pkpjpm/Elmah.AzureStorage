using Elmah.AzureStorage.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elmah.AzureStorage
{
    public class StorageManager
    {
        private ITableClient _tables;

        public StorageManager(ITableClient tables, IBlobClient blobs)
        {
            _tables = tables;
        }

        public int ErrorCount
        {
            get { throw new NotImplementedException(); }
        }

        public string StoreError(ExceptionRecord error)
        {
            _tables.Save(error);

            return KeyManager.EncodeKeys(error);
        }

        public ExceptionRecord RetrieveError(string id)
        {
            throw new NotImplementedException();
        }

        public ExceptionRecord[] GetPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
