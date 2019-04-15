# ITnmg.HexConvert
字节数组与16进制字符串互转。
Hexadecimal string and byte arrays convert to each other

# Install

Run the following command in the Package Manager Console.  
在 nuget 包管理器控制台输入以下命令

    PM> Install-Package ITnmg.HexConvert

# Usage
    
    var bytes = new byte[]{0xAA, 0xBB, 0xCC};
    var hex = bytes.ToHexString( " " );

    if ( hex.IsHexString() )
    {
        var tmpBytes = hex.ToBytes();
    }