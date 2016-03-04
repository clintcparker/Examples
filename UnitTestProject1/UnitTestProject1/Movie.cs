using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Movie
    {
        public int nyt_movie_id { get; set; }
        public string display_title { get; set; }

        public string sort_name { get; set; }
        public string mpaa_rating { get; set; }
        public string byline { get; set; }
        public string headline { get; set; }
        public string capsule_review { get; set; }
        public string summary_short { get; set; }
        public string publication_date { get; set; }
        public string opening_date { get; set; }
        public string dvd_release_date { get; set; }
        public string date_updated { get; set; }
        public string seo_name { get; set; }

        public Link link { get; set; }

        public List<Link> related_urls { get; set; }

        public DateTime? PublicationDate
        {
            get
            {
                DateTime date;
                var success = DateTime.TryParse(publication_date, out date);
                return success ? date : (DateTime?)null;
            }
        }

        public DateTime? OpeningDate
        {
            get
            {
                DateTime date;
                var success = DateTime.TryParse(opening_date, out date);
                return success ? date : (DateTime?)null;
            }
        }

    }
}
