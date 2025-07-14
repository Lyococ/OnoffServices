# Onoff Test!

Buen día querido usuario, a continuación encontraras las pautas necesarias para que puedas correr este proyecto.
  
## Descripción del Proyecto
Este proyecto fue creado con el fin de poder administrar un todo list de actividades para la prueba de `OnoFF`.


## 🧱 Arquitectura General

Para el proyecto de la prueba se oriento mediante el patron  `Cliente-Servidor` con separación de responsabilidades. Esta separación mejora la mantenibilidad, escalabilidad y reutilización del código, debido a que es un proyecto pequeño no se requirio realizar un arquitectura mas robusta para soportar la funcionalidad.

## 📦 Estructura de carpetas
|Nombre                |Descripción                          |
|----------------|-------------------------------|-----------------------------|
|Data| Centralizar el dbcontext para acceso a datos de la BD
|Dto| Centralizar los objectos que permitan la interación con la logica de negocio                      
|Migrations |Carpeta que permite contener las migraciones de BD que se requieran a medida que se realicen cambios en la BD
|Model|Carpeta que permite establecer la información de los modelos de BD 

## 🛠️ Tecnologías utilizadas

- .NET Core 9

- FluentValidation, JWT, xUnit

## 🚀 Configuración del entorno

- .Net core 9
- Sql server 16
Para correr el entorno se recomienda cambiar la cadena de conexión en el archivo de configuración del proyecto.
- ### Correr el proyecto 
	- Restaurar la BD Enoff.bak que se encuentra dentro del respositio.
 	- una vez descargado el proyecto correr el comando dotnet build mediante una consola o el ide de su preferencia.

## 🔐 Autenticación
Al momento de iniciar sesión se pueden utilizar las siguientes credenciales
- Usuario: ing.dareyes@hotmail.com
- Contraseña: C0dely0c0*.*17

## 🧪 Pruebas
Si se requiere correr las pruebas del proyecto se recomienda mediante linea de comando o mediante el visor de pruebas de visual studio
- xUnit para controladores (AddTask, GenerateToken)
