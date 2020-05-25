
$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "/api/v1/bedrijf/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            $.each(data, function (i, item) {
                

                $("#bedrijfstabel").append(


                    "< div class= 'row' >" +
                    "<div class='column' style='background-color:#ccc;'>" +
                    "<p>" + item.bedrijfNaam + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#ddd;'>" +
                    "<p>" + item.email + "</p>" +

                    "</div>" +
                    "<div class='column' style='background-color:#ccc;'>" +
                    "<p>" + item.adres + "</p>" +

                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.tel + "</p>" +

                    "</div>" +
                    "</div >"
                )
            });
        }
    })
});


