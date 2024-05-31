using System.Collections.Generic;

namespace RecyclingApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<RecyclableType> RecyclableTypes { get; set; }
        public IEnumerable<RecyclableItem> RecyclableItems { get; set; }
        public RecyclableType NewRecyclableType { get; set; }
        public RecyclableItem NewRecyclableItem { get; set; }
    }
}
