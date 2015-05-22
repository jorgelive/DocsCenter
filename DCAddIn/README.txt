Configuración del Addin de Outlook:


Configuración de usuario


	[HKEY_CURRENT_USER\Software\Gopro\Vipac Share Center\Cuentas] (string)

		"usuario@vipac.pe"="xxxx"


Parametros del módulo

	[HKEY_CURRENT_USER\Software\Gopro\Vipac Share Center\Parametros] (string)

		debug => valores: 1 o 0. Inserción de datos de depuración en el Log Windows/aplicaciones


		preload => valores: 1 o 0. Precarga de librerias, requere la habilitacion del log mediante el comando


			eventcreate /ID 1 /L APPLICATION /T INFORMATION  /SO ShareCenter /D "Se ha creado el origen de aplicación ShareCenter"	


		forzarred => Valores: no / "10.10.x" (tres primeros bytes de la red local)

		modoremoto => valores: exchange Parametro opcional, requiere la creación de la clave completa.