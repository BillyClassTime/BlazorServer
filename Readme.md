# Desarrollo de una aplicación Blazor desde cero



1. **Define la estructura de tu aplicación**: Decide qué páginas o componentes necesitarás y cómo se relacionarán entre sí. Crea archivos `.razor` para cada uno de estos componentes en la carpeta `Pages` o `Shared` según corresponda.
2. **Crea tus componentes**: En cada archivo `.razor`, define el marcado HTML y la lógica de tu componente. Puedes usar la sintaxis de Razor para crear componentes interactivos.
3. **Establece las rutas**: En Blazor, las rutas a los componentes se definen con la directiva `@page`. Asegúrate de que cada componente en la carpeta `Pages` tenga una directiva `@page` con la ruta que deseas.
4. **Crea un Layout**: Si tu aplicación va a tener una apariencia común en todas las páginas, como una barra de navegación o un pie de página, considera crear un Layout. Puedes hacer esto en la carpeta `Shared`, y luego referenciar este Layout en `_Imports.razor`.
5. **Añade estilos**: Puedes añadir estilos globales en `wwwroot/css/site.css`. Si estás usando Bootstrap, puedes personalizarlo según tus necesidades. El fichero que viene por defecto personaliza los siguientes puntos:
   1. `@import url('open-iconic/font/css/open-iconic-bootstrap.min.css');`: Importa los estilos de la biblioteca de iconos Open Iconic.
   2. `html, body { font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; }`: Establece la fuente por defecto para todo el documento.
   3. `h1:focus { outline: none; }`: Elimina el contorno que se muestra cuando un encabezado `h1` está enfocado.
   4. `a, .btn-link { color: #0071c1; }`: Cambia el color de los enlaces y los botones con la clase `.btn-link` a un tono de azul.
   5. `.btn-primary { color: #fff; background-color: #1b6ec2; border-color: #1861ac; }`: Personaliza el color de texto, fondo y borde de los botones con la clase `.btn-primary`.
   6. `.btn:focus, .btn:active:focus, .btn-link.nav-link:focus, .form-control:focus, .form-check-input:focus { box-shadow: 0 0 0 0.1rem white, 0 0 0 0.25rem #258cfb; }`: Añade un efecto de sombra a varios elementos cuando están enfocados.
   7. `.content { padding-top: 1.1rem; }`: Añade un padding superior a los elementos con la clase `.content`.
   8. `.valid.modified:not([type=checkbox]) { outline: 1px solid #26b050; }`: Añade un contorno verde a los elementos válidos que han sido modificados, excepto los checkboxes.
   9. `.invalid { outline: 1px solid red; }`: Añade un contorno rojo a los elementos inválidos.
   10. `.validation-message { color: red; }`: Cambia el color de los mensajes de validación a rojo.
   11. `#blazor-error-ui { ... }` y `#blazor-error-ui .dismiss { ... }`: Personaliza la apariencia de la interfaz de error de Blazor y el botón para descartarla.
   12. `.blazor-error-boundary { ... }` y `.blazor-error-boundary::after { ... }`: Personaliza la apariencia de los mensajes de error de Blazor.
6. **Crea servicios**: Si tu aplicación necesita interactuar con una base de datos o con una API, puedes crear servicios para manejar estas interacciones. Estos servicios pueden inyectarse en tus componentes donde sean necesarios.
7. **Prueba tu aplicación**: Asegúrate de probar tu aplicación a medida que la desarrollas. Puedes hacer esto ejecutando la aplicación y navegando a través de ella en tu navegador.
8. **Publica tu aplicación**: Una vez que estés satisfecho con tu aplicación, puedes publicarla. En Visual Studio, puedes hacer esto usando la opción "Publish" en el menú "Build".



### Entendiendo `_Host.cshtml`

`_Host.cshtml` es donde tenemos el <html><body></body></html> que incluye en `App` para que todas las siguientes páginas rendericen alli. (Y se conversve un estilo único en toda la web app),

 `Shared\MainLayout.razor` y en `Shared\NavMenu.razor` se enlazan con `_Host.cshtml` asi:

```html
<!-- Navigation-->
<nav class="navbar navbar-expand-lg navbar-light fixed-top py-1" id="mainNav">
    <div class="container px-4 px-lg-5">
       <!-- Oculto para brevedad -->
    </div>
</nav>

<!-- Masthead-->
    <header class="masthead">
        <div class="container px-4 px-lg-5 h-100">
            <div class="row gx-4 gx-lg-5 h-100 align-items-center justify-content-center text-center">
               <!-- Oculto para brevedad -->
            </div>
        </div>
    </header>
    <!-- About-->
    <section class="page-section" id="about">
        <div class="container ">
            <!-- Primera fila -->
            <div class="row py-5">
                <div class="col-md-6 animated fadeInLeft">
                        <!-- Oculto para brevedad -->
                </div>
                <div class="col-md-6 animated fadeInRight">
					    <!-- Oculto para brevedad -->
                </div>
            </div>
        </div>    
    </section>
    <section class="page-section second-row" id="about2">
        <div class="container">
               <!-- Oculto para brevedad -->
        </div>
    </section>
    <!-- Call to action-->
    <section class="page-section masthead text-white">
        <div class="container px-4 px-lg-5 text-center">    
           <!-- Oculto para brevedad -->
        </div>
    </section>
    </div>
    <!-- Services-->
    <section class="page-section" id="services">
        <div class="container px-4 px-lg-5">
         <!-- Oculto para brevedad -->
        </div>
    </section>
    <!-- Precios-->
    <section class="bg-light py-5 border-bottom" id="prices">
        <div class="container px-5 my-5">
             <!-- Oculto para brevedad -->
        </div>
    </section>

    <section id="accent" class="accent-section">
        <div class="container">
             <!-- Oculto para brevedad -->
        </div>
    </section>
	<!-- Basic features section-->
    <section class="bg-light about" id="about_us">
        <div class="container px-5">
             <!-- Oculto para brevedad -->
        </div>
    </section>
   <!-- Contact-->
    <section class="page-section masthead" id="contact">
        <div class="container px-4 px-lg-5">
          <!-- Oculto para brevedad -->
        </div>
    </section>
   <footer class="footer bg-light">
        <div class="container">
            <div class="row">
        		<!-- Oculto para brevedad -->
   		    </div>
       </div>
   </footer>

```

### NavBar

```html
<ul class="navbar-nav ms-auto my-2 my-lg-0">
<li class="nav-item"><a class="nav-link" href="#about">Que es Domótica Brotons</a></li>
    <li class="nav-item"><a class="nav-link" href="#services">Servicios</a></li>
    <li class="nav-item"><a class="nav-link" href="#prices">Precios</a></li>
    <li class="nav-item"><a class="nav-link" href="#about_us">Sobre Nosotros</a></li>
    <li class="nav-item"><a class="nav-link" href="#contact">Contacto</a></li>
 </ul>
```

```html
<li class="nav-item"><a class="nav-link" href="#domoticaDigitalHome">Domotica para el hogar digital</a></li>
<li class="nav-item"><a class="nav-link" href="#servicios">Servicios</a></li>
<li class="nav-item"><a class="nav-link" href="#precios">Precios</a></li>
<li class="nav-item"><a class="nav-link" href="#quienesSomos">¿Quiénes Somos?</a></li>
<li class="nav-item"><a class="nav-link" href="#contacto">Contacto</a></li>
```

### Index.razor

```html
@page "/"
<PageTitle>Brotons Domótica</PageTitle>
<Masthead/ > <!-- Domótica para el hogar digital id=domoticaDigitalHome-->
<About /> <!-- Domotica id=domotica-->
<SegundaFila /> <!-- Inmótica id=inmotica -->
<CallToAction /> <!-- ventajas de un hogar domotizado id=ventajas-->
<Services /> <!-- ¿Que ofrece domotica brotons? -->
<Precios /> <!-- Precios paquetes orientativos -->
<EsquemaContratacion /> <!-- Esquema Contratacion -->
<BasicFeaturesSection /> <!-- ¿Quienes somos -->
<Contact /><!-- contacto -->
```

```html
@page "/"
<PageTitle>Brotons Domótica</PageTitle>
<DomoticaDigitalHome />
<Domotica />
<Inmotica />
<Ventajas />
<Services />
<Precios />
<EsquemaContratacion />
<QuienesSomos />
<Contact />
```

# footer better

```c#
output.Content.SetHtmlContent($" via build {appVersionInfo.BuildNumber}");
			output.Content.SetHtmlContent($"< a href = 'https://dev.azure.com/BillyClassTime/BillyClassTimeBlog/_build/results?buildId={appVersionInfo.BuildId} &view=results' > {appVersionInfo.BuildNumber} </ a >");
```

## Refactorizar para cumplimiento SOLID

Se ha detectado que la mayor lógica de negocio la lleva el componente `Contact.razor` pues recibe los dato para contactar, se valida, se realiza un `Captcha`y se envía el correo de confirmación y de almacenamiento de la solicitud.

Plan para mejorar la organización y cumplir SOLID:

- [x] **Separar la lógica de negocio**: Extraer la lógica de captcha y envío de correo a servicios independientes.
- [x] **Crear un servicio de Captcha**: Encapsular la generación y validación del captcha.
- [x] **Crear un ViewModel**: Usar un modelo para el formulario y delegar la validación.
- [x] **Mantener el componente Razor solo para UI y coordinación**.

## Deployment to Azure

1 - Publicar una versión de release:

```powershell
dotnet publish --configuration Release --output ./publish
```

2 - Empaquetar la publicación

```powershell
cd publish
zip -r ../publish.zip .
o 
Compress-Archive -Path ./publish/* -DestinationPath ./publish.zip
```

3 - Conectar con Azure

```powershell
az login
```

4 - Desplegar en un `App Service` y `Resource Group` existente

```powershell
az webapp deployment source config-zip --resource-group SpainRG --name bmspa2024 --src ./publish.zip

o 

az webapp deploy --resource-group SpainRG --name bmspa2024 --src-path ./publish.zip
```

