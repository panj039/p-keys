using P_Keys.conf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using YamlDotNet.Serialization;

namespace P_Keys
{
    internal class Config
    {
        public static readonly string AppName = "P-Keys";
        private static readonly string Assets = "assets";
        private static readonly string ConfigName = "config.yml";
        public static readonly string HelpAbortInfo = @"P-Keys

Author: Pan
Version: 0.0.3
Date: 2024-12-10 19:30:00
Repository: https://github.com/panj039/p-keys.git";
        private static readonly string DefaultConfig = @"hotkey: ""`"" # keep empty to disable hotkey
# keydelay: 50 # key delay in ms(default 50)
groups:
  example_group: # group name
    q: # copy
      - key: ""CTrL""
      - key: ""C""
    W: # paste
      - key: ""ctrl""
      - key: ""v""
    e: # mouse right click
      - key: ""rbutton""
    r: # mouse double click
      - key: ""lbutton""
      - key: ""lbutton""
  example_group_b:
    q:
      - key: ""a""
      - key: ""s""
      - key: ""d""
      - key: ""f""
";
        public static readonly int KeyDelayDefault = 50;
        public static KeyConfig HotKey;
        public static int KeyDelay = KeyDelayDefault;
        public static List<KeysGroup> Groups = new List<KeysGroup>();
        public static void Load()
        {
            try
            {
                TryCreateConfig();

                string configPath = GetConfigPath();
                using (var reader = new StreamReader(configPath))
                {
                    var deserializer = new DeserializerBuilder().Build();
                    var configData = deserializer.Deserialize<Dictionary<string, object>>(reader);
                    HotKey = KeysConfig.Key(configData["hotkey"] as string);
                    if (configData.ContainsKey("keydelay"))
                    {
                        KeyDelay = Convert.ToInt32(configData["keydelay"]);
                    }
                    else
                    {
                        KeyDelay = KeyDelayDefault;
                    }
                    var groups = configData["groups"] as Dictionary<object, object>;
                    Groups.Clear();
                    foreach (var group in groups)
                    {
                        Groups.Add(new KeysGroup(group.Key as string, group.Value as Dictionary<object, object>));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing the YAML file: {ex.Message}\nPlease check config.yml file content format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public static void Save()
        //{
        //    if (Groups.Count == 0)
        //    {
        //        return;
        //    }

        //    string configPath = GetConfigPath();
        //    string assetsDirectory = Path.GetDirectoryName(configPath);

        //    if (!Directory.Exists(assetsDirectory))
        //    {
        //        Directory.CreateDirectory(assetsDirectory);
        //    }

        //    var configData = new ConfigData();
        //    configData.HotKey = SKey(HotKey);
        //    configData.groups = Groups;
        //    string jsonContent = JsonConvert.SerializeObject(configData, Formatting.Indented);

        //    try
        //    {
        //        File.WriteAllText(configPath, jsonContent);
        //        Console.WriteLine($"Save config to file: {configPath} done!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Fail to Save Config File In: {configPath}, error: {ex.Message}");
        //    }
        //}

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
