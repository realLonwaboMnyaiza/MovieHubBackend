using System.Collections.Generic;

namespace MovieHub.Web.ViewModels;

public class MovieForm
{
    public IEnumerable<Genre> Genres { get; set; }
    public Movie Movie { get; set; }
    public string Title 
    { 
        get
        {
            if (movie != null && movie.Id != 0)
                return "Edit Movie";

            return "Create New Movie";
        }
    }
}