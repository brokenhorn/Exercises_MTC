using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ex3
{
    static class  Program
    {
        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <returns></returns>

        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable,
            int? tailLength)
        {
            List<(T item, int? tail)> 
                ret    = new List<(T item, int? tail)>();
            int enSize = enumerable.Count();
            int i      = 0;
            int? tail  = tailLength - 1;

            foreach (var elem in enumerable)
            {
                if (i >= enSize - tailLength)
                {
                    ret.Add((elem, tail));
                    tail--;
                }
                else
                {
                    ret.Add((elem, null));
                }

                i++;
            }
            return ret;

        }
        static void Main(string[] args)
        {
            IEnumerable < (int item, int? tail) > tmp = new[] {1, 2, 5, 4, 5, 3, 4}.EnumerateFromTail(2);
        }
    }
}
