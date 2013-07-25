using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;
using Xunit;

namespace Elmah.AzureStorage.Tests
{
    public class KeyTests
    {
        [Fact]
        public void PartitionIsBasedOnTheCurrentDay()
        {
            var record = new ExceptionRecord
            {
                StorageMethod = Constants.USE_TABLE_STORAGE
            };

            var refDate = DateTime.Parse("7/4/1776");

            var mgr = new KeyManager();

            mgr.SetKey(record, refDate);

            Assert.Equal("17760704", record.PartitionKey);
        }

        [Fact]
        public void NextPartitionIsNextDay()
        {
            string thisPartition = "20081231";

            var mgr = new KeyManager();

            string nextPartition = mgr.NextPartition(thisPartition);

            Assert.Equal("20090101", nextPartition);
        }

        [Fact]
        public void PrevPartitionIsDayBefore()
        {
            string thisPartition = "20120101";

            var mgr = new KeyManager();

            string prevPartition = mgr.PrevPartition(thisPartition);

            Assert.Equal("20111231", prevPartition);
        }

        [Fact]
        public void NextPartitionMidMonthIsNextDay()
        {
            string thisPartition = "20130315";

            var mgr = new KeyManager();

            string nextPartition = mgr.NextPartition(thisPartition);

            Assert.Equal("20130316", nextPartition);
        }

    }
}
