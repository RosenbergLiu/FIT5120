window.addEventListener('scroll', function () {
    var navbarHeight = 70;
    var scrollPosition = window.scrollY + navbarHeight;
    var home = document.getElementById('home').offsetTop;
    var form = document.getElementById('form').offsetTop;
    var visualization = document.getElementById('visualization').offsetTop;
    var about = document.getElementById('about').offsetTop;

    setActiveLink('home', scrollPosition >= home && scrollPosition < form);
    setActiveLink('form', scrollPosition >= form && scrollPosition < visualization);
    setActiveLink('visualization', scrollPosition >= visualization && scrollPosition < about);
    setActiveLink('about', scrollPosition >= about);
});

function setActiveLink(sectionId, isActive) {
    var link = document.querySelector('.nav-' + sectionId);
    if (isActive) {
        link.classList.add('active');
    } else {
        link.classList.remove('active');
    }
}