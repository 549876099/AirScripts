using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// JsonConstructor 的摘要说明
/// </summary>
public static class JsonConstructor
{
    //缺少必要的参数
    public static String SendMessage(Boolean state,String message)
    {
        if (state)
        {
            return "{\"success\":\"success\",\"message\":\""+ message + "\"}";
        }
        else
        {
            return "{\"state\":\"error\",\"message\":\"" + message + "\"}";
        }

    }
}