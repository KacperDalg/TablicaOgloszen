var title = document.getElementById("title")

function askForTitle() {
    confirm("Czy na pewno chcesz dodać ogłoszenie o następującym tytule: "+title.value)
}

document.getElementById("submit").addEventListener("click", askForTitle)