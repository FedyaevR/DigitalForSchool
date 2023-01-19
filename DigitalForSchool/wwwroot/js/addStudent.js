var students = $("#students tbody");
$("#addStudent").on("click", function () {
    var rowNum = students.find("tr").length;
    var template =
        '<tr>' +
        '<td><input name="Input[' + rowNum + '].FirstName" id="Input[' + rowNum + '].FirstName" /></td>' +
        '  <span asp-validation-for="Input[i].FirstName" class="text-danger"></span>' +
        '<td><input name="Input[' + rowNum + '].LastName" id="Input[' + rowNum + '].LastName" /></td>' +
        '<span asp-validation-for="Input[i].LastName" class="text-danger"></span>' +
        '<td><input name="Input[' + rowNum + '].Patronymic" id="Input[' + rowNum + '].Patronymic" /></td>' +
        '<span asp-validation-for="Input[i].Patronymic" class="text-danger"></span>' +
        '<td><input name="Input[' + rowNum + '].SchoolName" id="Input[' + rowNum + '].SchoolName" /></td>' +
        '<span asp-validation-for="Input[i].SchoolName" class="text-danger"></span>' +
        '<td><button class="btn btn-secondary remove">Удалить</button></td>' +
        '</tr>'
    students.append(template);
});
students.on("click", ".remove", function (e) {
    $(this).closest("tr").remove();
});