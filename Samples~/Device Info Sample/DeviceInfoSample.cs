using UnityEngine;

namespace DBD.DeviceInfo.Sample
{
    public class DeviceInfoSample : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            string info = $"OS: {DeviceInfoUtility.GetOSVersion()}\n" +
                          $"Brand: {DeviceInfoUtility.GetDeviceBrand()}\n" +
                          $"Model: {DeviceInfoUtility.GetDeviceModel()}\n" +
                          $"CPU: {DeviceInfoUtility.GetCPUModel()}\n" +
                          $"RAM: {DeviceInfoUtility.GetTotalRAM()}\n" +
                          $"Storage: {DeviceInfoUtility.GetTotalStorage()}";
            Debug.Log($"datdb - info {info}");
        }
    }
}