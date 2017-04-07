using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Web.Common
{
    public class RandomHelper
    {
        ///<summary>   
        ///返回一组唯一不重复的随机数   
        ///</summary>   
        ///<param name="minValue">最小值</param>   
        ///<param name="maxValue">最大值</param>   
        ///<returns>返回一组唯一不重复的随机数</returns>   
        public static List<int> GetRandom(int minValue, int maxValue, int count)
        {
            List<int> Numbers = new List<int>();
            //使用Guid.NewGuid().GetHashCode()作为种子，可以确保Random在极短时间产生的随机数尽可能做到不重复   
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            //Console.WriteLine("GUID:" + Guid.NewGuid().GetHashCode());
            int item;
            for (int i = minValue; i <= maxValue; i++)
            {
                item = rand.Next(minValue, maxValue + 1);
                while (Numbers.IndexOf(item) != -1)
                {
                    item = rand.Next(minValue, maxValue + 1);
                }
                Numbers.Add(item);
                if (Numbers.Count >= count)
                    break;

            }

            return Numbers;
        }
    }
}
