#if UNITY_IOS
using System.Runtime.InteropServices;
#endif
using UnityEngine;

namespace PaperStag
{
// Mocks iPhone 6 in Editor
public static class DeviceHelper
{
    #if UNITY_ANDROID && !UNITY_EDITOR
    private static AndroidJavaClass _helper;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType
        .BeforeSceneLoad)]
    public static void Init()
    {
        _helper = new AndroidJavaClass("com.paperstag.AndroidHelper");

        if (_helper != null)
        {
            Debug.Log("DeviceHelper static class found");
        }
        else
        {
            Debug.LogError(
                "DeviceHelper static class is null. Something went wrong");
        }
    }
    #endif

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getPkgName();
    #endif
    private static string _packageName;

    public static string PackageName
    {
        get
        {
            if (_packageName == null)
            {
                #if UNITY_EDITOR
                _packageName = Application.identifier;
                #elif UNITY_ANDROID
                _packageName =
                    _helper.CallStatic<string>("getPackageName");
                #elif UNITY_IOS
                _packageName = _getPkgName();
                #endif
            }

            return _packageName;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getPkgVersionCode();
    #endif
    private static string _packageVersionCode;

    public static string PackageVersionCode
    {
        get
        {
            if (_packageVersionCode == null)
            {
                #if UNITY_EDITOR
                _packageVersionCode = "99999";
                #elif UNITY_ANDROID
                _packageVersionCode =
                    _helper.CallStatic<string>("getVersionCode");
                #elif UNITY_IOS
                _packageVersionCode = _getPkgVersionCode();
                #endif
            }

            return _packageVersionCode;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getPkgShortVersionName();
    #endif
    private static string _shortVersionName;

    public static string ShortVersionName
    {
        get
        {
            if (_shortVersionName == null)
            {
                #if UNITY_EDITOR
                _shortVersionName = Application.version;
                #elif UNITY_ANDROID
                _shortVersionName =
                    _helper.CallStatic<string>("getVersionName");
                #elif UNITY_IOS
                _shortVersionName = _getPkgShortVersionName();
                #endif
            }

            return _shortVersionName;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getOSVersion();
    #endif
    private static string _osVersion;

    public static string OSVersion
    {
        get
        {
            if (_osVersion == null)
            {
                #if UNITY_EDITOR
                _osVersion = "12.4.2";
                #elif UNITY_ANDROID
                _osVersion =
                    _helper.CallStatic<string>("getOSVersion");
                #elif UNITY_IOS
                _osVersion = _getOSVersion();
                #endif
            }

            return _osVersion;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getDeviceModelName();
    #endif
    private static string _deviceModelName;

    public static string DeviceModelName
    {
        get
        {
            if (_deviceModelName == null)
            {
                #if UNITY_EDITOR
                _deviceModelName = "iPhone7,2";
                #elif UNITY_ANDROID
                _deviceModelName =
                    _helper.CallStatic<string>("getModelName");
                #elif UNITY_IOS
                _deviceModelName = _getDeviceModelName();
                #endif
            }

            return _deviceModelName;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getLocale();
    #endif
    private static string _locale;

    public static string Locale
    {
        get
        {
            if (_locale == null)
            {
                #if UNITY_EDITOR
                _locale = "en_US";
                #elif UNITY_ANDROID
                _locale = _helper.CallStatic<string>("getLocale");
                #elif UNITY_IOS
                _locale = _getLocale();
                #endif
            }

            return _locale;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getTimeZone();
    #endif
    private static string _timeZone;

    public static string TimeZone
    {
        get
        {
            if (_timeZone == null)
            {
                #if UNITY_EDITOR
                _timeZone = "Europe/Moscow";
                #elif UNITY_ANDROID
                _timeZone = _helper.CallStatic<string>("getTimeZone");
                #elif UNITY_IOS
                _timeZone = _getTimeZone();
                #endif
            }

            return _timeZone;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getTimeZoneAbr();
    #endif
    private static string _timeZoneAbbreviation;

    public static string TimeZoneAbbreviation
    {
        get
        {
            if (_timeZoneAbbreviation == null)
            {
                #if UNITY_EDITOR
                _timeZoneAbbreviation = "GMT+3";
                #elif UNITY_ANDROID
                _timeZoneAbbreviation =
                    _helper.CallStatic<string>("getTimeZoneAbr");
                #elif UNITY_IOS
                _timeZoneAbbreviation = _getTimeZoneAbr();
                #endif
            }

            return _timeZoneAbbreviation;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getCarrierName();
    #endif
    private static string _carrierName;

    public static string CarrierName
    {
        get
        {
            if (_carrierName == null)
            {
                #if UNITY_EDITOR
                _carrierName = "Carrier";
                #elif UNITY_ANDROID
                _carrierName =
                    _helper.CallStatic<string>("getCarrierName");
                #elif UNITY_IOS
                _carrierName = _getCarrierName();
                #endif
            }

            return _carrierName;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern string _getScreenDensity();
    #endif
    private static string _screenDensity;

    public static string ScreenDensity
    {
        get
        {
            if (_screenDensity == null)
            {
                #if UNITY_EDITOR
                _screenDensity = "2.00";
                #elif UNITY_ANDROID
                _screenDensity =
                    _helper.CallStatic<string>("getScreenDensity");
                #elif UNITY_IOS
                _screenDensity = _getScreenDensity();
                #endif
            }

            return _screenDensity;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern int _getCPUCores();
    #endif
    private static int? _cpuCores;

    public static int CPUCores
    {
        get
        {
            if (_cpuCores == null)
            {
                #if UNITY_EDITOR
                _cpuCores = 2;
                #elif UNITY_ANDROID
                _cpuCores = _helper.CallStatic<int>("getCPUCores");
                #elif UNITY_IOS
                _cpuCores = _getCPUCores();
                #endif
            }

            return (int)_cpuCores;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern float _getTotalDiskSpace();
    #endif
    private static float? _totalDiskSpace;

    public static float TotalDiskSpace
    {
        get
        {
            if (_totalDiskSpace == null)
            {
                #if UNITY_EDITOR
                _totalDiskSpace = 60;
                #elif UNITY_ANDROID
                _totalDiskSpace =
                    _helper.CallStatic<int>("getExternalStorageSize");
                #elif UNITY_IOS
                _totalDiskSpace = _getTotalDiskSpace();
                #endif
            }

            return (float)_totalDiskSpace;
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    // ReSharper disable once UnusedMember.Local
    private static extern float _getRemainingDiskSpace();
    #endif
    private static float? _remainingDiskSpace;

    public static float RemainingDiskSpace
    {
        get
        {
            if (_remainingDiskSpace == null)
            {
                #if UNITY_EDITOR
                _remainingDiskSpace = 29;
                #elif UNITY_ANDROID
                _remainingDiskSpace =
                    _helper.CallStatic<int>(
                        "getAvailableExternalStorageSize");
                #elif UNITY_IOS
                _remainingDiskSpace = _getRemainingDiskSpace();
                #endif
            }

            return (float)_remainingDiskSpace;
        }
    }
}
}