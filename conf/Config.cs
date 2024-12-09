using Newtonsoft.Json;
using P_Keys.conf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace P_Keys
{
    internal class ConfigData
    {
        public string HotKey = "`";
        public List<KeysGroup> Groups = new List<KeysGroup>();
    }

    internal class Config
    {
        public static readonly string AppName = "P-Keys";
        public static readonly string HelpAbortInfo = @"P-Keys

Author: Pan
Version: 0.0.2
Date: 2024-12-04 17:00:00
Repository: https://github.com/panj039/p-keys.git";
        private static readonly string DefaultConfig = @"{
	""hotkey"": ""`"",
	""groups"": [
		{
			""name"": ""test_group"",
			""keys"": [
				{
					""key"": ""Q"",
					""links"": [
						{
							""key"": ""CTRL""
						},
						{
							""key"": ""C""
						}
					]
				},
				{
					""key"": ""W"",
					""links"": [
						{
							""key"": ""CTRL""
						},
						{
							""key"": ""V""
						}
					]
				}
			]
		}
	]
}";
        private static readonly string Assets = "assets";
        private static readonly string ConfigName = "config.json";
        public static Keys HotKey;
        public static List<KeysGroup> Groups = new List<KeysGroup>();
        public static Dictionary<string, KeysGroup> DGroups = new Dictionary<string, KeysGroup>();
        public static void Load()
        {
            try
            {
                TryCreateConfig();

                string configPath = GetConfigPath();
                string jsonContent = File.ReadAllText(configPath);
                var configData = JsonConvert.DeserializeObject<ConfigData>(jsonContent);
                HotKey = KKey(configData.HotKey);
                Groups = configData.Groups;

                DGroups.Clear();
                foreach (KeysGroup keyGroup in Groups)
                {
                    keyGroup.Tidy();
                    DGroups[keyGroup.Name] = keyGroup;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading or parsing the JSON file: {ex.Message}");
            }
        }

        public static void Save()
        {
            if (Groups.Count == 0)
            {
                return;
            }

            string configPath = GetConfigPath();
            string assetsDirectory = Path.GetDirectoryName(configPath);

            if (!Directory.Exists(assetsDirectory))
            {
                Directory.CreateDirectory(assetsDirectory);
            }

            var configData = new ConfigData();
            configData.HotKey = SKey(HotKey);
            configData.Groups = Groups;
            string jsonContent = JsonConvert.SerializeObject(configData, Formatting.Indented);

            try
            {
                File.WriteAllText(configPath, jsonContent);
                Console.WriteLine($"Save config to file: {configPath} done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fail to Save Config File In: {configPath}, error: {ex.Message}");
            }
        }

        public static void Open()
        {
            try
            {
                TryCreateConfig();
                string configPath = GetConfigPath();
                Process.Start(new ProcessStartInfo(configPath) { UseShellExecute = true });
            }
            catch (Exception e)
            {
                MessageBox.Show($"Open config fail: {e.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string SKey(Keys key)
        {
            if (KeysConfig.KKeys.TryGetValue(key, out var k))
            {
                return k.Key;
            }

            return "unknown";
        }

        public static Keys KKey(string c)
        {
            c = c.ToLower();
            if (KeysConfig.SKeys.TryGetValue(c, out var k))
            {
                return k.KeyCode;
            }
            return Keys.Oemtilde;
        }

        private static string GetConfigPath()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string assetsDirectory = Path.Combine(appDirectory, Assets);
            string configPath = Path.Combine(assetsDirectory, ConfigName);

            return configPath;
        }

        private static void TryCreateConfig()
        {
            string configPath = GetConfigPath();
            if (File.Exists(configPath))
            {
                return;
            }

            try
            {
                string dir = Path.GetDirectoryName(configPath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                File.WriteAllText(configPath, Config.DefaultConfig);
            }
            catch (Exception e)
            {
                //Console.WriteLine($"Write config fail: {e.Message}.");
                MessageBox.Show($"Write config fail: {e.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }

    public static class VirtualKeyCodeExtensions
    {
        public static bool IsMouseEvent(this VirtualKeyCode vkc)
        {
            if (
                (vkc == VirtualKeyCode.LBUTTON)
                || (vkc == VirtualKeyCode.RBUTTON)
                || (vkc == VirtualKeyCode.MBUTTON)
                || (vkc == VirtualKeyCode.XBUTTON1)
                || (vkc == VirtualKeyCode.XBUTTON2)
            ) {
                return true;
            }

            return false;
        }

        public static void Press(this VirtualKeyCode vkc, InputSimulator sim, bool isDown)
        {
            if (vkc.IsMouseEvent())
            {
                if (vkc == VirtualKeyCode.LBUTTON) { if (isDown) { sim.Mouse.LeftButtonDown(); } else { sim.Mouse.LeftButtonUp(); } }
                else if (vkc == VirtualKeyCode.RBUTTON) { if (isDown) { sim.Mouse.RightButtonDown(); } else { sim.Mouse.RightButtonUp(); } }
                else if (vkc == VirtualKeyCode.MBUTTON) { if (isDown) { sim.Mouse.MiddleButtonDown(); } else { sim.Mouse.MiddleButtonUp(); } }
                else if (vkc == VirtualKeyCode.XBUTTON1) { if (isDown) { sim.Mouse.XButtonDown(1); } else { sim.Mouse.XButtonUp(1); } }
                else if (vkc == VirtualKeyCode.XBUTTON2) { if (isDown) { sim.Mouse.XButtonDown(2); } else { sim.Mouse.XButtonUp(2); } }
            }
            else
            {
                if (isDown) { sim.Keyboard.KeyDown(vkc); } else { sim.Keyboard.KeyUp(vkc); }
            }
        }
    }
}
