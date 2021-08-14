using System;
using System.Threading;
using System.Threading.Tasks;

namespace foobar
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

            var n = 20;
            var f1 = new FooBar(n);
            //new Task(f1.Foo({ i => Console.Write("foo") }));
            Action act = new Action(MyPrintFoo);
            //new Task(f1.Foo(() => Console.Write("foo")));
            //f1.Foo(MyPrintFoo);

            var tsk1 = Task.Factory.StartNew(()=>f1.Foo(MyPrintFoo));
            var tsk2 = Task.Factory.StartNew(() => f1.Bar(MyPrintBar));

            Thread.Sleep(2000);
            Console.WriteLine("end");
        }

        internal static void MyPrintFoo()
		{
			Console.Write("foo{0}", Thread.CurrentThread.ManagedThreadId);
		}
        internal static void MyPrintBar()
        {
            Console.Write("bar{0}", Thread.CurrentThread.ManagedThreadId);
        }
    }


    public class FooBar
    {
        private int n;

        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {

                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
            }
        }
    }
}
