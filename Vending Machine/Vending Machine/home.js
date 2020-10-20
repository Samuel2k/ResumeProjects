$(document).ready(function () {
  //Ready the money box
  $("#moneyDisplayBox").text(`$0.00`);

  //Add initial elements
  $.ajax({
    type: "GET",
    url: "http://tsg-vending.herokuapp.com/items",
    dataType: "json",

    success: function (items) {

      // Append to the body
      $.each(items, function(index, item) {
        var newItem = `<a class="clickbox" onclick="clickToDisplay(${item.id})"><span class="a" id="${item.id}">`;
            newItem += `<p class="label">${item.id}</p>`;
            newItem += item.name;
            newItem += "<br/>";
            newItem += `<div >$${item.price.toFixed(2)}</div>`;
            newItem += "<br/><br/>";
            newItem += `<div id="quantity${item.id}">Quantity Left: ${item.quantity}</div>`;
            newItem +="</span></a>";

        $(".col-md-8").append(newItem);
      })
    },
    error: function (jqXHR, textStatus, errorThrown) {
      alert("FAILURE! Couldn't place database's items.");
    }
  });
});

//Functions for inserting money amounts
//Dollar
function insertDol() {
  var insertedMoney = parseFloat(($("#moneyDisplayBox").text().substring(1)));
      insertedMoney += 1;
  $("#moneyDisplayBox").text("$" + insertedMoney.toFixed(2));
};
//Quarter
function insertQ() {
  var insertedMoney = parseFloat(($("#moneyDisplayBox").text().substring(1)));
      insertedMoney += 0.25;
    $("#moneyDisplayBox").text("$" + insertedMoney.toFixed(2));
};
//Dime
function insertDi() {
  var insertedMoney = parseFloat(($("#moneyDisplayBox").text().substring(1)));
      insertedMoney += 0.10;
    $("#moneyDisplayBox").text("$" + insertedMoney.toFixed(2));
};
//Nickel
function insertN() {
  var insertedMoney = parseFloat(($("#moneyDisplayBox").text().substring(1)));
      insertedMoney += 0.05;
    $("#moneyDisplayBox").text("$" + insertedMoney.toFixed(2));
};

  function returnChange() {
    var insertedMoney = parseFloat(($("#moneyDisplayBox").text().substring(1))).toFixed(2);
    var dueChange = " ";
    var tempNumber;
    //Quarters
    if ((insertedMoney / 0.25) >= 1)
    {
      tempNumber = Math.floor(insertedMoney / 0.25);
      dueChange += ((tempNumber) + " quarters ")
      insertedMoney -= (tempNumber * 0.25);
      insertedMoney = insertedMoney.toFixed(2);
    }
    //Dimes
    if ((insertedMoney / 0.10) >= 1)
    {
      tempNumber = Math.floor(insertedMoney / 0.10);
      dueChange += ((tempNumber) + " dimes ")
      insertedMoney -= (tempNumber * 0.10);
      insertedMoney = insertedMoney.toFixed(2);
    }
    //Nickels
    if ((insertedMoney / 0.05) >= 1)
    {
      tempNumber = Math.floor(insertedMoney / 0.05);
      dueChange += ((tempNumber) + " nickels ")
      insertedMoney -= (tempNumber * 0.05);
      insertedMoney = insertedMoney.toFixed(2);
    }
    $("#changeDisplayBox").text(dueChange);
    $("#messageDisplayBox").text("");
    $("#moneyDisplayBox").text(`$0.00`);
  }

  function attemptPurchase () {

    if (!$("#itemDisplayBox").text()) {
      $("#itemDisplayBox").text("-1");
    };

    var amount = parseFloat($("#moneyDisplayBox").text().substring(1));
    var id = parseInt($("#itemDisplayBox").text());

    //Purchase here
    $.ajax({
      type: "POST",
      url: `http://tsg-vending.herokuapp.com/money/${amount}/item/${id}`,
      dataType: "json",

      //Count & display change
      success: function (item) {
        var changeDue = "";
        if (item.quarters > 0) {
          changeDue += item.quarters + " quarters";
        }
        if (item.dimes > 0) {
          changeDue += item.dimes + " dimes";
        }
        if (item.nickels > 0) {
          changeDue += item.nickels + " nickels";
        }
        if (item.pennies > 0) {
          changeDue += item.pennies + " pennies";
        }

        $("#changeDisplayBox").text(changeDue);
        $("#messageDisplayBox").text("Thank you!!!");
        $("#moneyDisplayBox").text(`$0.00`);
      },
      //Display the error message
      //jqXHR, textStatus, errorThrown
      error: function(failItem) {
        var obj = jQuery.parseJSON( failItem.responseText );
        $("#messageDisplayBox").text(obj.message);
      }
    });
  };

//Make it so the ID of the item is put into the itemDisplayBox upon the click of the vending machine item square
function clickToDisplay(id) {
  $("#itemDisplayBox").text(id);
}
