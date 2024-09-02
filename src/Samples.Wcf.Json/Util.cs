using System;
using Oracle.DataAccess.Client;

namespace Samples.Wcf.Json
{
    internal static class Util
    {
        internal static string CastNullToString(OracleDataReader reader, string column)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                return reader.GetString(reader.GetOrdinal(column)).Trim();
            return null;
        }

        internal static Decimal? CastNullToDecimal(OracleDataReader reader, string column)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                return reader.GetDecimal(reader.GetOrdinal(column));
            return null;
        }

        internal static DateTime? CastNullToDateTime(OracleDataReader reader, string column)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                return reader.GetDateTime(reader.GetOrdinal(column));
            return null;
        }

        internal static int? CastNullToInt(OracleDataReader reader, string column)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                return reader.GetInt32(reader.GetOrdinal(column));
            return null;
        }
    }
}