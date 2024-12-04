let globalName = null;
let globalStock = null;
let searchInput;
let stockInput;


document.addEventListener("DOMContentLoaded", function () {
    searchInput = document.getElementById('search-name');
    stockInput = document.getElementById('search-stock');
    searchInput.addEventListener('keyup', SearchName);
    stockInput.addEventListener('keyup', SearchStock);
    LoadTable();
});

function LoadTable() {
    let result = GetData(globalName, globalStock)

    table = $('#productsTable').DataTable({
        dom: 'tip',
        data: result,
        columns: [
            { data: 'name' },
            {
                data: 'price', searchable: false,
                render: function (data) {
                    return `${data} €`
                }
            },
            { data: 'stock', searchable: false },
            {
                data: 'categories',
                className: 'categories',
                render: function (data) {
                    var htmlCategories = '';
                    data.forEach(element => {
                        htmlCategories += `<span class="category">${element.name}</span> `;
                    });;
                    return htmlCategories;
                }

            },
            {
                orderable: false,
                data: 'description',
                className: 'desc-show',
                render: function () {
                    return `<a class="btn btn-outline-light desc-btn desc-show">Show Description<a/>`
                }

            },
            {
                orderable: false,
                data: 'id',
                render: function (data) {
                    return `
                    <div class="d-flex justify-content-center gap-1">
                        <a class="btn btn-warning" href="/Products/Edit/${data}">Edit</a>
                        <a class="btn btn-danger" href="/Products/Delete/${data}">Delete</a>
                    </div>`;
                },
            }
        ]
    });

    table.on('click', 'a.desc-show', function () {
        var tr = $(this).parents('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            // Open this row (the format() function would return the data to be shown)
            row.child(format(row.data()), 'desc-list').show();
            tr.addClass('shown');
        }
    });
}

function SearchName() {
    globalName = searchInput.value;
    table.destroy();
    LoadTable();
}
function SearchStock() {
    globalStock = stockInput.value;
    table.destroy();
    LoadTable();
}
function GetData(name, stock) {
    let searchParameters = new SearchProduct(name, stock);
    let result;

    $.ajax(
        {
            url: '/Products/GetAll',
            async: false,
            data: { 'searchProductJson': JSON.stringify(searchParameters) },
            dataType: "json",
            success: (givenData) => {
                result = givenData;
            },
        });
    return result
}

class SearchProduct {
    constructor(name, stock) {
        this.name = name;
        this.stock = stock;
    }
}
function format(data) {
    return data.description;
}

