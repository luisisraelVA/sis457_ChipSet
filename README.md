# 💻 LabChipSet: Sistema de Gestión de Componentes Informáticos

## 💡 Descripción del Negocio

**LabChipSet** es una aplicación diseñada para la gestión integral de un negocio de **hardware y componentes informáticos**. El sistema se centra en el **control de inventario**, la administración de **proveedores y clientes**, y el registro detallado de las **transacciones de venta (Pedidos)**. Su objetivo es optimizar la disponibilidad de stock, precios y la eficiencia en la facturación de ventas.

---

## 🏗️ Entidades Clave y Atributos

A continuación, se presentan las entidades principales del sistema con sus atributos clave.

### 1. Producto 🏷️
(Inventario y Stock)

* `id` (Clave Primaria)
* `idProveedor` (Clave Foránea)
* **`nombre`**
* **`descripcion`**
* **`precioVenta`**
* **`stock`**
* `usuarioRegistro`
* `estado`

### 2. Proveedor 🤝
(Empresas Suministradoras)

* `id` (Clave Primaria)
* **`nombre`**
* **`telefono`**
* `fechaRegistro`
* `estado`

### 3. Cliente 👤
(Compradores)

* `id` (Clave Primaria)
* **`nombre`**
* **`email`**
* **`telefono`**
* `estado`

### 4. Pedido 🛒
(Cabecera de la Transacción de Venta)

* `id` (Clave Primaria)
* `idCliente` (Clave Foránea)
* **`fechaPedido`**
* **`total`**
* `usuarioRegistro`
* `estado`

### 5. DetallePedido 📃
(Ítems de la Venta)

* `id` (Clave Primaria)
* `idPedido` (Clave Foránea)
* `idProducto` (Clave Foránea)
* **`cantidad`**
* **`precioUnitario`**
* `estado`

### 6. Usuario 🔐
(Autenticación de Empleados)

* `id` (Clave Primaria)
* **`usuario`**
* **`clave`** (Contraseña Hasheada)
* `usuarioRegistro`
* `estado`
