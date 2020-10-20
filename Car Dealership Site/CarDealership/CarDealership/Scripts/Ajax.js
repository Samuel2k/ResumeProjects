/*https://localhost:44345/ */


function SearchVehiclesAdmin() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44345/admin/vehicles/" + $("#search-box").val() + '/' + $("#min-price").val() + '/' + $("#max-price").val() + '/' + $("#min-year").val() + '/' + $("#max-year").val(),
        dataType: "json",

        success: function (vehicles) {
            // Get a reference to the table.
            var area = $("#contain");

            // Append to the table.

            $.each(vehicles, function (index, VehicleVM) {
                var row = `<div class="row longbox">
                                <div class="col-md-3">
                                    <p> ${VehicleVM.Model.ModelYear} </p>
                                   <img src="${VehicleVM.Vehicle.Picture}" style="height: 200px; width: 250px;">
                                </div>
                                <div class="col-md-3">
                                  <b>Body Style:</b> ${VehicleVM.BodyStyle.BodyStyleName}
                                  <br/>
                                  <b>     Trans:</b> ${VehicleVM.Vehicle.Transmission}
                                  <br/>
                                  <b>     Color:</b> ${VehicleVM.Color.ColorName}
                                </div>
                                <div class="col-md-3">
                                 <b>Interior:</b> ${VehicleVM.Interior.InteriorName}
                                    <br/>
                                    <b> Mileage:</b> ${VehicleVM.Vehicle.Mileage}
                                    <br/>
                                    <b>   VIN #:</b> ${VehicleVM.Vehicle.VIN}
                                </div>
                               <div class="col-md-3">
                                    <b>Sale Price:</b> ${VehicleVM.Vehicle.Price}
                                    <br/>
                                    <b> MSRP:</b> ${VehicleVM.Vehicle.MSRP}
                                <br/>
                                @Html.ActionLink("Details", "Details", "Inventory", ${VehicleVM.Vehicle.VehicleId}, null)
                               </div>
                          </div>`

                area.append(row);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("FAILURE! Could not load initial vehicles.");
        }
    });
}

function SearchVehiclesSales() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44345/sales/vehicles/" + + $("#search-box").val() + '/' + $("#min-price").val() + '/' + $("#max-price").val() + '/' + $("#min-year").val() + '/' + $("#max-year").val(),
        dataType: "json",

        success: function (vehicles) {
            // Get a reference to the table.
            var area = $("#contain");

            // Append to the table.

            $.each(vehicles, function (index, vehicle) {
                var row = `<div class="row longbox">
                                <div class="col-md-3">
                                    <p> ${VehicleVM.Model.ModelYear} </p>
                                   <img src="${VehicleVM.Vehicle.Picture}" style="height: 200px; width: 250px;">
                                </div>
                                <div class="col-md-3">
                                  <b>Body Style:</b> ${VehicleVM.BodyStyle.BodyStyleName}
                                  <br/>
                                  <b>     Trans:</b> ${VehicleVM.Vehicle.Transmission}
                                  <br/>
                                  <b>     Color:</b> ${VehicleVM.Color.ColorName}
                                </div>
                                <div class="col-md-3">
                                 <b>Interior:</b> ${VehicleVM.Interior.InteriorName}
                                    <br/>
                                    <b> Mileage:</b> ${VehicleVM.Vehicle.Mileage}
                                    <br/>
                                    <b>   VIN #:</b> ${VehicleVM.Vehicle.VIN}
                                </div>
                               <div class="col-md-3">
                                    <b>Sale Price:</b> ${VehicleVM.Vehicle.Price}
                                    <br/>
                                    <b> MSRP:</b> ${VehicleVM.Vehicle.MSRP}
                                <br/>
                                @Html.ActionLink("Details", "Details", "Inventory", ${VehicleVM.Vehicle.VehicleId}, null)
                               </div>
                          </div>`

                area.append(row);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("FAILURE! Could not load initial vehicles.");
        }
    });
}

function SearchVehiclesUsed() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44345/inventory/used/" + + $("#search-box").val() + '/' + $("#min-price").val() + '/' + $("#max-price").val() + '/' + $("#min-year").val() + '/' + $("#max-year").val(),
        dataType: "json",

        success: function (vehicles) {
            // Get a reference to the table.
            var area = $("#contain");

            // Append to the table.

            $.each(vehicles, function (index, vehicle) {
                var row = `<div class="row longbox">
                                <div class="col-md-3">
                                    <p> ${VehicleVM.Model.ModelYear} </p>
                                   <img src="${VehicleVM.Vehicle.Picture}" style="height: 200px; width: 250px;">
                                </div>
                                <div class="col-md-3">
                                  <b>Body Style:</b> ${VehicleVM.BodyStyle.BodyStyleName}
                                  <br/>
                                  <b>     Trans:</b> ${VehicleVM.Vehicle.Transmission}
                                  <br/>
                                  <b>     Color:</b> ${VehicleVM.Color.ColorName}
                                </div>
                                <div class="col-md-3">
                                 <b>Interior:</b> ${VehicleVM.Interior.InteriorName}
                                    <br/>
                                    <b> Mileage:</b> ${VehicleVM.Vehicle.Mileage}
                                    <br/>
                                    <b>   VIN #:</b> ${VehicleVM.Vehicle.VIN}
                                </div>
                               <div class="col-md-3">
                                    <b>Sale Price:</b> ${VehicleVM.Vehicle.Price}
                                    <br/>
                                    <b> MSRP:</b> ${VehicleVM.Vehicle.MSRP}
                                <br/>
                                @Html.ActionLink("Details", "Details", "Inventory", ${VehicleVM.Vehicle.VehicleId}, null)
                               </div>
                          </div>`

                area.append(row);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("FAILURE! Could not load initial vehicles.");
        }
    });
}

function SearchVehiclesNew() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44345/inventory/new/" + $("#search-box").val() + '/' + $("#min-price").val() + '/' + $("#max-price").val() + '/' + $("#min-year").val() + '/' + $("#max-year").val(),
        dataType: "json",

        success: function (vehicles) {
            // Get a reference to the table.
            var area = $("#contain");

            // Append to the table.

            $.each(vehicles, function (index, vehicle) {
                var row = `<div class="row longbox">
                                <div class="col-md-3">
                                    <p> ${VehicleVM.Model.ModelYear} </p>
                                   <img src="${VehicleVM.Vehicle.Picture}" style="height: 200px; width: 250px;">
                                </div>
                                <div class="col-md-3">
                                  <b>Body Style:</b> ${VehicleVM.BodyStyle.BodyStyleName}
                                  <br/>
                                  <b>     Trans:</b> ${VehicleVM.Vehicle.Transmission}
                                  <br/>
                                  <b>     Color:</b> ${VehicleVM.Color.ColorName}
                                </div>
                                <div class="col-md-3">
                                 <b>Interior:</b> ${VehicleVM.Interior.InteriorName}
                                    <br/>
                                    <b> Mileage:</b> ${VehicleVM.Vehicle.Mileage}
                                    <br/>
                                    <b>   VIN #:</b> ${VehicleVM.Vehicle.VIN}
                                </div>
                               <div class="col-md-3">
                                    <b>Sale Price:</b> ${VehicleVM.Vehicle.Price}
                                    <br/>
                                    <b> MSRP:</b> ${VehicleVM.Vehicle.MSRP}
                                <br/>
                                @Html.ActionLink("Details", "Details", "Inventory", ${VehicleVM.Vehicle.VehicleId}, null)
                               </div>
                          </div>`

                area.append(row);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("FAILURE! Could not load initial vehicles.");
        }
    });
}

function GetModelsFromMakes() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44345/admin/add/" + `${$("#model-drop").val()}`,
        dataType: "json",

        success: function (vehicles) {
            // Get a reference to the table.
            var area = $("#contain");

            // Append to the table.

            $.each(vehicles, function (index, model) {
                var row = 

                area.append(row);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("FAILURE! Could not load initial vehicles.");
        }
    });
}