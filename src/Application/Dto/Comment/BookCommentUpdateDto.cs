﻿using System.Collections.Generic;

namespace Application.Dto.Comment
{
    public class BookCommentUpdateDto
    {
        public IEnumerable<string> Ids { get; set; }
        public string Text { get; set; }
    }
}
