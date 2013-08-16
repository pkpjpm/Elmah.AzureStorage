using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Moq;
using Elmah.AzureStorage.Interface;

namespace Elmah.AzureStorage.Tests
{
    public class StorageManagerTests
    {
        [Fact]
        public void StorageManagerStoreSmallErrorTextDirectlyInTable()
        {
            var tableMock = new Mock<ITableClient>();

            var blobMock = new Mock<IBlobClient>();

            var mgr = new StorageManager(tableMock.Object, blobMock.Object);

            var record = new ExceptionRecord
            {
                SerializedError = "Small Error"
            };

            mgr.StoreError(record);

            tableMock.Verify(x => x.Save(It.Is<ExceptionRecord>(r => r == record)));
        }

    }
}
