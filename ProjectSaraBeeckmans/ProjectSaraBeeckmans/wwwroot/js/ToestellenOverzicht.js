
$(document).ready(function () {
    console.log("aaaaaaaaaa");
    $.ajax({
        type: "GET",
        url: "/api/v1/toestel/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            $("#find").append(

                "<input id = 'myInput' type='text' class='form-control' placeholder='Search' aria-describedby='button-addon4'>" +
                "<div class='input-group-append' id='button-addon4'>" +
                "<button class='btn btn-outline-secondary' type='button' onclick=searchItem(document.getElementById('myInput').value)>Zoek</button>" +
                "<button class='btn btn-outline-secondary' type='button' onclick=originalState()>Terug</button>"


            );

            console.log("xxx");
            $.each(data, function (i, item) {
                console.log("aaé");
                $("#toestelTabel").append(
                    
                    "<div class='row' id='" + item.id + "'>" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.serieNummer + "id =" + item.id + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p style='word-break: break-all;'>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='col-md-2 text-center'>" +
                    "<button type='button' class='btn btn-outline-danger btn-sm' onclick = 'verwijderItem(" + item.id + ")' > Verwijderen</button > " +
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
                    "<div class='col-md-3'>" +
                    "<p>" + item.serieNummer + " id = " + item.id + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p style='word-break: break-all;'>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='col-md-2 text-center'>" +
                    "<button type='button' class='btn btn-outline-danger btn-sm' onclick = 'verwijderItem(" + item.id + ")' > Verwijderen</button > " +
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
                    "<div class='col-md-3'>" +
                    "<p>" + item.serieNummer + " id = " + item.id + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p style='word-break: break-all;'>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='col-md-2 text-center'>" +
                    "<button type='button' class='btn btn-outline-danger btn-sm' onclick = 'verwijderItem(" + item.id + ")' > Verwijderen</button > " +
                    "</div>" +

                    "</div >"
                )
            });
        }

    })
};



