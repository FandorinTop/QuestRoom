using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoom.ViewModel.Common
{
    public class ApiResultViewModel<T>
    {
        #region Properties
        /// <summary>
        /// The data result.
        /// </summary>
        public IEnumerable<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// Zero-based index of current page.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Number of items contained in each page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total items count
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Total pages count
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// TRUE if the current page has a previous page, FALSE otherwise.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 0;
            }
        }

        /// <summary>
        /// TRUE if the current page has a next page, FALSE otherwise.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return PageIndex + 1 < TotalPages;
            }
        }

        public IEnumerable<SortingRequest> SortingRequests { get; set; }

        public IEnumerable<FilterRequest> FilterRequests { get; set; }
        #endregion
    }

}
