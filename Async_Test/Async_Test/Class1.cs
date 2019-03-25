using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Async_Test
{

    //https://www.cnblogs.com/liqingwen/p/5922573.html

    public class Class1
    {

        //例子1
        /// <summary>
        /// 异步访问 Web 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 方法签名的 3 要素：
        ///     ① async 修饰符
        ///     ② 返回类型 Task 或 Task<TResult>：这里的 Task<int> 表示 return 语句返回 int 类型
        ///     ③ 方法名以 Async 结尾
        /// </remarks>
        async Task<int> AccessTheWebAsync()
        {
            //记得 using System.Net.Http 哦
            var client = new HttpClient();

            //执行异步方法 GetStringAsync
            Task<string> getStringTask = client.GetStringAsync("http://www.google.com.hk/");

            //假设在这里执行一些非异步的操作
            Do();

            //等待操作挂起方法 AccessTheWebAsync
            //直到 getStringTask 完成，AccessTheWebAsync 方法才会继续执行
            //同时，控制将返回到 AccessTheWebAsync 方法的调用方
            //直到 getStringTask 完成后，将在这里恢复控制。
            //然后从 getStringTask 拿到字符串结果
            string urlContents = await getStringTask;

            //返回字符串的长度（int 类型）
            return urlContents.Length;
        }

        //例子2-简化代码
        /// <summary>
        /// 异步访问 Web 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 方法签名的 3 要素：
        ///     ① async 修饰符
        ///     ② 返回类型 Task 或 Task<TResult>：这里的 Task<int> 表示 return 语句返回 int 类型
        ///     ③ 方法名以 Async 结尾
        /// </remarks>
        async Task<int> AccessTheWebAsync2()
        {
            //记得 using System.Net.Http 哦
            var client = new HttpClient();

            //执行异步方法 GetStringAsync
            string urlContents = await client.GetStringAsync("http://www.google.com.hk/");

            //返回字符串的长度（int 类型）
            return urlContents.Length;
        }

        public void Do()
        { }
    }
}
