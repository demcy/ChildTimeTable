// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let today = new Date();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();
let months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
let monthAndYear = document.getElementById('monthAndYear');

let logoDiv = document.getElementById('logo-div');
let logoImg = document.getElementById('logo-img');
let logoInput = document.getElementById('logo-input');

let newPersonDiv = document.getElementById('newPerson-div');


showCalendar(currentMonth, currentYear);

function showCalendar(month, year) {
    
    
    let firstDay = new Date(year, month).getDay();
    let daysInMonth = new Date(year, month, 0).getDate();
    let tbl = document.getElementById("calendar-body");
    tbl.innerHTML = "";
    
    monthAndYear.innerHTML = months[month] + " " + year;
    
    let date = 1;


    
    for (let i = 0; i < 6; i++){
        let row = document.createElement('tr');
        for (let j = 0; j < 7; j++) {
            let cell = document.createElement('td');
            if(i === 0 && j < firstDay -1 ){
                let cellText = document.createTextNode("");
                cell.appendChild(cellText);
                row.appendChild(cell);
            } else if(date > daysInMonth){
                break;
            }else{
                //let cellText = document.createTextNode(date);
                //cell.appendChild(cellText);
                let cellDiv = calendarControl(date, month + 1, year);
                cell.appendChild(cellDiv);
                row.appendChild(cell);
                date++;
            }
            
        }
        tbl.appendChild(row)
    }
}

function previous() {
    currentYear = (currentMonth === 0)? currentYear - 1 : currentYear;
    currentMonth = (currentMonth === 0)? 11: currentMonth - 1;
    showCalendar(currentMonth, currentYear);
}

function next() {
    currentYear = (currentMonth === 11)? currentYear + 1 : currentYear;
    currentMonth = (currentMonth + 1) % 12;
    showCalendar(currentMonth, currentYear);
}

function calendarControl(date, month, year) {
    let dataDiv = document.createElement('div');
    dataDiv.classList.add('dropdown');
    let dataButton = document.createElement('button');
    dataButton.classList.add('btn');
    dataButton.classList.add('btn-outline-primary');
    
    dataButton.type="button";
    dataButton.setAttribute('data-toggle', 'dropdown');
    dataButton.innerText=date;
    dataButton.style.width = "60px";
    dataDiv.appendChild(dataButton);
    let menuDiv = document.createElement('div');
    menuDiv.classList.add('dropdown-menu');
    menuDiv.classList.add('dropdown-menu-right');
    let viewLink = document.createElement('a');
    viewLink.classList.add('dropdown-item');
    viewLink.href="/Obligations/Index";
    viewLink.innerText = "View";
    menuDiv.appendChild(viewLink);
    let addLink = document.createElement('a');
    addLink.classList.add('dropdown-item');
    //let dt = month + "/" + date + "/" + year;
    let dt = year + "-" + month + "-" + date;
    addLink.href="/Obligations/Create/?dt=" + dt;
    addLink.innerText = "Add";
    menuDiv.appendChild(addLink);
    dataDiv.appendChild(menuDiv);
    
    return dataDiv;
}



function changeLogo() {
    logoDiv.style.display="block";
}

function chooseLogo(logoName) {
    logoImg.src = logoName;
    logoInput.value = logoName;
    logoDiv.style.display="none";
}

function newPerson() {
    newPersonDiv.style.display="block";
}

function closeNewPerson() {
    newPersonDiv.style.display="none";
}

