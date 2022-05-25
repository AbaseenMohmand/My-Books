﻿namespace my_books.Data.Models.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBooksVM 
    {
        public string FullName { set; get; }
        public List<string> BookTitles  { get; set; }
    }

}
