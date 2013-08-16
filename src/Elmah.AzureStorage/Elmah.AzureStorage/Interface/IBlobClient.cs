using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elmah.AzureStorage.Interface
{
    public interface IBlobClient
    {
        void Save(ExceptionRecord record);

        ExceptionRecord Load(string container, string filename);
    }
}
