$(document).ready(function() {
    $('#txtName').autocomplete({
        source: function(request, response) {
            var searchText = request.term;
            var autocompleteUrl = 'http://localhost:61330/api/Literatures/RetrieveAuthors/' + searchText;
            $.ajax({
                url: autocompleteUrl,
                type: 'GET',
                cache: false,
                dataType: 'json',
                success: function(json) {
                    response($.map(json, function(data, id) {
                        return {
                            label: data.AuthorId + ': ' + data.FirstName + ' ' + data.SurName + ' ' + data.LastName,
                            value: data.AuthorId + ': ' + data.FirstName + ' ' + data.SurName + ' ' + data.LastName,
                            authorId: data.AuthorId,
                            firstName: data.FirstName,
                            surName: data.SurName,
                            lastName: data.LastName
                        };
                    }));
                },
                error: function(xmlHttpRequest, textStatus, errorThrown) {
                    console.log('some error occured', textStatus, errorThrown);
                }
            });
        }, //minLength: 1,
        select: function(event, ui) {
            var theChosenAuthorText = ui.item.label;
            var chosenAuthorId = ui.item.authorId;
            lblMessage.innerText = "You Selected Author :";
            lblSelectedVal.innerText = ui.item.label;
            $('#txtName').val(ui.item.label);
            $('#txtAuthorId').val(ui.item.authorId);
            $('#txtAuthorFirstName').val(ui.item.firstName);
            $('#txtAuthorSurName').val(ui.item.surName);
            $('#txtAuthorLastName').val(ui.item.lastName);
            $('#authorList').append("<option value='" + chosenAuthorId + "'>" + theChosenAuthorText + "</option>");
            @GetValue()
            return false;
        }
    });
});