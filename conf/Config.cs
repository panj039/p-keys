﻿using Newtonsoft.Json;
using P_Keys.conf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WindowsInput.Native;

namespace P_Keys
{
    internal class ConfigData
    {
        public string HotKey = "`";
        public List<KeysGroup> Groups = new List<KeysGroup>();
    }

    internal class Config
    {
        public static Keys HotKey;
        public static List<KeysGroup> Groups = new List<KeysGroup>();
        public static Dictionary<string, KeysGroup> DGroups = new Dictionary<string, KeysGroup>();
        private static readonly string Assets = "assets";
        private static readonly string ConfigName = "config.json";
        private static readonly Dictionary<string, VirtualKeyCode> CharsToVirtualKeyCode = new Dictionary<string, VirtualKeyCode> {
            {"a", VirtualKeyCode.VK_A},
            {"b", VirtualKeyCode.VK_B},
            {"c", VirtualKeyCode.VK_C},
            {"d", VirtualKeyCode.VK_D},
            {"e", VirtualKeyCode.VK_E},
            {"f", VirtualKeyCode.VK_F},
            {"g", VirtualKeyCode.VK_G},
            {"h", VirtualKeyCode.VK_H},
            {"i", VirtualKeyCode.VK_I},
            {"j", VirtualKeyCode.VK_J},
            {"k", VirtualKeyCode.VK_K},
            {"l", VirtualKeyCode.VK_L},
            {"m", VirtualKeyCode.VK_M},
            {"n", VirtualKeyCode.VK_N},
            {"o", VirtualKeyCode.VK_O},
            {"p", VirtualKeyCode.VK_P},
            {"q", VirtualKeyCode.VK_Q},
            {"r", VirtualKeyCode.VK_R},
            {"s", VirtualKeyCode.VK_S},
            {"t", VirtualKeyCode.VK_T},
            {"u", VirtualKeyCode.VK_U},
            {"v", VirtualKeyCode.VK_V},
            {"w", VirtualKeyCode.VK_W},
            {"x", VirtualKeyCode.VK_X},
            {"y", VirtualKeyCode.VK_Y},
            {"z", VirtualKeyCode.VK_Z},
            {"0", VirtualKeyCode.VK_0},
            {"1", VirtualKeyCode.VK_1},
            {"2", VirtualKeyCode.VK_2},
            {"3", VirtualKeyCode.VK_3},
            {"4", VirtualKeyCode.VK_4},
            {"5", VirtualKeyCode.VK_5},
            {"6", VirtualKeyCode.VK_6},
            {"7", VirtualKeyCode.VK_7},
            {"8", VirtualKeyCode.VK_8},
            {"9", VirtualKeyCode.VK_9},
            {"`", VirtualKeyCode.OEM_3},
            {"ctrl", VirtualKeyCode.CONTROL},
            //{"lctrl", VirtualKeyCode.LCONTROL},
            //{"rctrl", VirtualKeyCode.RCONTROL},
            {"alt", VirtualKeyCode.MENU},
            //{"lalt", VirtualKeyCode.LMENU},
            //{"ralt", VirtualKeyCode.RMENU},
            {"shift", VirtualKeyCode.SHIFT},
            //{"lshift", VirtualKeyCode.LSHIFT},
            //{"rshift", VirtualKeyCode.RSHIFT},
            {"tab", VirtualKeyCode.TAB},
            {"enter", VirtualKeyCode.RETURN}
        };
        private static readonly Dictionary<Keys, string> KeysToChar = new Dictionary<Keys, string>
        {
            { Keys.A, "A" },
            { Keys.B, "B" },
            { Keys.C, "C" },
            { Keys.D, "D" },
            { Keys.E, "E" },
            { Keys.F, "F" },
            { Keys.G, "G" },
            { Keys.H, "H" },
            { Keys.I, "I" },
            { Keys.J, "J" },
            { Keys.K, "K" },
            { Keys.L, "L" },
            { Keys.M, "M" },
            { Keys.N, "N" },
            { Keys.O, "O" },
            { Keys.P, "P" },
            { Keys.Q, "Q" },
            { Keys.R, "R" },
            { Keys.S, "S" },
            { Keys.T, "T" },
            { Keys.U, "U" },
            { Keys.V, "V" },
            { Keys.W, "W" },
            { Keys.X, "X" },
            { Keys.Y, "Y" },
            { Keys.Z, "Z" },
            { Keys.D0, "0" },
            { Keys.D1, "1" },
            { Keys.D2, "2" },
            { Keys.D3, "3" },
            { Keys.D4, "4" },
            { Keys.D5, "5" },
            { Keys.D6, "6" },
            { Keys.D7, "7" },
            { Keys.D8, "8" },
            { Keys.D9, "9" },
            { Keys.NumPad0, "0" },
            { Keys.NumPad1, "1" },
            { Keys.NumPad2, "2" },
            { Keys.NumPad3, "3" },
            { Keys.NumPad4, "4" },
            { Keys.NumPad5, "5" },
            { Keys.NumPad6, "6" },
            { Keys.NumPad7, "7" },
            { Keys.NumPad8, "8" },
            { Keys.NumPad9, "9" },
            { Keys.Oemtilde, "`" },
            { Keys.ControlKey, "Ctrl" },
            { Keys.LControlKey, "LCtrl" },
            { Keys.RControlKey, "RCtrl" },
            { Keys.Alt, "Alt" },
            { Keys.ShiftKey, "Shift" },
            { Keys.LShiftKey, "LShift" },
            { Keys.RShiftKey, "RShift" },
            { Keys.Tab, "Tab" },
            { Keys.Enter, "Enter" }
        };
        public static void Load()
        {
            string configPath = GetConfigPath();

            if (!File.Exists(configPath))
            {
                MessageBox.Show($"没有找到配置文件: {configPath}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"The config file [{configPath}] was not found.");
                Application.Exit();
                return;
            }

            try
            {
                string jsonContent = File.ReadAllText(configPath);
                var configData = JsonConvert.DeserializeObject<ConfigData>(jsonContent);
                HotKey = GetKeyFromChar(configData.HotKey);
                Groups = configData.Groups;

                DGroups.Clear();
                foreach (KeysGroup keyGroup in Groups)
                {
                    keyGroup.Tidy();
                    DGroups[keyGroup.Group] = keyGroup;
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
            configData.HotKey = GetCharFromKey(HotKey);
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

        public static VirtualKeyCode GetVirtualKeyCodeFromChar(string character)
        {
            string lowerChar = character.ToLower(); // 忽略大小写
            if (CharsToVirtualKeyCode.ContainsKey(lowerChar))
            {
                return CharsToVirtualKeyCode[lowerChar];
            }
            else
            {
                throw new ArgumentException("Unsupported character", nameof(character));
            }
        }

        public static string GetCharFromKey(Keys key)
        {
            if (KeysToChar.TryGetValue(key, out string result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Key does not have a corresponding character", nameof(key));
            }
        }

        public static Keys GetKeyFromChar(string c)
        {
            c = c.ToLower();
            foreach (var kvp in KeysToChar)
            {
                if (kvp.Value.ToLower() == c)
                    return kvp.Key;
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
    }
}
