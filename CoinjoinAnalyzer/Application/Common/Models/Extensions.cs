namespace Application.Common.Models
{
    public static class Extensions
    {
        public static ICollection<T> SkipAndTake<T>(this List<T> list, out int count, int? skip = 0, int? take = 0)
        {
            List<T> items = default(List<T>);
            count = 0;
            try
            {
                if (list != null)
                {
                    count = list.Count;
                    if (skip == 0 & take == 0)
                    {
                        items = list;
                    }
                    else if (skip > 0 & take == 0)
                    {
                        items = list.Skip(skip.Value).ToList();
                    }
                    else if (skip == 0 & take > 0)
                    {
                        items = list.Take(take.Value).ToList();
                    }
                    else
                    {
                        items = list.Skip(skip.Value).Take(take.Value).ToList();
                    }
                }
            }
            catch (Exception ex) { }
            return items;
        }

        public static ICollection<T> SkipAndTake<T>(this List<T> list, int? skip = 0, int? take = 0)
        {
            List<T> items = new List<T>();
            try
            {
                if (list != null)
                {
                    if (skip == 0 & take == 0)
                    {
                        items = list;
                    }
                    else if (skip > 0 & take == 0)
                    {
                        items = list.Skip(skip.Value).ToList();
                    }
                    else if (skip == 0 & take > 0)
                    {
                        items = list.Take(take.Value).ToList();
                    }
                    else
                    {
                        items = list.Skip(skip.Value).Take(take.Value).ToList();
                    }
                }
            }
            catch (Exception ex) { }
            return items;
        }

        public static PaginatedList<T> Paginate<T>(this List<T> list, int? skip = 0, int? take = 0)
        {
            var result = new PaginatedList<T>();
            try
            {
                var items = new List<T>();
                if (list != null)
                {
                    if (skip == 0 & take == 0)
                    {
                        items = list;
                    }
                    else if (skip > 0 & take == 0)
                    {
                        items = list.Skip(skip.Value).ToList();
                    }
                    else if (skip == 0 & take > 0)
                    {
                        items = list.Take(take.Value).ToList();
                    }
                    else
                    {
                        items = list.Skip(skip.Value).Take(take.Value).ToList();
                    }
                }
                result = new PaginatedList<T>
                {
                    PageList = items,
                    TotalCount = list.Count()
                };
            }
            catch (Exception ex) { }
            return result;
        }

        public class PaginatedList<T>
        {
            public List<T> PageList { get; set; }
            public int TotalCount { get; set; }
        }
    }
}
