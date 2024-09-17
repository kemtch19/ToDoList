# To-Do List Application

## Descripción

Este es un proyecto de aplicación **To-Do List** que permite a los usuarios crear, leer, actualizar y eliminar tareas. La aplicación está desarrollada en .NET con ASP.NET Core y MongoDB como base de datos. La aplicación soporta tareas principales y subtareas, con la posibilidad de marcar tareas como completadas, en proceso o pendientes, y realizar un **soft delete** de las mismas para tener persistencia de datos.

## Características

- Crear, leer, actualizar y eliminar (CRUD) tareas y subtareas.
- Gestión de subtareas dentro de tareas.
- **Soft delete**: las tareas no se eliminan de manera definitiva, permitiendo su recuperación.
- Búsqueda y filtrado de tareas por nombre.
- Actualización del estado de las tareas y subtareas (completadas, en proceso o pendientes).
- Interfaz web simple y fácil de usar.
  
## Requisitos Previos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (instalado y ejecutándose localmente o en la nube)
- [Node.js y npm](https://nodejs.org/en/) (opcional, como son endpoints se pueden consumir desde un front con otras tecnologías como lo pueden ser vue o angular)

## Instalación

Sigue estos pasos para configurar el entorno y ejecutar el proyecto localmente.

1. Clona este repositorio:
   ```bash
   git clone https://github.com/tuusuario/todolist-app.git
2. Accede a la carpeta del proyecto:
   ```bash
   cd todolist-app
3. Restaura las dependencias de .NET:
   ```bash
   dotnet restore
4. Configura tu conexión a MongoDB: Abre el archivo appsettings.json y actualiza la cadena de conexión de MongoDB con tu propia URL.
   {
    "ConnectionStrings": {
      "MongoDB": "mongodb://localhost:27017/todolist-db"
    }
  }
5. Ejecuta la aplicación:
   ```bash
   dotnet run
## Estructura del Proyecto
Este proyecto está organizado en varias carpetas clave:

- Controllers: Contiene los controladores de la API para gestionar las tareas y subtareas.
- Models: Contiene las clases que representan las entidades del proyecto (Tarea, SubTarea, etc.).
- Services: Contiene la lógica de negocio de la aplicación, incluyendo los repositorios para interactuar con MongoDB.
- Interfaces: Define las interfaces para los servicios, facilitando la inyección de dependencias.
- Repositories: Implementa las operaciones CRUD y el manejo de las tareas y subtareas con MongoDB (lógica fuerte del negocio).

## Endpoints de la API
Los endpoints que maneja esta API para la gestión de la to-do list son:

- ```GET /api/tasks```: Obtiene todas las tareas.
- ```POST /api/tasks```: Crea una nueva tarea.
- ```PUT /api/tasks/{id}```: Actualiza una tarea por su ID.
- ```PUT /api/tasks/{id}```: Cambia el estado de una tarea a true si es borrada (soft delete).

## Contribuir
Si deseas contribuir a este proyecto:

1. Haz un fork del repositorio.
2. Crea una rama con tu nueva característica (```git checkout -b feature/nueva-caracteristica```).
3. Realiza commit de tus cambios (```git commit -m 'Añadir nueva característica'```).
4. Haz push a tu rama (```git push origin feature/nueva-caracteristica```).
5. Abre un pull request.

## Licencia
Este proyecto está bajo la licencia MIT. Puedes ver más detalles en el archivo LICENSE.

## Apoyo
Para cualquier consulta o sugerencia, puedes enviarme una star que las estare mirando . 
