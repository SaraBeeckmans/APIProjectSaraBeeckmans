
$(document).ready(function () {
    var urlParams = new URLSearchParams(window.location.search);
    console.log(urlParams.has('id')); 
    console.log(urlParams.get('id'));
    if (!urlParams.has('id')) {
        $.ajax({
            type: "GET",
            url: "/api/v1/toestel/list",
            data: '$format=json',
            dataType: 'json',
            success: function (data) {

                $("#find").append(

                    "<input id = 'myInput' type='text' class='form-control' placeholder='Search' aria-describedby='button-addon4'>" +
                    "<div class='input-group-append' id='button-addon4'>" +
                    "<button class='btn btn-outline-secondary' type='button' onclick=searchItem(document.getElementById('myInput').value)>Zoek</button>" +
                    "<button class='btn btn-outline-secondary' type='button' onclick=originalState()>Terug</button>"


                );


                $.each(data, function (i, item) {
                    console.log(data);
                    console.log(item.bedrijfId);
                    $("#toestelTabel").append(



                        "<div class='row' id='" + item.id + "'>" +
                        "<div class='col-md-2'>" +
                        "<p>" + item.serieNummer + "id =" + item.id + "</p>" +
                        "</div>" +
                        "<div class='col-md-3'>" +
                        "<p style='word-break: break-all;'>" + item.aankoopDatum + "</p>" +
                        "</div>" +
                        "<div class='col-md-1'>" +
                        "<p>" + item.prijs + "</p>" +
                        "</div>" +
                        "<div class='col-md-2'>" +
                        "<p style='word-break: break-all;'>" + item.garantie + "</p>" +
                        "</div>" +
                        "<div class='col-md-1'>" +
                        "<p style='word-break: break-all;'>" + item.supplier.name + "</p>" +
                        "</div>" +
                        "<div class='col-md-1'>" +
                        "<p style='word-break: break-all;'>" + item.bedrijf.bedrijfNaam + "</p>" +
                        "</div>" +
                        "<div class='col-md-2 text-center'>" +
                        "<button type='button' class='btn btn-outline-danger btn-sm' onclick = 'verwijderItem(" + item.id + ")' > Verwijderen</button > " +

                        "</div>" +

                        "</div >"

                    )
                });
            }

        })
    }
    else {
        if (urlParams.has('id')) {
            showBedrijfToestellen(urlParams.get('id'));
        }

    }

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

                    "<div class='row' id='" + item.id + "'>" +
                    "<div class='col-md-2'>" +
                    "<p>" + item.serieNummer + "id =" + item.id + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p style='word-break: break-all;'>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p style='word-break: break-all;'>" + item.supplier.name + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p style='word-break: break-all;'>" + item.bedrijf.bedrijfNaam + "</p>" +
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

            $.each(data, function (i, item) {

                $("#toestelTabel").append(

                    "<div class='row' id='" + item.id + "'>" +
                    "<div class='col-md-2'>" +
                    "<p>" + item.serieNummer + "id =" + item.id + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p style='word-break: break-all;'>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p style='word-break: break-all;'>" + item.supplier.name + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p style='word-break: break-all;'>" + item.bedrijf.bedrijfNaam + "</p>" +
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


function showBedrijfToestellen(id) {
    $.ajax({
        type: "GET",
        url: "/api/v1/toestel/bedrijf/" + id,
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            //$('#toestelTabel > div').remove();
            $("#find").append(

                "<input id = 'myInput' type='text' class='form-control' placeholder='Search' aria-describedby='button-addon4'>" +
                "<div class='input-group-append' id='button-addon4'>" +
                "<button class='btn btn-outline-secondary' type='button' onclick=searchItem(document.getElementById('myInput').value)>Zoek</button>" +
                "<button class='btn btn-outline-secondary' type='button' onclick=originalState()>Terug</button>"


            );

            


            $.each(data, function (i, item) {

                $("#toestelTabel").append(

                    "<div class='row' id='" + item.id + "'>" +
                    "<div class='col-md-2'>" +
                    "<p>" + item.serieNummer + "id =" + item.id + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p style='word-break: break-all;'>" + item.aankoopDatum + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p>" + item.prijs + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.garantie + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p style='word-break: break-all;'>" + item.supplier.name + "</p>" +
                    "</div>" +
                    "<div class='col-md-1'>" +
                    "<p style='word-break: break-all;'>" + item.bedrijf.bedrijfNaam + "</p>" +
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




