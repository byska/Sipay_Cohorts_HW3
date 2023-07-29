using Sipay_Cohorts_HW3.Entities.BaseModel;
using Sipay_Cohorts_HW3.Entities.Enums;

namespace Sipay_Cohorts_HW3.Entities.DbSets
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public Genre GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
