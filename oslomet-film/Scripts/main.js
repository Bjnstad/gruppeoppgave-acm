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
 * Buy movies
 */
$("buy-movies").click(function () {
    $.ajax({
        type: "GET",
        url: "/Cart/CreateOrder"
    }).done(function (response) {
        console.log(response)
    });
});


/**
 *  Open cart 
 */
$("#cart").click(function () {
    $(".cart-popout").addClass("show");
});

/**
 * Add movie to cart
 */
$(".movie-thumbnail").click(function () {
    $.ajax({
        type: "GET",
        url: "/Cart/AddItem",
        data: "movieID=" + this.id
    }).done(function (response) {
        $("#cart").html(response)
    });
});


/**
 *  Extend movie view
 */
$(".movie-thumbnail2").click(function (element) {
    $.ajax({
        type: "GET",
        url: "/Movie/GetMovie",
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