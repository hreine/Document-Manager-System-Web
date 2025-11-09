# Resumen del Proyecto

Esta es una aplicación web .NET 4.0 llamada "dmsflex". Parece ser un Sistema de Gestión Documental con un frontend basado en Flex. El backend está construido con ASP.NET y C#, utilizando una arquitectura en capas.

## Tecnologías Principales

*   **Backend:** C# con .NET Framework 4.0
*   **Framework Web:** ASP.NET
*   **Comunicación Frontend:** FluorineFx para comunicación AMF (Action Message Format), lo que sugiere un frontend Adobe Flex/Flash.
*   **Base de Datos:** PostgreSQL
*   **ORM:** NHibernate con FluentNHibernate para los mapeos.
*   **Arquitectura:** El proyecto está estructurado en varias capas:
    *   `dmsflex`: El proyecto principal de la aplicación web.
    *   `amf3service`: Expone servicios al frontend de Flex utilizando FluorineFx.
    *   `BLL`: Capa de Lógica de Negocio (Business Logic Layer).
    *   `Dao`: Capa de Acceso a Datos (Data Access Object), responsable de las interacciones con la base de datos utilizando NHibernate.
    *   `DAL`: Otra capa de acceso a datos, posiblemente para un propósito diferente o un remanente de una implementación anterior.
    *   `ConsoleTest`: Una aplicación de consola para pruebas.

## Construcción y Ejecución

Para construir y ejecutar este proyecto, necesitarás:

*   Visual Studio 2012 o posterior.
*   .NET Framework 4.0.
*   Una instancia de base de datos PostgreSQL.

1.  **Configuración de la Base de Datos:**
    *   Crea una base de datos PostgreSQL llamada `simes`.
    *   La cadena de conexión en `dmsflex/Web.config` está configurada para conectarse a `Server=localhost;Port=5432;User Id=postgres;Password=root;Database=simes;`. Es posible que necesites actualizar las credenciales.

2.  **Construir la Solución:**
    *   Abre el archivo `dmsflex.sln` en Visual Studio.
    *   Construye la solución. Esto debería restaurar los paquetes NuGet listados en el directorio `packages`.

3.  **Ejecutar la Aplicación:**
    *   Establece el proyecto `dmsflex` como proyecto de inicio.
    *   Ejecuta la aplicación desde Visual Studio. Esto iniciará la aplicación web en un servidor de desarrollo local.

## Convenciones de Desarrollo

*   El proyecto sigue una arquitectura en capas, separando las responsabilidades en presentación, lógica de negocio y acceso a datos.
*   La Capa de Acceso a Datos utiliza los patrones Repository y Unit of Work con NHibernate.
*   La lógica de negocio está encapsulada en el proyecto BLL.
*   Los servicios para el frontend de Flex se definen en el proyecto `amf3service` y se marcan con el atributo `[RemotingService]`.
*   El hash de contraseñas se realiza utilizando SHA512.