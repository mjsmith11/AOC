package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"unicode"
)

func main() {
	fmt.Println("Part 1 ", part1())
	fmt.Println("Part 2 ", part2())
}

func part1() int {
	grid := readInput()
	ySize := len(grid)
	xSize := len(grid[0])
	total := 0
	for y, str := range grid {
		for x := 0; x < xSize; {
			if unicode.IsDigit(rune(str[x])) {
				numStr := ""
				numStart := x
				for x < xSize && unicode.IsDigit(rune(str[x])) {
					numStr += string(str[x])
					x++
				}
				numStop := x - 1
				if isPartNum(grid, y, numStart, numStop, xSize, ySize) {
					num, err := strconv.Atoi(numStr)
					if err != nil {
						panic(err)
					}
					total += num
				}
			} else {
				x++
			}
		}
	}
	return total
}

func part2() int {
	grid := readInput()
	ySize := len(grid)
	xSize := len(grid[0])
	partsAtGear := make(map[int][]int, 0)
	for y, str := range grid {
		for x := 0; x < xSize; {
			if unicode.IsDigit(rune(str[x])) {
				numStr := ""
				numStart := x
				for x < xSize && unicode.IsDigit(rune(str[x])) {
					numStr += string(str[x])
					x++
				}
				numStop := x - 1
				if gear := findAdjacentGear(grid, y, numStart, numStop, xSize, ySize); gear != -1 {
					num, err := strconv.Atoi(numStr)
					if err != nil {
						panic(err)
					}
					partsAtGear[gear] = append(partsAtGear[gear], num)
				}
			} else {
				x++
			}
		}
	}
	total := 0
	for _, v := range partsAtGear {
		if len(v) == 2 {
			total += (v[0] * v[1])
		}
	}
	return total
}

func isPartNum(grid []string, numRow, numStart, numStop, maxX, maxY int) bool {
	lookStart := numStart - 1
	if lookStart < 0 {
		lookStart = 0
	}
	lookStop := numStop + 1
	if lookStop == maxX {
		lookStop--
	}
	// top
	if numRow > 0 {
		for l := lookStart; l <= lookStop; l++ {
			if grid[numRow-1][l] != '.' && !unicode.IsDigit(rune(grid[numRow-1][l])) {
				return true
			}
		}
	}
	// bottom
	if numRow+1 < maxY {
		for l := lookStart; l <= lookStop; l++ {
			if grid[numRow+1][l] != '.' && !unicode.IsDigit(rune(grid[numRow+1][l])) {
				return true
			}
		}
	}
	// left
	if numStart > 0 {
		if grid[numRow][numStart-1] != '.' && !unicode.IsDigit(rune(grid[numRow][numStart-1])) {
			return true
		}
	}
	// right
	if numStop+1 < maxX {
		if grid[numRow][numStop+1] != '.' && !unicode.IsDigit(rune(grid[numRow][numStop+1])) {
			return true
		}
	}
	return false
}

// returns adjacent gear location as 150*x + y or -1 for none foune
func findAdjacentGear(grid []string, numRow, numStart, numStop, maxX, maxY int) int {
	lookStart := numStart - 1
	if lookStart < 0 {
		lookStart = 0
	}
	lookStop := numStop + 1
	if lookStop == maxX {
		lookStop--
	}
	// top
	if numRow > 0 {
		for l := lookStart; l <= lookStop; l++ {
			if grid[numRow-1][l] == '*' {
				return 150*l + numRow - 1
			}
		}
	}
	// bottom
	if numRow+1 < maxY {
		for l := lookStart; l <= lookStop; l++ {
			if grid[numRow+1][l] == '*' {
				return 150*l + numRow + 1
			}
		}
	}
	// left
	if numStart > 0 {
		if grid[numRow][numStart-1] == '*' {
			return 150*(numStart-1) + numRow
		}
	}
	// right
	if numStop+1 < maxX {
		if grid[numRow][numStop+1] == '*' {
			return 150*(numStop+1) + numRow
		}
	}
	return -1
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	grid := make([]string, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		s := scanner.Text()
		grid = append(grid, s)
	}
	return grid
}
