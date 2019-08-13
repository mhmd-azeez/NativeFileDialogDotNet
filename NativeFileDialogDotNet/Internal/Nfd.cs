using System.Runtime.InteropServices;

namespace NativeFileDialogDotNet.Internal
{
    internal class Nfd
    {

#if X86
        internal const string DllName = "nfd-x86.dll";
#elif X64
        internal const string DllName = "nfd-x64.dll";
#endif

        /// Return Type: nfdresult_t->Anonymous_db01cab1_f6d3_4a72_acce_74b317f7941c
        ///filterList: nfdchar_t*
        ///defaultPath: nfdchar_t*
        ///outPath: nfdchar_t**
        [DllImport(DllName, EntryPoint = "NFD_OpenDialog")]
        internal static extern nfdresult_t NFD_OpenDialog([In()] byte[] filterList, [In()] byte[] defaultPath, out System.IntPtr outPath);


        /// Return Type: nfdresult_t->Anonymous_db01cab1_f6d3_4a72_acce_74b317f7941c
        ///filterList: nfdchar_t*
        ///defaultPath: nfdchar_t*
        ///outPaths: nfdpathset_t*
        [DllImport(DllName, EntryPoint = "NFD_OpenDialogMultiple")]
        internal static extern nfdresult_t NFD_OpenDialogMultiple([In()] byte[] filterList, [In()] byte[] defaultPath, out nfdpathset_t outPaths);


        /// Return Type: nfdresult_t->Anonymous_db01cab1_f6d3_4a72_acce_74b317f7941c
        ///filterList: nfdchar_t*
        ///defaultPath: nfdchar_t*
        ///outPath: nfdchar_t**
        [DllImport(DllName, EntryPoint = "NFD_SaveDialog")]
        internal static extern nfdresult_t NFD_SaveDialog([In()] byte[] filterList, [In()] byte[] defaultPath, out System.IntPtr outPath);


        /// Return Type: nfdresult_t->Anonymous_db01cab1_f6d3_4a72_acce_74b317f7941c
        ///defaultPath: nfdchar_t*
        ///outPath: nfdchar_t**
        [DllImport(DllName, EntryPoint = "NFD_PickFolder")]
        internal static extern nfdresult_t NFD_PickFolder([In()] byte[] defaultPath, out System.IntPtr outPath);


        /// Return Type: char*
        [DllImport(DllName, EntryPoint = "NFD_GetError")]
        internal static extern System.IntPtr NFD_GetError();


        /// Return Type: size_t->unsigned int
        ///pathSet: nfdpathset_t*
        [DllImport(DllName, EntryPoint = "NFD_PathSet_GetCount")]
        [return: MarshalAs(UnmanagedType.SysUInt)]
        internal static extern uint NFD_PathSet_GetCount(ref nfdpathset_t pathSet);


        /// Return Type: nfdchar_t*
        ///pathSet: nfdpathset_t*
        ///index: size_t->unsigned int
        [DllImport(DllName, EntryPoint = "NFD_PathSet_GetPath")]
        internal static extern System.IntPtr NFD_PathSet_GetPath(in nfdpathset_t pathSet, uint index);


        /// Return Type: void
        ///pathSet: nfdpathset_t*
        [DllImport(DllName, EntryPoint = "NFD_PathSet_Free")]
        internal static extern void NFD_PathSet_Free(ref nfdpathset_t pathSet);

    }


    internal partial class NativeConstants
    {

        /// _NFD_H -> 
        /// Error generating expression: Value cannot be null.
        ///Parameter name: node
        internal const string _NFD_H = "";
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nfdpathset_t
    {

        /// nfdchar_t*
        internal System.IntPtr buf;

        /// size_t*
        internal System.IntPtr indices;

        /// size_t->unsigned int
        internal uint count;
    }

    internal enum nfdresult_t
    {
        NFD_ERROR = 0,
        NFD_OKAY = 1,
        NFD_CANCEL = 2
    }
}
