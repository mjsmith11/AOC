package main

import (
	"fmt"
	"math"
)

func main() {
	var board [5]string
	board[0] = "#.#.#"
	board[1] = "..#.."
	board[2] = ".#.##"
	board[3] = ".####"
	board[4] = "###.."

	seen := map[string]string{}
	seen[boardToString(board)] = ""

	done := false

	for !done {
		var newBoard [5]string
		for y := 0; y < 5; y++ {
			newLine := ""
			for x := 0; x < 5; x++ {
				bugs := 0
				//left
				if x > 0 {
					if board[y][x-1] == '#' {
						bugs++
					}
				}
				// right
				if x < 4 {
					if board[y][x+1] == '#' {
						bugs++
					}
				}
				//up
				if y > 0 {
					if board[y-1][x] == '#' {
						bugs++
					}
				}
				// down
				if y < 4 {
					if board[y+1][x] == '#' {
						bugs++
					}
				}

				newChar := board[y][x]
				if newChar == '#' && bugs != 1 {
					newChar = '.'
				} else if newChar == '.' && (bugs == 1 || bugs == 2) {
					newChar = '#'
				}
				newLine = newLine + string(newChar)
			}
			newBoard[y] = newLine
		}
		board = newBoard

		boardStr := boardToString(board)
		if _, ok := seen[boardStr]; ok {
			done = true
		} else {
			seen[boardToString(board)] = ""
		}
	}
	finalBoardStr := boardToString(board)
	rating := 0.0
	for pos, char := range finalBoardStr {
		if char == '#' {
			rating += math.Pow(2.0, float64(pos))
		}
	}
	fmt.Printf("Part 1: %f", rating)
	/*fmt.Println(board[0])
	fmt.Println(board[1])
	fmt.Println(board[2])
	fmt.Println(board[3])
	fmt.Println(board[4])
	fmt.Println("")*/

}

func boardToString(board [5]string) string {
	return board[0] + board[1] + board[2] + board[3] + board[4]
}
