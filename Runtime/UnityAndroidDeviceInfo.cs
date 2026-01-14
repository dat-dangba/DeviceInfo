using UnityEngine;

namespace DBD.DeviceInfo
{
    public class UnityAndroidDeviceInfo
    {
        public static long GetTotalRAM()
        {
            using (var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (var context = activity.GetStatic<AndroidJavaObject>("currentActivity"))
            using (var actMan = context.Call<AndroidJavaObject>("getSystemService", "activity"))
            {
                AndroidJavaObject memInfo = new AndroidJavaObject("android.app.ActivityManager$MemoryInfo");
                actMan.Call("getMemoryInfo", memInfo);

                long totalMem = memInfo.Get<long>("totalMem"); // bytes
                return totalMem;
            }
        }

        public static long GetTotalStorage()
        {
            using (var statFs = new AndroidJavaObject("android.os.StatFs", "/data"))
            {
                long blockSize = statFs.Call<long>("getBlockSizeLong");
                long blockCount = statFs.Call<long>("getBlockCountLong");

                return blockSize * blockCount; // bytes
            }
        }
    }
}