# DMSflex - Sistema de Gestión Documental

[![Estado de la Compilación](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://shields.io/)
[![Versión](https://img.shields.io/badge/version-1.0.0-blue.svg)](https://shields.io/)
[![Licencia](https://img.shields.io/badge/license-MIT-green.svg)](https://opensource.org/licenses/MIT)

**DMSflex** es una solución robusta para la gestión documental, diseñada para ofrecer una experiencia de usuario fluida y eficiente. Construido sobre una base de tecnologías .NET y Adobe Flex, este sistema proporciona una plataforma centralizada para la administración, seguimiento y consulta de documentos.

## ✨ Características Principales

*   **Arquitectura en Capas:** Separación clara de responsabilidades entre la presentación, la lógica de negocio y el acceso a datos, lo que facilita el mantenimiento y la escalabilidad.
*   **Comunicación Eficiente:** Utiliza FluorineFx para una comunicación de alto rendimiento entre el backend .NET y el frontend Adobe Flex a través del protocolo AMF.
*   **Acceso a Datos Robusto:** Emplea NHibernate como ORM para una interacción flexible y potente con la base de datos PostgreSQL.
*   **Seguridad:** Implementa autenticación de formularios y hashing de contraseñas con SHA512 para proteger la información del usuario.
*   **Gestión Centralizada:** Ofrece una interfaz de usuario intuitiva para la gestión de documentos, usuarios y otros datos maestros del sistema.

## 🚀 Empezando

Sigue estas instrucciones para configurar el entorno de desarrollo y ejecutar el proyecto en tu máquina local.

### Prerrequisitos

*   **Visual Studio:** Se recomienda Visual Studio 2012 o una versión posterior.
*   **.NET Framework:** Versión 4.0.
*   **Base de Datos:** Una instancia de PostgreSQL.

### Instalación

1.  **Clona el Repositorio:**
    ```bash
    git clone https://github.com/tu-usuario/dmsflex.git
    cd dmsflex
    ```

2.  **Configuración de la Base de Datos:**
    *   Asegúrate de que tu instancia de PostgreSQL esté en funcionamiento.
    *   Crea una nueva base de datos llamada `simes`.
    *   Abre el archivo `dmsflex/Web.config` y actualiza la cadena de conexión `simesstr` con tus credenciales de PostgreSQL si es necesario. La configuración por defecto es:
        ```xml
        <add name="simesstr" connectionString="Server=localhost;Port=5432;User Id=postgres;Password=root;Database=simes;" providerName="Npgsql" />
        ```

3.  **Construye la Solución:**
    *   Abre el archivo `dmsflex.sln` con Visual Studio.
    *   Visual Studio restaurará automáticamente los paquetes NuGet necesarios.
    *   Construye la solución (Build > Build Solution) para compilar todos los proyectos.

4.  **Ejecuta la Aplicación:**
    *   En el "Solution Explorer", haz clic derecho en el proyecto `dmsflex` y selecciona "Set as StartUp Project".
    *   Presiona `F5` o haz clic en el botón "Start" para iniciar la aplicación. Esto abrirá el sitio web en tu navegador por defecto.

## 🏗️ Arquitectura del Proyecto

El proyecto está diseñado siguiendo una arquitectura multicapa para promover un código limpio y mantenible.

*   `dmsflex`: El proyecto principal de la aplicación web ASP.NET. Contiene las páginas, las vistas y la configuración principal. Es el punto de entrada de la aplicación.
*   `amf3service`: Actúa como una capa de servicio que expone la lógica de negocio al cliente de Adobe Flex. Las clases en este proyecto están decoradas con el atributo `[RemotingService]` de FluorineFx.
*   `BLL` (Business Logic Layer): Contiene la lógica de negocio principal de la aplicación. Orquesta las operaciones y valida los datos antes de pasarlos a la capa de acceso a datos.
*   `Dao` (Data Access Object): Responsable de la persistencia y recuperación de datos. Utiliza NHibernate y FluentNHibernate para mapear los objetos de C# a las tablas de la base de datos.
*   `DAL` (Data Access Layer): Una capa de acceso a datos adicional. Podría ser una implementación anterior o utilizada para un propósito específico que difiere del `Dao` principal.
*   `ConsoleTest`: Una aplicación de consola utilizada para realizar pruebas y depurar funcionalidades de forma aislada.

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir a este proyecto, por favor, sigue estos pasos:

1.  Haz un fork del repositorio.
2.  Crea una nueva rama para tu feature (`git checkout -b feature/nueva-caracteristica`).
3.  Realiza tus cambios y haz commit (`git commit -am 'Añade nueva característica'`).
4.  Haz push a la rama (`git push origin feature/nueva-caracteristica`).
5.  Crea un nuevo Pull Request.

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Enlaces de Videos de su funcionamiento

https://youtu.be/t8eIc9wjXcg
https://youtu.be/gdFTfAXycXM
https://youtu.be/N-R_H_yuDIU
https://youtu.be/M6of8gN-xKE
https://youtu.be/HmFam_de_RM
https://youtu.be/B3CbBjlUj0E
https://youtu.be/eb3EWie5sYU
https://youtu.be/CBVxo_tmAVo



