window.addEventListener('scroll', function () {
    var navbarHeight = 70;
    var viewportCenter = window.scrollY + window.innerHeight / 4; // This gets the middle of the screen

    var sections = ['home', 'info', 'form', 'tips'];
    var activeSection = null;

    sections.forEach(function (sectionId) {
        var section = document.getElementById(sectionId);

        // Check if the viewport's center is within this section
        if (viewportCenter >= section.offsetTop && viewportCenter <= (section.offsetTop + section.offsetHeight)) {
            activeSection = sectionId;
        }
    });

    sections.forEach(function (sectionId) {
        setActiveLink(sectionId, sectionId === activeSection);
    });
});

function setActiveLink(sectionId, isActive) {
    var link = document.querySelector('.nav-' + sectionId);
    if (isActive) {
        link.classList.add('active');
    } else {
        link.classList.remove('active');
    }
}