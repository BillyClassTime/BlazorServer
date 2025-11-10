# Desarrollo de una aplicación Blazor desde cero

Desde la idea inicial hasta ci/cd y despligue en Azure

| Pipeline                      | Estado                                                       |
| ----------------------------- | ------------------------------------------------------------ |
| **Integración Continua (CI)** |![](https://dev.azure.com/BillyClassTime/Brotons%20Domotica/_apis/build/status%2FBillyClassTime.BlazorServer?branchName=main)                                                 |
| **Entrega Continua (CD)**     | ![](https://vsrm.dev.azure.com/BillyClassTime/_apis/public/Release/badge/7d0a1726-0e57-4da9-8fcb-706cf8fafdfe/1/1) |

## 1. Estrategia preliminar

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



### 1.1 Entendiendo `_Host.cshtml`

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

### 1.2 NavBar

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

### 1.3 Index.razor

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

### 1.4 footer better

```c#
output.Content.SetHtmlContent($" via build {appVersionInfo.BuildNumber}");
			output.Content.SetHtmlContent($"< a href = 'https://dev.azure.com/BillyClassTime/BillyClassTimeBlog/_build/results?buildId={appVersionInfo.BuildId} &view=results' > {appVersionInfo.BuildNumber} </ a >");
```

## 2. Refactorizar para cumplimiento SOLID

Se ha detectado que la mayor lógica de negocio la lleva el componente `Contact.razor` pues recibe los dato para contactar, se valida, se realiza un `Captcha`y se envía el correo de confirmación y de almacenamiento de la solicitud.

Plan para mejorar la organización y cumplir SOLID:

- [x] **Separar la lógica de negocio**: Extraer la lógica de captcha y envío de correo a servicios independientes.
- [x] **Crear un servicio de Captcha**: Encapsular la generación y validación del captcha.
- [x] **Crear un ViewModel**: Usar un modelo para el formulario y delegar la validación.
- [x] **Mantener el componente Razor solo para UI y coordinación**.

## 3. Instrumentando la aplicación

Instrumentar la aplicación y cumplir con buenas prácticas en .NET 9 y C# 13.

Usamos el nuevo logging integrado en lugar de `Console.WriteLine`. Inyectamos `ILogger<Contact>` en los componente y registrar los mensajes con el nivel adecuado.

- Usar `Log.LogInformation` para eventos informativos y `Log.LogError` para errores.
- El tipo `ILogger<NOMBRECOMPONENTERAZOR>` se inyecta automáticamente por DI.
- El nombre del componente (`Contact`) debe coincidir con el nombre de tu clase Razor.

## 4. Plan de pruebas

Toda aplicación antes de dejar los entornos de desarrollo debe ser rigurosamente probada, con las herramientas modernas, podemos realizar nuestras **pruebas unitarias y de integración** para componentes Blazor, usando **bUnit** (unit tests de componentes), **xUnit** (unit tests generales) y **Playwright** (end-to-end UI tests). 

Estas pruebas deben ser el preambulo para definir la `CI/CD` antes del despliegue a pre-producción y producción.

1. **Pruebas unitarias (xUnit)**
   - Servicios (ej: Email, Captcha, lógica de negocio).
   - Modelos y validaciones.
2. **Pruebas de componentes (bUnit)**
   - Renderizado y comportamiento de cada página/componente (no solo Contact).
   - Interacción entre componentes.
3. **Pruebas end-to-end (Playwright)**
   - Flujos completos de usuario: navegación, interacción, envío de formularios, mensajes, etc.
   - Pruebas de accesibilidad y visuales.

### 4.1 Estructura de carpetas

```powershell
BlazorServer/
│
├── BlazorServer/        # Proyecto principal
├── BlazorServer.Tests/  # Proyecto de pruebas unitarias (xUnit, bUnit)
├── BlazorServer.E2E/    # Proyecto de pruebas end-to-end (Playwright)
```

### 4.2 Proyecto de pruebas unitarias y de componentes

**BlazorServer.Tests**

- Frameworks: `xUnit`, `bUnit`, `Moq` (para mocks)
- Pruebas de servicios, modelos y componentes

**Ejemplo de estructura interna:**

```powershell
BlazorServer.Tests/
│
├── Services/       # Pruebas de servicios (Captcha, Email, etc.)
├── Models/         # Pruebas de modelos y validaciones
├── Components/     # Pruebas de componentes Razor (Contact, Home, etc.)
│   └── ContactTests.cs
│   └── HomeTests.cs
│   └── ...
└── TestUtils/      # Utilidades y helpers para pruebas
```



### **4.2 Proyecto de pruebas end-to-end**

**BlazorServer.E2E**

- Framework: `Playwright`
- Pruebas de flujos completos de usuario, navegación, accesibilidad, etc.

**Ejemplo de estructura interna:**

```powershell
BlazorServer.E2E/
│
├── ContactFormTests.cs
├── NavigationTests.cs
├── AccessibilityTests.cs
└── ...
```

------

### **4.3 Configuración y dependencias**

- Agregar los siguientes paquetes NuGet:
  - `xunit`
  - `bunit`
  - `Moq`
  - `Microsoft.Playwright`
- Se configura los proyectos de prueba para que referencien el proyecto principal (`BlazorServer`).

#### 4.3.1 Creación de la estructura de proyectos

En la solución Blazor (`BlazorServer.sln`),  se añade dos proyectos nuevos:

```powershell
dotnet new xunit -n BlazorServer.Tests
dotnet new xunit -n BlazorServer.E2E   # aunque aquí usaremos Playwright, se puede usar xUnit también
```

Después, ajusta nombres para mantener la convención:

```powershell
mv BlazorServer.E2E BlazorServer.E2E/
```

Y se añade referencias al proyecto principal:

```powershell
dotnet add BlazorServer.Tests reference BlazorServer
dotnet add BlazorServer.E2E reference BlazorServer
```

### 4.4 Instalación y configuración de los proyectos de prueba

#### 4.4.1 Configuración de `BlazorServer.Tests` (xUnit, bUnit, Moq)

Este proyecto manejará tanto las pruebas de lógica de negocio (xUnit/Moq) como las pruebas de componentes Blazor (bUnit).

| **Paquete**                           | **Propósito**                                                | **Comando a Ejecutar**                         |
| ------------------------------------- | ------------------------------------------------------------ | ---------------------------------------------- |
| `xunit` y `xunit.runner.visualstudio` | Framework principal para unit tests y su integración con VS. | `dotnet add BlazorServer.Tests package xunit`  |
| `Microsoft.NET.Test.Sdk`              | Base para ejecutar tests en .NET.                            | (Generalmente ya incluido en `xunit` template) |
| `bunit` (y dependencias)              | Testing específico para componentes Blazor.                  | `dotnet add BlazorServer.Tests package bunit`  |
| `Moq`                                 | Creación de objetos simulados (mocks) para servicios.        | `dotnet add BlazorServer.Tests package Moq`    |

Resumen de los comandos:
```powerhell
# 1. Instalar bUnit (ya trae dependencias clave)
dotnet add BlazorServer.Tests package bunit --version 1.25.1 

# 2. Instalar Moq para simular servicios
dotnet add BlazorServer.Tests package Moq --version 4.20.70 

# 3. Asegurar el Test Runner de xUnit (si no estaba ya)
dotnet add BlazorServer.Tests package xunit.runner.visualstudio --version 2.5.7
```



#### 4.4.2 Configuración de `BlazorServer.E2E` (Playwright)

Para las pruebas End-to-End, usaremos el *binding* de Playwright para .NET.

| **Paquete**                                                  | **Propósito**                                                | **Comando a Ejecutar**                                       |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------------------------------------------------------ |
| `Microsoft.Playwright.MSTest` o `Microsoft.Playwright.xUnit` | Playwright para .NET (usa su propio test runner o se integra con xUnit, NUnit, o MSTest). | `dotnet add BlazorServer.E2E package Microsoft.Playwright.NUnit --version 1.41.2` (Usaremos xUnit como base de E2E por su simplicidad con Playwright, si se ha usado `mstest` inicialmente, podemos usar el *runner* de MSTest también). |

Resumen de los comandos

```powershell
# 1. Instalar la librería de Playwright (Aquí usamos NUnit, puedes cambiar a xUnit si lo prefieres)
dotnet add BlazorServer.E2E package Microsoft.Playwright.NUnit --version 1.41.2

# 2. Instalar la herramienta CLI de Playwright globalmente
dotnet tool install --global Microsoft.Playwright.CLI

# 3. Inicializar Playwright (Descarga los binarios de los navegadores)
playwright install
```

#### 4.4.3 Asegurar las Referencias

El paso más importante es asegurar que los proyectos de prueba puedan ver el código y los componentes del proyecto principal.

```powershell
# Referencia al proyecto principal para los Unit Tests (lógica de negocio y componentes)
dotnet add BlazorServer.Tests reference BlazorServer/BlazorServer.csproj

# Referencia al proyecto principal para los E2E Tests (necesario si se quiere probar el servidor en ejecución)
dotnet add BlazorServer.E2E reference BlazorServer/BlazorServer.csproj
```

## 5. Desarrollando las pruebas Unitarias

### 5.1 Enfoque y Metodología de Pruebas

La metodología adoptada prioriza la **Inversión de Dependencias (DIP)** para aislar la lógica de negocio de la infraestructura. El enfoque se divide en:

1. **Pruebas Unitarias de Servicios:** Verifican la lógica de las clases *back-end* (ej. `EmailGraphService`) sin infraestructura real, utilizando **Moq**. 
2. **Pruebas de Componentes:** Verifican el flujo de trabajo (`.razor`) usando **bUnit** para simular la interacción del usuario y confirmar que el componente interactúa correctamente con los servicios simulados.

### 5.2 Resultado caso de pruebas 1

Servicio probado: `EmailGraphService`

#### 5.2.1. Principio Evaluado: Inversión de Dependencias (DIP)

| **Objetivo Evaluado**              | **Implementación en la Prueba**                              | **¿Cómo se verifica?**                                       |
| ---------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| **Aislamiento de Infraestructura** | Se inyectó el *mock* de `IGraphClientWrapper` en el constructor de `EmailGraphService`. | La prueba ejecutó el método `SendAsync` **sin errores de red** (`System.ArgumentNullException` desapareció), confirmando que la lógica de Azure fue totalmente ignorada. |
| **Testabilidad**                   | El `EmailGraphService` dependía de la interfaz `IGraphClientWrapper` en lugar de la clase concreta `GraphClientWrapper`. | El uso de `_mockGraphClient.Object` permitió que el flujo de ejecución fuera desviado a nuestro simulador de Moq. |



#### 5.2.2. Lógica de Negocio Evaluada: Envío Dual de Correo

| **Objetivo Evaluado**       | **Implementación en la Prueba**                              | **Código de Verificación Clave**                             |
| --------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| **Lógica de Envío Doble**   | El código de negocio requiere enviar el correo del **contacto** y el correo de **confirmación** al remitente. | Se verificó que el método `SendMailAsync` del cliente simulado fue llamado dos veces. |
| **Integridad de los Datos** | Se verificó que el servicio usó la configuración (`_settings.Sender`) correctamente como remitente de las llamadas a Graph. | El método `Verify` usa el remitente falso configurado en el *Arrange*. |

#### 5.2.3. Implementación de las Herramientas

| **Herramienta**   | **Rol en la Prueba**                 | **Implementación Específica**                                |
| ----------------- | ------------------------------------ | ------------------------------------------------------------ |
| **xUnit**         | Framework de pruebas.                | Define el método como un caso de prueba ejecutable con el atributo `[Fact]`. |
| **Moq**           | Framework de simulación (*Mocking*). | Se usó `new Mock<IGraphClientWrapper>()` para crear un objeto falso que registra las llamadas. |
| **`IOptions<T>`** | Simulación de la Configuración.      | Se usó `Options.Create(_settings)` para crear un objeto real `IOptions<T>` que contiene los datos de configuración necesarios para el servicio. |

#### 5.2.4 Extracto del resultado

##### Test Unitario: Validación de Lógica de Negocio del Servicio de Correo

**Clase de Prueba:** `EmailGraphServiceTests`
**Método de Prueba:** `SendAsync_ShouldCallGraphClientExactlyTwiceForTwoMessages`

**Objetivo del Test:**
Verificar que la clase `EmailGraphService` ejecuta correctamente su lógica de negocio de envío doble (correo principal del contacto y correo de confirmación al remitente), sin depender de la red de Azure o Microsoft Graph.

**Implementación de la Testabilidad:**
Para aislar el servicio de la infraestructura, se implementó el Patrón de Abstracción de Dependencias:

1.  Se creó la interfaz `IGraphClientWrapper` y su mock (`_mockGraphClient`).
2.  El constructor de `EmailGraphService` fue refactorizado para inyectar `IGraphClientWrapper`.

**Verificación (Assert):**
La prueba utiliza Moq para asegurar que el método de envío simulado (`SendMailAsync`) fue invocado **exactamente dos veces**, lo que confirma la lógica de negocio de la aplicación:

```csharp
// El mock verifica que el flujo interno del EmailGraphService haya invocado la abstracción 2 veces.
_mockGraphClient.Verify(
    x => x.SendMailAsync(
        _settings.Sender!, 
        It.IsAny<Message>()), 
    Times.Exactly(2)
);
```

**Resultado:**

La prueba se completó con éxito (Succeeded), confirmando que la lógica de negocio es correcta e inmune a fallos de red o configuración externa.

### 5.3 Resultado caso de pruebas 2

Componente probado: `Contact.Razor`

#### 5.3.1. Principio Evaluado: Testabilidad de Componentes e Integración de Servicios

| Objetivo Evaluado                  | Implementación en la Prueba                                  | Cómo se verifica                                             |
| ---------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| **Aislamiento de Infraestructura** | Se inyectó el **Mock** de `IEmailGraphService` y el **Fake** de `ICaptchaService` en el `TestContext`. | La prueba ejecutó el `HandleSubmit` asíncrono sin dependencias de la red o fallos de inicialización (`NullReferenceException`). |
| **Integridad del Flujo Asíncrono** | Se usó `Returns(Task.CompletedTask)` en el *mock* y `await cut.Find("form").SubmitAsync()`. | Se confirmó, mediante `cut.WaitForState()`, que la interfaz de usuario se actualiza **después** de que la tarea asíncrona simulada termina. |
| **Validación del `Captcha`**       | Se creó el **`FakeCaptchaService`** para devolver una respuesta predecible (`"14"`), asegurando que el flujo de la prueba siempre entrara en la rama de éxito. | Se verificó que el *mock* de correo se llama, probando que la validación `!Validate()` fue exitosa. |

#### 5.3.2. Lógica de Negocio Evaluada: Envío de Correo (Contacto)

| Objetivo Evaluado             | Implementación en la Prueba                                  | Código de Verificación Clave                                 |
| ----------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| **Integridad de Datos**       | Se simularon *inputs* en los campos (`#name`, `#email`, etc.) con `cut.Find("#id").Change(value)`. | La prueba utiliza `_mockEmailService.Verify` para asegurar que el **cuerpo del correo** se construye correctamente con todos los datos del formulario. |
| **Control de Llamada**        | Verificar que el servicio de correo solo se llama al pasar la validación y el Captcha. | `_mockEmailService.Verify(x => x.SendAsync(...), Times.Once())` |
| **Respuesta de Usuario (UX)** | Verificar que el mensaje de éxito se muestre en el DOM.      | `cut.WaitForState(() => cut.Markup.Contains("Mensaje enviado correctamente..."));` |

#### 5.3.3 Patrones de Prueba de `bUnit` Utilizados

| Patrón de `bUnit`                                        | Rol en la Prueba                       | Justificación de Uso                                         |
| -------------------------------------------------------- | -------------------------------------- | ------------------------------------------------------------ |
| **Herencia de Clase C#** (`ContactTests : TestContext`)  | Permite el *Setup* del entorno.        | **CRUCIAL:** Se utilizó este patrón (en lugar del patrón básico `@code`) porque es el único que permite **configurar y registrar los `mocks` y `fakes` en el contenedor de Inyección de Dependencias** antes de que el componente sea renderizado. |
| **Ajuste de Timeout** (`TestContext.DefaultWaitTimeout`) | Estabilización del entorno de pruebas. | Se configuró el tiempo de espera a 10 segundos para evitar fallos de sincronización (`WaitForFailedException`) en entornos lentos, garantizando que el *assert* asíncrono tenga tiempo suficiente para resolver el `await`. |
| **Interacción con Formularios** (`SubmitAsync`)          | Simulación de la acción del usuario.   | `await cut.Find("form").SubmitAsync()` es la forma más limpia y directa de disparar el evento `OnValidSubmit` del componente Blazor, asegurando que se omite el detalle de si el botón está o no deshabilitado. |

#### 5.3.4 Resultado Final

Todas las pruebas de componentes y servicios se completaron con **éxito (Succeeded)**, confirmando la correcta integración de los servicios, el flujo asíncrono y la gestión de la lógica de negocio y la UX.

### 5.4 **Componentes y Casos de Prueba**

Resumen de componentes y pruebas realizadas

| **Componente**              | **Archivo de prueba**        | Tipo de prueba   |
| --------------------------- | ---------------------------- | ---------------- |
| `Host.cshtml`               | `HostTest.cs`                | **PID**          |
| `Contact.razor`             | `ContactTest.cs`             | **PCJS** **PID** |
| `Domotica.razor`            | `DomoticaTest.cs`            | **PB**           |
| `DomoticaDigitalHome.razor` | `DomoticaDigitalHomeTest.cs` | **PCJS**         |
| `EsquemaContratacion.razor` | `EsquemaContratacionTest.cs` | **PB**           |
| `Inmotica.razor`            | `InmoticaTest.cs`            | **PB**           |
| `PoliticaCookies.razor`     | `PoliticaCookiesTest.cs`     | **PB**           |
| `Precios.razor`             | `PreciosTest.cs`             | **PB**           |
| `PrivatePolicies.razor`     | `PrivatePoliciesTest.cs`     | **PCJS**         |
| `QuienesSomos.razor`        | `QuienesSomosTest.cs`        | **PB**           |
| `Servicios.razor`           | `ServiciosTest.cs`           | **PB**           |
| `Term.razor`                | `TermTest.cs`                | **PB**           |
| `Ventajas.razor`            | `VentajasTest.cs`            | **PB**           |

Esta tabla te permite ver de un vistazo qué pruebas corresponden a qué componentes.

### 5.5 **Detalles de las Pruebas**

- **Pruebas Básicas (PB)**: Validación de que el componente se renderiza correctamente sin dependencias.
- **Pruebas con Inyección de Dependencias (PID)**: Configuración de servicios inyectados y validación del renderizado.
- **Pruebas con `JSRuntime` (PCJS)**: Simulación de `JSRuntime` para probar componentes que interactúan con JavaScript.

#### 5.5.1 **Pruebas Básicas (Sin Inyección de Dependencias)**

Este tipo de prueba está destinado a los componentes que no requieren servicios inyectados. Es una prueba sencilla que verifica que el componente se renderiza correctamente y contiene el contenido esperado.

**Plantilla para pruebas básicas utilizada:**

```
using Bunit;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using BlazorServer.Pages;  // Asegúrarse de cambiar el namespace al del propio componente

namespace BlazorServer.Tests.Components;

public class ComponenteXTests
{
    [Fact]
    public void ComponenteX_ShouldRenderWithoutErrors()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext(); 
        
        // 1. Si ComponenteX inyecta ILogger<ComponenteX>, descomenta la siguiente línea:
        // ctx.Services.AddSingleton(Mock.Of<ILogger<ComponenteX>>()); 

        // 2. ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<ComponenteX>(); 

        // 3. ASSERT: Verificar que el renderizado fue exitoso (Smoke Test).
        Assert.NotNull(cut.Markup);
        
        // 4. ASSERT: Verificación de contenido para asegurar que es el componente correcto.
        Assert.Contains("Texto Clave Único de ComponenteX", cut.Markup); 
    }
}
```

#### Pasos clave:

1. **ARRANGE**: Inicialización de `TestContext` para configurar el entorno de prueba.
2. **ACT**: Renderización del componente con `RenderComponent`.
3. **ASSERT**: Validación de que el componente se ha renderizado sin errores y contiene el texto esperado.

#### 5.5.2 **Pruebas para Componentes con Inyección de Dependencias**

Si el componente depende de servicios inyectados, como `ILogger<T>`, `IService`, o cualquier otra dependencia, se debe configurar el contenedor de servicios (`TestContext.Services`) antes de renderizar el componente.

**Ejemplo:**

```
using Bunit;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using BlazorServer.Pages;  // Asegúrarse de cambiar el namespace al propio componente

namespace BlazorServer.Tests.Components;

public class ComponenteConDependenciasTests
{
    [Fact]
    public void ComponenteConDependencias_ShouldRenderWithInjectedServices()
    {
        // ARRANGE: Inicializar el contexto de bUnit
        using var ctx = new TestContext();

        // Inyectar servicios como ILogger o cualquier otro servicio necesario.
        ctx.Services.AddSingleton(Mock.Of<ILogger<ComponenteConDependencias>>()); 

        // ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<ComponenteConDependencias>(); 

        // ASSERT: Verificar que el componente se renderiza correctamente
        Assert.NotNull(cut.Markup);
        Assert.Contains("Texto esperado", cut.Markup);  // Verifica un texto único o algo que debe estar en el DOM.
    }
}
```

#### Pasos clave:

1. **ARRANGE**: Agregar las dependencias necesarias al contenedor de servicios (por ejemplo, `ILogger`, `IService`, etc.).
2. **ACT**: Renderizar el componente.
3. **ASSERT**: Verificar que el componente se renderiza correctamente y contiene el contenido esperado.

#### 5.5.3 **Pruebas para Componentes con `JSRuntime`**

Cuando un componente depende de `JSRuntime` para ejecutar código JavaScript (por ejemplo, invocar funciones de JavaScript desde Blazor), se debe simular o "mockear" el comportamiento de `IJSRuntime` para probar la funcionalidad sin ejecutar realmente JavaScript.

**Ejemplo de uso con `JSRuntime` simulado:**

```
using Bunit;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Moq;
using BlazorServer.Pages;  // Asegúrate de cambiar el namespace a tu propio componente

namespace BlazorServer.Tests.Components;

public class ComponenteConJSRuntimeTests
{
    [Fact]
    public void ComponenteConJSRuntime_ShouldCallJSFunction()
    {
        // ARRANGE: Inicializar el contexto de bUnit y simular IJSRuntime.
        using var ctx = new TestContext();
        
        // Simular el comportamiento de JSRuntime
        var mockJsRuntime = new Mock<IJSRuntime>();
        mockJsRuntime.Setup(js => js.InvokeVoidAsync(It.IsAny<string>(), It.IsAny<object[]>()))
                     .ReturnsAsync(ValueTask.CompletedTask);
        ctx.Services.AddSingleton(mockJsRuntime.Object);  // Inyectar el mock de JSRuntime

        // ACT: Renderizar el componente.
        var cut = ctx.RenderComponent<ComponenteConJSRuntime>();

        // ASSERT: Verificar que la función de JavaScript fue llamada correctamente
        mockJsRuntime.Verify(js => js.InvokeVoidAsync(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
    }
}
```

#### Pasos clave:

1. **ARRANGE**: Simular `JSRuntime` usando Moq y configurarlo para devolver un valor.
2. **ACT**: Renderizar el componente que interactúa con `JSRuntime`.
3. **ASSERT**: Verificar que el componente haya invocado la función de JavaScript correctamente.

## 6. Desarrollo de las pruebas de integración

El propósito principal de estas pruebas fue validar el comportamiento de la página **BlazorServer**, asegurando que la navegación, interacción con formularios y manejo de elementos dinámicos como el **cookie banner** y el **captcha** funcionaran correctamente. Las pruebas cubrieron la carga de la página, la navegación entre secciones, la validación de formularios y la visualización de mensajes de error.

### 6.1 Herramientas Utilizadas

Siguiendo el objetivo del Plan de pruebas se usaron:

- **Playwright**: Framework de automatización para pruebas de aplicaciones web, utilizado para interactuar con los elementos de la página, realizar clics, completar formularios, y esperar elementos dentro de las pruebas.
- **xUnit**: Framework de pruebas unitarias para .NET, usado para organizar, ejecutar y verificar los resultados de las pruebas automatizadas, con la integración de **Assertions** para validar comportamientos esperados.

### 6.2 Pruebas Realizadas

#### 6.2.1 Verificación del Título de la Página (Test de Navegación Básica):

**Objetivo:** Validar la carga correcta del título de la página y comprobar la navegación entre secciones.

**Acciones realizadas:** Verificación de que el título de la página coincida con el esperado, validando diferencias de acentos y mayúsculas/minúsculas. Además, se probaron las transiciones de navegación entre las secciones de la página.

- Se verificó que el título de la página coincidiera con el esperado ("Domótica Brotons"), utilizando un comparador que ignorara diferencias de acentos y mayúsculas/minúsculas.

#### 6.2.2 Prueba de Navegación Entre Secciones

- Se simuló la navegación entre diferentes secciones de la página, comprobando que al hacer clic en los enlaces, el contenido de cada sección se cargara correctamente.

#### 6.2. 3 Prueba del Cookie Banner

- Se validó que el banner de cookies apareciera correctamente en la página, y se probó la interacción con él (como aceptar las cookies). Se verificó que una vez aceptado, el banner ya no apareciera en futuras interacciones dentro de la misma sesión, simulando el comportamiento esperado para una correcta UX.

#### 6.2.4 Formulario de Contacto - Envío con Captcha No Completado

- Se rellenaron los campos del formulario (nombre, email, mensaje) sin resolver el captcha y se comprobó que el formulario no se enviara. Además, se validó que se mostrara el mensaje de error correspondiente, indicando que el captcha debía ser resuelto.

### 6.3 Problemas Encontrados y Soluciones

#### 6.3.1 Comparación de Cadenas

- Hubo un problema inicial con la comparación de cadenas en el título de la página debido a diferencias de codificación. Se solucionó utilizando `StringComparer.OrdinalIgnoreCase` para una comparación robusta que no tuviera en cuenta las diferencias de tildes ni mayúsculas/minúsculas.

#### 6.3.2 Visibilidad de Elementos

- Durante la prueba de interacción con los campos de texto del formulario, algunos elementos no estaban visibles o accesibles de inmediato. Esto se solucionó utilizando técnicas de espera explícita (`WaitForSelectorAsync`) para asegurarse de que los elementos estuvieran completamente cargados antes de interactuar con ellos.

#### 6.3.3 Manejo del Captcha

- El manejo del captcha fue un desafío, especialmente para verificar el error cuando no se resolvía. Se implementaron esperas para detectar el mensaje de error correctamente, y se validó que el sistema no permitiera enviar el formulario sin completar el captcha.

#### 6.3.4 Interacción con el Cookie Banner

- El cookie banner fue probado para verificar que apareciera al inicio y que se pudiera aceptar correctamente, evitando que se mostrara en futuras interacciones dentro de la misma sesión. Esto garantizó que la experiencia del usuario fuera consistente con el comportamiento esperado.

### 6.4 Correcciones y Mejoras Realizadas

6.4.1 Normalización de Texto

- Se corrigió la comparación de cadenas en la validación del título de la página, usando técnicas de normalización para manejar diferencias de caracteres especiales.

6.4.2 Sincronización de Elementos

- Se aseguraron las interacciones con los campos de entrada y botones mediante el uso de esperas explícitas para garantizar que los elementos estuvieran visibles y disponibles antes de realizar cualquier acción.

6.4.3 Manejo de Errores del Captcha

- Se mejoró la gestión del captcha para garantizar que el mensaje de error solo se verificara cuando el captcha no estuviera resuelto, evitando falsos positivos y asegurando una correcta validación.

6.4.4 Cookie Banner - Aceptación y Persistencia

- Se implementó la verificación del comportamiento del banner de cookies, validando que este se ocultara después de ser aceptado y no apareciera nuevamente en la misma sesión.

### 6.5 Ejecución de los casos de prueba

#### 6.5.1 Ejecucón de la prueba de navegación entre sesiones

```powershell
dotnet test --filter "FullyQualifiedName~BlazorServer.E2E.Navegation.PlaywrightTests.Navigation_ShouldWorkCorrectly_BetweenSections"
```

#### 6.5.2 Ejecución de la prueba navegación básica

```powershell
dotnet test BlazorServer.E2E --filter "FullyQualifiedName~BlazorServer.E2E.Navegation.PlaywrightTests.Page_ShouldLoad_AllComponentsCorrectly"
```

#### 6.5.3 Ejecución de la prueba del Banner de los cookies

```powershell
dotnet test --filter "FullyQualifiedName~BlazorServer.E2E.Navegation.PlaywrightTests.CookieBanner_ShouldBeVisible_WhenPageLoads"
```

#### 6.5.4 Ejecución de la prueba del Captcha

```powershell
dotnet test --filter "FullyQualifiedName~BlazorServer.E2E.Navegation.PlaywrightTests.ContactForm_ShouldNotSend_WhenCaptchaNotCompleted"
```

#### 6.5.5 Lista de los casos de pruebas

```powershell
dotnet test --list-tests
```

## 7. CI - Construcción del la integración continua

### 7.1 Construcción del Pipeline de CI Azure DevOps

**CI: Build, Test y Empaquetado (Azure DevOps YAML)**

**Objetivo:**
 Construir, ejecutar pruebas unitarias, pruebas de componentes y pruebas E2E, empaquetar la aplicación Blazor Server y publicar artefactos listos para CD.

------

#### **Trigger**

- Se ejecuta automáticamente en los siguientes branches:
  - `main`
  - `fix/ci-e2e`

------

#### **Variables**

- `buildConfiguration`: `Release` → Configuración de compilación.
- `artifactName`: `drop` → Nombre del artefacto de salida.

------

#### **Stages y Jobs**

**Stage: `CI_BuildAndTest`**

- Nombre visible: `1. Build, Pruebas y Empaquetado`

**Job: `Build`**

- **Pool:** `windows-latest`

**Steps:**

1. **Restaurar dependencias .NET**
   - `dotnet restore` para todos los `.sln` del repositorio.
2. **Renombrar configuración de appsettings**
   - Si `appsettings.json` no existe y `appsetting_sExample.json` sí, se renombra automáticamente.
3. **Pruebas Unitarias y de Componentes**
   - `dotnet test` en proyecto `BlazorServer.Tests`
   - Configuración: `Release`
4. **Compilar proyecto E2E**
   - `dotnet build` en proyecto `BlazorServer.E2E`
5. **Instalación de Playwright**
   - Instala herramienta global `Microsoft.Playwright.CLI` y binarios de navegador necesarios.
6. **Arrancar Blazor Server en background**
   - Permite que las pruebas E2E accedan a `http://localhost:5000`.
7. **Esperar disponibilidad del servidor**
   - Hasta 20 intentos con 5s de espera entre ellos.
   - Se requiere 3 respuestas consecutivas HTTP 200 para continuar.
8. **Ejecutar pruebas E2E con Playwright**
   - `dotnet test` en `BlazorServer.E2E`
9. **Detener servidor Blazor** (Cleanup)
   - `taskkill /F /IM dotnet.exe /T`
   - Se ejecuta siempre, incluso si las pruebas fallan.
10. **Publicar aplicación**
    - `dotnet publish` de `BlazorServer` en carpeta de staging de artefactos.
11. **Publicar artefactos**
    - Carpeta de salida: `$(Build.ArtifactStagingDirectory)`
    - Nombre del artefacto: `drop`

------

**Notas técnicas:**

- CI incluye pruebas unitarias, de componentes y E2E para asegurar la calidad antes de desplegar.
- Se asegura que el servidor esté activo y estable antes de ejecutar E2E.
- Uso de PowerShell y CmdLine para tareas de preparación y cleanup.

### 8. CD - Construcción del despliegue continuo

Implementar una pipeline de **Entrega Continua (CD)** que despliegue la aplicación Blazor en el Azure App Service (`bmspa2024`) e inyecte dinámicamente cuatro secretos críticos (credenciales de Entra ID y correo electrónico del remitente) desde el **Azure Key Vault** (`bmspa2024-kv-prod`).

El sistema de CI/CD para la aplicación se ha configurado para garantizar la seguridad de las credenciales y la automatización del despliegue en el entorno de producción (`bmspa2024.azurewebsites.net`).

### 8.1 Mecanismo de Seguridad de Secretos (Key Vault Integration)

Todas las credenciales sensibles (incluyendo el Client ID, Tenant ID y Client Secret de Entra ID) se gestionan a través de **Azure Key Vault** (`bmspa2024-kv-prod`) y nunca se almacenan en la pipeline de Azure DevOps.

- **Identidad de Despliegue:** La pipeline utiliza una **Entidad de Servicio** con permisos de sólo **lectura de secretos (`Get, List`)** en el Key Vault.
- **Flujo de Secretos:** Los secretos se inyectan en la pipeline en tiempo de ejecución mediante la tarea **`Azure Key Vault`** (en lugar de la Library de variables), lo que garantiza la compatibilidad total con la configuración de permisos de Azure.
- **Inyección de Configuración:** Las variables se inyectan en el App Service como `App Settings` utilizando la **convención de variables de entorno de .NET (`__`)** para garantizar que la aplicación pueda leer la configuración jerárquica:
  - `EntraIdGraphSettings__ClientId`
  - `EntraIdGraphSettings__ClientSecret`

### 8.2 Estado de la Pipeline

El despliegue ha sido probado y verificado:

- **CI:** Compilación exitosa del artefacto.
- **CD:** Despliegue automatizado, lectura de secretos y aplicación de configuraciones funcionales.
- **Resultado:** Aplicación Blazor operativa en producción con autenticación Entra ID activa.
