using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elmah.AzureStorage.Interface
{
    public interface ITableClient
    {
        void Save(ExceptionRecord record);

        ExceptionRecord Load(string partition, string rowKey);
    }
}
