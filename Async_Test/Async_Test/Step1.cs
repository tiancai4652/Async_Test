using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Async_Test
{

    // http://www.cnblogs.com/liqingwen/p/5831951.html


    public class Step1
    {

        private readonly ITestOutputHelper Output;

        public Step1(ITestOutputHelper output)
        {
            this.Output = output;
        }

        //创建计时器
        private static readonly Stopwatch Watch = new Stopwatch();

        [Trait("Method","同步")]
        [Fact]
        public void Go()
        {
            Watch.Start();
            Work1();
            Work2();
            Assert.True(Watch.ElapsedMilliseconds>4000);
        }

        public void Work1()
        {
            Thread.Sleep(2000);
            Output.WriteLine($"Work1:{Watch.ElapsedMilliseconds}");
        }

        public void Work2()
        {
            Thread.Sleep(2000);
            Output.WriteLine($"Work2:{Watch.ElapsedMilliseconds}");
        }


        [Trait("Method", "异步")]
        [Fact]
        public async Task GoAsync()
        {
            Task a = Work1Async();
            Task b = Work2Async();
            await a;
            await b;
            Assert.True(Watch.ElapsedMilliseconds < 3000);
        }

        public async Task Work1Async()
        {
            Thread.Sleep(2000);
            Output.WriteLine($"Work1:{Watch.ElapsedMilliseconds}");
        }

        public async Task Work2Async()
        {
            Thread.Sleep(2000);
            Output.WriteLine($"Work2:{Watch.ElapsedMilliseconds}");
        }

    }



}
