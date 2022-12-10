using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using ClockC_;

namespace ClockC_
{
 
    class Program
    {
        
         [DllImport(@"\\main\RDP\41П\герасимовна\Desktop\TimeoClock-master\x64\Debug\TimeoClock.dll")]
        public static extern void FF();
        static bool[] F = new bool[2];
        Time time = new Time(5, 5, 5,5);
        static Time t = new Time(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

        [Obsolete]
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
            int cmd = 0;
            Console.WriteLine("DLL - 1, С# остальные символы");
            cmd = Convert.ToInt32(Console.ReadLine());
            if (cmd == 1)
            {
                FF();
            }

            else
            {
                F[0] = true;
                F[1] = false;
                Thread Thread = new Thread(new ThreadStart(Clock));
                Thread.Start();
                while (true)
                {

                    cmd = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (cmd == 1)
                    {
                        try
                        {
                            Thread.Resume();
                        }
                        catch
                        {


                        }
                        t = new Time(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                        Console.Clear();
                    }
                    if (cmd == 0)
                    {
                        Thread.Suspend();
                        Console.Clear();
                        Console.WriteLine("0-Остановка;1-Запуск;2-Сменить время;3-Поставить системное;4-Вкл/выкл секундомер,5-Вкл/выкл таймер");
                    }
                    if (cmd == 2)
                    {
                        try
                        {
                            Thread.Suspend();
                        }
                        catch
                        {

                        }
                        ChangeTime();
                        try
                        {
                            Thread.Resume();
                        }
                        catch
                        {

                        }
                    }
                    if (cmd == 3)
                    {
                        t = new Time(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                        Console.Clear();
                        try
                        {
                            Thread.Resume();
                        }
                        catch
                        {

                        }
                    }
                    if (cmd == 4)
                    {
                        F[1] = !F[1];
                        if (F[1])
                        {
                            t.Hour = 0;
                            t.Minute = 0;
                            t.Second = 0;
                            t.Milliseconds = 0;
                            try
                            { 
                                Thread.Resume();
                            } 
                            catch 
                            {

                            }

                        }
                        else
                        {
                            t = new Time(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                        }
                        Console.Clear();
                    }
                    if (cmd == 5)
                    {
                        F[0] = !F[0];
                        try
                        {
                            Thread.Suspend();
                        }
                        catch { }
                        if (!F[0])
                        {
                            ChangeTime();
                        }
                        else
                        {
                            t = new Time(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                        }
                        try
                        {

                            Thread.Resume();
                        }
                        catch
                        {


                        }
                    }
                    if (cmd == 6)
                    {

                        Thread.Suspend();
                        Console.WriteLine("Пауза активирована!");
                        Thread.Sleep(5);
                        Console.Clear();

                    }
                    if (cmd == 7)
                    {
                        Thread.Resume();
                        Console.WriteLine("Пауза деактивирована!");
                        Thread.Sleep(5);
                        Console.Clear();

                    }
                }
            }
        }
        public static void ChangeTime()
        {
            Console.Clear();
            int d = 0;
            Console.WriteLine("Введите часы:");
            d = Convert.ToInt32(Console.ReadLine());
            t.Hour = d;
            Console.WriteLine("Введите минуты:");
            d = Convert.ToInt32(Console.ReadLine());
            t.Minute = d;
            Console.WriteLine("Введите секунды:");
            d = Convert.ToInt32(Console.ReadLine());
            t.Second = d;
            Console.Clear();
        }
        public static void Clock()
        {
            DateTime st;
            st = DateTime.Now;
            Time nt = new Time(st.Hour, st.Minute, st.Second, st.Millisecond);
            while (true)
            {
                st = DateTime.Now;
                if (F[1])
                {
                    if ((st.Millisecond / 100) != (nt.Milliseconds / 100) || nt.Hour != st.Hour || nt.Minute != st.Minute || nt.Second != st.Second)
                    {
                        Console.Clear();
                        nt = new Time(st.Hour, st.Minute, st.Second, st.Millisecond);
                        Console.WriteLine(t.Hour + ":" + t.Minute + ":" + t.Second + ":" + t.Milliseconds);
                        if (F[0])
                        {
                            t.Milliseconds++;
                            if (t.Milliseconds == 10)
                            {
                                t.Milliseconds = 0;
                                t.Second++;
                            }
                            if (t.Second == 60)
                            {
                                t.Second = 0;
                                t.Minute++;
                            }
                            if (t.Minute == 60)
                            {
                                t.Minute = 0;
                                t.Hour++;
                            }
                            if (t.Hour == 24)
                            {
                                t.Hour = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (nt.Hour != st.Hour || nt.Minute != st.Minute || nt.Second != st.Second)
                    {
                        Console.Clear();

                        nt = new Time(st.Hour, st.Minute, st.Second, st.Millisecond);
                        Console.WriteLine(t.Hour + ":" + t.Minute + ":" + t.Second + " ");
                        if (F[0])
                        {
                            t.Second++;
                            if (t.Second == 60)
                            {
                                t.Second = 0;
                                t.Minute++;
                            }
                            if (t.Minute == 60)
                            {
                                t.Minute = 0;
                                t.Hour++;
                            }
                            if (t.Hour == 24)
                            {
                                t.Hour = 0;
                            }
                        }
                        else
                        {
                            if (t.Hour == 0 && t.Minute == 0 && t.Second == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("0:0:0 Время истекло");
                            }
                            else
                            {
                                if (t.Hour != 0 && t.Minute == 0 && t.Second == 0)
                                {
                                    t.Minute = 59;
                                    t.Second = 60;
                                    t.Hour--;
                                }
                                if (t.Minute != 0 && t.Second == 0)
                                {
                                    t.Second = 60;
                                    t.Minute--;
                                }
                                if (t.Second != 0)
                                {
                                    t.Second--;
                                }
                            }
                        }
                    }
                }
            }
        }

    }

    
}
