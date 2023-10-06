// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#refreshProductsBtn').on('click', function (e) {
        e.preventDefault();
        $.get("/Index?handler=RefreshProducts", function (data) {
            var content = '';
            for (var i = 0; i < data.length; i++) {
                content += `
                    <div class="col-lg-3 col-md-6 portfolio-item filter-app">
                        <div class="portfolio-wrap">
                            <img src="${data[i].url}" class="img-fluid" alt="">
                            <div class="portfolio-info">
                                <h4>${data[i].name}</h4>
                                <p>${data[i].qty}</p>
                                <div class="portfolio-links">
                                    <a><i class="bx bx-plus"></i> Add</a>
                                </div>
                            </div>
                        </div>
                    </div>`;
            }
            $('.portfolio-container').html(content);
        });
    });
});