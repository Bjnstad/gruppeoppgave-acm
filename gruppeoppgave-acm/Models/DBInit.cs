using System.Collections.Generic;
using System.Data.Entity;

namespace gruppeoppgave_acm.Models
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            Category superhelt = new Category
            {
                Name = "Superhelt"
            };

            Category action = new Category
            {
                Name = "Action"
            };


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

            context.Categories.Add(superhelt);

            Category_Relation cr = new Category_Relation
            {
                Movie = newMovie,
                Category = superhelt
            };

            Category_Relation cr2 = new Category_Relation
            {
                Movie = newMovie2,
                Category = superhelt
            };

            Category_Relation cr3 = new Category_Relation
            {
                Movie = newMovie3,
                Category = action
            };

            context.Category_Relations.Add(cr);
            context.Category_Relations.Add(cr2);
            context.Category_Relations.Add(cr3);

            base.Seed(context);
        }
    }
}