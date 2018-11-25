$("#postForm").validate({
    rules: {
        textarea:{
            required: true,
            minlength: 10,
            maxlength: 1000
        }
    },

    messages: {
        textarea: {
            required: "Поле сообщения обязательно для заполнения!",
            minlength: jQuery.format("Нельзя публиковать пустое сообщение! Сообщение не должно быть меньше {0} символов!"),
            maxlength: jQuery.format("Сообщение не должно быть больше {0} символов!")
        }
    }
});