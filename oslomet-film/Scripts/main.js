/**
 *  Filter on  categories 
 */
$(".category").click(function () {
    $.ajax({
        type: "GET",
        url: "/Movie/FilterMovies",
        data: "categoryID=" + this.id
    }).done(function (response) {
        if (response === "null") {
            console.log("null: " + response);
        } else {
            $('#movies').html(response);
        }
    });
});


/**
 * Buy movie
 */
$(".movie-thumbnail2").click(function () {
    $.ajax({
        type: "GET",
        url: "/Home/BuyMovie",
        data: "movieID=" + this.id
    }).done(function (response) {
        console.log("Resp: " + response);
    });
})


/**
 *  Extend movie view
 */
$(".movie-thumbnail").click(function (element) {
    $.ajax({
        type: "GET",
        url: "/Home/GetMovie",
        data: "movieID=" + this.id
    }).done(function (response) {
        // TODO: Check failed respons


        var movies = $("#movies").children();
        var parent = element.target.offsetParent;
        var index = movies.index(parent);

        console.log(movies[index]);
        var e = document.getElementById("movies");
        

        
        var div = document.createElement('div');
        $(div).html(response);

        $("#movies").append(response.trim());
    });
})