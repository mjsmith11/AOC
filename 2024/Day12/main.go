package main

import (
	"bufio"
	"fmt"
	"os"
)

var (
	used map[string]bool
	p    int
	a    int
	c    int
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	grid := readInput()
	used = make(map[string]bool, 0)
	total := 0
	for y, line := range grid {
		for x, r := range line {
			if !used[getXYString(x, y)] && r != 0 {
				p = 0
				a = 0
				explore(x, y, grid)
				total += p * a
			}
		}
	}
	return total
}

func explore(x, y int, grid [][]rune) {
	a++
	used[getXYString(x, y)] = true
	// up
	if grid[y][x] == grid[y-1][x] && !used[getXYString(x, y-1)] {
		explore(x, y-1, grid)
	} else if grid[y][x] != grid[y-1][x] {
		p++
	}
	//down
	if grid[y][x] == grid[y+1][x] && !used[getXYString(x, y+1)] {
		explore(x, y+1, grid)
	} else if grid[y][x] != grid[y+1][x] {
		p++
	}

	//left
	if grid[y][x] == grid[y][x-1] && !used[getXYString(x-1, y)] {
		explore(x-1, y, grid)
	} else if grid[y][x] != grid[y][x-1] {
		p++
	}

	//right
	if grid[y][x] == grid[y][x+1] && !used[getXYString(x+1, y)] {
		explore(x+1, y, grid)
	} else if grid[y][x] != grid[y][x+1] {
		p++
	}
}

func part2() int {
	grid := readInput()
	used = make(map[string]bool, 0)
	total := 0
	for y, line := range grid {
		for x, r := range line {
			if !used[getXYString(x, y)] && r != 0 {
				a = 0
				c = 0
				explore2(x, y, grid)
				total += a * c
			}
		}
	}
	return total
}

func explore2(x, y int, grid [][]rune) {
	a++
	used[getXYString(x, y)] = true
	neighbors := 0
	north := false
	south := false
	east := false
	west := false
	// up
	if grid[y][x] == grid[y-1][x] && !used[getXYString(x, y-1)] {
		explore2(x, y-1, grid)
	}
	//down
	if grid[y][x] == grid[y+1][x] && !used[getXYString(x, y+1)] {
		explore2(x, y+1, grid)
	}
	//left
	if grid[y][x] == grid[y][x-1] && !used[getXYString(x-1, y)] {
		explore2(x-1, y, grid)
	}

	//right
	if grid[y][x] == grid[y][x+1] && !used[getXYString(x+1, y)] {
		explore2(x+1, y, grid)
	}

	// up
	if grid[y][x] == grid[y-1][x] {
		north = true
		neighbors++
	}
	//down
	if grid[y][x] == grid[y+1][x] {
		south = true
		neighbors++
	}
	//left
	if grid[y][x] == grid[y][x-1] {
		west = true
		neighbors++
	}

	//right
	if grid[y][x] == grid[y][x+1] {
		east = true
		neighbors++
	}
	if grid[y][x] == 'A' {
	}
	if neighbors == 0 {
		c += 4
	} else if neighbors == 1 {
		c += 2

	} else if neighbors == 2 {
		c++
		if north && south {
			c--
		}
		if east && west {
			c--
		}
		if north && west && grid[y-1][x-1] != grid[y][x] && grid[y-1][x-1] != 0 {
			c++
		}
		if north && east && grid[y-1][x+1] != grid[y][x] && grid[y-1][x+1] != 0 {
			c++
		}
		if south && west && grid[y+1][x-1] != grid[y][x] && grid[y+1][x-1] != 0 {
			c++
		}
		if south && east && grid[y+1][x+1] != grid[y][x] && grid[y+1][x+1] != 0 {
			c++
		}
	} else if neighbors == 3 {
		if north && west && grid[y-1][x-1] != grid[y][x] && grid[y-1][x-1] != 0 {
			c++
		}
		if north && east && grid[y-1][x+1] != grid[y][x] && grid[y-1][x+1] != 0 {
			c++
		}
		if south && west && grid[y+1][x-1] != grid[y][x] && grid[y+1][x-1] != 0 {
			c++
		}
		if south && east && grid[y+1][x+1] != grid[y][x] && grid[y+1][x+1] != 0 {
			c++
		}
	} else {
		// 4
		if north && west && grid[y-1][x-1] != grid[y][x] && grid[y-1][x-1] != 0 {
			c++
		}
		if north && east && grid[y-1][x+1] != grid[y][x] && grid[y-1][x+1] != 0 {
			c++
		}
		if south && west && grid[y+1][x-1] != grid[y][x] && grid[y+1][x-1] != 0 {
			c++
		}
		if south && east && grid[y+1][x+1] != grid[y][x] && grid[y+1][x+1] != 0 {
			c++
		}
	}
}

func getXYString(x, y int) string {
	return fmt.Sprintf("%v,%v", x, y)
}

func readInput() [][]rune {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	scanner := bufio.NewScanner(f)
	strs := make([]string, 0)
	for scanner.Scan() {

		strs = append(strs, scanner.Text())
	}
	runes := make([][]rune, 0)
	for y := 0; y < len(strs)+2; y++ {
		line := make([]rune, 0)
		for x := 0; x < len(strs[0])+2; x++ {
			line = append(line, 0)
		}
		runes = append(runes, line)
	}
	for y, s := range strs {
		line := make([]rune, len(s)+2)
		for x, r := range s {
			line[x+1] = r
		}
		runes[y+1] = line
	}
	return runes
}
