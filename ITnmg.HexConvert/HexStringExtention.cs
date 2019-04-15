using System;
using System.Text.RegularExpressions;


/// <summary>
/// Hexadecimal string and byte arrays convert to each other
/// </summary>
public static class HexStringExtention
{
    /// <summary>
    /// 将字节数组转换为16进制字符串。
    /// Convert the byte arrays to hexadecimal string
    /// </summary>
    /// <param name="bytes">字节数组。byte arrays</param>
    /// <param name="separator">分隔符。separator</param>
    /// <exception cref="ArgumentNullException">如果字节数组为 null,将抛出异常。When the bytes is null</exception>
    /// <returns>Hexadecimal string</returns>
    public static string ToHexString( this byte[] bytes, string separator = "" )
    {
        if ( bytes == null )
        {
            throw new ArgumentNullException( nameof( bytes ) );
        }

        return BitConverter.ToString( bytes ).Replace( "-", separator );
    }

    /// <summary>
    /// 验证字符串是否为16进制数字表示。Verify if that string is a hexadecimal string
    /// </summary>
    /// <param name="hexStr">要验证的字符串。A string</param>
    /// <param name="separator">分隔符。separator</param>
    /// <returns>True or False</returns>
    public static bool IsHexString( this string hexStr, string separator = "" )
    {
        bool result = false;

        if ( !string.IsNullOrWhiteSpace( hexStr ) )
        {
            var str = string.IsNullOrEmpty( separator ) ? hexStr : hexStr.Replace( separator, "" );

            if ( str.Length % 2 == 0 && Regex.IsMatch( str, @"^[0-9a-fA-F]*$" ) )
            {
                result = true;
            }
        }

        return result;
    }

    /// <summary>
    /// 将16进制字符串转换为字节数组。Convert the hexadecimal string to byte arrays
    /// </summary>
    /// <param name="hexStr">16进制字符串，长度必须为偶数位。Hexadecimal string</param>
    /// <param name="separator">分隔符。separator</param>
    /// <exception cref="ArgumentNullException">如果字符串为 null，将抛出异常。When the hexStr is null</exception>
    /// <exception cref="ArgumentException">如果字符串长度为奇数，或字符串中包含非 0-9, a-f, A-F 的字符，将抛出异常。When hexStr.Length is odd, or hexStr without 0-9, a-f, A-F</exception>
    /// <returns>null or byte arrays</returns>
    public static byte[] ToBytes( this string hexStr, string separator = "" )
    {
        if ( hexStr == null )
        {
            throw new ArgumentNullException( nameof( hexStr ) );
        }

        var str = string.IsNullOrEmpty( separator ) ? hexStr : hexStr.Replace( separator, "" );

        if ( str.Length % 2 > 0 )
        {
            throw new ArgumentException( "The length of " + nameof( hexStr ) + " must be even" );
        }

        if ( !Regex.IsMatch( str, @"^[0-9a-fA-F]*$" ) )
        {
            throw new ArgumentException( nameof( hexStr ) + " is not a valid hexadecimal string" );
        }

        byte[] result = null;

        if ( str.Length > 0 )
        {
            result = new byte[str.Length / 2];
            var span = str.AsSpan();

            for ( int i = 0; i < span.Length / 2; i++ )
            {
                result[i] = Convert.ToByte( span.Slice( i * 2, 2 ).ToString(), 16 );
            }
        }

        return result;
    }
}
