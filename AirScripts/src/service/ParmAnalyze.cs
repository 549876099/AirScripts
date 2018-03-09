using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirScripts.src.service
{
    class ParmAnalyze
    {
        Action action = null;

        public ParmAnalyze()
        {
            action = new Action();
        }

        public String Analyze(String actionParm, String commandParm, String secret_keyParm)
        {
            //参数验证
            if (Properties.Settings.Default.secret_key)
            {
                if (actionParm == null || commandParm == null || secret_keyParm == null)
                {
                    return JsonConstructor.SendMessage(false, "必要参数无效");
                }

                if (secret_keyParm != Properties.Settings.Default.secret_key_str)
                {
                    return JsonConstructor.SendMessage(false, "密钥错误");
                }
            }
            else
            {
                if (actionParm == null || commandParm == null)
                {
                    return JsonConstructor.SendMessage(false, "必要参数无效！");
                }
            }
            //分参数执行
            if (actionParm == "System" || actionParm == "system")
            {
                return action.SystemAction(commandParm);
            }
            else if (actionParm == "Shell" || actionParm == "shell")
            {
                return action.ShellAction(commandParm);
            }
            else
            {
                return JsonConstructor.SendMessage(false, "action参数错误：" + actionParm);
            }
        }
    }

}
