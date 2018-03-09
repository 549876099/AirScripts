using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirScripts.src.service
{
    class HttpServer
    {
        HttpListener listerner = null;
        ParmAnalyze parmAnalyze = null;

        public HttpServer()
        {
            listerner = new HttpListener();
            parmAnalyze = new ParmAnalyze();
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <returns></returns>
        public Boolean start(String ip, String port)
        {
            try
            {

                listerner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;//指定身份验证 Anonymous匿名访问
                listerner.Prefixes.Add("http://" + ip + ":" + port + "/api/");
                listerner.Start();
                return true;
            }
            catch
            {
                //MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// 停止服务器
        /// </summary>
        /// <returns></returns>
        public Boolean stop()
        {
            listerner.Stop();
            return true;
        }

        /// <summary>
        /// 开始监听
        /// </summary>
        public void listen()
        {
            //线程池
            int minThreadNum;
            int portThreadNum;
            int maxThreadNum;
            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
            ThreadPool.GetMinThreads(out minThreadNum, out portThreadNum);
            Console.WriteLine("最大线程数：{0}", maxThreadNum);
            Console.WriteLine("最小空闲线程数：{0}", minThreadNum);
            //ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc1), x);

            while (true)
            {
                //没有请求则GetContext处于阻塞状态
                try
                {
                    HttpListenerContext ctx = listerner.GetContext();
                    ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc), ctx);

                }
                catch
                {
                    return;
                }
            }
            //listerner.Stop();
        }

        /// <summary>
        /// 任务线程
        /// </summary>
        /// <param name="o"></param>
        void TaskProc(object o)
        {
            HttpListenerContext ctx = (HttpListenerContext)o;
            ctx.Response.StatusCode = 200;//设置返回给客服端http状态代码

            //接收Get参数
            string action = ctx.Request.QueryString["action"];
            string command = ctx.Request.QueryString["command"];
            string secret_key = ctx.Request.QueryString["secret_key"];

            String result = parmAnalyze.Analyze(action, command, secret_key);


            //使用Writer输出http响应代码,UTF8格式
            using (StreamWriter writer = new StreamWriter(ctx.Response.OutputStream, Encoding.UTF8))
            {
                writer.Write(result);
                writer.Close();
                ctx.Response.Close();
            }
        }
    }

}
