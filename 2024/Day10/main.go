package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

var (
	reachable map[string]bool
	found     int
)

func main() {
	p1, p2 := run()
	fmt.Println("Part 1:", p1)
	fmt.Println("Part 2:", p2)
}

func run() (int, int) {
	p1total := 0
	found = 0
	grid := readInput()
	for y := 0; y < len(grid); y++ {
		for x := 0; x < len(grid[y]); x++ {
			if grid[y][x] == 0 {
				reachable = make(map[string]bool, 0)
				search(grid, x, y)
				p1total += len(reachable)
			}
		}
	}

	return p1total, found
}

func search(grid [][]int, x, y int) {
	next := grid[y][x] + 1
	if next == 10 {
		reachable[fmt.Sprintf("%v,%v", x, y)] = true
		found++
		return
	}
	// up
	if y > 0 && grid[y-1][x] == next {
		search(grid, x, y-1)
	}
	// down
	if y < len(grid)-1 && grid[y+1][x] == next {
		search(grid, x, y+1)
	}
	//left
	if x > 0 && grid[y][x-1] == next {
		search(grid, x-1, y)
	}
	//right
	if x < len(grid[y])-1 && grid[y][x+1] == next {
		search(grid, x+1, y)
	}
}

func readInput() [][]int {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	grid := make([][]int, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		row := make([]int, 0)
		for _, r := range scanner.Text() {
			if r == '.' {
				row = append(row, -1)
			} else {
				i, err := strconv.Atoi(string(r))
				if err != nil {
					panic(err)
				}
				row = append(row, i)
			}
		}
		grid = append(grid, row)
	}
	return grid
}
