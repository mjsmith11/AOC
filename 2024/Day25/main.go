package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	fmt.Println("Part 1:", part1())
}
func part1() int {
	keys := make([][]int, 0)
	locks := make([][]int, 0)
	grids := readInput()
	for _, grid := range grids {
		if grid[0][0] == '.' {
			keys = append(keys, getColHeights(grid))
		} else {
			locks = append(locks, getColHeights(grid))
		}
	}
	fits := 0
	limit := len(grids[0])
	for _, k := range keys {
		for _, l := range locks {
			ok := true
			for i, kv := range k {
				lv := l[i]
				if kv+lv > limit {
					ok = false
					break
				}
			}
			if ok {
				fits++
			}
		}
	}
	return fits
}

func getColHeights(grid []string) []int {
	heights := make([]int, 0)
	for x := 0; x < len(grid[0]); x++ {
		h := 0
		for y := 0; y < len(grid); y++ {
			if grid[y][x] == '#' {
				h++
			}
		}
		heights = append(heights, h)
	}
	return heights
}

func readInput() [][]string {
	grids := make([][]string, 0)

	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	grid := make([]string, 0)
	for scanner.Scan() {

		if scanner.Text() == "" {
			grids = append(grids, grid)
			grid = make([]string, 0)
		} else {
			grid = append(grid, scanner.Text())
		}
	}
	grids = append(grids, grid)
	return grids
}
