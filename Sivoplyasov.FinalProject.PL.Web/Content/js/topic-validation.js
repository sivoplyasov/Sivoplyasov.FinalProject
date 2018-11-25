$("#topicForm").validate({
    rules: {
        topicName: {
            required: true,
            minlength: 5,
            maxlength: 50
        },
        description: {
            maxlength: 50
        },

        textarea:{
            required: true,
            minlength: 10,
            maxlength: 1000
        }
    },

    messages: {
        topicName: {
            required: "Имя темы - обязательно для заполнения",
            minlength: jQuery.format("Имя темы не должно быть меньше {0} символов!"),
            maxlength: jQuery.format("Имя темы не должно быть больше {0} символов!")
        },
        description: {
            maxlength: jQuery.format("Максимальная длинна описания - {0} символов!")
        },

        textarea: {
            required: "Поле пароля обязательно для заполнения!",
            minlength: jQuery.format("Нельзя публиковать пустое сообщение! Сообщение не должно быть меньше {0} символов!"),
            maxlength: jQuery.format("Сообщение не должно быть больше {0} символов!")
        }
    }
});