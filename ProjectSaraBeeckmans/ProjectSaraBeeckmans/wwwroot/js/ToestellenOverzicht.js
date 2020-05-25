
$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "/api/v1/toestel/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            $("#find").append(
                "<input id = 'myInput'>" +
                "<button id='searchButton' onclick=searchItem(document.getElementById('myInput').value)>Zoek</button>" +
                "<button id='backButton' onclick=originalState()>Terug</button>"

            )

            $.each(data, function (i, item) {

                $("#toestelTabel").append(

                    "<div class= 'row' id='" + item.id + "' >" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.serieNummer + " id = " + item.id + "</p > " +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<button onclick='verwijderItem(" + item.id + ")'>Verwijderen</button>" +
                    "</div>" +

                    "</div >"
                )
            });
        }

    })


});

function verwijderItem(id) {

    $.ajax({
        type: "DELETE",
        url: "/api/v1/toestel/delete/" + id,
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log(id);
            $("#" + id).remove();
        }

    })

};

function searchItem(str) {
    var destinationUrl = "/api/v1/toestel/find/" + str;
    console.log(destinationUrl);
    $.ajax({
        type: "GET",
        url: destinationUrl,
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            $('#toestelTabel > div').remove();

            $.each(data, function (i, item) {

                $("#toestelTabel").append(

                    "<div class= 'row' id='" + item.id + "' >" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.serieNummer + " id = " + item.id + "</p > " +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<button onclick='verwijderItem(" + item.id + ")'>Verwijderen</button>" +
                    "</div>" +

                    "</div >"
                )
            });
           
        }

    })


};

function originalState() {
    $.ajax({
        type: "GET",
        url: "/api/v1/toestel/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {

            $('#toestelTabel > div').remove();

            console.log(data);

            $.each(data, function (i, item) {

                $("#toestelTabel").append(

                    "<div class= 'row' id='" + item.id + "' >" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.serieNummer + " id = " + item.id + "</p > " +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<p>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='column' style='background-color:#bbb;'>" +
                    "<button onclick='verwijderItem(" + item.id + ")'>Verwijderen</button>" +
                    "</div>" +

                    "</div >"
                )
            });
        }

    })
};



