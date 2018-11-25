$(document).ready(function(){

    $.validator.addMethod("login", function(value, element){
        return this.optional(element) || /^[a-zA-Z0-9]+([_ -]?[a-zA-Z0-9])*$/.test(value)
    }, "Логин должен содержать только латинские символы.");

    $.validator.addMethod("password", function(value, element){
        return this.optional(element) || /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]*$/.test(value)
    }, "Пароль должен содержать минимум одну букву и одно число.");

    $("#registerForm").validate({    
        rules: {
            login: {
                login: true,
                required: true,
                minlength: 5,
                maxlength: 20
            },
            password: {
                password: true,
                required: true,
                minlength: 8,
                maxlength: 25
            },
            retryPassword: {
                required: true,
                equalTo: "#password"
            },
            email:{
                required: true,
                email: true,
                maxlength: 30
            },
            username:{
                minlength: 5,
                maxlength: 50
            }
        },
    
        messages: {
            login: {
                required: "Поле логина обязательно для заполнения!",
                minlength: jQuery.format("Логин не должен быть меньше {0} символов!"),
                maxlength: jQuery.format("Логен не должен быть больше {0} символов!")
            },
            password: {
                required: "Поле пароля обязательно для заполнения!",
                minlength: jQuery.format("Пароль не должен быть быть меньше {0} символов!"),
                maxlength: jQuery.format("Пароль не должен быть быть больше {0} символов!")
            }, 
    
            retryPassword: {
                equalTo: "Пароли не совпадают.",
                required: "Поле повтора пароля обязательно для заполнения!"
            }, 
    
            email: {
                required: "Поле электронного адреса обязательно для заполнения!",
                maxlength: jQuery.format("Email не должен быть больше {0} символов!")
            },
            username: {
                minlength: jQuery.format("Имя пользователя не может быть меньше {0} символов!"),
                maxlength: jQuery.format("Имя пользователя не может быть больше {0} символов!")
            }
        },

        errorElement: "em",
        errorPlacement: function ( error, element ) {
            error.addClass( "help-block" );

            if ( element.prop( "type" ) === "checkbox" ) {
                error.insertAfter( element.parent( "label" ) );
            } else {
                error.insertAfter( element );
            }
        },
        highlight: function ( element, errorClass, validClass ) {
            $( element ).parents( ".form-group" ).addClass( "has-error" ).removeClass( "has-success" );
        },
        unhighlight: function (element, errorClass, validClass) {
            $( element ).parents( ".form-group" ).addClass( "has-success" ).removeClass( "has-error" );
        }    
    });    
});