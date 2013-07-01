using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;
using Xunit;

namespace Elmah.AzureStorage.Tests
{
    public static class Constants
    {
        public const int USE_TABLE_STORAGE = 1;
        public const int USE_BLOB_STORAGE = 2;
    }

    public class ExceptionRecord : TableEntity
    {
        public int StorageMethod { get; set; }
    }

    public class KeyManager
    {
        private const string PARTITION_FORMAT = "yyyyMMdd";

        internal void SetKey(ExceptionRecord record, DateTime refDate)
        {
            record.PartitionKey = refDate.ToString(PARTITION_FORMAT);
        }

        internal string NextPartition(string thisPartition)
        {
            DateTime refDate = ParsePartitionDate(thisPartition);

            return refDate.AddDays(1).ToString(PARTITION_FORMAT);
        }

        private static DateTime ParsePartitionDate(string thisPartition)
        {
            string yearString = thisPartition.Substring(0, 4);
            string monthString = thisPartition.Substring(4, 2);
            string dayString = thisPartition.Substring(6, 2);

            return new DateTime(int.Parse(yearString), int.Parse(monthString), int.Parse(dayString));
        }

        internal string PrevPartition(string thisPartition)
        {
            var refDate = ParsePartitionDate(thisPartition);

            return refDate.AddDays(-1).ToString(PARTITION_FORMAT);
        }
    }

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
