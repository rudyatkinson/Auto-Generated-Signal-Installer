﻿using System.IO;
using UnityEditor;
using UnityEngine;

namespace RudyAtkinson.AGSI.Editor
{
    public class SignalInstallerCodeGenerationSettings: EditorWindow
    {
        public static string InstallerClassName = "AutoGeneratedSignalInstaller";
        public static string InstallerPath = "../Assets/Installer/";
        public static bool GenerateSignalInstallerAtCompile = true;
        
        [MenuItem("Tools/RudyAtkinson/AGSI/Settings")]
        public static void OpenWindow()
        {
            GetWindow<SignalInstallerCodeGenerationSettings>("AGSI").Show();
        }

        private void OnEnable()
        {
            LoadSettings();
        }
        
        private void OnDisable()
        {
            SaveSettings();
        }

        private void OnGUI()
        {
            InstallerClassName = EditorGUILayout.TextField("Signal Installer Class Name:", InstallerClassName);
            InstallerPath = EditorGUILayout.TextField("Signal Installer Path:", InstallerPath);
            GenerateSignalInstallerAtCompile = EditorGUILayout.Toggle("Generate Signal Installer At Compile", GenerateSignalInstallerAtCompile);
            
            Repaint();
        }
        
        void SaveSettings()
        {
            var settingsFilePath = Path.Combine("./Assets/Resources/", "AGSI_Settings.json");

            var settings = new AGSISettings();
            settings.InstallerClassName = InstallerClassName;
            settings.InstallerPath = InstallerPath;
            settings.GenerateSignalInstallerAtCompile = GenerateSignalInstallerAtCompile;
            
            var jsonData = JsonUtility.ToJson(settings, true);
            
            Directory.CreateDirectory(Path.GetDirectoryName(settingsFilePath));
            File.WriteAllText(settingsFilePath, jsonData);
            
            AssetDatabase.Refresh();
        }

        void LoadSettings()
        {
            var settings = GetSettingsFromResources();
            
            InstallerClassName = settings.InstallerClassName;
            InstallerPath = settings.InstallerPath;
            GenerateSignalInstallerAtCompile = settings.GenerateSignalInstallerAtCompile;
        }

        public static AGSISettings GetSettingsFromResources()
        {
            var settingsTextAsset = (TextAsset)Resources.Load("AGSI_Settings");
            AGSISettings settings;
            
            if (settingsTextAsset == null)
            {
                settings = new AGSISettings();
                settings.InstallerClassName = InstallerClassName;
                settings.InstallerPath = InstallerPath;
                settings.GenerateSignalInstallerAtCompile = GenerateSignalInstallerAtCompile;
            }
            else
            {
                var settingsJson = settingsTextAsset.text;
                settings = JsonUtility.FromJson<AGSISettings>(settingsJson);
            }
            
            return settings;
        }
    }
    
    public class AGSISettings
    {
        public string InstallerClassName;
        public string InstallerPath;
        public bool GenerateSignalInstallerAtCompile;
    }
}