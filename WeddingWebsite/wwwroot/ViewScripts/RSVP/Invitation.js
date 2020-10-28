let songArtistDelimiter = "/|$|\\";
let songPicks = {};

function isValidArtist() {
    let artist = $("#songArtist").val().trim();

    return artist != "";
}

function isValidSongName() {
    let song = $("#songName").val().trim();

    return song != "";
}

function showSongErrors() {
    if (!isValidSongName() && !isValidArtist()) {
        $("#invalidSong").show();
        $("#invalidArtist").show();
    }

    if (!isValidSongName())
        $("#invalidSong").show();

    if (!isValidArtist())
        $("#invalidArtist").show();

}

function isValidSongRequest() {
    return isValidSongName() && isValidArtist();
}

function clearSongFields() {
    $("#songArtist").val("");
    $("#songName").val("");
}

function getSongListItem(artist, song) {
    let listItem =
        '<li class="list-group-item" style="display:table" id="' + artist.replace(" ", "") + song.replace(" ", "") + '">' +
        '<a style="vertical-align:middle;display:table-cell">' + song + " by " + artist + '</a>' +
        '<button class="btn btn-sm" style="float:right;" type="button" id="' + artist + "/|$|\\" + song + '" onclick="deleteSong(this)">' +
        '<i class="fa fa-times-circle" style="font-size:24px;color:red"></i>' +
        '</button >' +
        '</li >'

    return listItem;

}

function clearSongErrors() {
    $("#invalidSong").hide();
    $("#invalidArtist").hide();
}

function deleteListItem(itemId) {
    $("#" + itemId).remove();
}

function deleteSong(element) {
    let keyValueList = element.id.split(songArtistDelimiter);
    let artist = keyValueList[0];
    let song = keyValueList[1];
    deleteListItem(artist.replace(" ", "") + song.replace(" ", ""));

    if (songPicks[artist].length == 1)
        delete songPicks[artist];
    else {
        let songIndex = songPicks[artist].indexOf(song);
        songPicks[artist].splice(songIndex, 1);
    }
}

function artistInDict(artist) {
    return songPicks[artist] !== undefined;
}

function songInArtistSongList(artist, song) {
    return songPicks[artist].includes(song);
}

function addSongToList(artist, song) {
    let addSong = false;
    if (artistInDict(artist)) {
        if (!songInArtistSongList(artist, song)) {
            songPicks[artist].push(song);
            addSong = true;
        }
    }
    else {
        songPicks[artist] = [song];
        addSong = true;
    }

    if (addSong)
        $("#songs").append(getSongListItem(artist, song));
}

function addSongListener() {
    $("#addSong").click(function () {
        clearSongErrors();
        if (!isValidSongRequest()) {
            showSongErrors();
            return false;
        };

        let song = $("#songName")
            .val()
            .trim()
            .toLowerCase();
        let artist = $("#songArtist")
            .val()
            .trim()
            .toLowerCase();


        addSongToList(artist, song);
        clearSongFields();
    });
}