$(document).ready(function(){
    
    $("#loginForm").validate({
        rules: {
            login: {
                login: true,
                required: true,
                minlength: 5,
                maxlength: 20
            },
                password: {
                required: true,
                minlength: 5,
                maxlength: 25
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