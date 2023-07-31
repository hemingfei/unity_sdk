using System.Collections;
using System.Collections.Generic;
using SDK.Runtime;
using UnityEditor;
using UnityEngine;

namespace SDK.Editor
{
    [CustomEditor(typeof(SDKSettings), false)]
    public class SDKSettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(10);
            if (GUILayout.Button("保存设置"))
            {
                EditorUtility.SetDirty(target);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
