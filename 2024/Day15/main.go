package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	grid, moves := readInput()
	x, y := findRobot(grid)
	for _, r := range moves {
		if r == '<' {
			if moveLeft(grid, x, y) {
				x--
			}
		} else if r == '>' {
			if moveRight(grid, x, y) {
				x++
			}
		} else if r == 'v' {
			if moveDown(grid, x, y) {
				y++
			}
		} else if r == '^' {
			if moveUp(grid, x, y) {
				y--
			}
		} else {
			panic("shit")
		}
	}

	return score(grid)
}

func part2() int {
	grid, moves := readInput()
	newGrid := make([][]rune, 0)
	for _, line := range grid {
		newLine := make([]rune, 0)
		for _, r := range line {
			if r == '.' {
				newLine = append(newLine, '.')
				newLine = append(newLine, '.')
			} else if r == 'O' {
				newLine = append(newLine, '[')
				newLine = append(newLine, ']')
			} else if r == '#' {
				newLine = append(newLine, '#')
				newLine = append(newLine, '#')
			} else {
				newLine = append(newLine, '@')
				newLine = append(newLine, '.')
			}
		}
		newGrid = append(newGrid, newLine)
	}
	grid = newGrid
	x, y := findRobot(grid)
	for _, r := range moves {
		if r == '<' {
			if moveLeft(grid, x, y) {
				x--
			}
		} else if r == '>' {
			if moveRight(grid, x, y) {
				x++
			}
		} else if r == 'v' {
			if moveDown2(grid, x, y, true) {
				y++
			}
		} else if r == '^' {
			if moveUp2(grid, x, y, true) {
				y--
			}
		} else {
			panic("shit")
		}
	}
	return score2(grid)
}

func score(grid [][]rune) int {
	total := 0
	for y, line := range grid {
		for x, r := range line {
			if r == 'O' {
				total += (100*y + x)
			}
		}
	}
	return total
}

func score2(grid [][]rune) int {
	total := 0
	for y, line := range grid {
		for x, r := range line {
			if r == '[' {
				total += (100*y + x)
			}
		}
	}
	return total
}

func moveRight(grid [][]rune, rx, ry int) bool {
	canMove := false
	x := rx + 1
	for grid[ry][x] != '#' {
		if grid[ry][x] == '.' {
			canMove = true
			break
		}
		x++
	}
	if canMove {
		for ix := x; ix > rx; ix-- {
			grid[ry][ix] = grid[ry][ix-1]
		}
		grid[ry][rx] = '.'
	}
	return canMove
}

func moveLeft(grid [][]rune, rx, ry int) bool {
	canMove := false
	x := rx - 1
	for grid[ry][x] != '#' {
		if grid[ry][x] == '.' {
			canMove = true
			break
		}
		x--
	}
	if canMove {
		for ix := x; ix < rx; ix++ {
			grid[ry][ix] = grid[ry][ix+1]
		}
		grid[ry][rx] = '.'
	}
	return canMove
}

func moveUp(grid [][]rune, rx, ry int) bool {
	canMove := false
	y := ry - 1
	for grid[y][rx] != '#' {
		if grid[y][rx] == '.' {
			canMove = true
			break
		}
		y--
	}
	if canMove {
		for iy := y; iy < ry; iy++ {
			grid[iy][rx] = grid[iy+1][rx]
		}
		grid[ry][rx] = '.'
	}
	return canMove
}

func moveDown2(grid [][]rune, rx, ry int, live bool) bool {
	if grid[ry][rx] == '.' {
		return true
	}
	canMove := false
	if grid[ry][rx] == '[' {
		if grid[ry+1][rx] == '#' || grid[ry+1][rx+1] == '#' {
			return false
		}
		if grid[ry+1][rx] == '.' && grid[ry+1][rx+1] == '.' {
			canMove = true
		} else {
			if moveDown2(grid, rx, ry+1, false) && moveDown2(grid, rx+1, ry+1, false) {
				moveDown2(grid, rx, ry+1, live)
				moveDown2(grid, rx+1, ry+1, live)
				canMove = true
			}
		}
	} else if grid[ry][rx] == ']' {
		if grid[ry+1][rx] == '#' || grid[ry+1][rx-1] == '#' {
			return false
		}
		if grid[ry+1][rx] == '.' && grid[ry+1][rx-1] == '.' {
			canMove = true
		} else {
			if moveDown2(grid, rx, ry+1, false) && moveDown2(grid, rx-1, ry+1, false) {
				moveDown2(grid, rx, ry+1, live)
				moveDown2(grid, rx-1, ry+1, live)
				canMove = true
			}
		}
	} else {
		if grid[ry+1][rx] == '#' {
			return false
		}
		canMove = grid[ry+1][rx] == '.' || moveDown2(grid, rx, ry+1, live)
	}

	if canMove && live {
		if grid[ry][rx] == '[' {
			grid[ry+1][rx] = '['
			grid[ry+1][rx+1] = ']'
			grid[ry][rx] = '.'
			grid[ry][rx+1] = '.'
		} else if grid[ry][rx] == ']' {
			grid[ry+1][rx] = ']'
			grid[ry+1][rx-1] = '['
			grid[ry][rx] = '.'
			grid[ry][rx-1] = '.'
		} else {
			grid[ry+1][rx] = grid[ry][rx]
			grid[ry][rx] = '.'
		}
	}
	return canMove
}

func moveUp2(grid [][]rune, rx, ry int, live bool) bool {
	if grid[ry][rx] == '.' {
		return true
	}
	canMove := false
	if grid[ry][rx] == '[' {
		if grid[ry-1][rx] == '#' || grid[ry-1][rx+1] == '#' {
			return false
		}
		if grid[ry-1][rx] == '.' && grid[ry-1][rx+1] == '.' {
			canMove = true
		} else {
			if moveUp2(grid, rx, ry-1, false) && moveUp2(grid, rx+1, ry-1, false) {
				moveUp2(grid, rx, ry-1, live)
				moveUp2(grid, rx+1, ry-1, live)
				canMove = true
			}
		}
	} else if grid[ry][rx] == ']' {
		if grid[ry-1][rx] == '#' || grid[ry-1][rx-1] == '#' {
			return false
		}
		if grid[ry-1][rx] == '.' && grid[ry-1][rx-1] == '.' {
			canMove = true
		} else {
			if moveUp2(grid, rx, ry-1, false) && moveUp2(grid, rx-1, ry-1, false) {
				moveUp2(grid, rx, ry-1, live)
				moveUp2(grid, rx-1, ry-1, live)
				canMove = true
			}
		}
	} else {
		if grid[ry-1][rx] == '#' {
			return false
		}
		canMove = grid[ry-1][rx] == '.' || moveUp2(grid, rx, ry-1, live)
	}

	if canMove && live {
		if grid[ry][rx] == '[' {
			grid[ry-1][rx] = '['
			grid[ry-1][rx+1] = ']'
			grid[ry][rx] = '.'
			grid[ry][rx+1] = '.'
		} else if grid[ry][rx] == ']' {
			grid[ry-1][rx] = ']'
			grid[ry-1][rx-1] = '['
			grid[ry][rx] = '.'
			grid[ry][rx-1] = '.'
		} else {
			grid[ry-1][rx] = grid[ry][rx]
			grid[ry][rx] = '.'
		}
	}
	return canMove
}

func moveDown(grid [][]rune, rx, ry int) bool {
	canMove := false
	y := ry + 1
	for grid[y][rx] != '#' {
		if grid[y][rx] == '.' {
			canMove = true
			break
		}
		y++
	}
	if canMove {
		for iy := y; iy > ry; iy-- {
			grid[iy][rx] = grid[iy-1][rx]
		}
		grid[ry][rx] = '.'
	}
	return canMove
}

func dumpGrid(grid [][]rune) {
	for _, line := range grid {
		for _, r := range line {
			fmt.Print(string(r))
		}
		fmt.Println()
	}
	fmt.Println()
}

func findRobot(grid [][]rune) (int, int) {
	for y, line := range grid {
		for x, r := range line {
			if r == '@' {
				return x, y
			}
		}
	}
	return -1, -1
}

func readInput() ([][]rune, string) {
	f, err := os.Open("map.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	grid := make([][]rune, 0)

	for scanner.Scan() {
		line := make([]rune, 0)
		for _, r := range scanner.Text() {
			line = append(line, r)
		}
		grid = append(grid, line)
	}

	f, err = os.Open("moves.txt")
	if err != nil {
		panic(err)
	}
	scanner = bufio.NewScanner(f)
	defer f.Close()
	scanner.Scan()
	return grid, scanner.Text()
}
