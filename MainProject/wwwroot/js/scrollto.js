function scrollToHome() {
    var element = document.getElementById("home");
    if (element) {
        var position = element.getBoundingClientRect().top + window.scrollY;
        window.scrollTo({ top: position, behavior: 'smooth' });
    }
}

function scrollToInfo() {
    var element = document.getElementById("info");
    if (element) {
        var position = element.getBoundingClientRect().top + window.scrollY;
        window.scrollTo({ top: position, behavior: 'smooth' });
    }
}

function scrollToForm() {
    var element = document.getElementById("form");
    if (element) {
        var position = element.getBoundingClientRect().top + window.scrollY;
        window.scrollTo({ top: position, behavior: 'smooth' });
    }
}

function scrollToTips() {
    var element = document.getElementById("tips");
    if (element) {
        var position = element.getBoundingClientRect().top + window.scrollY;
        window.scrollTo({ top: position, behavior: 'smooth' });
    }
}