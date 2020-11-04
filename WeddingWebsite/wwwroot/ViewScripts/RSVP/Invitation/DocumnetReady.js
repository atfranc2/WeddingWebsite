
$(document).ready(function () {
    $('#drink-information').popover({
        container: 'body',
        html: true,
        trigger: 'hover',
        content: function () {
            return $('#drink-list').html();
        }
    });

    addSongListener();

    $("#selectDrinks").selectpicker();

    attendenceFormButtons();
    contactInformationFormButtons();
    timelineFormButtons();
    songRequestFormButtons();
    drinkFormButtons();
    marriageAdviceFormButtons();
});
