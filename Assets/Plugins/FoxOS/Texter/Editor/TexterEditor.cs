using System.Diagnostics;
using System.IO;
using UnityEditor;

using UnityEngine;

namespace FoxOS.Texter.Importer
{
    [CustomEditor(typeof(TextAsset))]
    public class TexterEditor : Editor
    {
        string original, content;
        bool   allowEdit, edited;
        public void OnEnable()
        {
            original = content = ((TextAsset)target).text;
        }

        public override void OnInspectorGUI()
        {
            using (new GUILayout.VerticalScope("box"))
            {
                GUI.enabled = true;

                using (new GUILayout.HorizontalScope(EditorStyles.toolbar, GUILayout.ExpandWidth(true)))
                {
                    if (GUILayout.Button("Open", EditorStyles.toolbarButton, GUILayout.Width(80)))
                        Process.Start(Path.Combine(Application.dataPath.Replace("/Assets", ""), AssetDatabase.GetAssetPath(target)));
                    if (!allowEdit)
                    {
                        if (GUILayout.Button("Edit", EditorStyles.toolbarButton, GUILayout.Width(80)))
                            allowEdit = true;
                    }
                    else
                    {
                        RevertButton();
                        using (new EditorGUI.DisabledScope(!edited))
                        {
                            ApplyButton();
                        }
                    }
                }

                using (new EditorGUI.DisabledScope(!allowEdit))
                {
                    EditorGUI.BeginChangeCheck();
                    content = EditorGUILayout.TextArea(content, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(800));
                    if (EditorGUI.EndChangeCheck())
                        edited = true;
                }
            }
        }

        void ApplyButton(string label = "Apply")
        {
            if (GUILayout.Button(label, EditorStyles.toolbarButton, GUILayout.Width(80)))
                Apply();
        }

        void RevertButton(string label = "Revert")
        {
            if (GUILayout.Button(label, EditorStyles.toolbarButton, GUILayout.Width(80)))
                Revert();
        }

        protected void Apply()
        {
            allowEdit = false;
            File.WriteAllText(AssetDatabase.GetAssetPath(target), content);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        protected void Revert()
        {
            allowEdit = false;

            content = original;
        }
    }
}
