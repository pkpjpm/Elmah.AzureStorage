using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elmah.AzureStorage
{
    public class StorageManager
    {
        public StorageManager(string connectionString)
        {

        }

        public int ErrorCount
        {
            get { throw new NotImplementedException(); }
        }

        public string StoreError(ExceptionRecord error)
        {
            throw new NotImplementedException();
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
