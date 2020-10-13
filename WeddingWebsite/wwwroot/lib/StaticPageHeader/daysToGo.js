function getTodaysDate() {
    let day = new Date().getDate();
    let month = new Date().getMonth();
    let year = new Date().getFullYear();

    return new Date(year, month, day);
}

function getDaysToGo() {
    let today = getTodaysDate();
    let weddingDay = new Date(2021, 3, 23);
    let dateDiff = weddingDay.getTime() - today.getTime();

    return dateDiff / 86400000;
}

$(document).ready(function () {
    $('#days-to-go').text(getDaysToGo()).css("font-weight", "Bold");
});