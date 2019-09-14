Feature: MODUS_BDDusModify
	Una funcionalidad para modificar el usuario 

@mytag
Scenario: Agregar fecha de alta
	When yo ingreso fecha
	Then actualizo la tabla usuario
