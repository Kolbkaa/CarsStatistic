$(document).ready(function () {
    
    $("a.confirm").click(function(event) {
        const result = confirm("Czy aby na pewno chcesz usunąć?");

        if (result !== true) {
            console.log(this);
            event.preventDefault();
        }
    })
})