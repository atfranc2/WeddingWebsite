
function getDrinkModel() {
    let DrinkModel = [];
    let drinkRequests = $("#selectDrinks :selected");
    for (let drink of drinkRequests) {
        drinkName = $(drink).attr('drink-name');
        drinkId = $(drink).attr('drink-id');
        let drinkVM = {
            "GuestId": guestId,
            "SpecialtyDrinkModelId": Number(drinkId)
        };

        DrinkModel.push(drinkVM);
    }

    return DrinkModel;
}

function getSongRequestModel() {
    songRequests = [];
    for (var index in songRequestViewModel.artistList) {
        let model = {
            "guestId": guestId,
            "songTitle": songRequestViewModel.songList[index],
            "songArtist": songRequestViewModel.artistList[index]
        };

        songRequests.push(model);
    }

    return songRequests;
}

