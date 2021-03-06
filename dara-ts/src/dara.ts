import { Player } from './player'

export class Dara {
    private X_CLASS: string = 'x'
    private CIRCLE_CLASS: string = 'circle'
    private BLOCK_CLASS: string = 'block'
    private _circleTurn: boolean = false
    private _allowSwap: boolean = true
    private _dragable: boolean = false
    private _playerX = new Player('playerX')
    private _playerO = new Player('playerO')
    private _message: HTMLHeadingElement
    private _board: HTMLDivElement
    private _finishButton: HTMLButtonElement
    private _cellElements: NodeListOf<HTMLDivElement>
    private _X_COMBINATION: Array<number> = []
    private _CIRCLE_COMBINATION: Array<number> = []
    private clickHandler = this._handleClick.bind(this)
    private dragHandler = this._drag.bind(this)
    private overDragHandler = this._allowDrop.bind(this)
    private dropHandler = this._drop.bind(this)
    private removeHandler = this._removeClick.bind(this)


    constructor(cellElements: NodeListOf<HTMLDivElement>, board: HTMLDivElement, message: HTMLHeadingElement, finishButton: HTMLButtonElement) {
        this._message = message
        this._finishButton = finishButton
        this._cellElements = cellElements
        this._board = board
        //this.clickHandler = this._handleClick.bind(this)
        /*this.dragHandler = this._drag.bind(this)
        this.overDragHandler = this._allowDrop.bind(this)
        this.dropHandler = this._drop.bind(this)
        this.removeHandler = this._removeClick.bind(this)*/
    }

    startGame() {
        this._message.innerHTML = "Player 'X' takes a turn placing own piece"
        this._playerX._pieces = 0
        this._playerO._pieces = 0
        this._circleTurn = false
        this._cellElements.forEach(cell => {
            cell.addEventListener('click', this.clickHandler, { once: true })
        })
        this._setBoardHoverClass()
    }

    _setBoardHoverClass() {
        this._board.classList.remove(this.X_CLASS)
        this._board.classList.remove(this.CIRCLE_CLASS)
        if (this._circleTurn) {
            this._board.classList.add(this.CIRCLE_CLASS)
        } else {
            this._board.classList.add(this.X_CLASS)
        }
    }

    _handleClick(event: MouseEvent) {
        let cell = event.target as HTMLDivElement
        let currentClass = this._circleTurn ? this.CIRCLE_CLASS : this.X_CLASS
        this._placeMark(cell, currentClass)
        this._possibles(cell, currentClass)
        this._swapTurns()
        this._setBoardHoverClass()
        this._gameState()
    }

    _gameState() {
        if (this._playerO._pieces === 3 && this._playerX._pieces == 3) {
            this._message.innerHTML = "Player 'X' takes a turn moving own piece"
            this._cellElements.forEach(cell => {
                cell.removeEventListener('click', this.clickHandler)
                if (cell.classList.contains(this.X_CLASS)) {
                    cell.style.cursor = "pointer"
                    cell.setAttribute('draggable', 'true')
                    cell.addEventListener('dragstart', this.dragHandler)
                } else if (cell.classList.contains(this.CIRCLE_CLASS)) {
                    cell.style.cursor= 'not-allowed'
                    cell.removeAttribute('draggable')
                    cell.removeEventListener('dragstart', this.dragHandler)
                    cell.removeEventListener('dragover', this.overDragHandler)
                } else {
                    cell.style.cursor= 'not-allowed'
                    cell.addEventListener('drop', this.dropHandler)
                    cell.addEventListener('dragover', this.overDragHandler)
                }
            })
            this._board.classList.remove(this.X_CLASS)
            this._board.classList.remove(this.CIRCLE_CLASS)
        }
    }

    _placeMark(cell: HTMLDivElement, currentClass: string) {
        cell.classList.add(currentClass)
        if (this._circleTurn) {
            this._playerO._pieces++
        } else {
            this._playerX._pieces++
        }
    }

    _possibles(cell: HTMLDivElement, currentClass: string) {
        let currentPos = Array.from(this._cellElements).indexOf(cell)
        let oppositeClass = (currentClass == this.X_CLASS) ? this.CIRCLE_CLASS : this.X_CLASS
        let tempCombination = []
        if (currentPos % 6 - 2 >= 0) {
            if (this._cellElements[currentPos - 2].classList.contains(currentClass)
                && !this._cellElements[currentPos - 1].classList.contains(oppositeClass)) {
                tempCombination.push(currentPos - 1)
            }
            if (!this._cellElements[currentPos - 2].classList.contains(oppositeClass)
                && this._cellElements[currentPos - 1].classList.contains(currentClass)) {
                tempCombination.push(currentPos - 2)
            }
        }
        if (currentPos % 6 - 1 >= 0 && currentPos % 6 + 1 <= 5) {
            if (!this._cellElements[currentPos - 1].classList.contains(oppositeClass)
                && this._cellElements[currentPos + 1].classList.contains(currentClass)) {
                tempCombination.push(currentPos - 1)
            }
        }
        if (currentPos % 6 + 2 <= 5) {
            if (this._cellElements[currentPos + 2].classList.contains(currentClass)
                && !this._cellElements[currentPos + 1].classList.contains(oppositeClass)) {
                tempCombination.push(currentPos + 1)
            }
            if (!this._cellElements[currentPos + 2].classList.contains(oppositeClass)
                && this._cellElements[currentPos + 1].classList.contains(currentClass)) {
                tempCombination.push(currentPos + 2)
            }
        }
        if (currentPos % 6 + 1 <= 5 && currentPos % 6 - 1 >= 0) {
            if (!this._cellElements[currentPos + 1].classList.contains(oppositeClass)
                && this._cellElements[currentPos - 1].classList.contains(currentClass)) {
                tempCombination.push(currentPos + 1)
            }
        }
        let row = parseInt((currentPos / 6).toString())
        if (row - 2 >= 0) {
            if (this._cellElements[currentPos - 6 * 2].classList.contains(currentClass)
                && !this._cellElements[currentPos - 6].classList.contains(oppositeClass)) {
                tempCombination.push(currentPos - 6)
            }
            if (!this._cellElements[currentPos - 6 * 2].classList.contains(oppositeClass)
                && this._cellElements[currentPos - 6].classList.contains(currentClass)) {
                tempCombination.push(currentPos - 6 * 2)
            }
        }
        if (row - 1 >= 0 && row + 1 <= 4) {
            if (!this._cellElements[currentPos - 6].classList.contains(oppositeClass)
                && this._cellElements[currentPos + 6].classList.contains(currentClass)) {
                tempCombination.push(currentPos - 6)
            }
        }
        if (row + 2 <= 4) {
            if (this._cellElements[currentPos + 6 * 2].classList.contains(currentClass)
                && !this._cellElements[currentPos + 6].classList.contains(oppositeClass)) {
                tempCombination.push(currentPos + 6)
            }
            if (!this._cellElements[currentPos + 6 * 2].classList.contains(oppositeClass)
                && this._cellElements[currentPos + 6].classList.contains(currentClass)) {
                tempCombination.push(currentPos + 6 * 2)
            }
        }
        if (row + 1 <= 4 && row - 1 >= 0) {
            if (!this._cellElements[currentPos + 6].classList.contains(oppositeClass)
                && this._cellElements[currentPos - 6].classList.contains(currentClass)) {
                tempCombination.push(currentPos + 6)
            }
        }
        if (currentClass == this.X_CLASS) {
            for (let i = 0; i < tempCombination.length; i++) {
                this._X_COMBINATION.push(tempCombination[i])
            }
        } else {
            for (let i = 0; i < tempCombination.length; i++) {
                this._CIRCLE_COMBINATION.push(tempCombination[i])
            }
        }
    }

    _allowDrop(event: MouseEvent) {
        event.preventDefault();
    }

    _drag(event: DragEvent) {
        this._dragable = true
        let targetIndex = Array.from(this._cellElements).indexOf(event.target as HTMLDivElement)
        let targetClass = (event.target as HTMLDivElement).classList[1]
        event.dataTransfer!.setData("text", targetClass + " " + targetIndex)
        console.log(targetIndex + " " + targetClass)
    }

    _drop(event: DragEvent) {
        console.log('drop')
        if(this._dragable) {
        let data = event.dataTransfer!.getData("text")
        let dataList = data.split(" ")
        let targetIndex = Array.from(this._cellElements).indexOf(event.target as HTMLDivElement)
        let fromIndex = parseInt(dataList[1].toString())
        if (Math.abs(targetIndex - fromIndex) == 1 || Math.abs(targetIndex - fromIndex) == 6) {
            if ((event.target as HTMLDivElement).classList.contains(this.X_CLASS) || (event.target as HTMLDivElement).classList.contains(this.CIRCLE_CLASS)) {
                event.preventDefault()
            } else {
                this._cellElements[parseInt(dataList[1])].classList.remove(dataList[0]);
                (event.target as HTMLDivElement).classList.remove('block');
                (event.target as HTMLDivElement).classList.add(dataList[0])
                this._checkCombination(targetIndex, dataList[0])
                if (this._allowSwap) {
                    this._swapTurns2()
                }
            }
        } else {
            event.preventDefault()
        }
    }

    }

    _checkCombination(cellId: number, cellName: string) {
        let cid = cellId//parseInt(cellId)
        if (cid % 6 - 2 >= 0) {
            if (this._cellElements[cid - 2].classList.contains(cellName) && this._cellElements[cid - 1].classList.contains(cellName)) {
                this._removeOpponent()
            }
        }
        if (cid % 6 - 1 >= 0 && cid % 6 + 1 <= 5) {
            if (this._cellElements[cid - 1].classList.contains(cellName) && this._cellElements[cid + 1].classList.contains(cellName)) {
                this._removeOpponent()
            }
        }
        if (cid % 6 + 2 <= 5) {
            if (this._cellElements[cid + 2].classList.contains(cellName) && this._cellElements[cid + 1].classList.contains(cellName)) {
                this._removeOpponent()
            }
        }
        let row = parseInt((cid / 6).toString())
        if (row - 2 >= 0) {
            if (this._cellElements[cid - 6 * 2].classList.contains(cellName) && this._cellElements[cid - 6].classList.contains(cellName)) {
                this._removeOpponent()
            }
        }
        if (row - 1 >= 0 && row + 1 <= 4) {
            if (this._cellElements[cid - 6].classList.contains(cellName) && this._cellElements[cid + 6].classList.contains(cellName)) {
                this._removeOpponent()
            }
        }
        if (row + 2 <= 4) {
            if (this._cellElements[cid + 6 * 2].classList.contains(cellName) && this._cellElements[cid + 6].classList.contains(cellName)) {
                this._removeOpponent()
            }
        }
    }

    _swapTurns() {
        this._circleTurn = !this._circleTurn
        if (!this._circleTurn) {
            this._message.innerHTML = "Player 'X' takes a turn placing own piece"
            for (let i = 0; i < this._CIRCLE_COMBINATION.length; i++) {
                this._cellElements[this._CIRCLE_COMBINATION[i]].addEventListener('click', this.clickHandler, { once: true })
                this._cellElements[this._CIRCLE_COMBINATION[i]].classList.remove(this.BLOCK_CLASS)
            }
            for (let i = 0; i < this._X_COMBINATION.length; i++) {
                this._cellElements[this._X_COMBINATION[i]].removeEventListener('click', this.clickHandler)
                this._cellElements[this._X_COMBINATION[i]].classList.add(this.BLOCK_CLASS)
            }
        } else {
            this._message.innerHTML = "Player 'O' takes a turn placing own piece"
            for (let i = 0; i < this._X_COMBINATION.length; i++) {
                this._cellElements[this._X_COMBINATION[i]].addEventListener('click', this.clickHandler, { once: true })
                this._cellElements[this._X_COMBINATION[i]].classList.remove(this.BLOCK_CLASS)
            }
            for (let i = 0; i < this._CIRCLE_COMBINATION.length; i++) {
                this._cellElements[this._CIRCLE_COMBINATION[i]].removeEventListener('click', this.clickHandler)
                this._cellElements[this._CIRCLE_COMBINATION[i]].classList.add(this.BLOCK_CLASS)
            }
        }
    }

    _swapTurns2() {
        this._circleTurn = !this._circleTurn
        let playerNow = this._circleTurn ? this.CIRCLE_CLASS : this.X_CLASS
        let playerNext = this._circleTurn ? this.X_CLASS  : this.CIRCLE_CLASS
        this._message.innerHTML = this._circleTurn ? "Player 'O' takes a turn moving own piece" : "Player 'X' takes a turn moving own piece"
        this._cellElements.forEach(cell => {
            cell.style.setProperty('--bb-color', 'white')
            cell.style.backgroundColor = "white"
            if (cell.classList.contains(playerNow)) {
                cell.style.cursor = "pointer"
                cell.setAttribute('draggable', 'true')
                cell.addEventListener('dragstart', this.dragHandler)
                cell.removeEventListener('dragover', this.overDragHandler)
                cell.removeEventListener('drop', this.dropHandler)
                cell.removeEventListener('click', this.removeHandler)
            } else if (cell.classList.contains(playerNext)) {
                cell.style.cursor= 'not-allowed'
                cell.setAttribute('draggable', 'false');
                cell.removeEventListener('dragstart', this.dragHandler)
                cell.removeEventListener('dragover', this.overDragHandler)
                cell.removeEventListener('drop', this.dropHandler)
                cell.removeEventListener('click', this.removeHandler)
            } else {
                cell.style.cursor= 'not-allowed'
                cell.setAttribute('draggable', 'false')
                cell.removeEventListener('dragstart', this.dragHandler)
                cell.addEventListener('dragover', this.overDragHandler)
                cell.addEventListener('drop', this.dropHandler)
                cell.removeEventListener('click', this.removeHandler)
            }
        })
        this._dragable = false
    }

    _removeOpponent() {
        this._allowSwap = false
        let playerNow = this._circleTurn ? this.CIRCLE_CLASS : this.X_CLASS
        let playerNext = this._circleTurn ? this.X_CLASS  : this.CIRCLE_CLASS
        this._message.innerHTML = this._circleTurn ? "Player 'O' takes a turn removing opponent piece" : "Player 'X' takes a turn removing opponent piece"
        this._cellElements.forEach(cell => {
            if(cell.classList.contains(playerNow) || !cell.classList.contains(playerNext)) {
                cell.style.setProperty('--bb-color', 'black')
                cell.style.cursor= 'not-allowed'
                cell.style.backgroundColor = "rgba(0,0,0,0.9)"
                cell.removeAttribute('draggable')
                cell.removeEventListener('dragstart', this.dragHandler)
                cell.removeEventListener('dragover', this.overDragHandler)
                cell.removeEventListener('drop', this.dropHandler)
            }else{
                cell.style.cursor = "pointer"
                cell.addEventListener('click', this.removeHandler, { once: true })
            }
        })
    }

    _removeClick(event: MouseEvent) {
        let cell = event.target as HTMLDivElement
        cell.classList.remove(cell.classList[1])
        if(this._circleTurn){
            this._playerX._pieces--
        } else {
            this._playerO._pieces--
        }
        this._allowSwap = true;
        this._checkWin()
    }

    _checkWin() {
        if(this._playerX._pieces == 2 || this._playerO._pieces == 2) {
            this._message.innerHTML = `${!this._circleTurn ? "Player 'X'" : "Player 'O'"} Wins!`
            this._finishButton.style.display = 'block'
        } else {
            this._swapTurns2()
        }
    }
}
