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

            var newCustomer = new DBCustomer
            {
                Username = "axel",
                Name = "Axel",
                Surname = "Bjørnstad",
                Phone = "12345678",
                Email = "axebjo@gmail.com",
                Password = CustomerDAL.createHash("axel", salt),
                Salt = salt
            }; 

            Movie newMovie = new Movie
            {
                Title = "Utøya",
                Price = 99,
                Description = "En film om en edderkopp mann",
                Thumbnail = "https://secure.sfanytime.se/movieimages/COVER/db3d3b52-e4ab-4c05-b037-a8f500eaa498_COVER_NO.jpg"
            };

            Movie newMovie2 = new Movie
            {
                Title = "Norske byggeklosser",
                Price = 56,
                Description = "En film om en flagermus mann",
                Thumbnail = "https://secure.sfanytime.se/movieimages/COVER/33343aab-4774-4b2f-b77e-a8c100f48d88_COVER_NO.jpg"
            };

            Movie newMovie3 = new Movie
            {
                Title = "A quite place",
                Price = 129,
                Description = "En film fylt med action",
                Thumbnail = "https://secure.sfanytime.se/movieimages/COVER/8af70d64-10fb-4e49-a338-a8d5009dd7fd_COVER_NO.jpg"
            };

            Movie newMovie4 = new Movie
            {
                Title = "Ready Player One",
                Price = 39,
                Description = "En veldig hyggelig barnefilm",
                Thumbnail = "https://secure.sfanytime.se/movieimages/COVER/39c9aef7-ac65-4a15-b304-a8da010616c5_COVER_NO.jpg"
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

            context.Customers.Add(newCustomer);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
