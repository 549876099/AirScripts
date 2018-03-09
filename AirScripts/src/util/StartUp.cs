using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace AirScripts.src.util
{
    class StartUp
    {
        public static Boolean set()
        {
            return StartUpUtil(true);
        }

        public static Boolean del()
        {
            return StartUpUtil(false);
        }

        private static Boolean StartUpUtil(Boolean flag)
        {
            string path = Application.StartupPath;
            string keyName = path.Substring(path.LastIndexOf("\\") + 1);
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//打开注册表子项
            if (key == null)//如果该项不存在的话，则创建该子项
            {
                key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            }
            if (flag == true)
            {
                try
                {
                    key.SetValue(keyName, Application.ExecutablePath);//设置为开机启动
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    key.DeleteValue(keyName);//取消开机启动
                    key.Close();
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
    }
}
