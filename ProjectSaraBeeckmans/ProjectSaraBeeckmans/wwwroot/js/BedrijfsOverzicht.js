
$(document).ready(function () {

    $.ajax({
        type: "GET",
        url: "/api/v1/bedrijf/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            $("#find").append(

                
                "<input id = 'myInput' type='text' class='form-control' placeholder='Search' aria-describedby='button-addon4'>"+
                    "<div class='input-group-append' id='button-addon4'>"+
                        "<button class='btn btn-outline-secondary' type='button' onclick=searchItem(document.getElementById('myInput').value)>Zoek</button>"+
                        "<button class='btn btn-outline-secondary' type='button' onclick=originalState()>Terug</button>"
                  

            )

            $.each(data, function (i, item) {

                $("#bedrijfstabel").append(

                    "<div class= 'row' id='" + item.id +"' >" +
                    "<div class='col-md-3'>" +
                    "<p>"+ item.bedrijfNaam + " id = " + item.id + "</p>" + 
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
                    "<button type='button' class='btn btn-outline-danger btn-sm' onclick = 'verwijderItem("+item.id+")' > Verwijderen</button > " +
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
        url: "/api/v1/bedrijf/delete/"+ id,
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            console.log(id);
            $("#" + id).remove();
        }

    })
    
};

function searchItem(str) {
    var destinationUrl = "/api/v1/bedrijf/find/" + str;
    console.log(destinationUrl);
    $.ajax({
        type: "GET",
        url: destinationUrl,
        data: '$format=json',
        dataType: 'json',
        success: function (data) {
            $('#bedrijfstabel > div').remove(); 

            $.each(data, function (i, item) {

                $("#bedrijfstabel").append(

                    "<div class= 'row' id='" + item.id + "' >" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.bedrijfNaam + " id = " + item.id + "</p>" +
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
        url: "/api/v1/bedrijf/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {

            $('#bedrijfstabel > div').remove();

            console.log(data);

            $.each(data, function (i, item) {

                $("#bedrijfstabel").append(

                    "<div class= 'row' id='" + item.id + "' >" +
                    "<div class='col-md-3'>" +
                    "<p>" + item.bedrijfNaam + " id = " + item.id + "</p>" +
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



