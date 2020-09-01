#import <sys/sysctl.h>
#import <sys/utsname.h>
#import <CoreTelephony/CTTelephonyNetworkInfo.h>
#import <CoreTelephony/CTCarrier.h>

#define FB_ARRAY_COUNT(x) sizeof(x) / sizeof(x[0])
const u_int FB_GIGABYTE = 1024 * 1024 * 1024;

uint readSysCtlUInt(int ctl, int type)
{
    int mib[2] = {ctl, type};
    uint value;
    size_t size = sizeof value;
    
    if (0 != sysctl(mib, FB_ARRAY_COUNT(mib), &value, &size, NULL, 0)) {
        return 0;
    }
    
    return value;
}

char* cStringCopy(const char* string)
{
   if (string == NULL)
   {
       return NULL;
   }
    
   char* res = (char*)malloc(strlen(string) + 1);
   strcpy(res, string);
   return res;
}

NSNumber* getTotalDiskSpace()
{
    NSDictionary *attrs = [[[NSFileManager alloc] init] attributesOfFileSystemForPath:NSHomeDirectory() error:nil];
    return [attrs objectForKey:NSFileSystemSize];
}

NSNumber* getRemainingDiskSpace()
{
    NSDictionary *attrs = [[[NSFileManager alloc] init] attributesOfFileSystemForPath:NSHomeDirectory() error:nil];
    return [attrs objectForKey:NSFileSystemFreeSize];
}

extern "C"
{
    char* _getPkgName()
    {
        NSBundle* mainBundle = [NSBundle mainBundle];
        return cStringCopy([mainBundle.bundleIdentifier UTF8String]);
    }

    char* _getPkgVersionCode()
    {
        NSBundle* mainBundle = [NSBundle mainBundle];
        return cStringCopy([[mainBundle objectForInfoDictionaryKey:@"CFBundleVersion"] UTF8String]);
    }

    char* _getPkgShortVersionName()
    {
        NSBundle* mainBundle = [NSBundle mainBundle];
        return cStringCopy([[mainBundle objectForInfoDictionaryKey:@"CFBundleShortVersionString"] UTF8String]);
    }

    char* _getOSVersion()
    {
        UIDevice* device = [UIDevice currentDevice];
        return cStringCopy([device.systemVersion UTF8String]);
    }

    char* _getDeviceModelName()
    {
        struct utsname systemInfo;uname(&systemInfo);
        return cStringCopy([[NSString stringWithFormat:@"%@", @(systemInfo.machine)] UTF8String]);
    }

    char* _getLocale()
    {
        return cStringCopy([[[NSLocale currentLocale] localeIdentifier] UTF8String]);
    }

    char* _getTimeZone()
    {
        NSTimeZone *timeZone = [NSTimeZone systemTimeZone];
        return cStringCopy([timeZone.name UTF8String]);
    }

    char* _getTimeZoneAbr()
    {
        NSTimeZone *timeZone = [NSTimeZone systemTimeZone];
        return cStringCopy([timeZone.abbreviation UTF8String]);
    }

    char* _getCarrierName()
    {
        CTTelephonyNetworkInfo *networkInfo = [[CTTelephonyNetworkInfo alloc] init];CTCarrier *carrier = [networkInfo subscriberCellularProvider];
        return cStringCopy([[carrier carrierName] ?: @"NoCarrier" UTF8String]);
    }

    char* _getScreenDensity()
    {
        UIScreen *sc = [UIScreen mainScreen];
        NSString *densityString = sc.scale ? [NSString stringWithFormat:@"%.02f", sc.scale] : @"";
        
        return cStringCopy([densityString UTF8String]);
    }

    int _getCPUCores()
    {
        return (int)readSysCtlUInt(CTL_HW, HW_AVAILCPU);
    }

    float _getTotalDiskSpace()
    {
        return (unsigned long long)round([getTotalDiskSpace() floatValue] / FB_GIGABYTE);
    }

    float _getRemainingDiskSpace()
    {
        return (unsigned long long)round([getRemainingDiskSpace() floatValue] / FB_GIGABYTE);
    }
}
