document.addEventListener("DOMContentLoaded", function () {
    let fieldset = document.getElementById('categories');
    let categories = GetCategories();
    for (let i = 0; i < categories.length; i++) {
        let divContainer = document.createElement('div');
        divContainer.className = "category-label"
        let inputCheckbox = document.createElement('input');
        let inputLabel = document.createElement('label');
        inputLabel.textContent = categories[i];

        inputCheckbox.type = "checkbox"
        inputCheckbox.name = "CategoryName"
        inputCheckbox.value = categories[i];
        divContainer.appendChild(inputLabel);
        divContainer.appendChild(inputCheckbox);
        fieldset.appendChild(divContainer);
    }
});

function GetCategories() {
    let result = [];
    $.ajax(
        {
            url: '/Products/GetAllCategories',
            async: false,
            dataType: "json",
            success: (givenData) => {
                result = givenData.map(item => item.name);
            },
        });
    return result;
}