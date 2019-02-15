using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace FastRegsvrWinForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //string a = "C:\\Users\\Yorkin\\Desktop\\XUIProject\\XGraph\\DllTest\\XGraph Alpha.dll";
            if (args.Length > 0)
            {
                List<string> Lines = new List<string>();
                foreach (string str in args)
                {

                    string LibName, LibPath;
                    if (Regsvr.RegLib(str,out LibName,out LibPath) >= 0)
                        Lines.Add(LibName + "注册成功于"+ LibPath);
                    else
                        Lines.Add(LibName + "注册失败");
                }

            Application.Run(new Form1(Lines));
            }
            else
            {
                Application.Run(new Form2());
            }

}
    }
    public class Regsvr
    {
        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(string path);
        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, string funcName);
        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);
        private delegate int LoadFunction();
        private static LoadFunction LoadDll;

        public static int RegLib(string Path,out string LibName,out string LibPath)
        {
            bool CopyToSys = (string)AppRegedit.Get("CopyToSys", "False") == "True" ? true : false;
            string SysPath = Environment.GetFolderPath(Environment.Is64BitOperatingSystem ? Environment.SpecialFolder.SystemX86 : Environment.SpecialFolder.System);

            string[] LibStr = Path.Split('\\');
            LibName = LibStr[LibStr.Length - 1];

            if (CopyToSys)
            {
                if(!File.Exists(SysPath + "\\" + LibName)) File.Copy(Path, SysPath+"\\"+LibName);
                LibPath = SysPath + "\\" + LibName;
            }
            else
            {
                LibPath = Path;
            }

            IntPtr Lib = LoadLibrary(LibPath);
            IntPtr API = GetProcAddress(Lib, "DllRegisterServer");
            LoadDll = (LoadFunction)Marshal.GetDelegateForFunctionPointer(API, typeof(LoadFunction));
            int number = LoadDll();
            if (number >= 0) AppRegedit.SetLibState(LibName,LibPath, AppRegedit.LibState.HasReg);
            FreeLibrary(Lib);
            return number;
        }
        public static int UnRegLib(string Path,out string LibName)
        {
            string[] LibStr = Path.Split('\\');
            LibName = LibStr[LibStr.Length - 1];
            IntPtr Lib = LoadLibrary(Path);
            IntPtr API = GetProcAddress(Lib, "DllUnregisterServer");
            LoadDll = (LoadFunction)Marshal.GetDelegateForFunctionPointer(API, typeof(LoadFunction));
            int number = LoadDll();
            if (number >= 0) AppRegedit.SetLibState(LibName,Path, AppRegedit.LibState.HasUnReg);
            FreeLibrary(Lib);
            return number;
        }
        public static void DeleteRegLib(string Path)
        {
            string[] LibStr = Path.Split('\\');
            string LibName = LibStr[LibStr.Length - 1];
            File.Delete(Path);
            AppRegedit.DeleteLibItem(LibName);
        }
    }
    public class AppRegedit
    {
        public static void Set(string name, object value)
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr");
            Key.SetValue(name, value);
            Key.Close();
        }
        public static object Get(string name)
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr");
            return Key.GetValue(name);
        }
        public static object Get(string name, object DefaultValue)
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr");
            return Key.GetValue(name, DefaultValue);
        }
        public enum LibState{HasReg,HasUnReg,NoExist};
        public static LibState GetLibState(string name)
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr\\RegItems");
            RegistryKey SubKey = Key.OpenSubKey(name);
            if(SubKey==null)
            {
                return LibState.NoExist;
            }
            else
            {
                if ((string)SubKey.GetValue("State") == "HasReg")
                    return LibState.HasReg;
                else
                    return LibState.HasUnReg;
            }
        }
        public static void DeleteLibItem(string name)
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr\\RegItems");
            Key.DeleteSubKey(name);
        }
        public static void SetLibState(string name,string Path,LibState state)
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr\\RegItems");
            RegistryKey SubKey = Key.OpenSubKey(name,true);
            if (SubKey == null)SubKey = Key.CreateSubKey(name, true);
            SubKey.SetValue("Path", Path);
            SubKey.SetValue("State", state.ToString());
        }
        public static List<string> GetRegItem()
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr\\RegItems");
            string[] items = Key.GetSubKeyNames();
            List<string> RegItem = new List<string>();
            foreach(string item in items)
                if ((string)Key.OpenSubKey(item).GetValue("State") == "HasReg") RegItem.Add(item);
            return RegItem;
        }
        public static List<string> GetUnRegItem()
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr\\RegItems");
            string[] items = Key.GetSubKeyNames();
            List<string> RegItem = new List<string>();
            foreach (string item in items)
                if ((string)Key.OpenSubKey(item).GetValue("State") == "HasUnReg") RegItem.Add(item);
            return RegItem;
        }
        public static string GetRegPath(string name)
        {
            RegistryKey Key = Registry.LocalMachine.CreateSubKey("software\\FastRegsvr\\RegItems\\"+name);
            return Key.GetValue("Path").ToString();
        }
    }

}
