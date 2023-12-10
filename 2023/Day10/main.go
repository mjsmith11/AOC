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
	grid := readInput()
	yLen := len(grid)
	xLen := len(grid[0])
	x, y := findChar(grid, 'S')
	startX, startY := x, y
	length := 1
	lastDir := ""
	for {
		if y > 0 && (grid[y-1][x] == '|' || grid[y-1][x] == '7' || grid[y-1][x] == 'F' || grid[y-1][x] == 'S') &&
			(grid[y][x] == '|' || grid[y][x] == 'L' || grid[y][x] == 'J' || grid[y][x] == 'S') &&
			lastDir != "south" {
			// go north
			lastDir = "north"
			y--
		} else if (y+1) < yLen && (grid[y+1][x] == '|' || grid[y+1][x] == 'L' || grid[y+1][x] == 'J' || grid[y+1][x] == 'S') &&
			(grid[y][x] == '|' || grid[y][x] == 'F' || grid[y][x] == '7' || grid[y][x] == 'S') &&
			lastDir != "north" {
			// go south
			lastDir = "south"
			y++
		} else if (x+1) < xLen && (grid[y][x+1] == '-' || grid[y][x+1] == '7' || grid[y][x+1] == 'J' || grid[y][x+1] == 'S') &&
			(grid[y][x] == '-' || grid[y][x] == 'F' || grid[y][x] == 'L' || grid[y][x] == 'S') &&
			lastDir != "west" {
			// go east
			lastDir = "east"
			x++
		} else if x > 0 && (grid[y][x-1] == '-' || grid[y][x-1] == 'F' || grid[y][x-1] == 'L' || grid[y][x-1] == 'S') &&
			(grid[y][x] == '-' || grid[y][x] == '7' || grid[y][x] == 'J' || grid[y][x] == 'S') &&
			lastDir != "east" {
			// go west
			lastDir = "west"
			x--
		} else {
			fmt.Println("Cannot move")
			break
		}

		if x == startX && y == startY {
			break
		}
		length++
	}
	return length / 2
}
func part2() int {
	// each tile becomes 3x3 to make the flood easy since we need to flood
	// between directly adjacent pipes.  Flood outside, then count 3x3s with
	// no flooding as 1 tile
	grid := readInput2()

	var myX, myY int
	// find a zero to start
	for y, row := range grid {
		for x, n := range row {
			if n == 0 {
				myX, myY = x, y
				break
			}
		}
	}
	yMax := len(grid)
	xMax := len(grid[0])
	flood(myX, myY, xMax, yMax, grid)

	interiorLocations := 0
	for y := 0; y < yMax; y += 3 {
		for x := 0; x < xMax; x += 3 {
			if isEnclosed(x, y, grid) {
				interiorLocations++
			}
		}
	}
	return interiorLocations
}

func isEnclosed(x, y int, grid [][]int) bool {
	saw0 := false
	saw2 := false
	for iy := y; iy < y+3; iy++ {
		for ix := x; ix < x+3; ix++ {
			if grid[iy][ix] == 0 {
				saw0 = true
			}
			if grid[iy][ix] == 2 {
				saw2 = true
			}
		}
	}
	return (saw0 && !saw2)
}

func flood(x, y, xMax, yMax int, grid [][]int) {
	if x >= 0 && y >= 0 && x < xMax && y < yMax && grid[y][x] == 0 {
		grid[y][x] = 2
		flood(x-1, y, xMax, yMax, grid)
		flood(x+1, y, xMax, yMax, grid)
		flood(x, y-1, xMax, yMax, grid)
		flood(x, y+1, xMax, yMax, grid)
	}
}

func findChar(grid []string, target rune) (int, int) {
	for y, s := range grid {
		for x, c := range s {
			if c == target {
				return x, y
			}
		}
	}
	return -1, -1
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	strs := make([]string, 0)
	for scanner.Scan() {
		strs = append(strs, scanner.Text())
	}
	return strs
}

func readInput2() [][]int {
	grid := readInput()
	ylen := len(grid)
	xlen := len(grid[0])

	intGrid := make([][]int, 3*ylen)
	for y := 0; y < 3*ylen; y++ {
		intGrid[y] = make([]int, 3*xlen)
	}
	for y, s := range grid {
		for x, c := range s {
			if c == '|' {
				intGrid[3*y][3*x] = 0
				intGrid[3*y][3*x+1] = 1
				intGrid[3*y][3*x+2] = 0

				intGrid[3*y+1][3*x] = 0
				intGrid[3*y+1][3*x+1] = 1
				intGrid[3*y+1][3*x+2] = 0

				intGrid[3*y+2][3*x] = 0
				intGrid[3*y+2][3*x+1] = 1
				intGrid[3*y+2][3*x+2] = 0
			} else if c == '-' {
				intGrid[3*y][3*x] = 0
				intGrid[3*y][3*x+1] = 0
				intGrid[3*y][3*x+2] = 0

				intGrid[3*y+1][3*x] = 1
				intGrid[3*y+1][3*x+1] = 1
				intGrid[3*y+1][3*x+2] = 1

				intGrid[3*y+2][3*x] = 0
				intGrid[3*y+2][3*x+1] = 0
				intGrid[3*y+2][3*x+2] = 0

			} else if c == 'L' {
				intGrid[3*y][3*x] = 0
				intGrid[3*y][3*x+1] = 1
				intGrid[3*y][3*x+2] = 0

				intGrid[3*y+1][3*x] = 0
				intGrid[3*y+1][3*x+1] = 1
				intGrid[3*y+1][3*x+2] = 1

				intGrid[3*y+2][3*x] = 0
				intGrid[3*y+2][3*x+1] = 0
				intGrid[3*y+2][3*x+2] = 0
			} else if c == 'J' {
				intGrid[3*y][3*x] = 0
				intGrid[3*y][3*x+1] = 1
				intGrid[3*y][3*x+2] = 0

				intGrid[3*y+1][3*x] = 1
				intGrid[3*y+1][3*x+1] = 1
				intGrid[3*y+1][3*x+2] = 0

				intGrid[3*y+2][3*x] = 0
				intGrid[3*y+2][3*x+1] = 0
				intGrid[3*y+2][3*x+2] = 0
			} else if c == '7' {
				intGrid[3*y][3*x] = 0
				intGrid[3*y][3*x+1] = 0
				intGrid[3*y][3*x+2] = 0

				intGrid[3*y+1][3*x] = 1
				intGrid[3*y+1][3*x+1] = 1
				intGrid[3*y+1][3*x+2] = 0

				intGrid[3*y+2][3*x] = 0
				intGrid[3*y+2][3*x+1] = 1
				intGrid[3*y+2][3*x+2] = 0
			} else if c == 'F' {
				intGrid[3*y][3*x] = 0
				intGrid[3*y][3*x+1] = 0
				intGrid[3*y][3*x+2] = 0

				intGrid[3*y+1][3*x] = 0
				intGrid[3*y+1][3*x+1] = 1
				intGrid[3*y+1][3*x+2] = 1

				intGrid[3*y+2][3*x] = 0
				intGrid[3*y+2][3*x+1] = 1
				intGrid[3*y+2][3*x+2] = 0
			} else if c == 'S' {
				intGrid[3*y][3*x] = 0
				intGrid[3*y][3*x+1] = 1
				intGrid[3*y][3*x+2] = 0

				intGrid[3*y+1][3*x] = 1
				intGrid[3*y+1][3*x+1] = 1
				intGrid[3*y+1][3*x+2] = 1

				intGrid[3*y+2][3*x] = 0
				intGrid[3*y+2][3*x+1] = 1
				intGrid[3*y+2][3*x+2] = 0
			} else {
				intGrid[3*y][3*x] = 0
				intGrid[3*y][3*x+1] = 0
				intGrid[3*y][3*x+2] = 0

				intGrid[3*y+1][3*x] = 0
				intGrid[3*y+1][3*x+1] = 0
				intGrid[3*y+1][3*x+2] = 0

				intGrid[3*y+2][3*x] = 0
				intGrid[3*y+2][3*x+1] = 0
				intGrid[3*y+2][3*x+2] = 0
			}
		}
	}
	return intGrid
}
