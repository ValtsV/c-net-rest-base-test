#Curso APIs con C# .Net de OpenBootcamp

### Enunciado del ejercicio Video 2
Replica el proyecto completo .Net 6 visto en el vídeo

Asegúrate de crear las migraciones y actualizar la base de datos

Asegúrate de crear correctamente el diagrama del modelo de EntityFramework

Crea una clase llamada Curso que debe tener:

Nombre (máximo

Descripción Corta (máximo 280 caracteres)

Descripción larga

Público Objetivo

Objetivos

Requisitos

Nivel (solo puede ser Básico, Intermedio o Avanzado para ello usa un enumerado)

### Enunciado del ejercicio video 3
Replica el proyecto completo .Net 6 visto en el vídeo

Asegúrate de crear correctamente el diagrama del modelo de EntityFramework

Asegúrate de crear las migraciones y actualizar la base de datos

Establece relaciones entre:

Usuarios y BaseEntit

Actualiza la base de datos

Crea los controllers necesarios para cada modelo

Realiza pruebas desde Swagger para todas las peticiones CRUD de cada controller y asegúrate de su buen funcionamiento.
### Enunciado del ejercicio video 4
Replica los ejemplos vistos en la sesión en un proyecto aparte

Asegúrate de entender todos los ejemplos

Usando las clases de los modelos que venimos usando en proyectos actuales, crea funciones en una clase llamada “Services.cs” que exponga métodos que sirvan para:

Buscar usuarios por email

Buscar alumnos mayores de edad

Buscar alumnos que tengan al menos un curso

Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito

Buscar cursos de un nivel determinado que sean de una categoría determinada

Buscar cursos sin alumnos
### Enunciado del ejercicio video 5
Replica los ejemplos vistos en la sesión en un proyecto aparte

Asegúrate de entender todos los ejemplos de consultas

Asegúrate de entender la funcionalidad de los servicios

Habilita CORS y asegúrate de que la aplicación sigue funcionando correctamente

Crea interfaces para los servicios de modelos y aplícalos en controladores

Crea rutas para:

Obtener todos los Cursos de una categoría concreta

Obtener todos los alumnos que no tienen cursos asociados

Obtener Cursos sin temarios

Obtener temario de un curso concreto

Obtener alumnos de un Curso concreto

Obtener los Cursos de un Alumno
### Enunciado del ejercicio video 6
Replica las configuraciones para trabajar con JWT

Asegúrate de entender las partes de un JWT

Asegúrate de entender la funcionalidad de cada clase

Asegúrate de entender el proceso de creación del JWT
### Enunciado del ejercicio video 7
Replica las configuraciones para trabajar con JWT

Asegúrate de entender el archivo que extiende los servicios del builder

Asegúrate de entender cómo se protegen las rutas

Asegúrate de entender cómo pasar el Bearer JWT Token por Swagger

Modifica el controller de Accounts para que:

Usando Linq, busque en la lista de usuarios del contexto de la base de datos

Verifique tanto el nombre como la contraseña del usuario

Obtenga la primera coincidencia

Actualiza el modelo de usuarios para segurar que tengan Roles

Administrador

Usuario

Gestiona las rutas de tu aplicación para que solo los administradores puedan:

Realizar operaciones de Modificación, Eliminación o Creación en tu proyecto
### Ejercicio video 8
Replica los cambios a la hora de solicitar el JWT vistos en la sesión

Asegúrate de entender cómo realizar consultas con LinQ al contexto de la aplicación

Crea peticiones todas las peticiones LinQ que creas convenientes para:

Estudiantes

Cursos

Usuarios

Replica el proyecto de ejemplo de internacionalización visto en clase

Asegúrate de entender cómo declarar y añadir localización a un proyecto .Net

Asegúrate de entender cómo indicar la carpeta donde se alojan los recursos de traducciones

Asegúrate de entender cómo añadir claves y valores a los archivos .resx

Asegúrate de entender cómo acceder a los valores de los archivos de traducciones

Asegúrate de entender cómo hacer solicitudes a la API para distintos idiomas desde Postman

Crea archivos de traducción para los mensajes de login de un usuario

Español, Inglés, Francés y Alemán

Cuando un usuario haga login, debe enviarse el Token y también un mensaje de bienvenida en el idioma escogido.
### Enunciado del ejercicio video 9
Replica lo visto en la sesión para crear dos versiones distintas de una misma API

Asegúrate de entender qué instalaciones son necesarias

Asegúrate de entender cómo documentar la versión en controladores y rutas

Asegúrate de entender el archivo de configuración y personalizaciónd e información de Swagger

Asegúrate de entender todas las configuraciones realizadas en Program.cs

Crea un nuevo proyecto desde cero de tipo API Restful

Utilizando la URL https://fakestoreapi.com/products

Plantea un DTO de Producto y otro de Rating para la versión 1 de tu API restful

Producto:

id (int)

title (string)

price (float)

description (string)

category (string)

image (string)

rating (Rating)

Rating:

rate (float)

count (int)

Plantea un DTO de Producto y otro de Rating para la versión 2 de tu API restful

Producto:

InternalId (Guid)

int id

title (string)

price (float)

description (string)

category (string)

image (string)

Crea dos controladores, uno para cada versión

Versión 1:

Que devuelva la lista de productos con sus respectivo rating

Versión 2:

Que devuelva la lsita de productos con un InternalID de tipo Guid nuevo para cada uno

Para ello, puedes usar Guid.NewGuid()

Asegúrate de documentar correctamente tu API y de que Swagger muestre ambas versiones para ser probadas
### Enunciado del ejercicio video 10
Replica lo visto en la sesión para crear logs de distintos niveles

Asegúrate de entender para qué sirven los logs

Asegúrate de entender de qué es Serilog y los distintos niveles de logs que existen

Asegúrate de entender la configuración de Serilog para almacenar logs en archivos de texto plano

Asegúrate de entender la configuración de Serilog para almacenar logs en tablas de la base de datos

Asegúrate de entender cómo persistir un log desde código en un controlador o un servicio

Asegúrate de entender cómo obtener los logs de la base de datos

Asegúrate de entender cómo persistir logs de EntityFramework y cómo filtrar aquellos que quieres persistir.

Crea logs para todos tus controllers y servicios de la aplicación y asegúrate de que se almacenan únicamente en la base de datos los logs de niveles: Warning, Error o Critical.
### Enunciado del ejercicio video 11
Replica lo visto en la sesión para crear operaciones asíncronas y entender las ventajas en tiempo de ejecución que ofrece

Asegúrate de entender qué es flujo síncrono y cómo se completan las tareas

Asegúrate de entender qué es flujo asíncrono y cómo se completan las tareas

Asegúrate de entender qué son las palabras async y await

Asegúrate de entender cómo se usa el tipo Task y cómo se obtiene su valor

Asegúrate de entender cómo puedes usar Stopwatch para analizar tiempos de ejecución

Analiza tu proyecto de tipo API restful University e identifica en los controladores y Servicios aquellas operaciones asíncronas

Introduce en la base de datos al menos:

20 alumnos

10 cursos

Realizar operaciones asíncronas en las búsquedas y filtrado de los diferentes modelos de tu aplicacción

Mide los tiempos de ejecución y comprueba si han mejorado usando procesos asíncronos.
.net restful api course code + exercises
