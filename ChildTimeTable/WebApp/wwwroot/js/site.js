// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let today = new Date();
let thisDay = today.getDate();
let thisMonth = today.getMonth();
let currentMonth = today.getMonth();
let thisYear = today.getFullYear();
let currentYear = today.getFullYear();
let months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
let dutyDates = [];
let monthAndYear = document.getElementById('monthAndYear');

let logoDiv = document.getElementById('logo-div');
let logoImg = document.getElementById('logo-img');
let logoInput = document.getElementById('logo-input');

let newPersonDiv = document.getElementById('newPerson-div');

//const badgeText = {};
let notificationBadge = document.getElementById('notBadge');

notificationBadge.innerText=localStorage.getItem('x');





//showCalendar(currentMonth, currentYear);

function newDutyDays(arrayDutyDates) {
    for (let i = 0; i < arrayDutyDates.length; i++){
        let dd = new Date(arrayDutyDates[i]);
        //let dutyDate = [];
        //dutyDate.push(dd.getDate());
        //dutyDate.push(dd.getMonth());
        //dutyDate.push(dd.getFullYear());
        dutyDates.push(dd);
    }
    showCalendar(currentMonth, currentYear);
}



function showCalendar(month, year) {
    
    
    let firstDay = new Date(year, month).getDay();
    let daysInMonth = new Date(year, month+1, 0).getDate();
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

function existDate(date, month, year) {
    let existFound = false;
    for (let i = 0; i < dutyDates.length; i++){
        if(date === dutyDates[i].getDate() && month === dutyDates[i].getMonth()+1 && year === dutyDates[i].getFullYear()){
            existFound = true;
        }
    }
    return existFound;
}

function lateDay(date, month, year) {
    let late = false;
    if((date>=thisDay && month===thisMonth+1 && year===thisYear) || (month>thisMonth+1 && year>=thisYear)){
        late = true;
    }
    return late;
}

function calendarControl(date, month, year) {
    let dataDiv = document.createElement('div');
    dataDiv.classList.add('dropdown');
    let dataButton = document.createElement('button');
    dataButton.classList.add('btn');
    if(date===thisDay && month===thisMonth+1 && year===thisYear) {
        if (existDate(date, month, year)) {
            dataButton.classList.add('btn-warning');
        } else {
            dataButton.classList.add('btn-primary');
        }
    }else if(existDate(date, month, year)){
        dataButton.classList.add('btn-outline-warning');
    }else {
        dataButton.classList.add('btn-outline-primary');
    }
    
    
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
    let dt = year + "-" + month + "-" + date;
    viewLink.href="/Obligations/Index/?dt=" + dt;
    viewLink.innerText = "View";
    menuDiv.appendChild(viewLink);
    if(lateDay(date, month, year)) {
        let addLink = document.createElement('a');
        addLink.classList.add('dropdown-item');
        let dt = year + "-" + month + "-" + date;
        addLink.href = "/Obligations/Create/?dt=" + dt;
        addLink.innerText = "Add";
        menuDiv.appendChild(addLink);
    }
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

