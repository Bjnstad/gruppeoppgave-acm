
/*
 * $("#@Html.IdFor(model => model.Postnummer)").change(function () {

});

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
})
