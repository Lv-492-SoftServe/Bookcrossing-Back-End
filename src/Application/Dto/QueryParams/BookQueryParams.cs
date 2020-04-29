﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Dto.QueryParams
{
    public class BookQueryParams : PageableParams
    {
        public FilterParameters[] BookFilters { get; set; }
        public FilterParameters[] AuthorFilters { get; set; }
        public FilterParameters[] GenreFilters { get; set; }
        public FilterParameters[] LocationFilters { get; set; }
    }
}