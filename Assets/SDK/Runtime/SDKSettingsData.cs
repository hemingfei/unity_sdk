using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SDK.Runtime
{
    public class SDKSettingsData
    {
        private static SDKSettings _settings = null;
        public static SDKSettings Settings
        {
            get
            {
                if (_settings == null)
                    LoadSettingData();
                return _settings;
            }
        }
        
        public static string TalkingDatasAppId
        {
            get
            {
#if UNITY_ANDROID
                return Settings.talkingDataAppIdAndroid;
#elif UNITY_IOS
                return Settings.talkingDataAppIdIOS;
#else
                return "";
#endif
            }
        }
        
        public static string BuglyAppId
        {
            get
            {
#if UNITY_ANDROID
                return Settings.buglyAppIdAndroid;
#elif UNITY_IOS
                return Settings.buglyAppIdIOS;
#else
                return "";
#endif
            }
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        private static void LoadSettingData()
        {
            _settings = Resources.Load<SDKSettings>("SDKSettings");
            if (_settings == null)
            {
                Debug.Log("SDKSettings use default settings.");
                _settings = ScriptableObject.CreateInstance<SDKSettings>();
            }
            else
            {
                Debug.Log("SDKSettings use user settings.");
            }
        }
    }
}