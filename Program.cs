﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPack
{
    class Program
    {
        static void Main(string[] args)
        {


            var n = 0;
            var m = 0;
            var k = 0;

            //خواندن ورودی ها
            Console.WriteLine($"Enter Things Number :");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter Boxs Number :");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter Boxs Volume :");
            k = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter Things (Weith Must Be <= {k}) :");

            int[] things = new int[n];
            int[] boxs = new int[m];

            //دریافت لیست اشیاء
            for (int q = 0; q < n; q++)
            {
                var inp = int.Parse(Console.ReadLine());
                while (inp > k)
                {
                    inp = int.Parse(Console.ReadLine());
                }

                things[q] = inp;
            }

            //ایجاد جعبه ها
            for (int r = 0; r < m; r++)
            {
                boxs[r] = k;
            }


            var thingW = 0;
            var boxesCap = 0;

            //محاسبه وزن کل اشیاء
            foreach (var item in things)
            {
                thingW += item;
            }
            //محاسبه ظرفیت جعبه ها
            foreach (var item in boxs)
            {
                boxesCap += item;
            }

            // شناسایی مکان اولیه جواب باتوجه به وزن اشیاء بعد از جواب و ظرفیت جعبه ها 
            var j = 0;
            while (thingW > boxesCap)
            {
                thingW -= things[j];
                j++;
            }
            //حرکت به سمت راست در صورتی که تمامی اشیاء در جعبه ها جای نگیرند
            for (int i = j; i < things.Length; i++)
            {
                var l = i;
                for (int p = 0; p < boxs.Length; p++)
                {
                    var reThw = things[l];
                    
                    while (boxs[p] >= reThw && l < (things.Length - 1))
                    {
                        l++;
                        reThw += things[l];
                        
                    }
                }

                if (l == things.Length)
                {
                    j = i;
                    break;
                }
            }

            //نمایش نتایج
            var result = things.Length - j;
            Console.WriteLine($"{things.ToString()}");
            Console.WriteLine($"===================================");
            Console.WriteLine($"Answer ( Maximum Number Of Things ) Is : {result}");
            Console.WriteLine($"Index Is : {j}");
            Console.WriteLine($"===================================");
            for (int i = j; i < things.Length; i++)
            {
                Console.WriteLine($"{things[i]} - ");
            }
            Console.ReadKey();
        }
    }
}
