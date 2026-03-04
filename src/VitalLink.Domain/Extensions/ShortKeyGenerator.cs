namespace VitalLink.Extensions;

using System;
using System.Text;

public static class ShortKeyGenerator
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly DateTime CustomEpoch = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static string GenerateSixCharKey()
    {
        long secondsSinceEpoch = (long)(DateTime.UtcNow - CustomEpoch).TotalSeconds;
        return EncodeBase62(secondsSinceEpoch).PadLeft(6, '0');
    }

    private static string EncodeBase62(long value)
    {
        if (value == 0) return Alphabet[0].ToString();

        var sb = new StringBuilder();
        while (value > 0)
        {
            sb.Insert(0, Alphabet[(int)(value % 62)]);
            value /= 62;
        }

        return sb.ToString();
    }
}