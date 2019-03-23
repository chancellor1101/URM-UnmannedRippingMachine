using System;
using System.Runtime.InteropServices;

namespace URM_Unmanned_Ripping_Machine
{
    internal static class EjectMedia
    {
        // Constants used in DLL methods
        private const uint Genericread = 0x80000000;
        private const uint Openexisting = 3;
        private const uint IoctlStorageEjectMedia = 2967560;
        private const int InvalidHandle = -1;

        // File Handle
        private static IntPtr _fileHandle;
        private static uint _returnedBytes;
        // Use Kernel32 via interop to access required methods
        // Get a File Handle
        [DllImport("kernel32", SetLastError = true)]
        private static extern IntPtr CreateFile(string fileName,
            uint desiredAccess,
            uint shareMode,
            IntPtr attributes,
            uint creationDisposition,
            uint flagsAndAttributes,
            IntPtr templateFile);
        [DllImport("kernel32", SetLastError = true)]
        private static extern int CloseHandle(IntPtr driveHandle);
        [DllImport("kernel32", SetLastError = true)]
        private static extern bool DeviceIoControl(IntPtr driveHandle,
            uint ioControlCode,
            IntPtr lpInBuffer,
            uint inBufferSize,
            IntPtr lpOutBuffer,
            uint outBufferSize,
            ref uint lpBytesReturned,
            IntPtr lpOverlapped);

        public static void Eject(string driveLetter)
        {
            try
            {
                // Create an handle to the drive
                _fileHandle = CreateFile(driveLetter,
                    Genericread,
                    0,
                    IntPtr.Zero,
                    Openexisting,
                    0,
                    IntPtr.Zero);
                if ((int)_fileHandle != InvalidHandle)
                {
                    // Eject the disk
                    DeviceIoControl(_fileHandle,
                        IoctlStorageEjectMedia,
                        IntPtr.Zero, 0,
                        IntPtr.Zero, 0,
                        ref _returnedBytes,
                        IntPtr.Zero);
                }
            }
            catch
            {
                throw new Exception(Marshal.GetLastWin32Error().ToString());
            }
            finally
            {
                // Close Drive Handle
                CloseHandle(_fileHandle);
                _fileHandle = IntPtr.Zero;
            }
        }
    }
}