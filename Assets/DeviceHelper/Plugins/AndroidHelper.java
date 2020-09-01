package com.paperstag;

import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Build;
import android.os.Environment;
import android.os.StatFs;
import android.telephony.TelephonyManager;
import android.content.pm.PackageInfo;
import android.util.DisplayMetrics;
import android.view.Display;
import android.view.WindowManager;

import java.io.File;
import java.util.Date;
import java.util.Locale;
import java.util.TimeZone;
import java.lang.Runtime;

import com.unity3d.player.UnityPlayer;

public class AndroidHelper {
    private static Context getContext() {
        return UnityPlayer.currentActivity.getApplicationContext();
    }

    public static String getPackageName() {
        return getContext().getPackageName();
    }

    public static PackageInfo getPackageInfo() {
        Context context = getContext();

        try {
            return context.getPackageManager().getPackageInfo(getPackageName(), 0);
        } catch (PackageManager.NameNotFoundException e) {
            return null;
        }
    }

    public static String getVersionCode() {
        Context context = getContext();

        String result = "";
        PackageInfo info = getPackageInfo();
        if (info != null) {
            result = Integer.toString(info.versionCode);
        }

        return result;
    }

    public static String getVersionName() {
        Context context = getContext();

        String result = "";
        PackageInfo info = getPackageInfo();
        if (info != null) {
            result = info.versionName;
        }

        return result;
    }

    public static String getOSVersion() {
        return Build.VERSION.RELEASE;
    }

    public static String getModelName() {
        return Build.MODEL;
    }

    public static String getLocale() {
        Context context = getContext();

        Locale locale;
        try {
            locale = context.getResources().getConfiguration().locale;
        } catch (Exception e) {
            locale = Locale.getDefault();
        }
        return locale.getLanguage() + "_" + locale.getCountry();
    }

    public static String getTimeZoneAbr() {
        TimeZone tz = TimeZone.getDefault();
        return tz.getDisplayName(tz.inDaylightTime(new Date()), TimeZone.SHORT);
    }

    public static String getCarrierName() {
        Context context = getContext();

        TelephonyManager telephonyManager = ((TelephonyManager) context.getSystemService(Context.TELEPHONY_SERVICE));
        return telephonyManager.getNetworkOperatorName();
    }

    public static String getScreenDensity() {
        Context context = getContext();

        double density = 0;
        try {
            WindowManager wm = (WindowManager) context.getSystemService(Context.WINDOW_SERVICE);
            if (wm != null) {
                Display display = wm.getDefaultDisplay();
                DisplayMetrics displayMetrics = new DisplayMetrics();
                display.getMetrics(displayMetrics);
                density = displayMetrics.density;
            }
        } catch (Exception e) {
            // Swallow
        }

        return String.format("%.2f", density);
    }

    public static int getCPUCores() {
        return Math.max(Runtime.getRuntime().availableProcessors(), 1);
    }

    private static boolean externalStorageExists() {
        return Environment.MEDIA_MOUNTED.equals(Environment.getExternalStorageState());
    }

    // getAvailableBlocks/getBlockSize deprecated but required pre-API v18
    @SuppressWarnings("deprecation")
    public static int getAvailableExternalStorageSize() {
        int result = 0;
        try {
            long availableExternalStorageGB = 0;
            if (externalStorageExists()) {
                File path = Environment.getExternalStorageDirectory();
                StatFs stat = new StatFs(path.getPath());
                availableExternalStorageGB =
                        (long) stat.getAvailableBlocks() * (long) stat.getBlockSize();
            }
            availableExternalStorageGB =
                    convertBytesToGB(availableExternalStorageGB);
            result = (int) availableExternalStorageGB;
        } catch (Exception e) {
            // Swallow
        }

        return result;
    }

    // getAvailableBlocks/getBlockSize deprecated but required pre-API v18
    @SuppressWarnings("deprecation")
    public static int getExternalStorageSize() {
        int result = 0;
        try {
            long totalExternalStorageGB = 0;
            if (externalStorageExists()) {
                File path = Environment.getExternalStorageDirectory();
                StatFs stat = new StatFs(path.getPath());
                totalExternalStorageGB = (long) stat.getBlockCount() * (long) stat.getBlockSize();
            }
            totalExternalStorageGB = convertBytesToGB(totalExternalStorageGB);
            result = (int) totalExternalStorageGB;
        } catch (Exception e) {
            // Swallow
        }

        return result;
    }

    private static long convertBytesToGB(double bytes) {
        return Math.round(bytes / (1024.0 * 1024.0 * 1024.0));
    }

    public static String getTimeZone() {
        TimeZone tz = TimeZone.getDefault();
        return tz.getID();
    }
}
