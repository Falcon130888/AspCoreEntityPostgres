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
    $("#ButtonPost").on("click", function () {
        var listName = "CopyItems";
        var items = $('#CopyList>li');
        var ContentHTML = $("#editor").html();
        var ContentText = $("#editor").text();
        $("#Content").val(ContentHTML);
        $.each(items, function () {
            var Id = $(this).val();
            $("#UserCopy").prepend("<input type='hidden' name='" + listName + "' value='" + Id + "' />");
        });
    });
    $('.select2').select2();
});

    DecoupledEditor
        .create(document.querySelector('#editor'))
            .then(editor => {
                const toolbarContainer = document.querySelector('#toolbar-container');

    toolbarContainer.appendChild(editor.ui.view.toolbar.element);
})
            .catch(error => {
        console.error(error);
});