using System.Collections.Generic;

namespace oslomet_film.Model
{
    public class MovieHelper
    {
        public virtual Movie movie { get; set; }
        public IList<Category> selectList { get; set; }
        public virtual IList<string> selectedList { get; set; }
    }
}
