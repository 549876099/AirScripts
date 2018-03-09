using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Action 的摘要说明
/// </summary>

namespace AirScripts.src.service
{
    public class Action
    {
        public Action()
        {

        }

        public String SystemAction(String command)
        {
            if (RunSystemAction.Run(command))
            {
                return JsonConstructor.SendMessage(true, "成功");
            }
            else
            {
                return JsonConstructor.SendMessage(false, "命令不存在");
            }
        }

        public String ShellAction(String command)
        {
            if (RunProcess.Run(command))
            {
                return JsonConstructor.SendMessage(true, "成功");
            }
            else
            {
                return JsonConstructor.SendMessage(false, "脚本不存在或执行失败");
            }
        }
    }
}