using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmah.AzureStorage
{
    public static class Constants
    {
        public const int USE_TABLE_STORAGE = 1;
        public const int USE_BLOB_STORAGE = 2;

        public const int AZURE_TABLE_PROP_SIZE_LIMIT = 0x8000; //32k in unicode = 64k binary
    }
}
