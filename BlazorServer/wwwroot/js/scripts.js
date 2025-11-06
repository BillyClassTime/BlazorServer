/*!
* Start Bootstrap - Creative v7.0.7 (https://startbootstrap.com/theme/creative)
* Copyright 2013-2023 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-creative/blob/master/LICENSE)
*/
//
// Scripts
// 

window.navbarShrink = function () {
    const navbarCollapsible = document.body.querySelector('#mainNav');
    if (!navbarCollapsible) {
        return;
    }

    if (window.scrollY > 50) {
        // Cuando el usuario hace scroll y el navbar está fijo
        navbarCollapsible.classList.add('navbar-shrink');

        // Cambia a la imagen del logo blanco
        document.getElementById('transparent-logo').style.display = 'none';
        document.getElementById('white-logo').style.display = 'inline-block';
    } else {
        // Cuando el usuario hace scroll y el navbar está en su posición original
        navbarCollapsible.classList.remove('navbar-shrink');

        // Cambia a la imagen del logo transparente
        document.getElementById('transparent-logo').style.display = 'inline-block';
        document.getElementById('white-logo').style.display = 'none';
    }
};

window.addEventListener('DOMContentLoaded', event => {

    // Shrink the navbar 
    window.navbarShrink();

    // Shrink the navbar when page is scrolled
    document.addEventListener('scroll', navbarShrink);

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            rootMargin: '0px 0px -40%',
        });
    };

    // Collapse responsive navbar when toggler is visible
    const navbarToggler = document.body.querySelector('.navbar-toggler');
    const responsiveNavItems = [].slice.call(
        document.querySelectorAll('#navbarResponsive .nav-link')
    );
    responsiveNavItems.map(function (responsiveNavItem) {
        responsiveNavItem.addEventListener('click', () => {
            if (window.getComputedStyle(navbarToggler).display !== 'none') {
                navbarToggler.click();
            }
        });
    });
});


document.addEventListener("scroll", function() {
    var scrollPosition = window.scrollY;
    var parallaxElement = document.querySelector(".masthead");

    parallaxElement.style.backgroundPositionY = scrollPosition * 0.5 + "px"; /* Ajusta el factor de paralaje según tus preferencias */
});


window.addEventListener('DOMContentLoaded', () => {
    const aboutSection = document.getElementById('domoticaDigitalHome');
    const aboutSectionOffset = aboutSection.offsetTop; // Posición vertical de la sección

    function checkScroll() {
        // Distancia del scroll desde la parte superior de la ventana
        const scrollPosition = window.scrollY;

        // Altura de la ventana del navegador
        const windowHeight = window.innerHeight;

        // Agrega la clase de animación cuando la sección está en el área visible
        if (scrollPosition > aboutSectionOffset - windowHeight / 2) {
            aboutSection.classList.add('animated', 'fadeInLeft');
            
        }
    }

    // Ejecuta la función cuando se hace scroll
    window.addEventListener('scroll', checkScroll);

    // Ejecuta la función al cargar la página para animaciones iniciales
    checkScroll();
});

window.addEventListener('DOMContentLoaded', () => {
    const aboutSection = document.getElementById('inmotica');
    const aboutSectionOffset = aboutSection.offsetTop; // Posición vertical de la sección

    function checkScroll() {
        // Distancia del scroll desde la parte superior de la ventana
        const scrollPosition = window.scrollY;

        // Altura de la ventana del navegador
        const windowHeight = window.innerHeight;

        // Agrega la clase de animación cuando la sección está en el área visible
        if (scrollPosition > aboutSectionOffset - windowHeight / 2) {
           
            aboutSection.classList.add('animated', 'fadeInRight');
        }
    }

    // Ejecuta la función cuando se hace scroll
    window.addEventListener('scroll', checkScroll);

    // Ejecuta la función al cargar la página para animaciones iniciales
    checkScroll();
});

window.addEventListener('DOMContentLoaded', () => {
    const aboutSection = document.getElementById('servicios');
    const aboutSectionOffset = aboutSection.offsetTop; // Posición vertical de la sección

    function checkScroll() {
        // Distancia del scroll desde la parte superior de la ventana
        const scrollPosition = window.scrollY;

        // Altura de la ventana del navegador
        const windowHeight = window.innerHeight;

        // Agrega la clase de animación cuando la sección está en el área visible
        if (scrollPosition > aboutSectionOffset - windowHeight / 2) {
           
            aboutSection.classList.add('animated', 'fadeInUp');
        }
    }

    // Ejecuta la función cuando se hace scroll
    window.addEventListener('scroll', checkScroll);

    // Ejecuta la función al cargar la página para animaciones iniciales
    checkScroll();
});

window.navigateToAnchor = (id) => {
    try {
        let element = document.getElementById(id);
        if (element) {
            element.scrollIntoView({behavior: "smooth"});
        } else {
            console.error(`Element with id ${id} not found`);
        }
    } catch (error) {
        console.error(error);        
    }
}