# 96A9B28ECD799D20168D59D26C198FAADAAE0BC21C8541F1918150EFFA440C86
Repositorio para la solución de la prueba técnica de Resocentro
#### Leonardo Vargas

# Proyecto
Impresora Sci-Fi 3D de Materia
- Tecnología .NET Framework 5
- Entity Framework Core (EF) Code First
- IDE: Visual Studio 2019
- BD: SQL Server 14 (2017)

# Modelo de Base de Datos
- Los insumos que sirven de materiales para crear un item se encuentran referenciados a la misma tabla de Item por medio de la tabla Recetas.
- Las Órdenes de impresión contienen el ítem a imprimir, la impresora a utilizar y la solicitud a la que corresponde.
- Una solicitud puede tener varias órdenes por si los insumos no son suficientes y deben ser también creados. 
- Cada orden inicia en estado "Pendiente", esto actúa como Cola de Impresiones. Otros estados: "En Ejecución", "Finalizado".
- **Ojo:** es cola de items a imprimir y no cola de una impresora en específico (aunque puede sacarse este dato como consulta SQL). La idea es que si una Órden tiene que imprimir 1 ítem y 2 insumos, los insumos pueden imprimirse en distintas impresoras de forma paralela.

![image](https://user-images.githubusercontent.com/2180309/120215129-5e6fae80-c203-11eb-83d5-ca3070708153.png)

# Arquitectura
- Capa de Acceso a datos
- Capa de Lógica de Negocio
- Capa de API / UI Consola (para pruebas, se conecta directo a la capa de negocio)
- Paralelo entre las anteriores: capa de Entidades (Acá se encuentra el modelo y cualquier otra clase requerida)
![image](https://user-images.githubusercontent.com/2180309/120217838-e6a38300-c206-11eb-848c-6c4fa18300f0.png)


# Consulta de ítem a imprimir
- A partir de un **Item**, por medio de **Receta** se busca la disponibilidad de los **insumos**. Esto actúa recursivamente, si no hay suficientes insumos se debe revisar la receta de los insumos faltantes. La recursividad termina al llegar a un Insumo Base o si existen suficientes insumos.
- El resultado se almacena dentro de una Lista de la clase **ReporteVerificarImpresionItem** el cual sirve para sacar el reporte de ítema a imprimir (Capa de Entidades)
- Columnas (propiedades): NombreItem, NombreInsumo, CantidadNecesaria, CantidadExistente (del insumo), Se imprime? (si/no), CantidadAImprimir, Tiempo, Impresora

##### Ejemplo
- Al imprimir **Cola de fénix** con los datos iniciales de CSV. 
  - Solo se imprime el item debido a que existen todos los insumos
  - El tiempo total es de 120
  
![image](https://user-images.githubusercontent.com/2180309/120219108-b2c95d00-c208-11eb-8740-4bb865b4348a.png)

##### Ejemplo
- Ejemplo al imprimir **Cola de fénix** con escacés de **Pluma** y **Estus** (a cada uno les falta 1 de stock) 
  - La cantidad necesaria (cNe) de **pluma** es 5 pero solo existe 4 (cEx), por lo cual se debe imprimir (SeImp=true) la cantidad de 1 (cIm). Cada uno tarda 30 (Tmp), y se le puede asignar la Impresora 36 (ahora la impresora está libre, puede que al momento de imprimir ya no lo esté y se asigne otra impresora)
    - La recursividad entra en juego cuando se ve que tampoco hay **nitrogeno** para crear las plumas. Se requieren 4 más para imprimir (cIm).
  - Posteriormente falta **estus** para **cola de fenix** --> luego, falta **Proteina** para crear **estus**
  - Todo lo faltante de imprimir (SeImp=true) tiene asignado la cantidad de impresiones a realizar (cIm), su tiempo correspondiente y la impresora asignada.
  - El tiempo total si se usase una sola impresora es de 214, si se utilizacen impresiones en paralelo sería 120 de tiempo

![image](https://user-images.githubusercontent.com/2180309/120240056-aa374d80-c22d-11eb-8048-474b6192c1b7.png)

# Realizar Orden
- De igual forma, la realización de búsqueda de recetas es de manera recursiva
- La tabla que interactúa es **Ordenes** y se comportará como una Pila donde el primero en registrarse es el último en imprimirse
- Tomando el ejemplo anterior de **Cola de fénix**:
  - Se registra en estado **Pendiente** (quedando al fondo de la pila)
  - Como falta **Pluma**, también se registra como **Pendiente** (quedando en la pila)
  - Como falta **Nitrogeno** y es Base se inicia con esta impresión
  - La misma lógica de pila para **Estus** y **Proteina**
