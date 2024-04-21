
# PruebaUCH_V1 API

## Descripción
PruebaUCH_V1 es una API REST desarrollada en .NET Core, diseñada para ser desplegada como una función AWS Lambda utilizando Amazon API Gateway para la gestión de propiedades inmobiliarias.

## Tecnologías Utilizadas
- .NET Core 8
- AWS Lambda
- AWS S3 Buckets
- Amazon API Gateway
- Entity Framework Core
- PostgreSQL

## Configuración del Entorno

### Pre-requisitos
- .NET SDK 8
- AWS CLI configurado con credenciales adecuadas
- PostgreSQL Database

### Instalación de Dependencias
Ejecuta el siguiente comando para instalar todas las dependencias necesarias:

```bash
dotnet restore
```

## Estructura del Proyecto
```
PruebaUCH_V1/
├── src/
│   ├── PruebaUCH_V1/
│   │   ├── Controllers/
│   │   ├── Enums/
│   │   ├── Interfaces/
│   │   ├── Models/
│   │   ├── Data/
│   │   ├── Migrations/
│   │   ├── Properties/
│   │   ├── Repositories/
│   │   └── Startup.cs
├── test/
│   └── PruebaUCH_V1.Tests/
└── PruebaUCH_V1.sln
```

### Descripción de Directorios
- `Controllers`: Contiene los controladores que gestionan las solicitudes API.
- `Models`: Define las entidades del modelo de datos.
- `Data`: Incluye el contexto de Entity Framework para la interacción con la base de datos.
- `Migrations`: Contiene las migraciones de Entity Framework.
- `test`: Tests unitarios y de integración para la aplicación.

## Configuración de Aplicación, Entorno y Despliegue

### Entorno

- Configuración de `appsettings.json`: Este archivo contiene configuraciones generales y específicas del entorno de producción.
	```
	{
	"Logging": {
		"LogLevel": {
		"Default": "Information"
		}
	},
	"ConnectionStrings": {
		"DefaultConnection": "Tu cadena de conexión a la base de datos aquí"
	}
	}
	```

Nota: Reemplaza "Tu cadena de conexión a la base de datos aquí" con tu cadena de conexión real en tu entorno de producción, pero asegúrate de no subir esta información a repositorios públicos para mantener la seguridad.

- Configuración de `appsettings.Development.json`: Este archivo sobrescribe algunas configuraciones para el entorno de desarrollo, asegurando que se utilicen configuraciones específicas para este entorno.

	```
	{
	"AWS": {
		"Region": "Especifica la región de AWS aquí"
	}
	}
	```

Nota: Asegúrate de especificar la región adecuada de AWS para tu aplicación en desarrollo.

### Local

- Para ejecutar el proyecto localmente, utiliza el siguiente comando en el directorio `src/PruebaUCH_V1`:

	```bash
	dotnet run
	```

### AWS
Para desplegar en AWS Lambda y API Gateway, sigue estos pasos:

1. Crear un Bucket en S3 de AWS.

	aws s3 mb s3://uch-bucket-2024 --region (region en la cual se encuentra en mi caso "us-west-2")

	```bash
	aws s3 mb s3://uch-bucket-2024 --region us-west-2
	```

2. Verificar la creación del Bucket.

	```bash
	aws s3 ls
	```

	Salida: 2024-04-20 11:46:22 uch-bucket-2024

3. Configura el archivo `aws-lambda-tools-defaults.json`.
4. Una vez configurado el archivo `aws-lambda-tools-defaults.json` ejecuta:

	```bash
	dotnet lambda deploy-serverless
	```

5. El comando le pedirá algunos datos para poder completar el despliegue.

	```bash
	Enter CloudFormation Stack Name: (CloudFormation stack name for an AWS Serverless application)
	PruebaUCHV1Stack
	Enter S3 Bucket: (S3 bucket to upload the build output)
	uch-bucket-2024
	```

6. Con estos datos podrá desplegar el Lambda y estará configurado para utilizar los Endpoints.

## Uso de la API

### Endpoints Disponibles
- `GET /api/Properties`: Retorna todas las propiedades.
- `GET /api/Properties/{id}`: Retorna una propiedad por ID.
- `POST /api/Properties`: Crea una nueva propiedad.
- `PUT /api/Properties/{id}`: Actualiza una propiedad existente.
- `DELETE /api/Properties/{id}`: Elimina una propiedad.

### Ejemplo de solicitud
```bash
curl -X GET https://msd2gkmlp0.execute-api.us-west-2.amazonaws.com/Prod/api/Properties
```

## Migraciones de Base de Datos
Para aplicar las migraciones a la base de datos, utiliza:

```bash
dotnet ef database update
```

## Pruebas
Para ejecutar las pruebas unitarias, navega al directorio `test/PruebaUCH_V1.Tests` y ejecuta:

```bash
dotnet test
```

## Contacto y Soporte
Para soporte técnico o contactar al desarrollador, envía un correo a [rdipaolaj@outlook.com](mailto:rdipaolaj@outlook.com).
