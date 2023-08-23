window.addEventListener('scroll', function () {
    var scrollPosition = window.scrollY;
    var sections = ['home', 'info', 'form', 'visualization', 'tips'];
    var activeSection = sections[0];
    var maxOverlap = 0;

    sections.forEach(function (sectionId) {
        var section = document.getElementById(sectionId);
        var overlap = Math.min(section.offsetTop + section.offsetHeight, scrollPosition + window.innerHeight) -
            Math.max(section.offsetTop, scrollPosition);

        if (overlap > maxOverlap) {
            activeSection = sectionId;
            maxOverlap = overlap;
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