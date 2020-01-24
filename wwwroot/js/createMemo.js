function AddCopy() {
    var e = document.getElementById("IdUserCopy");
    var result = e.options[e.selectedIndex].value;

    document.getElementById("result").innerHTML = result;
}
function chk() {
    var chk = document.getElementById('AddCopy');
    if (chk.checked) {
        document.getElementById('UserCopy').style.visibility = 'visible';
    }
    else {
        document.getElementById('UserCopy').style.visibility = 'hidden';
    }
}
$(document).ready(function () {
    $("#IdUserCopy").change(function () {
        var Selected = $('#IdUserCopy option:selected')
        $("#CopyList").append($("<li name='CopyItems' class='list-group-item' value='" + Selected.val() + "'>").text(Selected.text()));
    });
    $('.select2').select2();
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
});