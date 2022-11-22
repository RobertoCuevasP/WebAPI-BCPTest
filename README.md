# WebAPI-BCPTest

--------------------------------------------------------------------------------------------------------------------------------------------
Guía:
--------------------------------------------------------------------------------------------------------------------------------------------
1. Para Microsoft S.Q.L Server Management Studio, en consola CMD creamos un servidor local
		sqllocaldb create "Nombre"
   Nos conectamos a (localdb)\Nombre 
2. Creamos un Database Ej Test
	Dentro de la misma creamos las tablas, colocando campos y sus tipos

3. En Visual Studio
	New Project
		Tipo> ASP.NET .API Web Application (.NET Framework)

4. En SQL, Crear los procedimientos Almacenados

5. En Visual Studio, crear modelos y controllers de Tipo Api
	Luego en Archivo web.config luego de <appSettings> colocar
	<connectionString>
		<add name = "webapi_connection" connectionString = "server = (localdb)\Nombre; database = Test; Integrated Security = true"/>
	</connectionString>

6. En los controllers creamos los métodos CRUD para unirlos con los procedimientos Almacenados
	Para conectar el controller con la base de datos:
		SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_connection"].ConnectionString);

	Crear los controllers: Cuenta, Movimiento, Transaccion, Abono, Retiro
	Crear y probar los métodos en postman
7. Creamos un nuevo proyecto MVC dentro de nuestra solución (para separar frontend de backend)

8. Creamos controller para la ruta a la app del banco (BankController)

9. Creamos los modelos y copiamos el código (atributos) de los ApiModels (Backend)

10. En el controller creamos la vista Index para colocar la lista de cuentas

11. Para consumir Request HTTP instalamos WebApiClient 
	Click derecho en proyecto
	Manage NuGet Packages
		instalamos Microsoft.AspNet.WebApi.Client

12. Creamos la clase que servirá de objeto HTTP, debemos instanciarlo para evitar errores de socket. Se llama GlobalVariables

	public static HttpClient WebApiClient = new HttpClient();
	static GlobalVariables(){
		WebApiClient.BaseAddress = new Uri("htttp://localhost:____/api/");
		WebApiClient.DefaultRequestHeaders.Clear();
		WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	}

13. En el BankController crear los action result´s para cada View y Pantalla:
	Index
	NuevaCuenta
	Movimientos
	Transaccion
	Operacion

14. Para cada pantalla
	Index: Lista de cuentas
	NuevaCuenta: Formulario
	Movimientos: Lista de movimientos pasando un ID
	Transaccion: Formulario
	Operacion: Formulario
