using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LINQExtentions
{
    public static class LINQExtensions
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, TResult> selector) 
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");
            return (from item in source select selector(item));
            
        }


        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            foreach (var item in source)
            {
                if(predicate(item))
                    yield return item;
            }
        }


        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) 
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            return (from item in source group item by keySelector(item));

        }


        public static List<TSource> MyToList<TSource>(this IEnumerable<TSource> source) 
        {
            if (source == null)
                throw new ArgumentNullException("source");
            List<TSource> mylist = new List<TSource>();
            foreach (var item in source)
                mylist.Add(item);
            return mylist;

        }


        public static IOrderedEnumerable<TSource> MyOrderBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) 
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            return (from item in source orderby keySelector(item) select item);
        }

        public static IOrderedEnumerable<TSource> MyOrderByDescending<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.OrderByDescending(y => keySelector(y));
        }


        public static Dictionary<TKey, TSource> MyToDictionary<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.ToDictionary(item => keySelector(item), item => item);
        }
        
    }
}
