$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/api/v1/supplier/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {

            $.each(data, function (i, item) {
                $("#inlineFormCustomSelect").append(
                    "<option>" + item.name + "</option>"
                )
            });
        }

    })


});

function AddToestel(serienummer, aankoopdatum, prijs, garantie) {

    var theUrl = "/api/v1/toestel/add?serieNummer=" + serienummer + "&aankoopDatum=" + aankoopdatum + "&prijs=" + prijs + "&garantie=" + garantie;
    console.log(theUrl);
    $.ajax({
        type: "PUT",
        url: theUrl,
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log("toegevoegd");
        }

    })

};