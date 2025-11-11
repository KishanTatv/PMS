namespace PMS.Entity.Models
{
    public class PageCommonDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SortCommonDto
    {
        public string SortBy { get; set; } = "CreatedDate";
        public string SortDirection { get; set; } = "DESC";
    }

    public class FilterCommonDto
    {
        public string? SearchTerm { get; set; }
    }

}
