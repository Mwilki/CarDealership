$(document).ready(function () {
    $('#SearchNew').click(function () {
        if ($("#search-dropdown").val() !== "default") {
            var val = $("#QuickSearch").val();
            var trimmed = $.trim(val);
            if (trimmed !== "") {


                // content from search
                var quickSearch = $('#QuickSearch').val();
                var priceLow = $('#PriceLow').val();
                var priceHigh = $('#PriceHigh').val();
                var yearLow = $('#YearLow').val();
                var yearHigh = $('#YearHigh').val();

                $.ajax({
                    type: 'GET',
                    url: 'http://localhost:59055/inventory/' + quickSearch + '/' + priceLow + "-" + priceHigh + "/" + yearLow + "-" + yearHigh,

                    success: function (data, status) {
                        console.log(data + " " + status);
                    },
                    error: function () {
                        console.log(data + " " + status);
                    }

                });

            }
            else {
                console.log(data + " " + status);
            }
        }
        else {
            console.log(data + " " + status);
        };


    });

});




function ClearErrorMessages() {
    $("#errorMessages").empty();
}


