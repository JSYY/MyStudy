using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    class Program
    {
        private static object obj = new object();
        private static int sum = 0;
        private static Mutex m;
        static void Main(string[] args)
        {
            //获取当前线程信息
            //Thread thread = new Thread(OneTest);
            //thread.Name = "Test";
            //thread.Start();
            //----------------------------------------------------------------

            //线程的状态：新建对象、就绪状态(等待cpu调度)、运行状态(cpu正在调度)、阻塞状态(等待阻塞、同步阻塞等)、死亡(对象释放)
            //--------------------

            //使用lock锁住资源，可以使进程在资源被释放后依次执行
            //Thread thread1 = new Thread(Method1);
            //Thread thread2 = new Thread(Method2);
            //thread1.Start();
            //thread2.Start();
            //----------------------------------------------------------------

            //死锁案例 如果使用Monitor.TryEnter 可以设置超时时间来释放资源
            //如果对象已经被锁定，另一个线程使用 `Monitor.Enter` 对象，就会一直等待另一个线程解除锁定。
            //但是，如果一个线程发生问题或者出现死锁的情况，锁一直被锁定呢？或者线程具有时效性，超过一段时间不执行，已经没有了意义呢？
            //我们可以通过 `Monitor.TryEnter()` 来设置等待时间，超过一段时间后，如果锁还没有释放，就会返回 false。
            //案例中th1 与th2 两个线程互相在等待对方释放obj2和obj1的资源
            //此时th1在等待5S后选择放弃等待obj2资源，所以执行完LockMethod1方法后释放obj1
            //随后th2线程也相应拿到obj1资源完成方法调度
            //如果不用Monitor.TryEnter 两边互相等待则会造成死锁情况出现
            //object obj1 = new object();
            //object obj2 = new object();
            //Thread th1 = new Thread(()=> { LockMethod1(obj1, obj2); });
            //Thread th2 = new Thread(() => { LockMethod2(obj1, obj2); });
            //th1.Start();
            //th2.Start();
            //----------------------------------------------------------------

            //竞争条件
            //当两个或两个以上的线程访问共享数据，并且尝试同时改变它时，就发生争用的情况。它们所依赖的那部分共享数据，叫做竞争条件。
            //数据争用是竞争条件中的一种，出现竞争条件可能会导致内存(数据)损坏或者出现不确定性的行为。
            //线程同步
            //如果有 N 个线程都会执行某个操作，当一个线程正在执行这个操作时，其它线程都必须依次等待，这就是线程同步。
            //多线程环境下出现竞争条件，通常是没有执行正确的同步而导致的。
            //上下文切换
            //上下文切换（Context Switch），也称做进程切换或任务切换，是指 CPU 从一个进程或线程切换到另一个进程或线程。
            //阻塞
            //阻塞状态指线程处于等待状态。当线程处于阻塞状态时，会尽可能少占用 CPU 时间。
            //当线程从运行状态(Runing)变为阻塞状态时(WaitSleepJoin)，操作系统就会将此线程占用的 CPU 时间片分配给别的线程。
            //当线程恢复运行状态时(Runing)，操作系统会重新分配 CPU 时间片。分配 CPU 时间片时，会出现上下文切换。
            //Interlocked类
            //使用 Interlocked 类，可以在不阻塞线程(lock、Monitor)的情况下，避免竞争条件。
            //原子操作，在某个时刻，必须只有一个线程能够进行某个操作，Interlocked 可以实现原子性的操作。
            //for(int i = 0; i < 5; i++)
            //{
            //    Thread th = new Thread(AddOne);
            //    th.Start();

            //}
            //Thread.Sleep(2000);
            //Console.WriteLine(sum);
            //----------------------------------------------------------------

            //Mutex 互斥锁，用于多线程中防止两条线程同时对一个公共资源进行读写的机制，和lock相似，但是Mutex支持多个进程，Mutex大约比lock慢20倍
            //Mutex 只要考虑实现进程间的同步，它会耗费比较多的资源，进程内请考虑 Monitor/lock。
            //下面实例表示开启多个相同进程时，之后的进程会等待前面的进程执行完dowork方法才启动
            //bool instance;
            //m = new Mutex(true, "example", out instance);
            //if (!instance)
            //{
            //    m.WaitOne();
            //    DoWork();
            //}
            //else
            //{
            //    DoWork();
            //}
            //----------------------------------------------------------------

            //Semaphore和SemaphoreSlim 两者都可以限制同时访问某一资源或资源池的线程数，实现并发时限制具体数量的线程进行并发操作
            //AutoRestEvent 
            //----------------------------------------------------------------

            Program p1 = new Program();
            Program p2 = new Program();
            Program p3 = new Program();
            Task.Factory.StartNew(()=>p1.methodA("1"));
            Task.Factory.StartNew(() => p2.methodA("2"));
            Task.Factory.StartNew(() => p3.methodA("3"));
            Task.Factory.StartNew(() => p3.methodB("4"));
            Console.ReadKey();
        }

        public void methodA(string item)
        {
            lock (obj)
            {
                Console.WriteLine(item);
            }
        }
        public void methodB(string item)
        {
            lock (obj)
            {
                Console.WriteLine(item);
            }
        }

        private static void DoWork()
        {
            Console.WriteLine("do work--------");
            Console.WriteLine("need 10 seconds");
            Thread.Sleep(10000);
            Console.WriteLine("complete");
            m.ReleaseMutex();
        }

        private static void AddOne()
        {
            for(int i = 1; i < 1000000; i++)
            {
                //sum += 1;此时会致使sum值被多个线程修改，影响最终的sum值
                //Interlocked.Increment(ref sum);
                //Increment 指+1 下面的Add方法可以达到同样效果
                Interlocked.Add(ref sum, 1);
            }
        }

        private static void LockMethod1(object obj1, object obj2)
        {
            lock (obj1)
            {
                Thread.Sleep(1000);
                if(Monitor.TryEnter(obj2, 5000))
                {
                    Console.WriteLine("LockMethod1:get obj2");
                }
                else
                {
                    Console.WriteLine("LockMethod1:get obj2 failed");
                }
                //lock (obj2)
                //{
                //    Console.WriteLine("LockMethod1:get obj2");
                //}
            }
        }
        private static void LockMethod2(object obj1, object obj2)
        {
            lock (obj2)
            {
                Thread.Sleep(1000);
                lock (obj1)
                {
                    Console.WriteLine("LockMethod2:get obj1");
                }
            }
        }

        private static void Method1()
        {
            sum = 0;
            lock (obj)
            {
                for(int i = 0; i < 10; i++)
                {
                    sum += i;
                    Console.WriteLine("Method1 : {0}",sum);
                    Thread.Sleep(1000);
                }
            }
        }
        private static void Method2()
        {
            sum = 0;
            lock (obj)
            {
                for (int i = 0; i < 5; i++)
                {
                    sum += i;
                    Console.WriteLine("Method2 : {0}", sum);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void OneTest()
        {
            Thread thisTHread = Thread.CurrentThread;
            Console.WriteLine("线程标识：" + thisTHread.Name);
            Console.WriteLine("当前地域：" + thisTHread.CurrentCulture.Name);  // 当前地域
            Console.WriteLine("线程执行状态：" + thisTHread.IsAlive);
            Console.WriteLine("是否为后台线程：" + thisTHread.IsBackground);
            Console.WriteLine("是否为线程池线程" + thisTHread.IsThreadPoolThread);
        }
    }
}
