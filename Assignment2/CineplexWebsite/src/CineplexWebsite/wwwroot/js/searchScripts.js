$(function() {

    $("#movieSearchButton")
        .click(function(e) {
            e.preventDefault();
            requestMovieSession(e);
        });


});

$(function () {

    $("#cinemaSearchButton")
        .click(function (e) {
            e.preventDefault();
            requestCinemaSession(e);
        });
});

function requestCinemaSession() {
    //id of the input field in the searchboc
    var cinema = $("#cinemaInput").val();
    var searchResults = $("#searchResults");

    $.ajax({
        type: "GET",
        url: "/api/SessionSearch/cinema/" + encodeURIComponent(cinema),
        success: function(response) {

            searchResults.empty();
            response.result.value.forEach(function (result) {
                var resultDisplay = createSessionResult(result);

                resultDisplay.appendTo(searchResults);

            });
        },
        error: function() {
            searchResults.text("No results");
        }
    });
}


function requestMovieSession() {
    //id of the input field in the searchboc
    var movieTitle = $("#movieTitleInput").val();
    var searchResults = $("#searchResults");

    $.ajax({
        type: "GET",
        url: "/api/SessionSearch/movie/" + encodeURIComponent(movieTitle),
        success: function (response) {

            searchResults.empty();

            response.result.value.forEach(function (result) {
                var resultDisplay = createSessionResult(result);

                resultDisplay.appendTo(searchResults);

            });
        },
        error: function() {
            searchResults.text("No results");
        }
});

}

function createSessionResult(sessionData) {
    console.log(sessionData);
    var containingDiv = $("<div />",
        {
            "class": "sessionResult"
        });

    var infoDiv = $("<div />",
        {
            "class": "info"
        });

    var left = $("<div />",
        {
            "class": "left"
        });

    var right = $("<div />",
        {
            "class": "right"
        });

    var image = $("<img />",
        {
            src: sessionData.movie.imageUrl,
            "class": "movieImage"
        });

    var title = $("<h1 />",
        {
            "class": "MovieTitle",
            text: sessionData.movie.title
        });

    var description = $("<p />",
        {
            "class": "description",
            text: sessionData.movie.shortDescription
        });

    var cinema = $("<p />",
        {
            "class": "cinema",
            text: sessionData.cineplex.location
        });

    var time = $("<p />",
        {
            "class": "time",
            text: sessionData.sessionTime
        });

    var button = $("<a/>",
        {
            "class": "button",
            "href": "/MovieSessions/Details/" + sessionData.movieSessionId,
            text: "Buy Tickets"
        });

    image.appendTo(left);
    title.appendTo(containingDiv);
    description.appendTo(right);
    cinema.appendTo(right);
    time.appendTo(right);
    button.appendTo(right);
    left.appendTo(infoDiv);
    right.appendTo(infoDiv);
    infoDiv.appendTo(containingDiv);

    return containingDiv;
}