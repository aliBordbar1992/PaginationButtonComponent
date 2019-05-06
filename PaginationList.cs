using System.Collections.Generic;

namespace Accounting.UI.Web.Models
{
    public class PaginationList
    {
        public int TotalPages { get; }
        public int CurrentPage { get; }
        public string Controller { get; }
        public string Action { get; }
        public int MaxButtonsToShow { get; }

        public string FirstButtonText { get; }
        public string LastButtonText { get; }
        public string NextButtonText { get; }
        public string PreviousButtonText { get; }

        public List<PageItem> PagesList { get; }
        public object RouteValues { get; }

        public PaginationList(int totalPages, int currentPage, string controller, string action, object routeValues)
        {
            TotalPages = totalPages;
            CurrentPage = currentPage;
            Controller = controller;
            Action = action;
            RouteValues = routeValues;
            FirstButtonText = "First";
            LastButtonText = "Last";
            NextButtonText = "Next";
            PreviousButtonText = "Previous";
            PagesList = new List<PageItem>();
            GeneratePageList();
        }
        public PaginationList(int totalPages, int currentPage, string controller, string action, object routeValues, string firstButtonText, string lastButtonText, string nextButtonText, string previousButtonText) : this(totalPages, currentPage, controller, action, routeValues)
        {
            FirstButtonText = firstButtonText;
            LastButtonText = lastButtonText;
            NextButtonText = nextButtonText;
            PreviousButtonText = previousButtonText;
            PagesList = new List<PageItem>();
            GeneratePageList();
        }

        //private void GeneratePageList()
        //{
        //    if (TotalPages == 1)
        //        return;

        //    if (CurrentPage > 1)
        //    {
        //        //print "Prev"
        //        PagesList.Add(new PageItem(CurrentPage - 1, PreviousButtonText));
        //    }

        //    //print "1"
        //    PagesList.Add(new PageItem(1, FirstButtonText));

        //    if (CurrentPage > 2)
        //    {
        //        //print "..."
        //        PagesList.Add(new PageItem(-1, "...", false));

        //        if (CurrentPage == TotalPages && TotalPages > 3)
        //        {
        //            //print CurrentPage - 2
        //            PagesList.Add(new PageItem(CurrentPage - 2, $"{CurrentPage - 2}"));
        //        }
        //        //print CurrentPage - 1
        //        PagesList.Add(new PageItem(CurrentPage - 1, $"{CurrentPage - 1}"));
        //    }


        //    if (CurrentPage != 1 && CurrentPage != TotalPages)
        //    {
        //        //print CurrentPage
        //        PagesList.Add(new PageItem(CurrentPage, $"{CurrentPage}"));
        //    }

        //    if (CurrentPage < TotalPages - 1)
        //    {
        //        //print CurrentPage + 1
        //        PagesList.Add(new PageItem(CurrentPage + 1, $"{CurrentPage + 1}"));
        //        if (CurrentPage == 1 && TotalPages > 3)
        //        {
        //            //print CurrentPage + 2
        //            PagesList.Add(new PageItem(CurrentPage + 2, $"{CurrentPage + 2}"));
        //        }

        //        //print "..."
        //        PagesList.Add(new PageItem(-1, "...", false));
        //    }

        //    //print TotalPagesPages
        //    PagesList.Add(new PageItem(TotalPages, LastButtonText));

        //    if (CurrentPage < TotalPages)
        //    {
        //        //print "Next"
        //        PagesList.Add(new PageItem(CurrentPage + 1, NextButtonText));
        //    }
        //}

        private void GeneratePageList()
        {
            var delta = 2;
            var left = CurrentPage - delta;
            var right = CurrentPage + delta + 1;
            var range = new List<int>();
            int l = -1;

            for (int i = 1; i <= TotalPages; i++)
            {
                if (i == 1 || i == TotalPages || i >= left && i < right)
                {
                    range.Add(i);
                }
            }

            foreach (var i in range)
            {
                if (l != -1)
                {
                    if (i - l == 2)
                    {
                        PagesList.Add(new PageItem(l + 1, l + 1 + ""));
                    }
                    else if (i - l != 1)
                    {
                        PagesList.Add(new PageItem(-1, "...", false));
                    }
                }

                PagesList.Add(new PageItem(i, i + ""));
                l = i;
            }
        }
    }

    public class PageItem
    {
        public PageItem(int pageNumber, string caption, bool isButton = true)
        {
            PageNumber = pageNumber;
            Caption = caption;
            IsButton = isButton;
        }

        public int PageNumber { get; }
        public string Caption { get; }
        public bool IsButton { get; }
    }
}