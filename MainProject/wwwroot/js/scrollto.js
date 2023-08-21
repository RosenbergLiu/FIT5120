function scrollToHome() {
    var element = document.getElementById("home");
    if (element) {
        var position = element.getBoundingClientRect().top + window.pageYOffset - 70;
        window.scrollTo({ top: position, behavior: 'smooth' });
    }
}

function scrollToForm() {
    var element = document.getElementById("form");
    if (element) {
        var position = element.getBoundingClientRect().top + window.pageYOffset - 70;
        window.scrollTo({ top: position, behavior: 'smooth' });
    }
}

function scrollToVisualization() {
    var element = document.getElementById("visualization");
    if (element) {
        var position = element.getBoundingClientRect().top + window.pageYOffset - 70;
        window.scrollTo({ top: position, behavior: 'smooth' });
    }
}

function scrollToAboutUs() {
    var element = document.getElementById("about");
    if (element) {
        var position = element.getBoundingClientRect().top + window.pageYOffset - 70;
        window.scrollTo({ top: position, behavior: 'smooth' });
    }
}