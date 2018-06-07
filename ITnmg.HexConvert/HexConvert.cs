using System;
using System.Text.RegularExpressions;

namespace ITnmg.HexConvert
{
    /// <summary>
    /// Hexadecimal string and byte arrays convert to each other
    /// </summary>
    public static class HexConvert
    {
        /// <summary>
		/// Convert the byte arrays to hexadecimal string
		/// </summary>
		/// <param name="bytes">byte arrays</param>
		/// <exception cref="ArgumentNullException">When the bytes is null</exception>
		/// <returns>Hexadecimal string</returns>
		public static string ToHexString( this byte[] bytes )
        {
            if ( bytes == null )
            {
                throw new ArgumentNullException( nameof( bytes ) );
            }

            return BitConverter.ToString( bytes ).Replace( "-", "" );
        }

        /// <summary>
        /// Verify if that string is a hexadecimal string
        /// </summary>
        /// <param name="hexStr">A string</param>
        /// <returns>True or False</returns>
        public static bool IsHexString( this string hexStr )
        {
            bool result = true;

            switch ( hexStr )
            {
                case string val when string.IsNullOrWhiteSpace( val ):
                    result = false;
                    break;
                case string val when val.Length % 2 > 0:
                    result = false;
                    break;
                case string val when !Regex.IsMatch( hexStr, @"^[0-9a-fA-F]*$" ):
                    result = false;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Convert the hexadecimal string to byte arrays
        /// </summary>
        /// <param name="hexStr">Hexadecimal string</param>
        /// <exception cref="ArgumentNullException">When the hexStr is null</exception>
        /// <exception cref="ArgumentException">When hexStr.Length is odd, or hexStr without 0-9, a-f, A-F</exception>
        /// <returns>null or byte arrays</returns>
        public static byte[] ToBytes( string hexStr )
        {
            if ( hexStr == null )
            {
                throw new ArgumentNullException( nameof( hexStr ) );
            }

            if ( hexStr.Length % 2 > 0 )
            {
                throw new ArgumentException( "The length of " + nameof( hexStr ) + " must be even" );
            }

            if ( !Regex.IsMatch( hexStr, @"^[0-9a-fA-F]*$" ) )
            {
                throw new ArgumentException( nameof( hexStr ) + " is not a valid hexadecimal string" );
            }

            byte[] result = null;

            if ( hexStr.Length > 0 )
            {
                result = new byte[hexStr.Length / 2];
                var span = hexStr.AsSpan();

                for ( int i = 0; i < span.Length / 2; i++ )
                {
                    result[i] = Convert.ToByte( span.Slice( i * 2, 2 ).ToString(), 16 );
                }
            }

            return result;
        }
    }
}
