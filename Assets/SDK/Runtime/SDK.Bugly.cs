using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDK.Runtime
{
    public partial class SDK
    {
        public class Bugly
        {
            /// <summary>
            /// 日志等级
            /// </summary>
            public enum LogLevel
            {
                Info,
                Warning,
                Error,
                Exception
            }

            /// <summary>
            /// 初始化SDK
            /// </summary>
            /// <param name="isDebugMode">是否为debug模式</param>
            /// <param name="logLevel">日志等级</param>
            public static void Init(bool isDebugMode = false, LogLevel logLevel = LogLevel.Error)
            {
                string appID = SDKSettingsData.Settings.buglyAppId;
                // Enable the debug log print
                BuglyAgent.ConfigDebugMode(isDebugMode);
                // Config default channel, version, user 
                BuglyAgent.ConfigDefault(null, null, null, 0);
                // Config auto report log level, default is LogSeverity.LogError, so the LogError, LogException log will auto report
                var buglyLogLevel = LogSeverity.LogError;
                switch (logLevel)
                {
                    case LogLevel.Info:
                        buglyLogLevel = LogSeverity.LogInfo;
                        break;
                    case LogLevel.Warning:
                        buglyLogLevel = LogSeverity.LogWarning;
                        break;
                    case LogLevel.Error:
                        buglyLogLevel = LogSeverity.LogError;
                        break;
                    case LogLevel.Exception:
                        buglyLogLevel = LogSeverity.LogException;
                        break;
                }

                BuglyAgent.ConfigAutoReportLogLevel(buglyLogLevel);
                // Config auto quit the application make sure only the first one c# exception log will be report, please don't set TRUE if you do not known what are you doing.
                BuglyAgent.ConfigAutoQuitApplication(false);
                // If you need register Application.RegisterLogCallback(LogCallback), you can replace it with this method to make sure your function is ok.
                BuglyAgent.RegisterLogCallback(null);

                // Init the bugly sdk and enable the c# exception handler.
                BuglyAgent.InitWithAppId(appID);

                // TODO Required. If you do not need call 'InitWithAppId(string)' to initialize the sdk(may be you has initialized the sdk it associated Android or iOS project),
                // please call this method to enable c# exception handler only.
                BuglyAgent.EnableExceptionHandler();
            }

            /// <summary>
            /// 设置用户ID
            /// </summary>
            /// <param name="uid">用户ID</param>
            public static void Login(string uid)
            {
                BuglyAgent.SetUserId(uid);
            }
            
            /// <summary>
            /// 设置额外的信息
            /// </summary>
            /// <param name="deviceId">设备id</param>
            /// <param name="deviceModel">设备型号</param>
            /// <param name="deviceName">设备名称</param>
            public static void SetLogCallbackExtras(string deviceId, string deviceModel, string deviceName)
            {
                // TODO NOT Required. If you need to report extra data with exception, you can set the extra handler
                BuglyAgent.SetLogCallbackExtrasHandler(() =>
                {
                    // TODO Test log, please do not copy it
                    BuglyAgent.PrintLog(LogSeverity.Log, "extra handler");

                    // TODO Sample code, please do not copy it
                    Dictionary<string, string> extras = new Dictionary<string, string>();
                    extras.Add("ScreenSolution", string.Format("{0}x{1}", Screen.width, Screen.height));
                    extras.Add("deviceModel", deviceModel);
                    extras.Add("deviceName", deviceName);
                    extras.Add("deviceType", SystemInfo.deviceType.ToString());

                    extras.Add("deviceUId", deviceId);
                    extras.Add("gDId", $"{SystemInfo.graphicsDeviceID}");
                    extras.Add("gDName", SystemInfo.graphicsDeviceName);
                    extras.Add("gDVdr", SystemInfo.graphicsDeviceVendor);
                    extras.Add("gDVer", SystemInfo.graphicsDeviceVersion);
                    extras.Add("gDVdrID", $"{SystemInfo.graphicsDeviceVendorID}");

                    extras.Add("graphicsMemorySize", $"{SystemInfo.graphicsMemorySize}");
                    extras.Add("systemMemorySize", $"{SystemInfo.systemMemorySize}");
                    extras.Add("UnityVersion", Application.unityVersion);

                    BuglyAgent.PrintLog(LogSeverity.LogInfo, "Package extra data");
                    return extras;
                });
            }


        }
    }
}
