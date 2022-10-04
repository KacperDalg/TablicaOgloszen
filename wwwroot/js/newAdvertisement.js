var title = document.getElementById("title")
var content = document.getElementById("content")

function checkAd() {
    if (title.value == "") {
        alert("Wpisz tytuł ogłoszenia!")
        document.getElementById("isOk").value = "0";
    } else if (content.value == "") {
        alert("Uzupełnij treść ogłoszenia!")
        document.getElementById("isOk").value = "0";
    } else if (!confirm("Czy na pewno chcesz dodać ogłoszenie o następującym tytule: " + title.value)) {
        document.getElementById("isOk").value = "0";
    } else {
        alert("Ogłoszenie zostało dodane!")
    }
}

document.getElementById("submit").addEventListener("click", checkAd)