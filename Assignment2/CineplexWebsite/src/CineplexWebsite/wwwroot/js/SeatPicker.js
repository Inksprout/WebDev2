var firstSeatLabel = 1;
var seatMap = $('#seat-map');
var total = 0;

$(document).ready(function () {
    //create the Cineplex namespace to store movie session data
    if (window.CINEPLEX === undefined || window.CINEPLEX === null) window.CINEPLEX = {};

    //create a variable to track the sessions
    window.CINEPLEX.session = {
        movieName: "",
        sessionTime: "",
        seats: []
    };

    var $cart = $('#selected-seats'),
        $counter = $('#counter'),
        $total = $('#total'),
        sc = seatMap.seatCharts({
            map: [
                'aaaaa_aaaaa',
                'aaaaa_aaaaa'
            ],
            seats: {
                a: {
                    adult: 45,
                    child: 20,
                    price: 0,
                    classes: 'seat', //your custom CSS class
                    category: 'adult'
                }

            },
            naming: {
                top: false,
                getLabel: function (character, row, column) {
                    return firstSeatLabel++;
                },
            },
            legend: {
                node: $('#legend'),
                items: [
                    ['a', 'available', 'seat'],
                    ['f', 'unavailable', 'Already Booked']
                ]
            },
            click: function () {
                if (this.status() === 'available') {

                    var seat = this;

                    //set the fact we set the seat in the window object
                    var seatDetails = {
                        id: seat.settings.label,
                        location: seat.settings.id,
                        status: "SELECTED"
                    };
                    window.CINEPLEX.session.seats.push(seatDetails);

                    //create the plz choose a ticket element
                    $('<select id="price"> ' +
                        '<option value=' +
                        this.data().adult +
                        '>adult</option> <option value=' +
                        this.data().child +
                        '>child</option> </select>').appendTo($cart);

                    $('<a href="#" id="add-cart-item">[Add]</a>').appendTo($cart);


                    $('<a href="#" id="add-cart-item">[Add]</a>');

                    $("#add-cart-item").click(function() {

                        seat.data().price = $('#price').val();

                        if (seat.data().price === 45) {
                            seat.data().category = "adult";
                        } else {
                            seat.data().category = "child";
                        }
                      
            
                        total = total + parseFloat(seat.data().price);
                  

                        $total.text(total);

                        $("#price").remove();
                        $("#add-cart-item").remove();

                        $('<li>' +
                                seat.data().category +
                                ' Seat # ' +
                                seat.settings.label + ': <b>$' + seat.data().price +
                                '</b> <a href="#" class="cancel-cart-item">[cancel]</a></li>')
                            .attr('id', 'cart-item-' + seat.settings.id)
                            .data('seatId', seat.settings.id)
                            .appendTo($cart);

                        var seats = window.CINEPLEX.session.seats;
                        var seatIndex = seats.findIndex(el => el.id === seat.settings.label);
                        var seatChosen = seats[seatIndex];
                        seatChosen.status = "CONFIRMED";
                        seatChosen.seatType = seat.data().category;
                        seatChosen.price = seat.data().price;
                    });

                    /*
                     * Lets update the counter and total
                     *
                     * .find function will not find the current seat, because it will change its stauts only after return
                     * 'selected'. This is why we have to add 1 to the length and the current seat price to the total.
                     */

                    $counter.text(sc.find('selected').length + 1);


                    $total.text(total);
                    console.log(sc);
                    return 'selected';
                  

                } else if (this.status() === 'selected') {
                    //update the counter
                    $counter.text(sc.find('selected').length - 1);
                    //and total
                    total -= parseFloat(this.data().price);
                    $total.text(total);

                    //remove the item from our cart
                    $('#cart-item-' + this.settings.id).remove();

                    if ($("#price")) {
                        $("#price").remove();
                        $("#add-cart-item").remove();
                    }

                    //seat has been vacated
                    return 'available';
                } else if (this.status() === 'unavailable') {
                    //seat has been already booked
                    return 'unavailable';
                } else {
                    return this.style();
                }
            }
        });

    //this will handle "[cancel]" link clicks
    $('#selected-seats').on('click', '.cancel-cart-item', function () {
        //let's just trigger Click event on the appropriate seat, so we don't have to repeat the logic here
        sc.get($(this).parents('li:first').data('seatId')).click();
    });

    $('#add-to-cart-button').click(function(e) {
        e.preventDefault();

        $.ajax({
            type: "POST",
            url: "/moviesessions/save/",
            contentType: 'application/json',
            data: JSON.stringify(window.CINEPLEX.session),
            success: function (response) {
                console.log("yay");
            },
            error: function () {
                console.error("Rip in peace");
            }
        });
    });

});

function recalculateTotal(sc) {
    var total = 0;

    //basically find every selected seat and sum its price
    sc.find('selected').each(function () {
        console.log("selected seat found" + this.data().price);
        total += parseFloat(this.data().price);
    });

    return total;
}