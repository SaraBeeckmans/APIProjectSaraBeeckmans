$(document).ready(function () {
   

    $.ajax({
        type: "GET",
        url: "/api/v1/supplier/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {

            $.each(data, function (i, item) {
                $("#inlineFormCustomSelect").append(
                    
                    "<option value = '"+ item.id +"'>" + item.name + "</option>" 
                )
            });
        }

    })


    $.ajax({
        type: "GET",
        url: "/api/v1/bedrijf/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {

            $.each(data, function (i, item) {
                $("#inlineBedrijven").append(
                    "<option value = '" + item.id +"'>" + item.bedrijfNaam + "</option>" 
                    
                )
            });
        }

    })


});

function AddToestel(serienummer, aankoopdatum, prijs, garantie, supplierId, bedrijfId) {
    console.log('addtoestel');
    console.log('Bedrijf ID:' + bedrijfId);
    console.log('SupplierID:' + supplierId);

    
    var theUrl = "/api/v1/toestel/add?serieNummer=" + serienummer + "&aankoopDatum=" + aankoopdatum + "&prijs=" + prijs + "&garantie=" + garantie + "&supplierId=" + supplierId + "&bedrijfId=" + bedrijfId;
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