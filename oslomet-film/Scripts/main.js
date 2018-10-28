/**
 *  Filter on  categories 
 */
$(".category").click(function () {
    refreshMovies(this.id)
});

/**
 * Add movie to cart
 */
$(".add-movie").click(function () {
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
        console.log(response)
        if (response === "") {
            window.location.href = "/Customer/Login";
        } else {
            window.location.href = "/Profile";
        }
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
 *  Open/close cart
 */
$("#cart").click(function (e) {
    $(".cart-popout-open").toggleClass("hide show").toggleClass("cart-popoup-open cart-popoup-close");
    e.stopPropagation();
});

$(".cart-popoup-close").click(function (e) {
    e.stopPropagation();
});

$(document).click(function () {
    $(".cart-popout-close").toggleClass("show hide").toggleClass("cart-popoup-close cart-popoup-open");
});

/**
 *  Edit user Adminpanel Modal
 */

$(function () {
    $('.editUsersModal').on("click", function (e) {
        e.preventDefault();
        //perform the url load  then
        $('#myModal').modal({
            keyboard: true
        }, 'show');
        return false;
    })
})
