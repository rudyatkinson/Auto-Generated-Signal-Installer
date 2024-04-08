using UnityEditor;

namespace RudyAtkinson.AGSI.Editor
{
    public class SignalInstallerCodeGenerationManually : EditorWindow
    {
        [MenuItem("Tools/RudyAtkinson/AGSI/Generate Signal Installer Manually")]
        public static void GenerateSignalInstaller()
        {
            var settings = SignalInstallerCodeGenerationSettings.GetSettingsFromResources();

            SignalInstallerCodeGeneration.FindSignalsAndGenerateCode(settings);
        }
    }
}