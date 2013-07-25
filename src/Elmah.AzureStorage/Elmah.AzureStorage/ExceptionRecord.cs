using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmah.AzureStorage
{
    public class ExceptionRecord : TableEntity
    {
        public int StorageMethod { get; set; }
    }
}
