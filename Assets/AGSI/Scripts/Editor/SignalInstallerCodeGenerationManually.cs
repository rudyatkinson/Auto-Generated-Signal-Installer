using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace RudyAtkinson.GenerateCode
{
    public class SignalInstallerCodeGenerationManually : EditorWindow
    {
        [MenuItem("Tools/RudyAtkinson/Signal Installer Generator/Generate Signal Installer")]
        public static void GenerateSignalInstaller()
        {
            var settings = SignalInstallerCodeGenerationSettings.GetSettingsFromResources();

            SignalInstallerCodeGeneration.FindSignalsAndGenerateCode(settings);
        }
    }
}