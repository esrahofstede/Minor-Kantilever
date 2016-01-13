$(document).ready(function () {
 

    

    var getUrlParameter = function getUrlParameter(sParam) {
        var sPageURL = decodeURIComponent(window.location.search.substring(1)),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : sParameterName[1];
            }
        }
    };

    if (getUrlParameter("AddedToWinkelmand") == "True") {

        setTimeout(function () {
            $("i.glyphicon.glyphicon-align-center.glyphicon-shopping-cart").animate({ fontSize: '60px' }, 1000);
            $("i.glyphicon.glyphicon-align-center.glyphicon-shopping-cart").animate({ fontSize: '35px' }, 1000);
        }, 500);
       
    }

});