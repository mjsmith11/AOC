package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {
	fmt.Println("Part 1", run(eval))
	fmt.Println("Part 2", run(eval2))
}
func run(evalFunc func([]string) int) int {
	grids := readInput()
	total := 0
	for _, g := range grids {
		total += evalFunc(g)
	}
	return total
}

func eval(grid []string) int {
	return 100*evalHorizontal(grid) + evalVertcal(grid)
}

func evalVertcal(grid []string) int {
	rotatedGrid := make([]string, 0)
	for c := 0; c < len(grid[0]); c++ {
		var sb strings.Builder
		for r := 0; r < len(grid); r++ {
			sb.WriteRune(rune(grid[r][c]))
		}
		rotatedGrid = append(rotatedGrid, sb.String())
	}
	amt := evalHorizontal(rotatedGrid)
	return amt
}

func evalHorizontal(grid []string) int {
	for topStart := 0; topStart < len(grid)-1; topStart++ {
		bottomStart := topStart + 1
		top := topStart
		good := true
		for top >= 0 && bottomStart < len(grid) {
			if grid[top] != grid[bottomStart] {
				good = false
				break
			}
			top--
			bottomStart++
		}
		if good {
			return topStart + 1
		}
	}
	return 0
}

// kinda stole this from reddit ¯\_(ツ)_/¯
func eval2(grid []string) int {
	width := len(grid[0])
	height := len(grid)
	for x := 1; x < width; x++ {
		isSymmetrical := true
		faults := 0
		for y := 0; y < height; y++ {
			for sx := 0; sx < x && (x+sx) < width; sx++ {
				if grid[y][x-1-sx] != grid[y][x+sx] {
					isSymmetrical = false
					faults++
				}
			}
		}
		if !isSymmetrical && faults == 1 {
			return x
		}
	}

	for y := 1; y < height; y++ {
		isSymmetrical := true
		faults := 0
		for x := 0; x < width; x++ {
			for sy := 0; sy < y && (y+sy) < height; sy++ {
				if grid[y-1-sy][x] != grid[y+sy][x] {
					isSymmetrical = false
					faults++
				}
			}
		}
		if !isSymmetrical && faults == 1 {
			return y * 100
		}
	}
	fmt.Println("Not supposed to get here")
	return 0
}

func readInput() [][]string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	grids := make([][]string, 0)
	grid := make([]string, 0)
	for scanner.Scan() {
		text := scanner.Text()
		if text == "" {
			grids = append(grids, grid)
			grid = make([]string, 0)
		} else {
			grid = append(grid, text)
		}
	}
	grids = append(grids, grid)
	return grids
}
