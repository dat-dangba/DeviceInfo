#if UNITY_IOS
using System.Runtime.InteropServices;
#endif
using UnityEngine;

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