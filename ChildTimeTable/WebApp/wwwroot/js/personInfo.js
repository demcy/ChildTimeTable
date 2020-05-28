let logoDiv = document.getElementById('logo-div');
let logoImg = document.getElementById('logo-img');
let logoInput = document.getElementById('logo-input');

function changeLogo() {
    logoDiv.style.display="block";
}

function chooseLogo(logoName) {
    logoImg.src = logoName;
    logoInput.value = logoName;
    logoDiv.style.display="none";
}