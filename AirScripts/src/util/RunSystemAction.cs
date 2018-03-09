using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

/// <summary>
/// SystemAction 的摘要说明
/// </summary>
public class RunSystemAction
{
    public RunSystemAction()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static Boolean Run(String name)
    {
        if (name == "lock")
        {
            LockWorkStation();
        }
        else if (name == "shutdown")
        {
            Process.Start("shutdown", "/s /t 0");
        }
        else if (name == "reboot")
        {
            Process.Start("shutdown", "/r /t 0");
        }
        else if (name == "logoff")
        {
            ExitWindowsEx(0, 0);
        }
        else if (name == "hibernate")
        {
            SetSuspendState(true, true, true);
        }
        else if (name == "sleep")
        {
            SetSuspendState(false, true, true);
        }
        else
        {
            return false;
        }
        return true;
    }

    [DllImport("User32.Dll", EntryPoint = "LockWorkStation")]
    private static extern bool LockWorkStation();

    [DllImport("user32")]
    public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

    [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

}