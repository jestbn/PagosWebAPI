# PagosWebAPI


Es una WebApi creada para simular una operación de pago típica en una solución de e-commerce

## Instalación

Se debe tener instalado Visual Studio IDE preferiblemente [2019](https://visualstudio.microsoft.com/downloads/) y el .Net Core idealmente version [5 SDK](https://dotnet.microsoft.com/download).

Se debe tener instalado un motor de base de datos SQLSERVER recomendado [2019 express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads?SilentAuth=1&wa=wsignin1.0)

Abrir el archivo .sln que se encuentra en la carpeta principal.

En el archivo appsettings.json debemos configurar la conexion a nuestra base de datos local, cambiar los valores a los equivalentes del nuevo host
```bash
"DefaultConnection": "Server=PCMR\\SQLEXPRESS; Database=PagosWebApi; Trusted_Connection=true;"
```
En la consola "Package Manager Console" del IDE
nos dirigimos a la carpeta pagoswebapi

```bash
cd pagoswebapi
```
Posteriormente actualizamos la base de datos 
```bash
update-database
```
En caso de éxito de la operación

```bash
Build started...
Build succeeded.
 <Warnings de Microsoft>
Done.
```
Mediante SQL Server Management studio se puede verificar la creación de la base de datos "PagosWebApi" 

Una vez creada la base de datos local se puede levantar la aplicación mediante el botón(Play verde) "IIS Express"


## Uso

El aplicativo levanta una sesión en el navegador donde se pueden consumir todos los endpoints del api mediante [Swagger Ui](https://swagger.io/tools/swagger-ui/)

¡Las migraciones de la base de datos no cuentan con datos iniciales!

Se sugiere crear Usuario e Items según necesidad, además se sugiere el uso de su respectivo API para la inserción

Debido a que las demas tablas seran llenadas según se use el aplicativo

### Funcionalidad principal
    1. Facturar la suma de todos los productos al usuario en el servicio Facturar
Se encuentra en el Get del controlador "MainController" , se envía el Id del usuario y el Id del ítem, retorna un mensaje con la info procesada.

    2. Llamar al servicio de Logística para crear un pedido enviado.

El controlador de Orden crea los pedidos.

## Componentes

- SQLServer2019 Express edition: Motor de base de datos
- .Net Core 5: Plataforma de desarrollo gratis, open-source, multi-plataforma para crear diferentes tipos de aplicaciones.

Paquetes usados:
- Swashbuckle.AspNetCore: Implementación de SwaggerUi
- Microsoft.EntityFrameworkCore: Mapeador Objeto relacional que permite la creación de bases de datos y sus componentes con el acercamiento usado en este aplicativo "Code first" donde a partir del código inicial de la solución se crean las entidades correspondientes.
- Microsoft.VisualStudio.Web.CodeGeneration: Contiene el dotnet-aspnet-codegenerator comando usado para generar vistas y controladores
