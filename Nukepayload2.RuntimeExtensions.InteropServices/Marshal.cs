using System;
using System.IO;
using System.Security;

namespace Nukepayload2.RuntimeExtensions.InteropServices
{
    /// <summary>
    /// Provides helper methods for creating objects in unsafe manner. This class is designed for Visual Basic and not intended to use in C# or F#.
    /// </summary>
    public static class Marshal
    {
        /// <summary>
        /// Creates a <see cref="Span{T}"/> from unmanaged memory.
        /// </summary>
        public static unsafe Span<T> UnsafeCreateSpan<T>(IntPtr ptr, int length)
        {
            return new Span<T>((void*)ptr, length);
        }
        /// <summary>
        /// Creates a <see cref="ReadOnlySpan{T}"/> from unmanaged memory.
        /// </summary>
        public static unsafe ReadOnlySpan<T> UnsafeCreateReadOnlySpan<T>(IntPtr ptr, int length)
        {
            return new ReadOnlySpan<T>((void*)ptr, length);
        }
        /// <summary>
        /// Creates a <see cref="UnmanagedMemoryStream"/> from unmanaged memory.
        /// </summary>
        public static unsafe UnmanagedMemoryStream UnsafeCreateUnmanagedMemoryStream(IntPtr ptr, long length)
        {
            return new UnmanagedMemoryStream((byte*)ptr, length);
        }
        /// <summary>
        /// Creates a <see cref="UnmanagedMemoryStream"/> from unmanaged memory.
        /// </summary>
        public static unsafe UnmanagedMemoryStream UnsafeCreateUnmanagedMemoryStream(IntPtr ptr, long length, long capacity, FileAccess access)
        {
            return new UnmanagedMemoryStream((byte*)ptr, length, capacity, access);
        }
        /// <summary>
        /// Creates a <see cref="string"/> from unmanaged memory which contains a null-terminated UTF-16 string.
        /// </summary>
        public static unsafe string UnsafeCreateNullTerminatedString(IntPtr chrPtr)
        {
            return new string((char*)chrPtr);
        }
        /// <summary>
        /// Creates a <see cref="string"/> from unmanaged memory which contains a UTF-16 string.
        /// </summary>
        public static unsafe string UnsafeCreateString(IntPtr chrPtr, int startIndex, int charCount)
        {
            return new string((char*)chrPtr, startIndex, charCount);
        }
        /// <summary>
        /// Creates a <see cref="SecureString"/> from unmanaged memory which contains a UTF-16 string.
        /// </summary>
        public static unsafe SecureString UnsafeCreateSecureString(IntPtr chrPtr, int charCount)
        {
            return new SecureString((char*)chrPtr, charCount);
        }
    }
}
