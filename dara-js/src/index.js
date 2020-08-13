import { Dara } from './dara.js'

let cellElements = document.querySelectorAll('[data-cell]')
let board = document.getElementById('board')
let startButton = document.querySelector('#startButton')
let finishButton = document.querySelector('#finishButton')
let message = document.querySelector('#message')

let dara = new Dara(cellElements, board, message, startButton, finishButton)

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