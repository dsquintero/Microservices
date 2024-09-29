# Prueba Técnica: Desarrollo de Microservicios para Gestión de Citas Médicas

## Descripción General
Este sistema está compuesto por tres microservicios independientes que están interconectados para gestionar una aplicación de citas médicas. Los microservicios son:

1. **Microservicio de Personas**: Gestiona la información de las personas involucradas (Médicos y Pacientes).
2. **Microservicio de Citas**: Gestiona la creación y administración de las citas médicas.
3. **Microservicio de Recetas**: Gestiona las recetas médicas asociadas a las citas, incluyendo los medicamentos prescritos.

Cada microservicio tiene operaciones CRUD completas (Crear, Leer, Actualizar y Eliminar) para gestionar sus respectivas entidades.

## Estructura del Proyecto

### Microservicios

1. **PersonasMicroservice**: 
   - Endpoints para la gestión de las personas (Médicos y Pacientes).
   - Uso de DTOs para transferencia de datos y asegurar la separación de las capas.
   - Implementación de servicios para las operaciones de negocio.
   
2. **CitasMicroservice**:
   - Endpoints para la gestión de citas médicas.
   - Cada cita está asociada con un médico y un paciente.
   
3. **RecetasMicroservice**:
   - Endpoints para la gestión de recetas médicas.
   - Las recetas están asociadas a las citas y pueden contener múltiples medicamentos.

### Tecnologías Utilizadas

- **.NET Framework 4.8**
- **Web API**
- **Entity Framework**: Para acceso a datos y mapeo objeto-relacional (ORM).
- **AutoMapper**: Para la conversión entre entidades y DTOs.
- **Simple Injector**: Inyección de dependencias para la gestión de servicios.
- **SQL Server**: Base de datos relacional.
  
## Instrucciones para Ejecutar

### Pre-requisitos

1. **Visual Studio 2022** o cualquier otro IDE compatible con .NET Framework 4.8.
2. **SQL Server** para la persistencia de datos.
3. **Postman** u otra herramienta para probar los endpoints de las APIs.

### Pasos para Configurar y Ejecutar

1. **Clonar el repositorio**: Clona el repositorio que contiene los tres microservicios.

```
https://github.com/dsquintero/Microservices.git
```

2. **Configurar la base de datos**:

- Actualiza las cadenas de conexión a la base de datos en el archivo Web.config de cada microservicio.
- Ejecuta las migraciones de base de datos con Entity Framework para generar las tablas necesarias.

```
Update-Database
```

3. **Construir y ejecutar los microservicios**:

- Abre la solución en Visual Studio.
- Asegúrate de que cada proyecto de microservicio esté configurado para iniciar correctamente.
- Ejecuta la solución para que los microservicios inicien.

4. **Probar los endpoints**:

- Utiliza Postman u otra herramienta para realizar solicitudes HTTP a los microservicios.

- Por ejemplo, para obtener una lista de personas:

```
GET http://localhost:5000/api/Personas
```

- Los detalles de los endpoints para cada microservicio se encuentran en la sección "Documentación de API" a continuación.

### Documentación de API

#### Microservicio de Personas

| Método | Ruta                           | Descripción                              |
|--------|--------------------------------|------------------------------------------|
| GET    | `/api/Personas`                | Obtener todas las personas               |
| GET    | `/api/Personas/{id}`           | Obtener persona por ID                   |
| POST   | `/api/Personas/{idTipoPersona}`| Crear una nueva persona                  |
| PUT    | `/api/Personas/{id}`           | Actualizar una persona                   |
| DELETE | `/api/Personas/{id}`           | Eliminar una persona                     |

#### Microservicio de Citas

| Método | Ruta                           | Descripción                              |
|--------|--------------------------------|------------------------------------------|
| GET    | `/api/Citas/{id}`              | Obtener una cita por ID                  |
| POST   | `/api/Citas`                   | Crear una nueva cita                     |
| PUT    | `/api/Citas/{id}`              | Actualizar una cita                      |
| DELETE | `/api/Citas/{id}`              | Eliminar una cita                        |

#### Microservicio de Recetas

| Método | Ruta                           | Descripción                              |
|--------|--------------------------------|------------------------------------------|
| GET    | `/api/Recetas/{id}`            | Obtener una receta por ID                |
| POST   | `/api/Recetas`                 | Crear una nueva receta                   |
| PUT    | `/api/Recetas/{id}`            | Actualizar una receta                    |
| DELETE | `/api/Recetas/{id}`            | Eliminar una receta                      |


### Detalles Adicionales
- **Filtros de Excepciones**: Los microservicios están configurados para manejar excepciones globalmente a través de filtros de excepciones personalizados.
- **DTOs**: Se utilizan para evitar exponer directamente las entidades del modelo a través de las APIs.
- Validaciones: Existen validaciones en los controladores para asegurar que los datos sean válidos antes de ejecutar las operaciones de negocio.

### Contacto
Si tienes alguna duda o pregunta sobre esta prueba técnica, por favor contacta a:

- **Nombre**: [Daniel Quintero]
- **Email**: dquintero.ing@gmail.com
- **GitHub**: https://github.com/dsquintero

Estaré disponible para responder cualquier consulta o proporcionar aclaraciones adicionales.