// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToList() {
    const inputEl = document.getElementById('ingradient');
    const listContainer = document.getElementById('listContainer');

    // Check if the input has a value
    if (inputEl.value.trim() !== "") {
        const rowDiv = document.createElement('div');
        rowDiv.className = 'row';

        const nameDiv = document.createElement('div');
        nameDiv.className = 'col-8';
        const nameP = document.createElement('p');
        nameP.textContent = inputEl.value;
        nameDiv.appendChild(nameP);

        const closeDiv = document.createElement('div');
        closeDiv.className = 'col-4';
        const closeLink = document.createElement('a');
        closeLink.href = '#';
        const closeIcon = document.createElement('i');
        closeIcon.className = 'bi bi-x';
        closeLink.appendChild(closeIcon);

        closeLink.addEventListener('click', function (e) {
            e.preventDefault();
            listContainer.removeChild(rowDiv);
        });

        closeDiv.appendChild(closeLink);

        rowDiv.appendChild(nameDiv);
        rowDiv.appendChild(closeDiv);
        listContainer.appendChild(rowDiv);

        // Clear the input
        inputEl.value = '';
    }
}


