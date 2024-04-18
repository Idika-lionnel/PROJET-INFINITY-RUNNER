using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

namespace FoxOS.Texter.Importer
{
    [UnityEditor.AssetImporters.ScriptedImporter(2, new string[] { "ini", "css" })]
    public class TexterImporter : UnityEditor.AssetImporters.ScriptedImporter
    {
        public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
        {
            TextAsset ta = new TextAsset(File.ReadAllText(ctx.assetPath));
            ctx.AddObjectToAsset("main obj", ta);
            ctx.SetMainObject(ta);
        }
    }
}