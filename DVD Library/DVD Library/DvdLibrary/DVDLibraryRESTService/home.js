//functions upon document bootup
$(document).ready(function () {
  $( "#newTableRow" ).hide();
  $( "#searchError" ).hide();
  $( "#yearError" ).hide();
  $( "#titleError" ).hide();
  $( "#modifyDvdMenu").hide();
  $( "#editHeader" ).hide();
  $( "#createHeader" ).hide();

  loadTable();
});

//Add the elements in the database
function loadTable() {
  $.ajax({
    type: "GET",
    url: "http://localhost:8080/dvds",
    dataType: "json",

    success: function (dvds) {

      // Get a reference to the table.
      var table = $("#dvdTable");

      $(".dvdTableRow").remove();
      // Append to the table.

      $.each(dvds, function(index, dvd) {
        var dvdRow = `<tr style="text-align:center;" class="dvdTableRow" id="row${dvd.dvdId}">`;
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.title + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.realeaseYear + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.director + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.rating + "</td>";
            dvdRow += `<td class="rowPiece" scope="row"><button onclick="showEditForm(${dvd.dvdId})">Edit</button>` + " | " + `<button class="deleteButton" onclick="promptDelete(${dvd.dvdId})">Delete</button></td>`;
            dvdRow += "</tr>";

        table.append(dvdRow);
      });
    },
    error: function (jqXHR, textStatus, errorThrown) {
      alert("FAILURE!");
    }
  });
}

function attemptSearch() {
  //Check validity
  if (!($("#termSearchBox").val().trim().length) || !($("#categoryDropdown").val() ) ) {
    $("#searchError").show();
  }
  else {
    $("#searchError").hide();
  };

  if ($("#termSearchBox").val().trim().length && $("#categoryDropdown").val() ) {

  $.ajax({
    type: "GET",
    url: "http://localhost:8080/dvds/" + $("#categoryDropdown").val() + "/" + $("#termSearchBox").val(),
    dataType: "json",
    data: JSON.stringify({
      title: $("#newTitle").val(),
      releaseYear: $("#newYear").val(),
      director: $("#newDirector").val(),
      rating: $("#newRating").val(),
      notes: $("#newNotes").val()
    }),
    headers: {
      "Accept": "application/json",
      "Content-Type": "application/json"
    },
    success: function (dvds) {

      // Get a reference to the table.
      var table = $("#dvdTable");

      $( "#searchError" ).hide();
      $(".dvdTableRow").remove();
      // Append to the table.

      $.each(dvds, function(index, dvd) {
        var dvdRow = `<tr style="text-align:center;" class="dvdTableRow" id="row${dvd.dvdId}">`;
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.title + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.realeaseYear + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.director + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.rating + "</td>";
            dvdRow += `<td class="rowPiece" scope="row"><button onclick="showEditForm(${dvd.dvdId})">Edit</button>` + " | " + `<button class="deleteButton" onclick="promptDelete(${dvd.dvdId})">Delete</button></td>`;
            dvdRow += "</tr>";

        table.append(dvdRow);
      });
    },
    error: function (jqXHR, textStatus, errorThrown) {
      alert("FAILURE! Could not complete search function properly.");
    }
  });
}

}

  //Attempt to create DVD
  function createDVDsec() {

    if (!($("#newTitle").val().trim().length)) {
      $("#titleError").show();
    }
    else {
      $("#titleError").hide();
    };
    //Check if length is 4
    if (($("#newYear").val().trim().length != 4) || !($.isNumeric($("#newYear").val()))) {
      $("#yearError").show();
    }
    else {
      $("#yearError").hide();
    };

    if (($("#newTitle").val().trim()) && ($("#newYear").val().trim().length == 4 && ($.isNumeric($("#newYear").val())))) {

    $.ajax({
      type: "POST",
      url: "http://localhost:8080/dvd",
      dataType: "json",
      data: JSON.stringify({
        title: $("#newTitle").val(),
        realeaseYear: $("#newYear").val(),
        director: $("#newDirector").val(),
        rating: $("#newRating").val(),
        notes: $("#newNotes").val()
      }),
      headers: {
        "Accept": "application/json",
        "Content-Type": "application/json"
      },
      success: function (dvd) {
        // Get a reference to the table.
        var table = $("#dvdTable");

        // Append to the table.
        var dvdRow = `<tr style="text-align:center;" id="row${dvd.dvdId}" class="newTableRow">`;
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.title + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.realeaseYear + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.director + "</td>";
            dvdRow += `<td class="rowPiece" scope="row">` + dvd.rating + "</td>";
            dvdRow += `<td class="rowPiece" scope="row"><button onclick="showEditForm(${dvd.dvdId})">Edit</button>` + " | " + `<button class="deleteButton" onclick="promptDelete(${dvd.dvdId})">Delete</button></td>`;
            dvdRow += "</tr>";

        table.append(dvdRow);

        cancelButton();
      },
      error: function (jqXHR, textStatus, errorThrown) {
        alert("FAILURE!");
      }
    });
  };
};


  //Display the edit form
  function showEditForm(dvdId) {

    //Hide elements
    $( "#searchError" ).hide();
    $( "#yearError" ).hide();
    $( "#titleError" ).hide();
    $("#dvdTable").hide();
    $("#FormHeader").hide();
    $("#createDVDfinal").hide();

      // get the details from the server and then fill and show the
      // form on success
      $.ajax({
          type: 'GET',
          url: 'http://localhost:8080/dvd/' + dvdId,
          success: function(data, status) {
                $('#newTitle').val(data.title);
                $('#newYear').val(data.realeaseYear);
                $('#newDirector').val(data.director);
                $('#newRating').val(data.rating);
                $('#newNotes').val(data.notes);

                //Show elements
                $("#editHeader").text("Edit DVD: " + data.title);
                $("#editHeader").show();
                $("#modifyDvdMenu").show();

                //set value of editDVDfinal
                $("#editDVDfinal").val(data.dvdId);
            },
            error: function() {
              alert("FAILURE! Couldn't display edit form.");
            }
      });
};

// Update Button onclick handler
function editDVDsec() {

  //Check if filled
  if (!($("#newTitle").val().trim().length)) {
    $("#titleError").show();
  }
  else {
    $("#titleError").hide();
  };
  //Check if length is 4
  if (($("#newYear").val().trim().length != 4) || !($.isNumeric($("#newYear").val()))) {
    $("#yearError").show();
  }
  else {
    $("#yearError").hide();
  };

  if (($("#newTitle").val().trim()) && ($("#newYear").val().trim().length == 4 && ($.isNumeric($("#newYear").val())))) {

    $.ajax({
       type: 'PUT',
       url: 'http://localhost:8080/dvd/' + $('#editDVDfinal').val(),
       data: JSON.stringify({
         dvdId: $('#editDVDfinal').val(),
         title: $("#newTitle").val(),
         realeaseYear: $("#newYear").val(),
         director: $("#newDirector").val(),
         rating: $("#newRating").val(),
         notes: $("#newNotes").val()
       }),
       headers: {
         'Accept': 'application/json',
         'Content-Type': 'application/json'
       },
       'dataType': 'json',
       success: function () {

         $.ajax({
           type: "GET",
           url: "http://localhost:8080/dvds",
           dataType: "json",

           success: function (dvds) {

         // Get a reference to the table.
         var table = $("#dvdTable");

         $("#searchError").hide();
         $(".dvdTableRow").remove();

           $.each(dvds, function(index, dvd) {
         // Append to the table.
         var dvdRow = `<tr style="text-align:center;" id="row${dvd.dvdId}" class="newTableRow">`;
             dvdRow += `<td class="rowPiece" scope="row">` + dvd.title + "</td>";
             dvdRow += `<td class="rowPiece" scope="row">` + dvd.realeaseYear + "</td>";
             dvdRow += `<td class="rowPiece" scope="row">` + dvd.director + "</td>";
             dvdRow += `<td class="rowPiece" scope="row">` + dvd.rating + "</td>";
             dvdRow += `<td class="rowPiece" scope="row"><button onclick="showEditForm(${dvd.dvdId})">Edit</button>` + " | " + `<button class="deleteButton" onclick="promptDelete(${dvd.dvdId})">Delete</button></td>`;
             dvdRow += "</tr>";

         table.append(dvdRow);

         cancelButton();
       });
     }
   });
 },
       error: function() {
         alert("FAILURE! Edit failed.");
       }
     });
   };
};

  //AJAX ABOVE


//Function for when "Create DVD" is clicked on the main menu
  function createDVD() {

    //Hide elements
    $("#dvdTable").hide();
    $("#FormHeader").hide();
    $("#editDVDfinal").hide();

    //Show elements
    $("#createHeader").show();
    $("#modifyDvdMenu").show();
  };

    //Function for when "Delete" is clicked on the main menu
    function promptDelete(id) {

    if (confirm("Are you sure you want to delete this DVD from your collection?")) {

      $.ajax({
      type: 'DELETE',
      url: 'http://localhost:8080/dvd/' + id,
    });
      $(`#row${id}`).hide();
    };
};

  //Cancel edit or cancel create
  function cancelButton() {
  $( "#yearError" ).hide();
  $( "#titleError" ).hide();
  $( "#searchError" ).hide();
  $( "#modifyDvdMenu").hide();
  $( "#editHeader" ).hide();
  $( "#createHeader" ).hide();

  $("#dvdTable").show();
  $("#FormHeader").show();
};
