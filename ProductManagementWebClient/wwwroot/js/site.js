// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    ShowAllProducts();

    function ShowAllProducts() {
        $("table tbody").html("");
        $.ajax({
            url: "http://localhost:5000/odata/Products",
            type: "get",
            contentType: "application/json",
            success: function (result, status, xhr) {
                $.each(result, function (index, value) {
                    $("tbody").append($("<tr>"));
                    appendElement = $("tbody tr").last();
                    appendElement.append($("<td>").html(value["productid"]));
                    appendElement.append($("<td>").html(value["productname"]));
                    appendElement.append($("<td>").html(value["unitprice"]));
                })
            }, error: function (xhr, status, error) {
                console.log(xhr);
            }
        })
    }
});
