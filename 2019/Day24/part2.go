package main

import (
	"fmt"
)

func main() {
	// A brute force attempt with 250 layers available assuming top and bottom
	// never get bugs within 200 min
	eris := getEmptyEris()
	eris[layerNumToIndex(0)][0] = "#.#.#"
	eris[layerNumToIndex(0)][1] = "..#.."
	eris[layerNumToIndex(0)][2] = ".#.##"
	eris[layerNumToIndex(0)][3] = ".####"
	eris[layerNumToIndex(0)][4] = "###.."
	minutes := 200
	for i := 0; i < minutes; i++ {
		// we have layers -125 to 124 and assume that bugs don't make it to -150 or 149
		newEris := getEmptyEris()
		for layer := -124; layer < 124; layer++ {
			for y := 0; y < 5; y++ {
				newLine := ""
				for x := 0; x < 5; x++ {
					bugs := 0
					//left
					if x > 0 {
						bugs = checkForBug(eris, layer, x-1, y, bugs)
					}
					// right
					if x < 4 {
						bugs = checkForBug(eris, layer, x+1, y, bugs)
					}
					//up
					if y > 0 {
						bugs = checkForBug(eris, layer, x, y-1, bugs)
					}
					// down
					if y < 4 {
						bugs = checkForBug(eris, layer, x, y+1, bugs)
					}
					// outside top
					if y == 0 {
						bugs = checkForBug(eris, layer-1, 2, 1, bugs)
					}
					// outside bottom
					if y == 4 {
						bugs = checkForBug(eris, layer-1, 2, 3, bugs)
					}
					// outside left
					if x == 0 {
						bugs = checkForBug(eris, layer-1, 1, 2, bugs)
					}
					// outside right
					if x == 4 {
						bugs = checkForBug(eris, layer-1, 3, 2, bugs)
					}
					// inside top
					if x == 2 && y == 1 {
						for thisX := 0; thisX < 5; thisX++ {
							bugs = checkForBug(eris, layer+1, thisX, 0, bugs)
						}
					}
					// inside bottom
					if x == 2 && y == 3 {
						for thisX := 0; thisX < 5; thisX++ {
							bugs = checkForBug(eris, layer+1, thisX, 4, bugs)
						}
					}
					// inside left
					if x == 1 && y == 2 {
						for thisY := 0; thisY < 5; thisY++ {
							bugs = checkForBug(eris, layer+1, 0, thisY, bugs)
						}
					}
					// inside right
					if x == 3 && y == 2 {
						for thisY := 0; thisY < 5; thisY++ {
							bugs = checkForBug(eris, layer+1, 4, thisY, bugs)
						}
					}

					newChar := eris[layerNumToIndex(layer)][y][x]
					if newChar == '#' && bugs != 1 {
						newChar = '.'
					} else if newChar == '.' && (bugs == 1 || bugs == 2) {
						newChar = '#'
					}
					if x == 2 && y == 2 {
						newChar = '.'
					}
					newLine = newLine + string(newChar)
				}
				newEris[layerNumToIndex(layer)][y] = newLine
			}
		}
		eris = newEris
	}
	// count the bugs
	totalBugs := 0
	for layer := -125; layer < 125; layer++ {
		for y := 0; y < 5; y++ {
			for x := 0; x < 5; x++ {
				if eris[layerNumToIndex(layer)][y][x] == '#' {
					totalBugs++
				}
			}
		}
	}
	fmt.Printf("Part 2: %d", totalBugs)

}

// returns new bug count after checking specified spot
func checkForBug(eris [250][5]string, layer, x, y, bugs int) int {
	if eris[layerNumToIndex(layer)][y][x] == '#' {
		return bugs + 1
	}
	return bugs
}

func boardToString(board [5]string) string {
	return board[0] + board[1] + board[2] + board[3] + board[4]
}
func layerNumToIndex(layer int) int {
	return layer + 125
}
func getEmptyEris() [250][5]string {
	var eris [250][5]string
	for i := 0; i < 250; i++ {
		for j := 0; j < 5; j++ {
			eris[i][j] = "....."
		}
	}
	return eris
}
