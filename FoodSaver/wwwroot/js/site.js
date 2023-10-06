// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function displayRandomProducts() {
    let displayedProducts = [];
    let productContainer = document.getElementById('productContainer');

    // Clear the previous products
    productContainer.innerHTML = "";
    // Get 4 random products
    while (displayedProducts.length < 4) {
        let randomIndex = Math.floor(Math.random() * allProducts.length);
        if (displayedProducts.indexOf(randomIndex) === -1) {
            displayedProducts.push(randomIndex);
            let product = allProducts[randomIndex];

            let productDiv = `
            <div class="col-lg-3 col-md-6 portfolio-item filter-app">
                <div class="portfolio-wrap">
                    <img src="${product.url}" class="img-fluid" alt="">
                    <div class="portfolio-info">
                        <h4>${product.name}</h4>
                        <p>${product.qty}</p>
                        <div class="portfolio-links">
                            <a><i class="bx bx-plus"></i> Add</a>
                        </div>
                    </div>
                </div>
            </div>`;

            productContainer.innerHTML += productDiv;
        }
    }
}
