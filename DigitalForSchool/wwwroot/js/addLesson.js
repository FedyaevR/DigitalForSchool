var lessons = $('#lessons tbody');
$("#addLesson").click(function () {
    var rowNo = lessons.find('tr').length;
    var template =
        '<tr>' +
        '<td><input name="Input.Lessons[' + rowNo + '].Name" id="Lessons_' + rowNo + 'Name" /></td>' +
        '<td><textarea name="Input.Lessons[' + rowNo + '].Description" id="Lessons_' + rowNo + 'Description"></textarea></td>' +
        '<td><input type="url" name="Input.Lessons[' + rowNo + '].VideoURL" id="Lessons_' + rowNo + 'VideoURL"/></td>' +
        '<td><input name="Input.Lessons[' + rowNo + '].VideoName" id="Lessons_' + rowNo + 'VideoName"/></td>' +
        '<td><input type="file" accept=".pdf" id="Upload['+rowNo+']" name="Upload['+ rowNo +']" /></td>'+
        '<td><button class="btn btn-secondary remove">Remove</button>'+'</td>' +
        '</tr>';
    lessons.append(template);
});
lessons.on('click', '.remove', function (e) {
    $(this).closest('tr').remove();
});
