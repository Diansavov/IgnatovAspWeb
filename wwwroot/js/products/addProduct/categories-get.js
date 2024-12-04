document.addEventListener("DOMContentLoaded", function () {
    let dropdown = document.getElementById('categories');
    let categories = GetCategories();
    for (let i = 0; i < categories.length; i++) {
        let option = document.createElement('option');
        option.value = categories[i];
        option.text = categories[i];
        dropdown.add(option);

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