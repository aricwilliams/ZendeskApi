// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*Aric Codes*/
    function ImgSlider(anything){
        document.querySelector(".image").src = anything
    };
    function bgColorChange(color){
      const sec = document.querySelector('.sec')
    sec.style.backgroundColor = color;
    };
    document.getElementById('button').addEventListener("click", function() {
        document.querySelector('.bg-modal').style.display = "flex"

});

    document.querySelector('.close').addEventListener("click", function() {
        document.querySelector('.bg-modal').style.display = "none"
});



