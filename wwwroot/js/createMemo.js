function chk() {
    var chk = document.getElementById('AddCopy');
    if (chk.checked) {
        document.getElementById('UserCopy').style.visibility = 'visible';
    }
    else {
        document.getElementById('UserCopy').style.visibility = 'collapse';
    }
}

$(document).ready(function () {
    $("#IdUserCopy").change(function () {
        var Selected = $('#IdUserCopy option:selected')
        $("#CopyList").append('<li  name="CopyItems"  class="list-group-item" value="'
            + Selected.val() + '"><a  class="itemDelete">' + Selected.text() + '<span class="tooltiptext">удалить</span></a></li>');
    });
    $('#CopyList').on('click', '.itemDelete', function () {
        $(this).closest('li').remove();
    });
    $('#CopyList').on('click', '.itemDelete', function () {
        $(this).closest('li').remove();
    });
    $("#ButtonPost").on("click", function () {
        var listName = "CopyItems";
        var qtd = 0;
        var items = $('#CopyList>li');
        $.each(items, function (index) {
            var Id = $(this).val();
            $("#UserCopy").prepend("<input type='hidden' name='" + listName + "' value='" + Id + "' />");
            qtd += 1;
        });
    });
    $('.select2').select2();
});