using UnityEngine;
using SystemInfo = UnityEngine.Device.SystemInfo;

public static class DeviceInfoUtility
{
    public static string GetOSVersion()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (var build = new AndroidJavaClass("android.os.Build$VERSION"))
        {
            return $"android {build.GetStatic<string>("RELEASE")}"; // Ví dụ: "13"
        }
#elif UNITY_IOS && !UNITY_EDITOR
        return $"ios {UnityIOSDeviceInfo.GetOSVersion()}";
#else
        return SystemInfo.operatingSystem;
#endif
    }

    public static string GetDeviceBrand()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (var build = new AndroidJavaClass("android.os.Build"))
        {
            return build.GetStatic<string>("BRAND"); // Samsung, Xiaomi...
        }
#elif UNITY_IOS && !UNITY_EDITOR
        return "Apple";
#else
        return "Unknown";
#endif
    }

    public static string GetDeviceModel()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return SystemInfo.deviceModel; // Đã rất chuẩn
#elif UNITY_IOS && !UNITY_EDITOR
        return UnityIOSDeviceInfo.GetDeviceModel(); // model thực (iPhone 13)
#else
        return SystemInfo.deviceModel;
#endif
    }

    public static string GetCPUModel()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (var process = new AndroidJavaClass("android.os.Process"))
        using (var runtime = new AndroidJavaClass("java.lang.Runtime"))
        {
            return SystemInfo.processorType;
        }
#elif UNITY_IOS && !UNITY_EDITOR
        return UnityIOSDeviceInfo.GetCPUModel();
#else
        return SystemInfo.processorType;
#endif
    }

    public static long GetTotalRAM()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return UnityAndroidDeviceInfo.GetTotalRAM() / 1024L / 1024L / 1024L;
#elif UNITY_IOS && !UNITY_EDITOR
        return UnityIOSDeviceInfo.GetTotalRAM() / 1024L / 1024L / 1024L;
#else
        return SystemInfo.systemMemorySize / 1024L;
#endif
    }

    public static long GetTotalStorage()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return UnityAndroidDeviceInfo.GetTotalStorage()  / 1024L / 1024L / 1024L;
#elif UNITY_IOS && !UNITY_EDITOR
        return UnityIOSDeviceInfo.GetTotalStorage()  / 1024L / 1024L / 1024L;
#else
        return 0;
#endif
    }
}