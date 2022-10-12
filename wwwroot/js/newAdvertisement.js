const title = document.getElementById("title")
const content = document.getElementById("content")
const errorCode = document.getElementById("errorCode")

function checkAd() {
    if (title.value == "") {
        errorCode.value = "1";
    } else if (content.value == "") {
        errorCode.value = "2";
    } else if (!confirm("Czy na pewno chcesz dodać ogłoszenie o następującym tytule: " + title.value)) {
        errorCode.value = "3";
    } else {
        errorCode.value = "0";
    }
}

function checkErrorCode() {
    if (window.location.href.indexOf("NewAdvertisement/1") != -1) {
        bootbox.alert("Uzupełnij tytuł ogłoszenia!");
    } else if (window.location.href.indexOf("NewAdvertisement/2") != -1) {
        bootbox.alert("Uzupełnij treść ogłoszenia!");
    } else if (window.location.href.indexOf("NewAdvertisement/3") != -1) {
        bootbox.alert("Ogłoszenie nie zostało dodane.");
    } else if (window.location.href.indexOf("NewAdvertisement/0") != -1) {
        bootbox.alert("Ogłoszenie zostało dodane.");
    }
}

window.addEventListener("load", checkErrorCode)
document.getElementById("submit").addEventListener("click", checkAd)