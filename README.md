# Prueba - backend k11

La solución completa contiene dos proyectos para la gestión de usuarios desde el lado del backend en C# .NetCore: 
-  Aplicación de consola TaskConsole
-  API Rest  

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgements](#acknowledgements)

## Introduction

La finalidad del proyecto es la gestión de usuarios para la persistencia en base de datos, por el momento se incluyen dos flujos, el primero desde la consola y el segundo el API. 

La consola se encargará de ejecutar una tarea programada que consuma la url [regres](https://reqres.in/api/users?page=1) para obtener usuarios y almacenarlos en una base de datos SQL server, proceso que se realiza de manera autónoma y en consulta por lotes. Por el otro lado, el proyecto API REST contiene los metodos mínimos para realizar CRUD basico de los usuarios. 

Se incluye un endpoint para la autenticación a modo de demo. 

## Features

- Integrar usuarios desde TaskConsole
- Crear Usuarios
- Consultar Usuarios
- Actualizar usuarios
- Autenticación (demo)

## Getting Started

- Clonar repositorio
- Actualizar dependecias y packetes NuGet
- Configurar conexión abase de datos desde el archivo appsettings.cs
- Crear migración de base de datos :
              add-migration [#nombre de la migración]
- Actualiza base de datos:
              update-database
- Configurar RestApi como proyecto de inicio
- Lanzar primero RestApi y luego ejecutar TaskConsole En una nueva instancia
  
## API Documentation

- Swagger
 
## Contributing

- Se incluye estructura base de autenticación por login a modo de ejemplo
- Se realiza separación por capas para el API. 

## License

## Acknowledgements

## ToDO 

- Refactorizar clases
- incluir manejo de errores
- Terminar sistema de autenticación
- incluir pruebas unitarias, integrales y e2e
- Agregar validaciones de campos.
- Crear archivo seed en caso de ser requerido para las migraciones. 

---
