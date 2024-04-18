using FoxOS.Texter.Enums;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxOS.Texter
{
    sealed class TexterFiles
    {
        #region Texter File Menu Items
        const int    TEXTER_MENU_PRIO = 81;
        const string TEXTER_MENU      = "Assets/Create/[TLF] Text Files/";

        const string INI                 = "INI";
        const string INI_DEFAULT_NAME    = "New INI File.ini";
        const string INI_DEFAULT_CONTENT = "[General]\nContent = This is an INI";

        const string JSON                 = "JSON";
        const string JSON_DEFAULT_NAME    = "New JSON File.json";
        const string JSON_DEFAULT_CONTENT = "{\n\t\"content\": \"This is a Json\"\n}";

        const string TXT                 = "TXT";
        const string TXT_DEFAULT_NAME    = "New Text File.txt";
        const string TXT_DEFAULT_CONTENT = "This is a text file";

        const string XML                 = "XML";
        const string XML_DEFAULT_NAME    = "New XML File.xml";
        const string XML_DEFAULT_CONTENT = "<?xml version=\"1.0\" encoding=\"utf - 8\"?>\n\t<content>\n\t\tThis is an XML\n\t</content>";

        const string HTML                 = "HTML";
        const string HTML_DEFAULT_NAME    = "New HTML File.html";
        const string HTML_DEFAULT_CONTENT = "<html>\n\t<header>\n\t\t<title>\n\t\t\tTitle\n\t\t</title>\n\t</header>\n\t<body>\n\t\tThis is a HTML File\n\t</body>\n</html>";

        const string CSS                 = "CSS";
        const string CSS_DEFAULT_NAME    = "New CSS File.css";
        const string CSS_DEFAULT_CONTENT = "";

        [MenuItem(TEXTER_MENU + INI, priority = TEXTER_MENU_PRIO)]
        static void CreateINI()
        {
            TextFileType type = TextFileType.INI;
            CreateTextFile(type, GetCurrentProjectPath());
        }

        [MenuItem(TEXTER_MENU + JSON, priority = TEXTER_MENU_PRIO)]
        static void CreateJSON()
        {
            TextFileType type = TextFileType.JSON;
            CreateTextFile(type, GetCurrentProjectPath());
        }

        [MenuItem(TEXTER_MENU + TXT, priority = TEXTER_MENU_PRIO)]
        static void CreateText()
        {
            TextFileType type = TextFileType.TXT;
            CreateTextFile(type, GetCurrentProjectPath());
        }

        [MenuItem(TEXTER_MENU + XML, priority = TEXTER_MENU_PRIO)]
        static void CreateXML()
        {
            TextFileType type = TextFileType.XML;
            CreateTextFile(type, GetCurrentProjectPath());
        }

        [MenuItem(TEXTER_MENU + HTML, priority = TEXTER_MENU_PRIO)]
        static void CreateHtml()
        {
            TextFileType type = TextFileType.HTML;
            CreateTextFile(type, GetCurrentProjectPath());
        }

        [MenuItem(TEXTER_MENU + CSS, priority = TEXTER_MENU_PRIO)]
        static void CreateCss()
        {
            TextFileType type = TextFileType.CSS;
            CreateTextFile(type, GetCurrentProjectPath());
        }

        #endregion

        #region File/Path Helper
        static void RefreshAndSelect(string path)
        {
            AssetDatabase.Refresh();
            var newAsset = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
            Selection.activeObject = newAsset;
        }

        static string CreateTextFile(TextFileType type, string path)
        {
            string file = GetUniqueFilename(path, GetDefaultName(type));
            File.WriteAllText(file, GetDefaultContent(type));
            RefreshAndSelect(file);
            return file;
        }

        static string GetDefaultName(TextFileType type)
        {
            switch (type)
            {
                case TextFileType.INI:
                    return INI_DEFAULT_NAME;
                case TextFileType.JSON:
                    return JSON_DEFAULT_NAME;
                case TextFileType.TXT:
                    return TXT_DEFAULT_NAME;
                case TextFileType.XML:
                    return XML_DEFAULT_NAME;
                case TextFileType.HTML:
                    return HTML_DEFAULT_NAME;
                case TextFileType.CSS:
                    return CSS_DEFAULT_NAME;
                default:
                    return "";
            }
        }

        static string GetDefaultContent(TextFileType type)
        {
            switch (type)
            {
                case TextFileType.INI:
                    return INI_DEFAULT_CONTENT;
                case TextFileType.JSON:
                    return JSON_DEFAULT_CONTENT;
                case TextFileType.TXT:
                    return TXT_DEFAULT_CONTENT;
                case TextFileType.XML:
                    return XML_DEFAULT_CONTENT;
                case TextFileType.HTML:
                    return HTML_DEFAULT_CONTENT;
                case TextFileType.CSS:
                    return CSS_DEFAULT_CONTENT;
                default:
                    return "";
            }
        }

        static string GetCurrentProjectPath()
        {
            string path = "Assets";
            foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (string.IsNullOrEmpty(path) == false && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }
            return path;
        }

        static string GetUniqueFilename(string path, string filename)
        {
            return AssetDatabase.GenerateUniqueAssetPath(path + "/" + filename);
        }

        #endregion
    }
}
