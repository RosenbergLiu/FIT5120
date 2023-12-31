﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToList() {
    const inputEl = document.getElementById('ingredient');
    const listContainer = document.getElementById('listContainer');

    // Check if the input has a value
    if (inputEl.value.trim() !== "") {
        ingredientsList.push(inputEl.value);
        const rowDiv = document.createElement('div');
        rowDiv.className = 'row';

        const nameDiv = document.createElement('div');
        nameDiv.className = 'col';
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

function fetchRecipes() {
    const resultTile = document.getElementById('resultTile');
    resultTile.innerHTML = `Searching ...`;

    if (ingredientsList.length) {
        const joinedIngredients = ingredientsList.join('%2C'); 
        const settings = {
            async: true,
            crossDomain: true,
            url: `https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/findByIngredients?ingredients=${joinedIngredients}&number=20&ignorePantry=true&ranking=1`,
            method: 'GET',
            headers: {
                'X-RapidAPI-Key': 'bffaa60994mshad99b0c495fe234p1bbc5fjsn7179305ed32f',
                'X-RapidAPI-Host': 'spoonacular-recipe-food-nutrition-v1.p.rapidapi.com',
                'RequestVerificationToken': token
            }
        };

        $.ajax(settings).done(function (response) {
            recipesIds = response.map(recipe => recipe.id); 
            fetchDetailedRecipes();
            console.log(recipesIds); 
        }).fail(function (error) {
            console.error("There was an error fetching the recipes:", error);
        });
    } else {
        alert('Please add ingredients first.');
    }
}

function fetchDetailedRecipes() {
    if (recipesIds.length) {
        const joinedIds = recipesIds.join('%2C'); // Join with %2C (URL encoded comma)

        const settings = {
            async: true,
            crossDomain: true,
            url: `https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/informationBulk?ids=${joinedIds}`,
            method: 'GET',
            headers: {
                'X-RapidAPI-Key': 'bffaa60994mshad99b0c495fe234p1bbc5fjsn7179305ed32f',
                'X-RapidAPI-Host': 'spoonacular-recipe-food-nutrition-v1.p.rapidapi.com',
                'RequestVerificationToken': token
            }
        };

        $.ajax(settings).done(function (response) {
            displayDetailedRecipes(response);
        }).fail(function (error) {
            console.error("There was an error fetching the detailed recipes:", error);
        });
    } else {
        console.warn('No recipe IDs to fetch detailed information for.');
    }
}


function displayDetailedRecipes(response) {
    
    const container = document.getElementById('recipesContainer');
    const resultTitle = document.getElementById('resultTile');
    const formattedIngredients = ingredientsList.join(', ');
    resultTitle.innerHTML = `Displaying results for ${formattedIngredients}`;

    for (let i = 0; i < response.length; i++) {
        const recipeHTML = `
        <div class="col-lg-3 col-md-6 portfolio-item filter-app" data-aos="zoom-in-up" data-aos-delay="80">
            <div class="portfolio-wrap">
                <img src="${response[i].image}" class="img-fluid" alt="${response[i].title}">
                <div class="portfolio-info">
                    <h4>${response[i].title}</h4>
                    <div class="portfolio-links">
                        <a href="${response[i].sourceUrl}" target="_blank"><i class="bx bx-link"></i> Open</a>
                    </div>
                </div>
            </div>
        </div>`;

        container.innerHTML += recipeHTML;
    }

}




async function AnalyzeFrame(imageDataUrl) {

    // Prepare API payload
    const payload = {
        "requests": [
            {
                "image": {
                    "content": imageDataUrl
                },
                "features": [
                    {
                        "type": "TEXT_DETECTION"
                    }
                ]
            }
        ]
    };

    // Call Google Vision API
    const response = await fetch("https://vision.googleapis.com/v1/images:annotate?key=AIzaSyAMLTuq5eTM1B_Q2BhMnc4qa6GzgDrnmuw", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(payload)
    });

    if (response.ok) {
        const data = await response.json();
        if (data.responses && data.responses[0] && data.responses[0].textAnnotations && data.responses[0].textAnnotations[0]) {
            const textAnnotations = data.responses[0].textAnnotations[0].description || "No text detected";
            console.log(textAnnotations);
            return textAnnotations;
        }
        else {
            return null;
        }
    } else {
        const errMessage = await response.text();
        throw new Error("Failed to call API: " + errMessage);
    }
    return null;
}

function triggerDownload(dataUrl, fileName) {
    const link = document.getElementById('downloadLink');
    link.href = dataUrl;
    link.download = fileName;
    link.click();
}