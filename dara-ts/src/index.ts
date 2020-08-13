import { Dara } from './dara'

let cellElements = document.querySelectorAll('[data-cell]') as NodeListOf<HTMLDivElement>
let board = document.getElementById('board') as HTMLDivElement
let startButton = document.querySelector('#startButton') as HTMLButtonElement
let finishButton = document.querySelector('#finishButton') as HTMLButtonElement
let message = document.querySelector('#message') as HTMLHeadingElement

let dara = new Dara(cellElements, board, message, finishButton)

finishButton.style.display = 'none'
startButton.addEventListener('click', startGame)
finishButton.addEventListener('click', finishGame)

function startGame() {
    board.style.display = 'grid'
    startButton.style.display = 'none'
    dara.startGame()
}

function finishGame() {
    location.reload()
}