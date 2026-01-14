#if UNITY_IOS && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace DBD.DeviceInfo
{
    public static class UnityIOSDeviceInfo
    {
#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")] private static extern string _iOSGetOSVersion();
    [DllImport("__Internal")] private static extern string _iOSGetDeviceModel();
    [DllImport("__Internal")] private static extern string _iOSGetCPUModel();
    [DllImport("__Internal")] private static extern long _iOSGetTotalRAM();
    [DllImport("__Internal")] private static extern long _iOSGetTotalStorage();

    public static string GetOSVersion() => _iOSGetOSVersion();
    public static string GetDeviceModel() => _iOSGetDeviceModel();
    public static string GetCPUModel() => _iOSGetCPUModel();
    public static long GetTotalRAM() => _iOSGetTotalRAM();
    public static long GetTotalStorage() => _iOSGetTotalStorage();
#endif
    }
}