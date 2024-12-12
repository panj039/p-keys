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
Version: 0.0.5
Date: 2024-12-12 14:18:00
Repository: https://github.com/panj039/p-keys.git";
        public static readonly string HelpHelpInfo = @"Usage:
    1. Create a group to contain key macros.
    2. Add a key macro to the group current selected.
    3. Switch on (hotkey supported) to activate widget.
    4. Press key and see it works.
    5. Right click to the InputBox can edit it's contents.

Caution:
    1. Use Edit function may cause `CallbackOnCollectedDelegate` exception sometimes.
    2. Becareful of key bind loop, for example: a=b; b=a. Use `Nest` to switch this function.
    3. Only keyboard available for left operator, mouse actions can only on the right side.";
        private static readonly string DefaultConfig = @"hotkey: ""`"" # keep empty to disable hotkey
# pressdowntime: 50 # key press down time in ms(default 50)
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
        public const string YML_HotKey = "hotkey";
        public const string YML_PressDownTime = "pressdowntime";
        public const string YML_Groups = "groups";
        public const string YML_Key = "key";
        public const string YML_Nest = "nest";
        public const string YML_Nest_Max = "nest_max";

        public static readonly int PressDownTimeDefault = 50;
        public static readonly int NestMaxDefault = 10;
        public static KeyConfig HotKey;
        public static int PressDownTime = PressDownTimeDefault;
        public static bool Nest = false;
        public static int NestMax = NestMaxDefault;
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
                    HotKey = KeysConfig.Key(configData[YML_HotKey] as string);
                    if (configData.ContainsKey(YML_PressDownTime)) { PressDownTime = Convert.ToInt32(configData[YML_PressDownTime]); } else { PressDownTime = PressDownTimeDefault; }
                    if (configData.ContainsKey(YML_Nest)) { Nest = Convert.ToBoolean(configData[YML_Nest]); } else { Nest = false; }
                    if (configData.ContainsKey(YML_Nest_Max)) { NestMax = Convert.ToInt32(configData[YML_Nest_Max]); } else { NestMax = NestMaxDefault; }
                    var groups = configData[YML_Groups] as Dictionary<object, object>;
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

        public static void Save()
        {
            string configPath = GetConfigPath();
            try
            {
                var serializer = new SerializerBuilder().Build();
                var data = Build();
                string yaml = serializer.Serialize(data);
                File.WriteAllText(configPath, yaml);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fail to Save Config File In: {configPath}, error: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static KeysGroup Group(string groupName)
        {
            foreach (var group in Groups)
            {
                if (group.Name != groupName) { continue; }
                return group;
            }
            return null;
        }

        public static void AddGroup(string groupName)
        {
            var group = new KeysGroup(groupName, new Dictionary<object, object>());
            AddGroup(group);
        }

        public static void AddGroup(KeysGroup group)
        {
            Groups.Add(group);
        }

        public static void DelGroup(string groupName)
        {
            var g = Groups.Find(item => item.Name == groupName);
            if (g == null) { return; }

            Groups.Remove(g);
        }

        public static void InfoBox(string info, string title = "Success")
        {
            MessageBox.Show(info, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private static Dictionary<string, object> Build()
        {
            var configData = new Dictionary<string, object>();
            configData[YML_HotKey] = HotKey?.SKey ?? "";
            configData[YML_PressDownTime] = PressDownTime;
            configData[YML_Nest] = Nest;
            configData[YML_Nest_Max] = NestMax;

            var groups = new Dictionary<string, object>();
            foreach (var group in Groups)
            {
                groups[group.Name] = group.Build();
            }
            configData[YML_Groups] = groups;

            return configData;
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
