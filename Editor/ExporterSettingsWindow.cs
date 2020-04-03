using UnityEditor;
using UnityEngine.UIElements;

namespace StansAssets.PackageExport.Editor
{
    public class ExporterSettingsWindow : EditorWindow
    {
        [MenuItem("Stan's Assets/ExporterSettingsWindow")]
        public static void OpenSettingsTest()
        {
            GetWindow<ExporterSettingsWindow>().Show();
        }

        void OnEnable()
        {
            var button  = new Button(() =>
            {
                var context = new PackageExportContext("PackageExport", "Assets/Plugins/StansAssets/Test")
                {
                    AddPackageVersionPostfix = true
                };

                PackageExporter.Export("com.stansassets.package-export", context);
            });

            button.text = "Export";
            rootVisualElement.Add(button);
        }
    }
}
