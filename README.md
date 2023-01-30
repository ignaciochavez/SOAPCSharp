# SOAPCSharp 🚀

El presente proyecto es un ejemplo de servicio SOAP con C#

## Tecnologias 📌

Visual studio 2015 .NET C#

.Net Framework 4.5.2

### Pre-requisitos 📋

Tener codigo fuente de solucion

Tener instalado Open Xml SDK 2.5 .msi (https://github.com/OfficeDev/Open-XML-SDK/releases/tag/v2.5)

Tener IIS instalado

Habilitar Sitio web IIS

### Instalación 🔧

Publicar solucion desde visual studio y mover compilado a carpeta que leera el IIS

Habilitar directorio y sitio web IIS

## Ejecutando las pruebas ⚙️

Ejecutar pruebas unitarias desde visual studio para verificar correcto funcionamiento

Una vez publicado el proyecto, abrir el sitio web IIS, redireccionar a la pagina index.html

Posteriormente presionar en el boton CheckService y verificar que el servicio se ejecute correctamente

Ejecutar metodos del servicio CheckService para verificar funcionalidad y autorizacion

Ejemplo de sitio inicial:
```
http://localhost:53462/index.html
```

## Construido con 🛠️

* [HtmlAgilityPack](https://html-agility-pack.net/) - Framework para el uso de HTML
* [Bootstrap](https://getbootstrap.com/) - Framework para el uso de bootstrap en el HTML

## Autores ✒️

* **Ignacio Chávez** - *Trabajo Inicial*
* **Ignacio Chávez** - *Documentación*

© Copyright IgnacioChávez, Todos Los Derechos Reservados