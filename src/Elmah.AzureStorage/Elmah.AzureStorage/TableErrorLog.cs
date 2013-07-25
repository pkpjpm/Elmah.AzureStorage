using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elmah.AzureStorage
{
    class TableErrorLog : ErrorLog
    {
        StorageManager _storage;

        public TableErrorLog(IDictionary config)
        {
            string connectionString = (string)config["connectionString"];
            //?? RoleEnvironment.GetConfigurationSettingValue((string)config["connectionStringName"]);

            _storage = new StorageManager(connectionString);
        }

        public TableErrorLog(string connectionString)
        {
            _storage = new StorageManager(connectionString);
        }

        public override ErrorLogEntry GetError(string id)
        {
            var error = _storage.RetrieveError(id);
            return new ErrorLogEntry(this, id, ErrorXml.DecodeString(error.SerializedError));
        }

        public override int GetErrors(int pageIndex, int pageSize, System.Collections.IList errorEntryList)
        {
            foreach (var error in _storage.GetPage(pageIndex, pageSize))
            {
                var logEntry = ErrorXml.DecodeString(error.SerializedError);
                errorEntryList.Add(logEntry);
            }

            return _storage.ErrorCount;
        }

        public override string Log(Error error)
        {
            var errorToStore = new ExceptionRecord
            {
                SerializedError = ErrorXml.EncodeString(error)
            };

            return _storage.StoreError(errorToStore);
        }
    }
}
