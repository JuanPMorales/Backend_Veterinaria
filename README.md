
# Veterinaria.API

## Descripción

Veterinaria.API es una API REST desarrollada con ASP.NET Core 8.0 y Entity Framework Core 9.0.5, diseñada para gestionar la información de una clínica veterinaria. Permite administrar entidades como Productos, Servicios, Clientes, Mascotas, Citas y la relación entre Citas y Productos.

La API incluye controladores completos para operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre estas entidades, facilitando su integración con aplicaciones front-end o sistemas externos.

---

## Tecnologías Utilizadas

- .NET 8.0  
- Entity Framework Core 9.0.5  
- SQL Server  
- ASP.NET Core Web API  
- Swashbuckle (Swagger) para documentación de API

---

## Funcionalidades Implementadas

- Endpoints RESTful para entidades principales: Productos, Servicios, Clientes, Mascotas, Citas y CitaProductos.  
- Implementación de relaciones entre entidades con navegación y claves foráneas.  
- Manejo de concurrencia en operaciones de actualización.  
- Inclusión de datos relacionados (Include) en consultas para facilitar el consumo de la API.  
- Controladores con métodos GET, POST, PUT y DELETE para cada entidad.

---

## Configuración de la Conexión a Base de Datos

La cadena de conexión a la base de datos SQL Server se define en el archivo `appsettings.json` de la siguiente forma:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS01;Database=MascotasForeverDB;Trusted_Connection=True;Encrypt=False;"
}
```

### Explicación sobre el doble backslash (`\\`)

En la cadena de conexión, la doble barra invertida (`\\`) se usa para escapar el carácter `\`, que en C# y JSON es un carácter especial de escape (por ejemplo, `\n` para salto de línea). 

Esto es necesario porque la barra invertida indica la instancia del servidor SQL (en este caso, `SQLEXPRESS01`), y para que sea interpretada literalmente debe duplicarse. Si se usa solo una barra (`\`), el compilador o el parser de JSON lo interpretará como el inicio de un carácter especial, causando error.

---

## Cómo Ejecutar el Proyecto

1. Clonar el repositorio.  
2. Configurar la cadena de conexión en `appsettings.json` según el entorno local.  
3. Ejecutar las migraciones para crear la base de datos con los siguientes comandos:

```bash
Add-Migration InitialCreate
Update-Database
```

4. Ejecutar la API:

```bash
dotnet run
```

5. Acceder a la API en `https://localhost:5001/api` o el puerto configurado.

---

## Notas Adicionales

- Se manejaron problemas con la conexión SSL a SQL Server configurando correctamente la confianza del certificado.  
- El modelo `CitaProducto` gestiona la relación muchos a muchos entre Citas y Productos.  
- Se recomienda validar permisos y estado del servicio de SQL Server antes de correr las migraciones.

---
