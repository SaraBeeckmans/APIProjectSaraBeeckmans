
$(document).ready(function () {
    showExternalApi();
    $.ajax({
        type: "GET",
        url: "/api/v1/supplier/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            $("#find").append(


                "<input id = 'myInput' type='text' class='form-control' placeholder='Search' aria-describedby='button-addon4'>" +
                "<div class='input-group-append' id='button-addon4'>" +
                "<button class='btn btn-outline-secondary' type='button' onclick=searchItem(document.getElementById('myInput').value)>Zoek</button>" +
                "<button class='btn btn-outline-secondary' type='button' onclick=originalState()>Terug</button>"


            )

            $.each(data, function (i, item) {

                $("#supplierTabel").append(

                    "<div class= 'row' id='" + item.id + "' >" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.name + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.email + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.adres + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.tel + "</p>" +
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
        url: "/api/v1/supplier/delete/" + id,
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log(id);
            $("#" + id).remove();
        }

    })

};

function searchItem(str) {
    var destinationUrl = "/api/v1/supplier/find/" + str;
    console.log(destinationUrl);
    $.ajax({
        type: "GET",
        url: destinationUrl,
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            $('#supplierTabel > div').remove();
            $("#supplierTabel").append(getSupplierHeaders());


            $.each(data, function (i, item) {

                $("#supplierTabel").append(

                    "<div class= 'row' id='" + item.id + "' >" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.name + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.email + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.adres + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.tel + "</p>" +
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
        url: "/api/v1/supplier/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {

            $('#supplierTabel > div').remove();
            $("#supplierTabel").append(getSupplierHeaders());

            console.log(data);

            $.each(data, function (i, item) {

                $("#supplierTabel").append(

                    "<div class= 'row' id='" + item.id + "' >" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.name + " id = " + item.id + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.email + "</p>" +
                    "</div>" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.adres + "</p>" +
                    "</div>" +
                    "<div class='col-md-2'>" +
                    "<p style='word-break: break-all;'>" + item.tel + "</p>" +
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

//function getSupplierForToestel() {
//    $.ajax({
//        type: "GET",
//        url: "/api/v1/supplier/list",
//        data: '$format=json',
//        dataType: 'json',
//        success: function (data) {
//            console.log(data);
           
//            $.each(data, function (i, item) {
                 
              
//            });
//        }

//    })
//}

function showExternalApi() {
    $.ajax({
        url: "https://api.adviceslip.com/advice",
        dataType: 'json',
        type: "GET",
        data: '$format=json',
        success: function (data) {
            $("#quote").append(
                "<p>Quote of the day: " + data.slip.advice + "</p>"

            )
        }
    });
}

function getSupplierHeaders() {
    var resultstring = "<div id='bedrijfstabel' class='container'>" +
        "<div class='row'>" +
        "<div class='col-md-3'>" +
        "<h2>Naam</h2>" +
        "</div> " +
        "<div class='col-md-2'> " +
        "<h2> Email</h2> " +
        "    </div> " +
        "<div class='col-md-3'> " +
        "<h2> Adres</h2> " +
        "    </div> " +
        "<div class='col-md-2'> " +
        "<h2>Tel</h2> " +
        "    </div> " +
        "<div class='col-md-2'> " +
        "<h2> Aanpassingen</h2> " +
        "    </div>" +
        "</div>" +
        "    </div>";
    return resultstring;
}