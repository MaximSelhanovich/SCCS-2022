using System.Linq.Expressions;
using WEB_053502_Selhanovich.Entities;

namespace WEB_053502_Selhanovich.Models
{
    public class ListViewModel<T>: List<T>
    {
        private static int _currentPageNumber;
        private static int _totalNumberOfPages;
        private static IQueryable<T> _currentItems;

        public int CurrentPageNumber { get { return _currentPageNumber; } }
        public int TotalNumberOfPages { get { return _totalNumberOfPages; } }

        private ListViewModel(IQueryable<T> list)
            :base(list)
        {
            
        }

        public static ListViewModel<T> GetModel(IQueryable<T> list, 
                                                int current, int itemsPerPage, 
                                                Expression<Func<T, bool>> filter)
        {
            _currentPageNumber = current;
            _totalNumberOfPages = (int)Math.Ceiling(list.Count() / 3.0);
            var items = list
                        .Where(filter);
            if (current <= 1)
            {
                _totalNumberOfPages = (int)Math.Ceiling(items.Count() / 3.0);
            }
            items = items.Skip((current - 1) * itemsPerPage)
                        .Take(itemsPerPage);
            _currentItems = items;
            return new ListViewModel<T>(items);
        }
    }
}
