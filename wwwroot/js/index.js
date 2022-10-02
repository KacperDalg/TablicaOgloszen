var ads = document.querySelectorAll(".advertisement");

ads.forEach(ad => {
    ad.addEventListener("click", function ViewContent(){
        ad.querySelector(".content").style.display = "inline";
    })
})