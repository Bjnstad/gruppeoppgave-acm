﻿/**
 *  Filter on  categories 
 */
$(".category").click(refreshMovies(this.id));

/**
 * Add movie to cart
 */
$(".movie-thumbnail").click(function () {
    $.ajax({
        type: "GET",
        url: "/Cart/AddMovie",
        data: "movieID=" + this.id
    }).done(function (response) {
        $("#cart").html(response)
    });
});

/**
 * Complete the cart
 */
$(".complete-cart").click(() => {
    $.ajax({
        type: "GET",
        url: "/Cart/CompleteOrder"
    }).done(function (response) {
        console.log(response);

        // TODO: Check for success
        refreshMovies(0);

        //$("#cart").html(response)
    });
});


function refreshMovies(categorId) {
    $.ajax({
        type: "GET",
        url: "/Movie/FilterMovies",
        data: "categoryID=" + categorId
    }).done(function (response) {
        if (response === "null") {
            console.log("null: " + response);
        } else {
            $('#movies').html(response);
        }
    });
}












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
 *  Open/close collapse - movie details
 */
$(function () {
    $(".detailsModal").click(function () {
        $("#displayModalContent").show();
    });
    $(".modal-close").click(function () {
        $("#displayModalContent").hide();
    });
});
/**
 *  Open/close cart not working
 */
$(function () {
    $("#cart").click(function (e) {
        $.ajax({
            type: "GET",
            url: "/Cart/GetTotal"
        })
        $(".cart-popout-open").toggleClass("hide show").toggleClass("cart-popoup-open cart-popoup-close");
        e.stopPropagation();
    });

    $(".cart-popoup-close").click(function (e) {
        e.stopPropagation();
    });

    $(document).click(function () {
        $(".cart-popout-close").toggleClass("show hide").toggleClass("cart-popoup-close cart-popoup-open");
    });
    
});

/**
 * Add movie to cart
 */
/*$(".movie-thumbnail").click(function () {
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