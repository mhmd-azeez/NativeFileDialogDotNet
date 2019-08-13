using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NativeFileDialogDotNet.Internal
{
    internal static class StringHelper
    {
        internal static byte[] EncodeUtf8String(string text)
        {
            if (text is null) return null;

            return Encoding.UTF8.GetBytes(text);
        }

        internal static string DecodeUtf8String(IntPtr pointer)
        {
            if (pointer == IntPtr.Zero)
                throw new ArgumentNullException(nameof(pointer));

            var length = Marshal.PtrToStringAnsi(pointer).Length;

            var bytes = new byte[length];
            Marshal.Copy(pointer, bytes, 0, length);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
