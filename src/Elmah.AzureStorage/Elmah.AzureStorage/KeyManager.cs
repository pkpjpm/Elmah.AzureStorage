using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmah.AzureStorage
{
    public static class KeyManager
    {
        private const string PARTITION_FORMAT = "yyyyMMdd";

        public static void SetKey(ExceptionRecord record, DateTime refDate)
        {
            record.PartitionKey = refDate.ToString(PARTITION_FORMAT);
        }

        public static string NextPartition(string thisPartition)
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

        public static string PrevPartition(string thisPartition)
        {
            var refDate = ParsePartitionDate(thisPartition);

            return refDate.AddDays(-1).ToString(PARTITION_FORMAT);
        }

        public static string EncodeKeys(ExceptionRecord record)
        {
            return string.Empty;
        }
    }
}
