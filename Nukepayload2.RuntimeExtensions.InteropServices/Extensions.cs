using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Text;

namespace Nukepayload2.RuntimeExtensions.InteropServices
{
    /// <summary>
    /// Make Visual Basic codes accessible to unsafe members of bcl types. This standard module is designed for Visual Basic and not intended to use in C# or F#.
    /// </summary>
    [StandardModule, HideModuleName]
    public static class Extensions
    {
        /// <summary>
        /// Gets the pointer that points to to the current position.
        /// </summary>
        public static unsafe IntPtr DangerousGetPositionPointer(this UnmanagedMemoryStream strm)
        {
            return new IntPtr(strm.PositionPointer);
        }
        /// <summary>
        /// Sets the pointer that points to to the current position.
        /// </summary>
        public static unsafe void DangerousSetPositionPointer(this UnmanagedMemoryStream strm, IntPtr ptr)
        {
            strm.PositionPointer = (byte*)ptr;
        }
        /// <summary>
        /// Appends characters from the specified address and count.
        /// </summary>
        public static unsafe StringBuilder DangerousAppend(this StringBuilder sb, IntPtr chrPtr, int charCount)
        {
            return sb.Append((char*)chrPtr, charCount);
        }
        /// <summary>
        /// Calculates the length of decoded buffer in bytes.
        /// </summary>
        public static unsafe int GetByteCount(this Encoding encoding, IntPtr chrPtr, int charCount)
        {
            return encoding.GetByteCount((char*)chrPtr, charCount);
        }
        /// <summary>
        /// Decodes characters in the specified buffer to another buffer.
        /// </summary>
        public static unsafe int GetBytes(this Encoding encoding, IntPtr chrPtr, int charCount, IntPtr outBuffer, int outBufferLength)
        {
            return encoding.GetBytes((char*)chrPtr, charCount, (byte*)outBuffer, outBufferLength);
        }
        /// <summary>
        /// Calculates the count of encoded characters.
        /// </summary>
        public static unsafe int GetCharCount(this Encoding encoding, IntPtr ptr, int length)
        {
            return encoding.GetCharCount((byte*)ptr, length);
        }
        /// <summary>
        /// Encodes raw bytes in the specified buffer to a buffer of characters.
        /// </summary>
        public static unsafe int GetChars(this Encoding encoding, IntPtr ptr, int length, IntPtr outChars, int outCharsCount)
        {
            return encoding.GetChars((byte*)ptr, length, (char*)outChars, outCharsCount);
        }
    }
}
