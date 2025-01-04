Early documentation:

FormUser.cs works as both an edit to users and to add new users. This has to be made properly clear during the program usage.

FormBuscarUser
  ListBox that fetches the values from the global user list. 
  PropertyGrid that shows the values fetched from the selected value in the ListBox. 
  Stores a tempEditedUsers that STORES THE USERS THAT HAVE BEEN EDITED during the current session in case they need to be fetched to be reverted.


TODO:
Mensajes de información, advertencia, error y confirmación si los necesito.
Copiar, pegar y cortar el texto seleccionado, por algún motivo.
Botón de Ayuda, Acerca de
Ir por las issues abiertas y cerrar alguna muy importante

ENHANCEMENTS:
Añadir botón de SAVE ALL y REVERT ALL


Hacer en clase:
Añadir las medidas necesarias para, en el futuro, poder implementar la opción
del lector de pantalla. ????
Save and Load from XML/JSON 
