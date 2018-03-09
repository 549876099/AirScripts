using System;
using System.Diagnostics;

/// <summary>
/// RunProcess 的摘要说明
/// </summary>
public class RunProcess
{
    static Process proc = new Process();
    static String scriptsLocation = AppDomain.CurrentDomain.BaseDirectory + "Scripts\\";

    public static Boolean Run(String name)
    {
        try
        {
            proc.StartInfo.FileName = scriptsLocation + name + ".bat";
            proc.StartInfo.Arguments = string.Format("10");
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
            return true;
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.Write(e);
            return false;
        }
    }
}