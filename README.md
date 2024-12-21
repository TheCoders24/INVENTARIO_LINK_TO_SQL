# Sistema de Punto de Venta (POS) con Inventario usando LINQ to SQL

Este proyecto describe cómo desarrollar un **Sistema de Punto de Venta (POS)** con un módulo de inventario utilizando **LINQ to SQL** en **Visual Studio**. El sistema sigue una **arquitectura por capas**, separando las responsabilidades para mantener el código limpio y escalable.

## Arquitectura por Capas

### 1. Capa de Presentación (Interfaz de Usuario)
La capa de presentación es responsable de interactuar con el usuario, mostrar la información y capturar las entradas. Utilizaremos **Windows Forms** (o WPF, si prefieres).

**Responsabilidad**:
- Mostrar formularios de ventas, inventario, y reportes.
- Capturar entradas del usuario para realizar ventas o actualizar inventarios.

**Ejemplo de formularios**:
- `frmVentas` (Formulario de ventas)
- `frmInventario` (Formulario de inventario)
- `frmReportes` (Formulario de reportes)

### 2. Capa de Negocio
La capa de negocio maneja la lógica de negocio y la validación de operaciones, interactuando con la capa de datos para acceder y procesar la información.

**Responsabilidad**:
- Procesar datos relacionados con ventas, control de inventario, y generación de reportes.
- Lógica de negocio, como descuentos, validación de existencias, y totalización de ventas.

**Ejemplo de clases**:
- `VentasService` (Servicio para gestionar las ventas)
- `InventarioService` (Servicio para gestionar el inventario)
- `ReporteService` (Servicio para generar reportes)

### 3. Capa de Datos
La capa de datos es la encargada de interactuar directamente con la base de datos. Usaremos **LINQ to SQL** para mapear las tablas de la base de datos a clases en C#.

**Responsabilidad**:
- Acceder a la base de datos para obtener, insertar, actualizar o eliminar datos.
- Definir los modelos (tablas) y consultas que se ejecutan en la base de datos.

**Ejemplo de clases**:
- `Venta` (Entidad para ventas)
- `Producto` (Entidad para productos)
- `Inventario` (Entidad para inventarios)
- `Cliente` (Entidad para clientes)

### 4. Base de Datos
La base de datos almacena toda la información relacionada con las ventas, productos, inventarios, clientes, etc.

**Tecnologías**:
- **SQL Server** (o **MySQL**, si prefieres).

**Ejemplo de tablas**:
- `Ventas` (id, fecha, total, cliente_id, etc.)
- `Productos` (id, nombre, precio, cantidad, etc.)
- `Clientes` (id, nombre, teléfono, dirección, etc.)

## Pasos para el Desarrollo

### 1. Crear el Proyecto en Visual Studio
Abre Visual Studio y crea un nuevo proyecto de **Windows Forms** (o **WPF** si prefieres).

### 2. Agregar LINQ to SQL
- En la capa de datos, agrega un archivo de **LINQ to SQL**.
- Conéctate a tu base de datos y genera las clases que representarán tus tablas.

### 3. Crear la Capa de Negocio
- En esta capa, crea los servicios que interactuarán con el contexto de LINQ to SQL para realizar las operaciones de negocio (por ejemplo, realizar ventas, actualizar inventarios, etc.).

### 4. Crear la Capa de Presentación
- En esta capa, diseña las interfaces gráficas (formularios) de ventas, inventario, y otros formularios. Los eventos de los formularios (como hacer clic en el botón de "vender") llamarán a los métodos de la capa de negocio.

### 5. Interacción entre Capas
- La capa de presentación interactúa con la capa de negocio a través de métodos de servicio.
- La capa de negocio interactúa con la base de datos mediante el contexto de LINQ to SQL.
