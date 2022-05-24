using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using QuestRoom.ViewModel.Common;
using QuestRoom.DomainModel;

namespace QuestRoom.DataAccess.Helper
{

    public class ApiResult<TResult> : ApiResultViewModel<TResult>
    {
        /// <summary>
        /// Private constructor called by the CreateAsync method.
        /// </summary>
        private ApiResult(
            List<TResult> data,
            int count,
            int pageIndex,
            int pageSize,
            IEnumerable<SortingRequest> sortingRequests,
            IEnumerable<FilterRequest> filterRequests)
        {
            Data = data;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            SortingRequests = sortingRequests;
            FilterRequests = filterRequests;
        }

        #region Methods
        /// <summary>
        /// Pages, sorts and/or filters a IQueryable source.
        /// </summary>
        /// <param name="source">An IQueryable source of generic type</param>
        /// <param name="pageIndex">Zero-based current page index (0 = first page)</param>
        /// <param name="pageSize">The actual size of each page</param>
        /// <param name="sortColumn">The sorting colum name</param>
        /// <param name="sortOrder">The sorting order ("ASC" or "DESC")</param>
        /// <param name="filterColumn">The filtering column name</param>
        /// <param name="filterQuery">The filtering query (value to lookup)</param>
        /// <returns>
        /// A object containing the IQueryable paged/sorted/filtered result 
        /// and all the relevant paging/sorting/filtering navigation info.
        /// </returns>
        public static async Task<ApiResult<TResult>> CreateAsync(
            IQueryable<TResult> source,
            int pageIndex,
            int pageSize,
            IEnumerable<SortingRequest> sortingRequests = null,
            IEnumerable<FilterRequest> filterRequests = null)
        {
            if (filterRequests is not null)
                foreach (var filterRequest in filterRequests)
                {
                    if (!string.IsNullOrEmpty(filterRequest.FilterColumn)
                   && !string.IsNullOrEmpty(filterRequest.FilterQuery)
                   && IsValidProperty(filterRequest.FilterColumn))
                    {
                        var type = GetPropertyValue(filterRequest.FilterColumn);

                        if (type == typeof(int))
                        {
                            source = source.Where(
                           string.Format("{0}.Equals(@0)",
                           filterRequest.FilterColumn),
                           Convert.ToInt32(filterRequest.FilterQuery));

                        }
                        else if (type == typeof(decimal))
                        {
                            source = source.Where(
                          string.Format("{0}.Equals(@0)",
                          filterRequest.FilterColumn),
                          Convert.ToDecimal(filterRequest.FilterQuery));
                        }

                        else if (filterRequest.IsPartFilter)
                        {
                            source = source.Where(
                                string.Format("{0}.Contains(@0)",
                                filterRequest.FilterColumn),
                                filterRequest.FilterQuery);
                        }
                        else
                        {
                            source = source.Where(
                               string.Format("{0}.Equals(@0)",
                               filterRequest.FilterColumn),
                               filterRequest.FilterQuery);
                        }
                    }
                }

            var count = await source.CountAsync();

            if (sortingRequests is not null)
            {
                var sortingString = string.Empty;

                foreach (var sortingRequest in sortingRequests)
                {
                    if (!string.IsNullOrEmpty(sortingRequest.SortColumn)
                    && IsValidProperty(sortingRequest.SortColumn))
                    {
                        sortingRequest.SortOrder = !string.IsNullOrEmpty(sortingRequest.SortOrder)
                            && sortingRequest.SortOrder.ToUpper() == "ASC"
                            ? "ASC"
                            : "DESC";

                        if (string.IsNullOrEmpty(sortingString))
                        {
                            sortingString += $"{sortingRequest.SortColumn} {sortingRequest.SortOrder}";
                        }
                        else
                        {
                            sortingString += $", {sortingRequest.SortColumn} {sortingRequest.SortOrder}";
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(sortingString))
                {
                    source = source.OrderBy(sortingString);
                }
            }

            source = source
                .Take((pageIndex * pageSize)..pageSize);


            var data = await source.ToListAsync();

            return new ApiResult<TResult>(
                data,
                count,
                pageIndex,
                pageSize,
                sortingRequests,
                filterRequests);
        }

        public static async Task<ApiResult<TResult>> CreateAsync<TResult, DData>(
            Expression<Func<DData, TResult>> selector,
            IQueryable<DData> source,
            int pageIndex,
            int pageSize,
            IEnumerable<SortingRequest> sortingRequests = null,
            IEnumerable<FilterRequest> filterRequests = null)
        {
            if (filterRequests is not null)
                foreach (var filterRequest in filterRequests)
                {
                    if (!string.IsNullOrEmpty(filterRequest.FilterColumn)
                   && !string.IsNullOrEmpty(filterRequest.FilterQuery)
                   && IsValidProperty(filterRequest.FilterColumn))
                    {
                        var type = GetPropertyValue(filterRequest.FilterColumn);

                        if (type == typeof(int))
                        {
                            source = source.Where(
                           string.Format("{0}.Equals(@0)",
                           filterRequest.FilterColumn),
                           Convert.ToInt32(filterRequest.FilterQuery));

                        }
                        else if (type == typeof(decimal))
                        {
                            source = source.Where(
                          string.Format("{0}.Equals(@0)",
                          filterRequest.FilterColumn),
                          Convert.ToDecimal(filterRequest.FilterQuery));
                        }

                        else if (filterRequest.IsPartFilter)
                        {
                            source = source.Where(
                                string.Format("{0}.Contains(@0)",
                                filterRequest.FilterColumn),
                                filterRequest.FilterQuery);
                        }
                        else
                        {
                            source = source.Where(
                               string.Format("{0}.Equals(@0)",
                               filterRequest.FilterColumn),
                               filterRequest.FilterQuery);
                        }
                    }
                }

            var count = await source.CountAsync();

            if (sortingRequests is not null)
            {
                var sortingString = string.Empty;

                foreach (var sortingRequest in sortingRequests)
                {
                    if (!string.IsNullOrEmpty(sortingRequest.SortColumn)
                    && IsValidProperty(sortingRequest.SortColumn))
                    {
                        sortingRequest.SortOrder = !string.IsNullOrEmpty(sortingRequest.SortOrder)
                            && sortingRequest.SortOrder.ToUpper() == "ASC"
                            ? "ASC"
                            : "DESC";

                        if (string.IsNullOrEmpty(sortingString))
                        {
                            sortingString += $"{sortingRequest.SortColumn} {sortingRequest.SortOrder}";
                        }
                        else
                        {
                            sortingString += $", {sortingRequest.SortColumn} {sortingRequest.SortOrder}";
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(sortingString))
                {
                    source = source.OrderBy(sortingString);
                }
            }

            source = source
                .Take((pageIndex * pageSize)..pageSize);

            var data = await source
                .Select(selector)
                .ToListAsync();

            return new ApiResult<TResult>(
                data,
                count,
                pageIndex,
                pageSize,
                sortingRequests,
                filterRequests);
        }

        /// <summary>
        /// Checks if the given property name exists
        /// to protect against SQL injection attacks
        /// </summary>
        public static bool IsValidProperty(
            string propertyName,
            bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(TResult).GetProperty(
                propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);
            if (prop == null && throwExceptionIfNotFound)
                throw new NotSupportedException(
                    string.Format(
                        "ERROR: Property '{0}' does not exist.",
                        propertyName)
                    );
            return prop != null;
        }

        public static Type GetPropertyValue(string propertyName, bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(TResult).GetProperty(
                propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);
            if (prop == null && throwExceptionIfNotFound)
                throw new NotSupportedException(
                    string.Format(
                        "ERROR: Property '{0}' does not exist.",
                        propertyName)
                    );
            return prop.PropertyType;
        }
        #endregion
    }

}