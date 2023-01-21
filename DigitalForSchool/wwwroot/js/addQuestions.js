var questions = $("#Questions");
let deletedAnswers = [[]];
$("#addQuestion").click(function () {
    var questionIndex = questions.find(".question").length;
    var template1 =
        '<div class="row question d-flex flex-column align-items-center" id="' + questionIndex + '">' +
        '<div class="form-group" id="form' + questionIndex + '">' +
        '<label name="Test.Questions[' + questionIndex + '].Name" id="Test.Questions[' + questionIndex + '].Name">Question name</label>' +
        '<div class="input-group" id="inp' + questionIndex + '" >' +
        '<textarea name="Test.Questions[' + questionIndex + '].Name" id="Test.Questions[' + questionIndex + '].Name" class= "form-control"></textarea>' +
        '<button type="button" class="btn btn-secondary remove">Remove</button>' +
        '<span asp-validation-for= "Test.Questions[' + questionIndex + '].Name" class="text-danger"></span>' +
        '</div>' +
        '<button type="button" class="btn btn-secondary mt-2" id="addAnswer">Add answer</button>' +
        '</div>' +
        '</div>';
    questions.append(template1);
})



questions.on("click", "#addAnswer", function (e) {

    var selectedIndex = $(this).closest(".row").attr('id');
    var selectedIndexId = selectedIndex.replace(/[^0-9]/gi, '');
    var selectedQuestion = $(this).closest('.question');
    var answerIndex = selectedQuestion.find('.answer').length;
    $(this).closest(".btn").remove();
    var questionIndex = questions.find(".question").length;

    var template2 =
        '<div class="row" id="AnswQuest' + selectedIndex + '">' +
        '<div class="form-group answer ps-4 ">' +
        '<div class="input-group" id="inp' + selectedIndexId + '">' +
        '<input type="radio" value="' + answerIndex + '" name="' + selectedIndexId + '"/>' +
        '<input name="Test.Questions[' + selectedIndexId + '].Answers[' + answerIndex + '].Text" id="Test.Questions[' + selectedIndexId + '].Answers[' + answerIndex + '].Text" class= "form-control" />' +
        '<button type="button" class="btn btn-secondary remove">Remove</button>' +
        '<span asp-validation-for="Test.Questions[' + selectedIndexId + '].Answers[' + answerIndex + '].Text" class= "text-danger" ></span>' +
        '</div>' +
        '<button type="button" class="btn btn-secondary d-flex flex-column align-items-center mt-2" id="addAnswer">Add answer</button>' +
        '</div>' +
        '</div>';

    $('div[id = ' + selectedIndexId + ']').append(template2);

})
questions.on('click', '.remove', function (e) {

    var inpId = $(this).closest('.input-group').attr('id');
    var questionId = inpId.replace(/[^0-9]/gi, '');
    var selectedQuestion = $(this).closest('.question');
    var inputCount = selectedQuestion.find('.input-group').length;

    $(this).closest('.form-group').remove();

    var allInput = selectedQuestion.find('.input-group');

    allInput.each(function (index) {
        if (index != 0) {

            var radioValue = $(this).children().eq(0).attr("value");
            if (radioValue > 0) radioValue--;
            $(this).children().eq(0).attr("value", radioValue);
        }

    })

    allInput.each(function (index) {
        if (index != 0) {

            var current = $(this).children().eq(1).attr("name");
            var source = allInput.eq(1).children().eq(1).attr("name");
            var answerId = current.split("[")[2].split("]")[0];
            if (answerId > 0) answerId--;
            var temp = current.split("[")[2];

            var res = current.replace(temp, answerId + "].Text");
            $(this).children().eq(1).attr("name", res);

        }


    })



    if (inputCount == 2) {
        selectedQuestion.find('.form-group').append('<button type="button" class="btn btn-secondary d-flex align-items-center flex-column mt-2" id="addAnswer">Add answer</button>');
    } else if (selectedQuestion.find('#addAnswer').attr('type') != 'button') {
        allInput.last().append('<button type="button" class="btn btn-secondary d-flex flex-column align-items-center mt-2" id="addAnswer">Add answer</button>');
    }
});