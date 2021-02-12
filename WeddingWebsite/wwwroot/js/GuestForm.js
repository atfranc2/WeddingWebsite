function getGuestOneViewModel() {
    let vm = {};
    vm.firstName = $("#firstName1").val();
    vm.middleName = $("#middleName1").val();
    vm.lastName = $("#lastName1").val();
    vm.plusOneAllowed = $("input[name='plusOnePermission']:checked").val() == 'yes';
    vm.partOfCouple = $("input[name='partOfCouple']:checked").val() == 'yes';

    return vm;
}

function getGuestTwoViewModel() {
    let vm = {};
    vm.firstName = $("#firstName2").val();
    vm.middleName = $("#middleName2").val();
    vm.lastName = $("#lastName2").val();
    vm.plusOneAllowed = false;
    vm.partOfCouple = true;

    if (vm.firstName == "")
        return null;

    return vm;
}

function getCoupleViewModel() {
    let vm = {};
    let guestOne = getGuestOneViewModel();
    let guestTwo = getGuestTwoViewModel();

    vm.guestOne = guestOne;
    vm.guestTwo = guestTwo;

    return vm;
}

function clearPlusOneRadio() {
    $("#plusOneAllowed").prop("checked", false);
    $("#plusOneDenied").prop("checked", false);
}

function resetForm() {
    $('#secondGuest').hide();
    $('#allowedPlusOne').hide();
    clearPlusOneRadio();
    $("#newGuest")[0].reset();
    $("#firstName1").select();
}

function ajaxPostGuest(viewModel) {
    return $.ajax({
        url: "/api/Guests",
        method: "post",
        contentType: 'application/json',
        data: viewModel
    });

}

function ajaxPostCouple(viewModel) {
    return $.ajax({
        url: "/api/Couples",
        method: "post",
        contentType: 'application/json',
        data: viewModel
    });
}

function loadRadioBtnBehavior() {
    $('#yesRadio').on('click', function () {
        $('#secondGuest').show();
        $('#allowedPlusOne').hide();
        clearPlusOneRadio();
        $("#firstName2").attr('required', true);
        $("#lastName2").attr('required', true);
        $("#plusOneAllowed").attr('required', false);
    });

    $('#noRadio').on('click', function () {
        $('#secondGuest').hide();
        $('#allowedPlusOne').show();
        $("#firstName2").val('');
        $("#middleName2").val('');
        $("#lastName2").val('');
        $("#firstName2").attr('required', false);
        $("#lastName2").attr('required', false);
        $("#plusOneAllowed").attr('required', true);
    });
}