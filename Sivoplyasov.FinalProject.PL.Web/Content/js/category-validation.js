$("#sectionForm").validate({
    rules: {
        categoryName: {
            required: true,
            minlength: 5,
            maxlength: 50
        },
        categoryDescription:{
            minlength: 5,
            maxlength: 50
        }
    },

    messages: {
        categoryName: {
            required: "Имя категории - обязательно для заполнения",
            minlength: jQuery.format("Имя категории не должно быть меньше {0} символов!"),
            maxlength: jQuery.format("Имя категории не должно быть больше {0} символов!")
        }, 
        categoryDescription: {
            minlength: jQuery.format("Описание не должно быть меньше {0} символов!"),
            maxlength: jQuery.format("Описание не должно быть больше {0} символов!")
        }
        
    }
});