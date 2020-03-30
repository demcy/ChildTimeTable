const X_CLASS = 'x'
const CIRCLE_CLASS = 'circle'
const BLOCK_CLASS = 'block'
const WINNING_COMBINATIONS = [
    [100, 1, 2]
]
const cellElements = document.querySelectorAll('[data-cell]')
const board = document.getElementById('board')
const winningMessageElement = document.getElementById('winningMessage')
const restartButton = document.getElementById('restartButton')
const winningMessageTextElement = document.querySelector('[data-winning-message-text]')
let circleTurn
let draggingItem
let overItem
let toDrag
let totalPos = 24
let X_COMBINATION = []
let CIRCLE_COMBINATION = []

startGame()

restartButton.addEventListener('click', startGame)

function startGame() {
    circleTurn = false
    cellElements.forEach(cell => {
        cell.classList.remove(X_CLASS)
        cell.classList.remove(CIRCLE_CLASS)
        cell.removeEventListener('click', handleClick)
        cell.addEventListener('click', handleClick, { once: true })
    })
    setBoardHoverClass()
    winningMessageElement.classList.remove('show')
    /*cellElements.forEach(cell=>{
        cell.addEventListener('dragstart', ()=>{
            draggingItem = cell.classList[1]
            if(cell.classList.contains(X_CLASS) || cell.classList.contains(CIRCLE_CLASS)){
                toDrag = true
            } else {
                toDrag = false
            }
        })
        cell.ondragstart = dragItem(cell)
        ////cell.addEventListener('dragstart', dragItem(cell))

        cell.addEventListener('dragend', ()=>{
            if(toDrag) {
                cell.classList.remove(draggingItem)
                cell.addEventListener('click', handleClick, {once: true})
                overItem.classList.add(draggingItem)
                overItem.removeEventListener('click', handleClick)
            }
        })

        cell.addEventListener('dragover', ()=>{

            if(cell.classList.contains(X_CLASS) || cell.classList.contains(CIRCLE_CLASS)){
                toDrag = false
            } else {
                toDrag = true
            }
            overItem = cell
        })
    })*/

}

function possibles(cell, currentClass) {
    let currentPos = Array.from(cellElements).indexOf(cell)
    let oppositeClass;
    let tempCombination = []
    if (currentClass==X_CLASS){
        oppositeClass = CIRCLE_CLASS
    }else{
        oppositeClass = X_CLASS
    }
    if(currentPos%6-2 >= 0){
        if(cellElements[currentPos-2].classList.contains(currentClass)
            && !cellElements[currentPos-1].classList.contains(oppositeClass)){
            tempCombination.push(currentPos-1)
        }
        if(!cellElements[currentPos-2].classList.contains(oppositeClass)
            && cellElements[currentPos-1].classList.contains(currentClass)){
            tempCombination.push(currentPos-2)
        }
    }
    if(currentPos%6-1 >= 0 && currentPos%6+1 <= 5){
        if(!cellElements[currentPos-1].classList.contains(oppositeClass)
            && cellElements[currentPos+1].classList.contains(currentClass)){
            tempCombination.push(currentPos-1)
        }
    }
    if(currentPos%6+2 <= 5){
        if(cellElements[currentPos+2].classList.contains(currentClass)
            && !cellElements[currentPos+1].classList.contains(oppositeClass)){
            tempCombination.push(currentPos+1)
        }
        if(!cellElements[currentPos+2].classList.contains(oppositeClass)
            && cellElements[currentPos+1].classList.contains(currentClass)){
            tempCombination.push(currentPos+2)
        }
    }
    if(currentPos%6+1 <= 5 && currentPos%6-1 >= 0){
        if(!cellElements[currentPos+1].classList.contains(oppositeClass)
            && cellElements[currentPos-1].classList.contains(currentClass)){
            tempCombination.push(currentPos+1)
        }
    }
    let row = parseInt((currentPos/6).toString()) //Number((currentPos/6).toFixed(0))
    if(row-2 >= 0){
        if(cellElements[currentPos-6*2].classList.contains(currentClass)
            && !cellElements[currentPos-6].classList.contains(oppositeClass)){
            tempCombination.push(currentPos-6)
        }
        if(!cellElements[currentPos-6*2].classList.contains(oppositeClass)
            && cellElements[currentPos-6].classList.contains(currentClass)){
            tempCombination.push(currentPos-6*2)
        }
    }
    if(row-1 >= 0 && row+1 <= 4){
        if(!cellElements[currentPos-6].classList.contains(oppositeClass)
            && cellElements[currentPos+6].classList.contains(currentClass)){
            tempCombination.push(currentPos-6)
        }
    }
    if(row+2 <= 4){
        if(cellElements[currentPos+6*2].classList.contains(currentClass)
            && !cellElements[currentPos+6].classList.contains(oppositeClass)){
            tempCombination.push(currentPos+6)
        }
        if(!cellElements[currentPos+6*2].classList.contains(oppositeClass)
            && cellElements[currentPos+6].classList.contains(currentClass)){
            tempCombination.push(currentPos+6*2)
        }
    }
    if(row+1 <= 4 && row-1 >= 0){
        if(!cellElements[currentPos+6].classList.contains(oppositeClass)
            && cellElements[currentPos-6].classList.contains(currentClass)){
            tempCombination.push(currentPos+6)
        }
    }

    if (currentClass==X_CLASS){
        for (let i = 0; i < tempCombination.length; i++) {
            X_COMBINATION.push(tempCombination[i])
        }
    }else{
        for (let i = 0; i < tempCombination.length; i++) {
            CIRCLE_COMBINATION.push(tempCombination[i])
        }
    }
}

function handleClick(e) {
    totalPos = totalPos - 1
    console.log(totalPos)
    const cell = e.target
    const currentClass = circleTurn ? CIRCLE_CLASS : X_CLASS
    placeMark(cell, currentClass)
    possibles(cell, currentClass)
    swapTurns()
    setBoardHoverClass()
    if(totalPos==0){
        cellElements.forEach(cell => {
            cell.removeEventListener('click', handleClick)
            cell.style.cursor = "pointer"
            if(cell.classList.contains(X_CLASS)) {
                cell.setAttribute('draggable', 'true');
                cell.setAttribute('ondrop', 'drop(event)')
                cell.setAttribute('ondragover', 'allowDrop(event)')
                cell.setAttribute('ondragstart', 'drag(event)')
            }else if(cell.classList.contains(CIRCLE_CLASS)){
                cell.removeAttribute('draggable');
                cell.removeAttribute('ondrop')
                cell.removeAttribute('ondragover')
                cell.removeAttribute('ondragstart')
            }else{
                cell.setAttribute('ondrop', 'drop(event)')
                cell.setAttribute('ondragover', 'allowDrop(event)')
                cell.setAttribute('ondragstart', 'drag(event)')
            }
        })
        board.classList.remove(X_CLASS)
        board.classList.remove(CIRCLE_CLASS)
    }
    /*if (checkWin(currentClass)) {
        endGame(false)
    } else if (isDraw()) {
        endGame(true)
    } else {

    }*/
}

function placeMark(cell, currentClass) {
    cell.classList.add(currentClass)
}

function swapTurns() {
    circleTurn = !circleTurn
    if(!circleTurn){
        for (let i = 0; i < CIRCLE_COMBINATION.length; i++) {
            cellElements[CIRCLE_COMBINATION[i]].addEventListener('click', handleClick, { once: true })
            cellElements[CIRCLE_COMBINATION[i]].classList.remove(BLOCK_CLASS)
        }
        for (let i = 0; i < X_COMBINATION.length; i++) {
            cellElements[X_COMBINATION[i]].removeEventListener('click', handleClick)
            cellElements[X_COMBINATION[i]].classList.add(BLOCK_CLASS)
        }
    }else{
        for (let i = 0; i < X_COMBINATION.length; i++) {
            cellElements[X_COMBINATION[i]].addEventListener('click', handleClick, { once: true })
            cellElements[X_COMBINATION[i]].classList.remove(BLOCK_CLASS)
        }
        for (let i = 0; i < CIRCLE_COMBINATION.length; i++) {
            cellElements[CIRCLE_COMBINATION[i]].removeEventListener('click', handleClick)
            cellElements[CIRCLE_COMBINATION[i]].classList.add(BLOCK_CLASS)
        }
    }
}

function swapTurns2() {
    circleTurn = !circleTurn
    let playerNow
    let playerNext
    if(!circleTurn){
        playerNow = X_CLASS
        playerNext = CIRCLE_CLASS
    }else{
        playerNow = CIRCLE_CLASS
        playerNext = X_CLASS
    }
    cellElements.forEach(cell => {
        if(cell.classList.contains(playerNow)) {
            cell.setAttribute('draggable', 'true');
            cell.setAttribute('ondrop', 'drop(event)')
            cell.setAttribute('ondragover', 'allowDrop(event)')
            cell.setAttribute('ondragstart', 'drag(event)')
        }else if(cell.classList.contains(playerNext)){
            cell.removeAttribute('draggable');
            cell.removeAttribute('ondrop')
            cell.removeAttribute('ondragover')
            cell.removeAttribute('ondragstart')
        }else{
            cell.setAttribute('ondrop', 'drop(event)')
            cell.setAttribute('ondragover', 'allowDrop(event)')
            cell.setAttribute('ondragstart', 'drag(event)')
        }
    })
}

function setBoardHoverClass() {
    board.classList.remove(X_CLASS)
    board.classList.remove(CIRCLE_CLASS)
    if (circleTurn) {
        board.classList.add(CIRCLE_CLASS)
    } else {
        board.classList.add(X_CLASS)
    }
}

function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    let targetIndex = Array.from(cellElements).indexOf(ev.target)
    let targetClass = ev.target.classList[1]
    ev.dataTransfer.setData("text", targetClass + " " + targetIndex);
    //ev.target.classList.remove(ev.target.classList[1])
}

function drop(ev) {
    let data = ev.dataTransfer.getData("text");
    let dataList = data.split(" ")
    let targetIndex = Array.from(cellElements).indexOf(ev.target)
    let fromIndex = parseInt(dataList[1].toString())
    if(Math.abs(targetIndex-fromIndex)==1 ||  Math.abs(targetIndex-fromIndex)==6){
        if(ev.target.classList.contains(X_CLASS) || ev.target.classList.contains(CIRCLE_CLASS)){
            ev.preventDefault();
        }else {
            cellElements[dataList[1]].classList.remove(dataList[0])
            ev.target.classList.add(dataList[0]);
            checkCombination(targetIndex, dataList[0])
            swapTurns2()
        }
    }else {
        ev.preventDefault();
    }

}

function checkCombination(cellId, cellName) {
    let cid = parseInt(cellId)
    if(cid%6 - 2 >=0){
        if(cellElements[cid - 2].classList.contains(cellName) && cellElements[cid - 1].classList.contains(cellName)){
            removeOpponent()
        }
    }
    if(cid%6 - 1 >=0 && cid%6 + 1 <=5){
        if(cellElements[cid - 1].classList.contains(cellName) && cellElements[cid + 1].classList.contains(cellName)){
            removeOpponent()
        }
    }
    if(cid%6 + 2 <=5){
        if(cellElements[cid + 2].classList.contains(cellName) && cellElements[cid + 1].classList.contains(cellName)){
            removeOpponent()
        }
    }

    let row = parseInt((cid/6).toString())
    if(row - 2 >=0){
        if(cellElements[cid - 6*2].classList.contains(cellName) && cellElements[cid - 6].classList.contains(cellName)){
            removeOpponent()
        }
    }
    if(row - 1 >=0 && row + 1 <=4){
        if(cellElements[cid - 6].classList.contains(cellName) && cellElements[cid + 6].classList.contains(cellName)){
            removeOpponent()
        }
    }
    if(row + 2 <=4){
        if(cellElements[cid + 6*2].classList.contains(cellName) && cellElements[cid + 6].classList.contains(cellName)){
            removeOpponent()
        }
    }


}

function removeOpponent() {
    let playerNow
    let playerNext
    if(!circleTurn){
        playerNow = X_CLASS
        playerNext = CIRCLE_CLASS
    }else{
        playerNow = CIRCLE_CLASS
        playerNext = X_CLASS
    }
    cellElements.forEach(cell => {
        if(cell.classList.contains(playerNow) || !cell.classList.contains(playerNext)) {
            cell.style.backgroundColor = "rgba(0,0,0,0.9)"
            cell.removeAttribute('draggable');
            cell.removeAttribute('ondrop')
            cell.removeAttribute('ondragover')
            cell.removeAttribute('ondragstart')
        }else{
            //cell.style.cursor = "default"
            cell.addEventListener('click', removeClick, { once: true })
        }
    })
}

function removeClick(e) {
    let cell = e.target
    cell.classList.remove(cell.classList[1])
    checkWin()
    cell.removeEventListener('click', removeClick)
    cellElements.forEach(cell => {
        cell.style.backgroundColor = "white"
    })
}

function checkWin() {
    let count = 0
    let playerNow
    let playerNext
    if(circleTurn){
        playerNow = X_CLASS
        playerNext = CIRCLE_CLASS
    }else{
        playerNow = CIRCLE_CLASS
        playerNext = X_CLASS
    }
    cellElements.forEach(cell => {
        if(cell.classList.contains(playerNext)){
            count = count + 1
        }
    })
    if(count==2){
        endGame()
    }
}

/*function checkWin(currentClass) {
    return WINNING_COMBINATIONS.some(combination => {
        return combination.every(index => {
            return cellElements[index].classList.contains(currentClass)
        })
    })
}*/

function endGame() {
    winningMessageTextElement.innerText = `${!circleTurn ? "O's" : "X's"} Wins!`
    winningMessageElement.classList.add('show')
}

function isDraw() {
    return [...cellElements].every(cell => {
        return cell.classList.contains(X_CLASS) || cell.classList.contains(CIRCLE_CLASS)
    })
}