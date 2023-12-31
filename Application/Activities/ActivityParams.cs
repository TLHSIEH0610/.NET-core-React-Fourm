using Application.Core;

namespace Application.Activities
{
    public class ActivityParams : PagingParams
    {
        public string ActivityFilter { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}