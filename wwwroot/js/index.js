var ads = document.querySelectorAll(".advertisement");

ads.forEach(ad => {
    ad.addEventListener("click", function ViewContent(){
        ad.querySelector(".content").style.display = "inline";
        ad.style.border = "4px solid navy"
        ad.style.boxShadow = "2px 2px 6px"
    })
})