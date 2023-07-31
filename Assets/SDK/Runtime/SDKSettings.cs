/****************************************************
*	文件：SDKSettings.cs
*	作者：何明飞
*	邮箱：hemingfei@outlook.com
*	日期：2023/07/28 10:36:34
*	功能：暂无
*****************************************************/

using UnityEditor;
using UnityEngine;

namespace SDK.Runtime
{
    [CreateAssetMenu(fileName = "SDKSettings", menuName = "Framework/Create SDK Settings")]
    public class SDKSettings : ScriptableObject
    {
        [Header("Bugly设置")] public string buglyAppId;
        
        [Header("TalkingData设置")] public string talkingDataAppId;
    }
}

