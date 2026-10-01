## ¿Por qué una List<Producto> puede contener objetos de tipo Bebida, Postre, PlatoPrincipal o Entrante?
Es posible almacenar estas clases debido al polimorfismo y a la herencia. En este caso al ser Postre, Entrante... clases
que heredan de la clase padre Producto es posible almacenarlas en una lista de tipo Producto.

## ¿Qué relación existe entre estas clases y Producto?
La clase Producto es la clase padre de las clases Entrante, Bebida, Plato Principal... de esta forma, por ejemplo, Bebida es un Producto.

# Filtrado por tipo
## ¿Qué tipo tiene la variable utilizada para recorrer la List<Producto>?
Es una variable de tipo Producto.

## ¿Puede esa variable contener un objeto cuyo tipo real sea Bebida?
Sí, esto se debe a la herencia y al polimorfismo. La clase Bebida hereda de la clase padre Producto, por lo que es posible almacenar una Bebida en una lista de tipo Producto.

## ¿Qué permite comprobar el operador is?
Permite comprobar si el producto que se le está pasando en el if es una Bebida. En el caso de que lo sea se mostrará su información por pantalla.