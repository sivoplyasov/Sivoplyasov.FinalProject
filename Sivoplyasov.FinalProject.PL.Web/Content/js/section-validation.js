$("#sectionForm").validate({
    rules: {
        sectionName: {
            required: true,
            minlength: 5,
            maxlength: 30
        }
    },

    messages: {
        sectionName: {
            required: "Имя секции - обязательно для заполнения",
            minlength: jQuery.format("Имя секции не должно быть меньше {0} символов!"),
            maxlength: jQuery.format("Имя секции не должно быть больше {0} символов!")
        }
    }
});