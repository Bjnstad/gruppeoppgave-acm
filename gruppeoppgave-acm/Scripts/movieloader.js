/**
 *  Filter on  categories 
 */
$(".cat-checkbox").change(function () {
    if (this.checked) {
        $.ajax({
            type: "GET",
            url: "/Home/FilterMovie",
            data: "category=" + this.value
        }).done(function (response) {
            if (response === "null") {
                console.log("null: " + response);
            } else {
                $('#movies').html(response);
            }
        });
    }
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
    var movies = $("#movies").children();
    var parent = element.target.offsetParent;
    console.log(movies.index(parent))
})


