package main

import (
	"bufio"
	"fmt"
	"os"
	"regexp"
	"strings"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	grid := readInput()
	return countStrings(grid) + countStrings(buildVerticalGrid(grid)) + countStrings(buildDownhillDiags(grid)) + countStrings(buildUphillDiags(grid))
}

func part2() int {
	grid := readInput()
	ySize := len(grid)
	xSize := len(grid[0])
	total := 0
	for y := 0; y < ySize; y++ {
		for x := 0; x < xSize; x++ {
			if evalSpot(grid, x, y) {
				total++
			}
		}
	}

	return total
}

func evalSpot(grid []string, x, y int) bool {
	ySize := len(grid)
	xSize := len(grid[0])
	if grid[y][x] != 'A' {
		return false
	}
	if x == 0 {
		return false
	}
	if y == 0 {
		return false
	}
	if x == xSize-1 {
		return false
	}
	if y == ySize-1 {
		return false
	}
	adj1 := grid[y-1][x-1]
	adj2 := grid[y+1][x+1]
	if !((adj1 == 'M' && adj2 == 'S') || (adj1 == 'S') && (adj2 == 'M')) {
		return false
	}
	adj1 = grid[y+1][x-1]
	adj2 = grid[y-1][x+1]
	if !((adj1 == 'M' && adj2 == 'S') || (adj1 == 'S') && (adj2 == 'M')) {
		return false
	}
	return true
}

func countStrings(inp []string) int {
	total := 0
	for _, s := range inp {
		total += countString(s)
	}
	return total
}

func countString(inp string) int {
	re := regexp.MustCompile("(XMAS)|(SAMX)")
	matches := 0
	start := 0
	for start < len(inp) {
		m := re.FindStringIndex(inp[start:])
		if m != nil {
			matches++
			start = m[0] + 1 + start
		} else {
			break
		}
	}
	return matches
}

func buildVerticalGrid(grid []string) []string {
	ySize := len(grid)
	xSize := len(grid[0])
	out := make([]string, 0)
	for x := 0; x < xSize; x++ {
		var sb strings.Builder
		for y := 0; y < ySize; y++ {
			sb.WriteByte(grid[y][x])
		}
		out = append(out, sb.String())
	}
	return out
}

func buildUphillDiags(grid []string) []string {
	ySize := len(grid)
	xSize := len(grid[0])
	out := make([]string, 0)
	//top left to bottom left
	for startY := 0; startY < ySize; startY++ {
		x := 0
		y := startY
		var sb strings.Builder
		for y >= 0 && x < xSize {
			sb.WriteByte(grid[y][x])
			x++
			y--
		}
		out = append(out, sb.String())
	}
	//bottom left to bottom right
	for startX := 1; startX < xSize; startX++ {
		x := startX
		y := ySize - 1
		var sb strings.Builder
		for y >= 0 && x < xSize {
			sb.WriteByte(grid[y][x])
			x++
			y--
		}
		out = append(out, sb.String())
	}
	return out
}

func buildDownhillDiags(grid []string) []string {
	ySize := len(grid)
	xSize := len(grid[0])
	out := make([]string, 0)
	// top right to bottom right
	for startY := 0; startY < ySize; startY++ {
		x := xSize - 1
		y := startY
		var sb strings.Builder
		for y >= 0 && x >= 0 {
			sb.WriteByte(grid[y][x])
			x--
			y--
		}
		out = append(out, sb.String())
	}
	//  bottom left to bottom right
	for startX := 0; startX < xSize-1; startX++ {
		x := startX
		y := ySize - 1
		var sb strings.Builder
		for y >= 0 && x >= 0 {
			sb.WriteByte(grid[y][x])
			x--
			y--
		}
		out = append(out, sb.String())
	}
	return out
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	strs := make([]string, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		strs = append(strs, scanner.Text())
	}
	return strs
}
