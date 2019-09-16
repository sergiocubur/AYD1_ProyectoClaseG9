Feature: Funcionalidad de inicio de sesion
Como usuario 
Para usar la aplicacion 
quiero iniciar sesion ingresando mi codigo de usuario y password

@mytag
Scenario: Inicio de sesion con credenciales no validas
	Given estoy en la pagina de inicio de sesion
	When complete el cuadro de texto con el codigo 'incorrectcodigo'
	And complete el cuadro de texto del password con el valor 'incorrectpassword'
	And hago click en el boton inicio de sesion 
	Then el texto '!No se puede iniciar sesion¡, correo o contraseña incorrecta.' deberia de aparecer

Scenario: Inicio de sesion con credenciales validas
	Given estoy en la pagina de inicio de sesion
	When complete el cuadro de texto con el codigo '2001'
	And complete el cuadro de texto del password con el valor '12345'
	And hago click en el boton inicio de sesion 
	Then deberia de ingresar correctamente a mi usuario
