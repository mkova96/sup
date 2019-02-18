$(document).ready(function () {
    $('select[multiple]').multiselect();
    var $select = $('#announcementRecieverType');
    if ($select) {
        $select.on('change', function (e) {
            var value = $(this).val();
            if (value === "User") {
                $('#announcementUsers').show();
                $('#announcementGroups').hide();
            } else {
                $('#announcementUsers').hide();
                $('#announcementGroups').show();
            }
        });
    }
    var $registerRadios = $('input[name="CompanyType"]');
    if ($registerRadios.length) {
        showCompanyView ();
        $registerRadios.on('change', function (e) {
            showCompanyView ();
        })
    }
});

function showCompanyView() {
        var value = $('input[name="CompanyType"]:checked').first().val();
    if (value === "new") {
        $('#registerCreateCompnay').show();
        $('#registerSelectCompany').hide();
    } else {
        $('#registerCreateCompnay').hide();
        $('#registerSelectCompany').show();
    }
}
