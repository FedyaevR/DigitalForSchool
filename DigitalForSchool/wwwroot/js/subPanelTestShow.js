
$('.form-select').removeAttr('multiple');

$('.form-select').change(function () {
    var lessonId = $(this).val();
    var lesson = $(this).closest("tr");
    lesson.find("#addTest").attr("href", function (index, attr) {
        var res = attr.split('/')[5];   
        return attr.replace(res, lessonId);
    });
    lesson.find("#editTest").attr("href", function (index, attr) {
        var res = attr.split('/')[5];
        return attr.replace(res, lessonId);
    });
    lesson.find("#removeTest").attr("href", function (index, attr) {
        var res = attr.split('/')[5];
        return attr.replace(res, lessonId);
    });
});
