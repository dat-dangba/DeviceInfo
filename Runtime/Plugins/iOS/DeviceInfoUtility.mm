#import <UIKit/UIKit.h>
#include <sys/utsname.h>
#include <sys/sysctl.h>
#include <mach/mach.h>
#include <sys/mount.h>

extern "C"
{
    const char* _iOSGetOSVersion() {
        NSString* version = [[UIDevice currentDevice] systemVersion];
        return strdup([version UTF8String]); // FIXED
    }

    const char* _iOSGetDeviceModel() {
        struct utsname systemInfo;
        uname(&systemInfo);
        return strdup(systemInfo.machine);
    }

    const char* _iOSGetCPUModel() {
        char buffer[256];
        size_t size = sizeof(buffer);
        sysctlbyname("machdep.cpu.brand_string", buffer, &size, NULL, 0);
        return strdup(buffer);
    }

    long long _iOSGetTotalRAM() {
        return (long long)[[NSProcessInfo processInfo] physicalMemory];
    }

    long long _iOSGetTotalStorage() {
        struct statfs stats;
        statfs("/", &stats);
        long long size = (long long)stats.f_bsize * stats.f_blocks;
        return size;
    }
}
