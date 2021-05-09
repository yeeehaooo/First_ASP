using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace First_ASP.Models
{
    public class ShowLotto
    {
        public string getLotto()
        {
            //取6個不重複亂數
            Random rand = new Random();
            int count = 0;
            int[] numbers = new int[6];
            while (count < 6)
            {
                int temp = rand.Next(1, 50);
                // 檢查重複ckeck_numbers()
                if (!ckeck_numbers(temp, numbers))
                {
                    numbers[count] = temp;
                    count++;
                }
            }
            //INT陣列排序
            numbers_Sort(numbers);           
            //View
            string s = "";
            foreach (int i in numbers)
                s +=$"<p style='font-size:50'>{i}   </p>" ;
            return s;
        }


        //INT陣列排序
        private void numbers_Sort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j + 1] < numbers[j])
                    {
                        int big = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = big;

                    }
                }
            }
        }


        // 檢查重複ckeck_numbers()
        private bool ckeck_numbers(int temp ,int[] numbers)
        {
            foreach (var n in numbers)
            {
                if (n == temp)
                {
                    return true;
                }
            }
            return false;
        }
    }
}