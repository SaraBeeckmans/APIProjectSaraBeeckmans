$(document).ready(function () {
   

    $.ajax({
        type: "GET",
        url: "/api/v1/supplier/list",
        data: '$format=json',
        dataType: 'json',
        success: function (data) {

            $.each(data, function (i, item) {
                $("#inlineFormCustomSelect").append(
                    "<option>" + item.name + "</option>" +
                    "<p type = 'hidden' id = 'getsupplierid'>"+item.id+"</p>"
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
                    "<option>" + item.bedrijfNaam + "</option>" +
                    "<p type = 'hidden' id = 'getbedrijfrid'>" + item.id + "</p>"
                )
            });
        }

    })


});

