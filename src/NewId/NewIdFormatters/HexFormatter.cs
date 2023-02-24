﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace FSH.NewId.NewIdFormatters;

#if NET6_0_OR_GREATER

#endif

public class HexFormatter :
    INewIdFormatter
{
    private const    uint LowerCaseUInt = 0x2020U;
    private readonly uint _alpha;

    public HexFormatter(bool upperCase = false) => _alpha = upperCase ? 0 : LowerCaseUInt;

    public unsafe string Format(in byte[] bytes)
    {
        Debug.Assert(bytes.Length == 16);

#if NET6_0_OR_GREATER
        if (Avx2.IsSupported && BitConverter.IsLittleEndian)
        {
            var isUpperCase = _alpha != LowerCaseUInt;

            return string.Create(32, (bytes, isUpperCase), (span, state) =>
            {
                var (bytes, isUpper) = state;

                var inputVec = MemoryMarshal.Read<Vector128<byte>>(bytes);
                var hexVec   = IntrinsicsHelper.EncodeBytesHex(inputVec, isUpper);

                var byteSpan = MemoryMarshal.Cast<char, byte>(span);
                IntrinsicsHelper.Vector256ToCharUtf16(hexVec, byteSpan);
            });
        }
#endif
        var result = stackalloc char[32];

        for (var pos = 0; pos < bytes.Length; pos++) HexToChar(bytes[pos], result, pos * 2, _alpha);

        return new string(result, 0, 32);
    }

    // From https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/System/HexConverter.cs#L83
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe void HexToChar(byte value, char* buffer, int startingIndex, uint casing)
    {
        var difference   = ((value & 0xF0U) << 4) + (value & 0x0FU) - 0x8989U;
        var packedResult = ((((uint)-(int)difference & 0x7070U) >> 4) + difference + 0xB9B9U) | casing;

        buffer[startingIndex + 1] = (char)(packedResult & 0xFF);
        buffer[startingIndex]     = (char)(packedResult >> 8);
    }
}
