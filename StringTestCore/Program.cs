using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StringTestCore
{
    class Program
    {
        const int testRepeat = 20;
        const int repeats = 50;
        const int testValueMultiplicator = 1;
        static string TestValue;
        static Dictionary<string, Tuple<long, string, long, long, long>> result = new Dictionary<string, Tuple<long, string, long, long, long>>();

        static void Main(string[] args)
        {
            SeedTestValue();

            Test(String1, "String1");
            Test(String2, "String2");
            Test(String3, "String3");
            Test(String4, "String4");
            Test(String5, "String5");
            //Test(String6, "String6");
            Test(String7, "String7");
            Test(String8, "String8");
            Test(String9, "String9");
            Test(String10, "String10");
            Test(String11, "String11");
            Console.WriteLine("Tests Complete");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Results");
            Console.ResetColor();
            foreach (var item in result.OrderBy(x => x.Value.Item1))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(item.Value.Item2);
                Console.ResetColor();
                Console.WriteLine("min Duration =>" + GetTimeSpan(new TimeSpan(item.Value.Item4)));
                Console.WriteLine("max Duration =>" + GetTimeSpan(new TimeSpan(item.Value.Item5)));
                Console.WriteLine($"Max Memory:{SizeSuffix(item.Value.Item3)}");
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Finish");
            Console.ResetColor();

            Console.ReadKey();
        }

        #region Helper
        static string GetTimeSpan(TimeSpan timeSpan)
        {
            return $"Minutes:{timeSpan.Minutes} Seconds:{timeSpan.Seconds} Milliseconds:{timeSpan.Milliseconds}";
        }

        static void Test(Action action, string testName)
        {
            long avg = 0;
            long maxMem = 0;
            long max = 0;
            long min = 0;
            long cur = 0;
            TimeSpan ts;
            Console.WriteLine($"Test: {testName}");

            using (Process proc = Process.GetCurrentProcess())
            {
                for (int i = 0; i < testRepeat; i++)
                {
                    proc.Refresh();
                    if (proc.PrivateMemorySize64 > maxMem)
                        maxMem = proc.PrivateMemorySize64;
                    cur = Messura(action).Ticks;
                    avg += cur;
                    if (cur > max)
                        max = cur;
                    if (cur < min || min == 0)
                        min = cur;
                }
                ts = new TimeSpan(avg / testRepeat);
                string avgAction = $"{testName} = Average Duration => {GetTimeSpan(ts)}";
                Console.WriteLine(avgAction);
                result.Add(testName, new Tuple<long, string, long, long, long>(ts.Ticks, avgAction, maxMem, min, max));
            }

        }

        static TimeSpan Messura(Action action)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            action();
            watch.Stop();
            var ts = new TimeSpan(watch.ElapsedTicks);

            Console.WriteLine($"Duration => Minutes:{ts.Minutes} Seconds:{ts.Seconds} Milliseconds:{ts.Milliseconds}");
            return ts;
        }

        static void SeedTestValue()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var createChars = new char[1048576]; // 1MB Test String
            var random = new Random();

            for (int y = 0; y < createChars.Length; y++)
            {
                createChars[y] = chars[random.Next(chars.Length)];
            }
            StringBuilder stringBuilder = new StringBuilder(testValueMultiplicator);
            for (int i = 0; i < testValueMultiplicator; i++)
            {
                stringBuilder.Append(new String(createChars));
            }
            TestValue = stringBuilder.ToString();
        }

        //https://stackoverflow.com/a/14488941
        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }
        #endregion

        static void String1()
        {
            string value = TestValue;
            string str = null;
            for (int i = 0; i < repeats; i++)
            {
                str += value;
            }
        }

        static void String2()
        {
            string value = TestValue;
            string str = null;
            for (int i = 0; i < repeats; i++)
            {
                str = str + value;
            }
        }

        static void String3()
        {
            string value = TestValue;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < repeats; i++)
            {
                str.Append(value);
            }
            string str1 = str.ToString();
        }

        static void String4()
        {
            string value = TestValue;
            string str = null;
            for (int i = 0; i < repeats; i++)
            {
                str = $"{str}{value}";
            }
        }

        static void String5()
        {
            string value = TestValue;
            string str = "";
            for (int i = 0; i < repeats; i++)
            {
                str = str.Insert(str.Length, value);
            }
        }

        static void String6()
        {
            string value = TestValue;
            string str = "";
            for (int i = 0; i < repeats; i++)
            {
                str = string.Format(str + "{0}", value);
            }
        }

        static void String7()
        {
            string value = TestValue;
            string str = "";
            List<string> list = new List<string>();
            for (int i = 0; i < repeats; i++)
            {
                list.Add(value);
            }
            str = string.Concat(list);
        }

        static void String8()
        {
            string value = TestValue;
            List<string> list = new List<string>();
            for (int i = 0; i < repeats; i++)
            {
                list.Add(value);
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                stringBuilder.Append(list[i]);
            }
            string str = stringBuilder.ToString();
        }

        static void String9()
        {
            string value = TestValue;
            List<string> list = new List<string>();
            for (int i = 0; i < repeats; i++)
            {
                list.Add(value);
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string item in list)
            {
                stringBuilder.Append(item);
            }
            string str = stringBuilder.ToString();
        }

        static void String10()
        {
            string value = TestValue;
            List<string> list = new List<string>();
            for (int i = 0; i < repeats; i++)
            {
                list.Add(value);
            }
            StringBuilder stringBuilder = new StringBuilder(list.Count);
            foreach (string item in list)
            {
                stringBuilder.Append(item);
            }
            string str = stringBuilder.ToString();
        }

        static void String11()
        {
            string value = TestValue;
            StringBuilder str = new StringBuilder(repeats);
            for (int i = 0; i < repeats; i++)
            {
                str.Append(value);
            }
            string str1 = str.ToString();
        }

    }
}
