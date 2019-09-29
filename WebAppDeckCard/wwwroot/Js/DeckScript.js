
var zIndexValue = 1;
$(document).on('click', '.card', function () {
    $(this).toggleClass('is-flipped');
});

$(document).on('mousedown', '#draggable-move', function (e) {
    $(this).parent().css(
        'z-index', zIndexValue++);
    $(this).draggable();
});




function ShuffleCard() {
    $.ajax({
        url: "/Home/ShufflePlayingCard",
        method: "GET",
        cash: false,
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            var yIndexValue = 0;
            var newRow = $('#rows');
            $.each(data, function (index, value) {
                var cards = $('<div id="' + index + '" class="cards"></div>');
                var card = $('<div class="card" id="draggable-move"></div>');
                var front = $('<div class="front">' +
                    '<img class="" src="Deck/' + value.image + '">' + '</div>');
                front.appendTo(card);
                var back = $('<div class="back">' +
                    '<img class="backImg" src="Deck/back.png" asp-append-version="true">' +
                    '</div>');
                back.appendTo(card);
                card.appendTo(cards);
                cards.appendTo(newRow).hide().css({
                    "display": "block",
                    "margin": "20%"
                }).delay(index * 30).animate({
                    left: '30%',
                }, 200, function () {
                    yIndexValue--;
                    $(this).css('z-index', yIndexValue)
                }).animate({
                    left: '1%',
                    marginTop: 50
                }, 200);
            });
        }
    });
}

function GetAllDeckCard() {
    $.ajax({
        url: "/Home/GetAllDeck",
        method: "GET",
        cash: false,
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            createModel(data);
        }
    });
}

function createModel(data) {
    var newRow = $('#rows');
    $.each(data, function (index, value) {
        var cards = $('<div id="' + index + '" class="cards"></div>');
        var card = $('<div class="card" id="draggable-move"></div>');
        var front = $('<div class="front">' +
            '<img class="" src="Deck/' + value.image + '">' + '</div>');
        front.appendTo(card);
        var back = $('<div class="back">' +
            '<img class="backImg" src="Deck/back.png" asp-append-version="true">' +
            '</div>');
        back.appendTo(card);
        card.appendTo(cards);
        cards.appendTo(newRow).hide().css({
            "display": "block",
            "margin": "20%"
        }).delay(index * 50).animate({
            right: '10%'
        }, 400, function () {

        }).animate({
            right: '1%',
        });
    });
}
function choiceCard(e) {
    $.ajax({
        url: "/Home/SortByGropName?=" + e,
        method: "GET",
        cash: false,
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            createModel(data);
        }
    });
}

$("#menu li a").on('click', function (e) {
    e.preventDefault()
    var choice = $(this).data('page');

    if (choice === "Start") {
        $('#rows').empty();
        GetAllDeckCard();
    }
    else if (choice === "Shuffle") {
        $('#rows').empty();
        ShuffleCard()
    }
    else {
        $('#rows').empty();
        choiceCard(choice)
    }
});