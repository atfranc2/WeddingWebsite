function attendenceFormButtons() {
    $("#attendenceForm").submit( async function (e) {
        e.preventDefault();
        $("#attendenceForm").hide();

        let guestOneAttending = $("#guestOneAttendence :checked").val() == "true";
        let guestTwoAttending = $("#guestTwoAttendence :checked").val() == "true";

        rsvpViewModel["guestOneAccepts"] = Boolean(guestOneAttending);
        rsvpViewModel["guestTwoAccepts"] = Boolean(guestTwoAttending);

        console.log("G1: " + guestOneAttending + " G2: " + guestOneAttending); 
        console.log(rsvpViewModel); 

        if (!guestOneAttending && !guestTwoAttending) {
            let result = await submitDeclinedInvitation(); 
            window.location.href = "/RSVP/RSVPSubmitSuccess"; 
        }

        $("#contactInformationForm").show();
    });
}

async function submitDeclinedInvitation() {

    let result = await $.ajax({
        url: "/api/RSVPs",
        method: "POST",
        contentType: 'application/json',
        data: JSON.stringify(rsvpViewModel)
    });

    return result; 
}

function contactInformationFormButtons() {
    $("#contactInformationForm").submit(function (e) {
        e.preventDefault();
        $("#contactInformationForm").hide();
        rsvpViewModel["contactEmail"] = $("#emailAddress").val();
        $("#timelineForm").show();
    });

    $("#prevAttendanceForm").click(function () {
        $("#contactInformationForm").hide();
        $("#attendenceForm").show();
    });
}

function timelineFormButtons() {
    $("#timelineForm").submit(function (e) {
        e.preventDefault();
        $("#timelineForm").hide();
        rsvpViewModel["dayOfArrival"] = $("#arrivalDay").val(); 
        rsvpViewModel["timeOfArrival"] = $("#arrivalTime").val();
        $("#songRequestForm").show();
    });

    $("#prevContactInformationForm").click(function () {
        $("#timelineForm").hide();
        $("#contactInformationForm").show();
    });
}

function songRequestFormButtons() {
    $("#songRequestForm").submit(function (e) {
        e.preventDefault();
        $("#songRequestForm").hide();
        unpackSongPicks();
        rsvpViewModel.songRequests = getSongRequestModel(); 
        $("#drinkForm").show();
    });

    $("#prevTimelineForm").click(function () {
        $("#songRequestForm").hide();
        $("#timelineForm").show();
    });
}

function drinkFormButtons() {
    $("#drinkForm").submit(function (e) {
        e.preventDefault();
        $("#drinkForm").hide();
        rsvpViewModel.drinkRequests = getDrinkModel(); 
        $("#marriageAdviceForm").show();
    });

    $("#prevSongRequestForm").click(function () {
        $("#drinkForm").hide();
        $("#songRequestForm").show();
    });
}

function marriageAdviceFormButtons() {

    $("#prevDrinkForm").click(function () {
        $("#drinkForm").show();
        $("#marriageAdviceForm").hide();
    });
}