using oslomet_film.DAL;
using oslomet_film.Models;
using System.Data.Entity;

namespace oslomet_film.DAL
{
    class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            Movie newMovie = new Movie
            {
                Title = "Spiderman",
                Price = 99,
                Description = "En film om en edderkopp mann",
                Thumbnail = "https://get.pxhere.com/photo/plastic-red-toy-iron-man-action-figure-marvel-superhero-spiderman-fictional-character-621150.jpg"
            };

            Movie newMovie2 = new Movie
            {
                Title = "Batman",
                Price = 56,
                Description = "En film om en flagermus mann",
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/8/89/Batman_%28retouched%29_%28cropped%29.jpg"
            };

            Movie newMovie3 = new Movie
            {
                Title = "Jame Bond",
                Price = 129,
                Description = "En film fylt med action",
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/2/2e/James_Bond_at_Madame_Tussauds%2C_London.jpg"
            };

            Movie newMovie4 = new Movie
            {
                Title = "De Utrolige",
                Price = 39,
                Description = "En veldig hyggelig barnefilm",
                Thumbnail = "https://orig00.deviantart.net/ac74/f/2010/253/d/e/the_incredibles_parr_family_by_kalulu77-d2yfpi2.jpg"
            };

            context.Movie.Add(newMovie);
            context.Movie.Add(newMovie2);
            context.Movie.Add(newMovie3);
            context.Movie.Add(newMovie4);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
