using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDK.Runtime
{
    public class TalkingData
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            string appId = SDKSettingsData.TalkingDatasAppId;
            TalkingDataSDK.BackgroundSessionEnabled();
            TalkingDataSDK.Init(appId, "", "");
        }

        /// <summary>
        /// 销毁/关APP
        /// </summary>
        public static void OnDestroy()
        {
            TalkingDataSDK.OnPause();
        }

        /// <summary>
        /// 设置用户ID
        /// </summary>
        /// <param name="uid"></param>
        public static void Login(string uid)
        {
            TalkingDataProfile profile = TalkingDataProfile.CreateProfile();
            TalkingDataSDK.OnLogin(uid, profile);
        }

        /// <summary>
        /// 窗口打开
        /// </summary>
        /// <param name="pageName">页面名称</param>
        public static void OnPageBegin(string pageName)
        {
            TalkingDataSDK.OnPageBegin(pageName);
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="pageName">页面名称</param>
        public static void OnPageEnd(string pageName)
        {
            TalkingDataSDK.OnPageEnd(pageName);
        }

        /// <summary>
        /// 自定义事件
        /// </summary>
        /// <param name="eventName">事件名称</param>
        /// <param name="dic">字典</param>
        public static void OnEvent(string eventName, Dictionary<string, object> dic)
        {
            TalkingDataSDK.OnEvent(eventName, dic);
        }
    }
}
