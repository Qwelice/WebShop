namespace WebShopBLL.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;

    public class PaginationHelper<T>
    {
        private IList<T> _collection;
        private int _itemsPerPage;
        public PaginationHelper(IList<T> collection, int itemsPerPage)
        {
            _collection = collection;
            _itemsPerPage = itemsPerPage;
        }

        public int ItemCount => _collection.Count;

        public int PageCount
        {
            get
            {
                var expand = ItemCount % _itemsPerPage != 0 ? 1 : 0;
                return ItemCount / _itemsPerPage + expand;
            }
        }

        public int PageItemCount(int pageIndex)
        {
            return pageIndex >= PageCount || pageIndex < 0 ? -1 : _collection.Skip(pageIndex * _itemsPerPage).Take(_itemsPerPage).Count();
        }

        public int PageIndex(int itemIndex)
        {
            if (itemIndex >= ItemCount || itemIndex < 0)
            {
                return -1;
            }
            var count = itemIndex + 1;
            return count % _itemsPerPage == 0 ? count / _itemsPerPage - 1 : count / _itemsPerPage;
        }
    }
}
