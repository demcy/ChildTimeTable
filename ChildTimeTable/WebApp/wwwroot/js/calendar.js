let today = new Date();
let currentDay = today.getDate();
let currentMonth = today.getMonth();
let currentYear = today.getFullYear();
let thisDay = today.getDate();
let thisMonth = today.getMonth();
let thisYear = today.getFullYear();
let dutyDates = [];
let cultureInfo;
let monthAndYear = document.getElementById('monthAndYear');
let tbl = document.getElementById('calendar-body');
let wd = document.getElementById('weekDay');
let newPersonDiv = document.getElementById('newPerson-div');
let notificationBadge = document.getElementById('notBadge');
notificationBadge.innerText=localStorage.getItem('x');

function newDutyDays(arrayDutyDates, cInfo) {
    for (let i = 0; i < arrayDutyDates.length; i++){
        let dd = new Date(arrayDutyDates[i]);
        dutyDates.push(dd);
    }
    cultureInfo = cInfo;
    weekDay();
    showCalendar(currentMonth, currentYear);
}

function weekDay() {
    for (let i = 1; i < 8; i++){
        let sd = new Date(2020,5, i)
        let th = document.createElement('th');
        let cellText = document.createTextNode(sd.toLocaleString(cultureInfo,{weekday: 'short'}));
        th.appendChild(cellText);
        wd.appendChild(th);
    }
}

function showCalendar(month, year) {
    currentDay = new Date(year, month);
    let firstDay = new Date(year, month).getDay();
    let daysInMonth = new Date(year, month+1, 0).getDate();
    tbl.innerHTML = "";
    monthAndYear.innerHTML = currentDay.toLocaleString(cultureInfo,{month: 'long'}) + " " + year;
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
                let cellDiv = calendarControl(date, month + 1, year);
                cell.appendChild(cellDiv);
                row.appendChild(cell);
                date++;
            }
        }
        tbl.appendChild(row)
    }
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

function newPerson() {
    newPersonDiv.style.display="block";
}

function closeNewPerson() {
    newPersonDiv.style.display="none";
}

