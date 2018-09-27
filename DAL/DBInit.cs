using oslomet_film.DAL;
using oslomet_film.Model;
using System.Data.Entity;

namespace oslomet_film.DAL
{

    class DBInit : DropCreateDatabaseAlways<DB>
    {

        protected override void Seed(DB context)
        {
            var salt = CustomerDAL.createSalt();

            /*Customer newCustomer = new DBCustomer
            {
                Username = "axel",
                Name = "Axel",
                Surname = "Bjørnstad",
                Phone = "12345678",
                Email = "axebjo@gmail.com",
                Password = CustomerDAL.createHash("axel", salt),
                Salt = salt
            }; */

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

            Category superhelt = new Category
            {
                Name = "Superhelter",
            };

            Category action = new Category
            {
                Name = "Action"
            };


            Category_Relation relation = new Category_Relation
            {
                Category = superhelt,
                Movie = newMovie
            };

            Category_Relation relation2 = new Category_Relation
            {
                Category = superhelt,
                Movie = newMovie2
            };

            Category_Relation relation3 = new Category_Relation
            {
                Category = action,
                Movie = newMovie3
            };


            context.Movie.Add(newMovie);
            context.Movie.Add(newMovie2);
            context.Movie.Add(newMovie3);
            context.Movie.Add(newMovie4);

            context.Category.Add(superhelt);
            context.Category.Add(action);

            context.Category_Relations.Add(relation);
            context.Category_Relations.Add(relation2);
            context.Category_Relations.Add(relation3);

            //context.Customers.Add(newCustomer);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
