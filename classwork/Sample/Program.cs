using System.Runtime.InteropServices;

long MaxAddress = 0x7fffffff;
long address = 0; do
{
    MEMORY_BASIC_INFORMATION m;
    int result = VirtualQueryEx(System.Diagnostics.Process.GetCurrentProcess().Handle, (IntPtr)address, out m, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION))); Console.Write(m.State);
    Console.Write("{0}-{1} : {2} bytes result={3}", m.BaseAddress, (uint)m.BaseAddress + (uint)m.RegionSize - 1, m.RegionSize, result); if (address == (long)m.BaseAddress + (long)m.RegionSize)
        break; address = (long)m.BaseAddress + (long)m.RegionSize;
    Console.WriteLine();
} while (address <= MaxAddress);


[DllImport("kernel32.dll")] static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);
public enum Type : uint
{
    MEM_IMAGE = 0x1000000,
    MEM_MAPPED = 0x40000, MEM_PRIVATE = 0x20000
}
public enum State : uint
{
    MEM_COMMIT = 0x1000,
    MEM_FREE = 0x10000, MEM_RESERVE = 0x2000
}
public enum AllocationProtect : uint
{
    PAGE_EXECUTE = 0x00000010,
    PAGE_EXECUTE_READ = 0x00000020, PAGE_EXECUTE_READWRITE = 0x00000040,
    PAGE_EXECUTE_WRITECOPY = 0x00000080, PAGE_NOACCESS = 0x00000001,
    PAGE_READONLY = 0x00000002, PAGE_READWRITE = 0x00000004,
    PAGE_WRITECOPY = 0x00000008,
    PAGE_GUARD = 0x00000100, PAGE_NOCACHE = 0x00000200,
    PAGE_WRITECOMBINE = 0x00000400
}
[StructLayout(LayoutKind.Sequential)]
public struct MEMORY_BASIC_INFORMATION
{
    public IntPtr BaseAddress;
    public IntPtr AllocationBase; public AllocationProtect AllocationProtect;
    public IntPtr RegionSize; public State State;
    public uint Protect; public Type Type;
}