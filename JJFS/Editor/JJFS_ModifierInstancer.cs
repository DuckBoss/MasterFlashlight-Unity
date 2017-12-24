using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace JJFS.Modifiers {
    public class JJFS_ModifierInstancer : Editor {

        [MenuItem("JJ_Systems/JJFS/Modifiers/Battery")]
        public static void Battery()
        {
            BatteryModifier asset = ScriptableObject.CreateInstance<BatteryModifier>();

            AssetDatabase.CreateAsset(asset, "Assets/JJFS/Modifiers/BatteryModifier.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }


        //UNIMPLEMENTED
        /*
        [MenuItem("JJ_Systems/JJFS/Modifiers/Flickering")]
        public static void Flickering()
        {
            FlickeringModifier asset = ScriptableObject.CreateInstance<FlickeringModifier>();

            AssetDatabase.CreateAsset(asset, "Assets/JJFS/Modifiers/FlickeringModifier.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        */

    }
}
