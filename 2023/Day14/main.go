package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {
	fmt.Println("Part 1", part1())
	fmt.Println("Part 2", part2())
}
func part1() int {
	grid := readInput()
	grid = tiltNorth(grid)
	return calculateLoad(grid)
}
func part2() int {
	// detect a cycle
	grid := readInput()
	hist := make(map[string]int, 0) //grid->iteration
	lastDiff := 1
	for i := 0; i < 200; i++ { // iterations is a guess on how many it will take for the cycle to stabilize
		grid = cycle(grid)
		if lastIter, ok := hist[toString(grid)]; ok {
			lastDiff = i - lastIter
		}
		hist[toString(grid)] = i
	}

	// run some rounds based on the cycle to find the load @ 1B
	// this could be done in the above loop to be efficient
	roundsNeeded := 1000000000%lastDiff + lastDiff // run an extra in case it doesn't stabilize right away
	grid = readInput()
	for i := 0; i < roundsNeeded; i++ {
		grid = cycle(grid)
	}

	return calculateLoad(grid)
}
func toString(g [][]rune) string {
	var sb strings.Builder
	for _, ra := range g {
		sb.WriteString(string(ra))
	}
	return sb.String()
}
func printGrid(g [][]rune) {
	for _, line := range g {
		for _, r := range line {
			fmt.Print(string(r))
		}
		fmt.Println()
	}
	fmt.Println()
}
func calculateLoad(grid [][]rune) int {
	load := 0
	height := len(grid)
	for y := 0; y < len(grid); y++ {
		for x := 0; x < len(grid[y]); x++ {
			if grid[y][x] == 'O' {
				load += height - y
			}
		}
	}
	return load
}
func cycle(grid [][]rune) [][]rune {
	grid = tiltNorth(grid)
	grid = tiltWest(grid)
	grid = tiltSouth(grid)
	return tiltEast(grid)
}
func tiltNorth(grid [][]rune) [][]rune {
	for y := 0; y < len(grid); y++ {
		for x := 0; x < len(grid[y]); x++ {
			if grid[y][x] == 'O' {
				// find the spot
				newY := y
				for lookY := y - 1; lookY >= 0; lookY-- {
					if grid[lookY][x] == '.' {
						newY = lookY
					} else {
						break
					}
				}
				if newY != y {
					grid[newY][x] = 'O'
					grid[y][x] = '.'
				}
			}
		}
	}
	return grid
}
func tiltSouth(grid [][]rune) [][]rune {
	for y := len(grid) - 1; y >= 0; y-- {
		for x := 0; x < len(grid[y]); x++ {
			if grid[y][x] == 'O' {
				// find the spot
				newY := y
				for lookY := y + 1; lookY < len(grid); lookY++ {
					if grid[lookY][x] == '.' {
						newY = lookY
					} else {
						break
					}
				}
				if newY != y {
					grid[newY][x] = 'O'
					grid[y][x] = '.'
				}
			}
		}
	}
	return grid
}
func tiltWest(grid [][]rune) [][]rune {
	for x := 0; x < len(grid[0]); x++ {
		for y := 0; y < len(grid); y++ {
			if grid[y][x] == 'O' {
				// find the spot
				newX := x
				for lookX := x - 1; lookX >= 0; lookX-- {
					if grid[y][lookX] == '.' {
						newX = lookX
					} else {
						break
					}
				}
				if newX != x {
					grid[y][newX] = 'O'
					grid[y][x] = '.'
				}
			}
		}
	}
	return grid
}

func tiltEast(grid [][]rune) [][]rune {
	for x := len(grid[0]) - 1; x >= 0; x-- {
		for y := 0; y < len(grid); y++ {
			if grid[y][x] == 'O' {
				// find the spot
				newX := x
				for lookX := x + 1; lookX < len(grid[0]); lookX++ {
					if grid[y][lookX] == '.' {
						newX = lookX
					} else {
						break
					}
				}
				if newX != x {
					grid[y][newX] = 'O'
					grid[y][x] = '.'
				}
			}
		}
	}
	return grid
}
func readInput() [][]rune {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	grid := make([][]rune, 0)

	for scanner.Scan() {
		text := scanner.Text()
		grid = append(grid, []rune(text))
	}

	return grid
}
