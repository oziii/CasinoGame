using System.Collections;

using System.Collections.Generic;



using UnityEngine;

using UnityEngine.U2D;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.U2D;
#endif


public class SpriteAtlasPaddingOverride

{
#if UNITY_EDITOR
    [MenuItem("Assets/SpriteAtlas Set Padding 64")]

    

    public static void SpriteAtlasCustomPadding()

    {

        Object[] objs = Selection.objects;

        foreach (var obj in objs)

        {

            SpriteAtlas sa = obj as SpriteAtlas;

            if (sa)

            {

                var ps = sa.GetPackingSettings();

                ps.padding = 64;

                sa.SetPackingSettings(ps);

            }

        }

        AssetDatabase.SaveAssets();

    }
#endif
}
