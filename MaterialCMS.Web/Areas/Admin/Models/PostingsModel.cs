using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Paging;

namespace MaterialCMS.Web.Areas.Admin.Models
{
    public class PostingsModel : AsyncListModel<FormPosting>
    {
        public string Search { get; set; }
        public PostingsModel(IPagedList<FormPosting> items, int id)
            : base(items, id)
        {
        }

        public IEnumerable<string> Headings
        {
            get { return Items.SelectMany(posting => posting.FormValues).Select(value => value.Key).Distinct().Take(7); }
        }
    }
}