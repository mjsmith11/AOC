package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	fmt.Println("Part 1:", part1())
	//fmt.Println("Part 2:", part2())
	//see comments above part2
	//202301 = (26501365+65)/131
	fmt.Println("Part 2:", model(202301))
}

func part1() int {
	grid := readInput()
	start := findStart(grid)
	locs := make(map[[2]int]int, 1)
	locs[start] = 0
	for steps := 0; steps < 64; steps++ {
		newLocs := make(map[[2]int]int, 1)
		for k, _ := range locs {
			if isOk(grid, k[1]+1, k[0]) {
				newLocs[[2]int{k[0], k[1] + 1}] = 0
			}
			if isOk(grid, k[1]-1, k[0]) {
				newLocs[[2]int{k[0], k[1] - 1}] = 0
			}
			if isOk(grid, k[1], k[0]+1) {
				newLocs[[2]int{k[0] + 1, k[1]}] = 0
			}
			if isOk(grid, k[1], k[0]-1) {
				newLocs[[2]int{k[0] - 1, k[1]}] = 0
			}
		}
		locs = newLocs
	}
	return len(locs)
}

func model(x int) int {
	return int(float64(3646) - float64(14699*x) + 14812*float64(x)*float64(x))
}

// turns out the the number of locations aligns to a quadratic curve (implemented in model) where x=(steps+66)/131
// 1 (65 steps),3759; 2(196 steps), 33496, 3(327 steps) 92857 , 4 (458 steps) 181842
func part2() int {
	grid := readInput()
	start := findStart(grid)
	locStart := &location{
		squareX: start[0],
		squareY: start[1],
		gridX:   0,
		gridY:   0,
	}
	locs := make(map[string]*location, 1)
	locs[locStart.String()] = locStart
	for steps := 0; steps < 196; steps++ {
		newLocs := make(map[string]*location, 1)
		for _, v := range locs {
			next := makeNewLoc(grid, v.squareX+1, v.squareY, v)
			if next != nil {
				newLocs[next.String()] = next
			}
			next = makeNewLoc(grid, v.squareX-1, v.squareY, v)
			if next != nil {
				newLocs[next.String()] = next
			}
			next = makeNewLoc(grid, v.squareX, v.squareY+1, v)
			if next != nil {
				newLocs[next.String()] = next
			}
			next = makeNewLoc(grid, v.squareX, v.squareY-1, v)
			if next != nil {
				newLocs[next.String()] = next
			}
		}
		locs = newLocs
		fmt.Println(steps+1, len(locs))
	}
	return len(locs)
}

type location struct {
	squareX int
	squareY int
	gridX   int
	gridY   int
}

func (l *location) String() string {
	return fmt.Sprint(l.squareX, l.squareY, l.gridX, l.gridY)
}

func isOk(g []string, x, y int) bool {
	if x < 0 {
		return false
	}
	if y < 0 {
		return false
	}
	if y >= len(g) {
		return false
	}
	if x >= len(g[0]) {
		return false
	}
	if g[y][x] == '#' {
		return false
	}
	return true
}

func makeNewLoc(g []string, x, y int, old *location) *location {
	checkX, checkY := x, y
	if checkX < 0 {
		checkX = len(g[0]) - 1
	}
	if checkY < 0 {
		checkY = len(g) - 1
	}
	if checkX == len(g[0]) {
		checkX = 0
	}
	if checkY == len(g) {
		checkY = 0
	}
	if g[checkY][checkX] == '#' {
		return nil
	}
	if x < 0 {
		return &location{
			squareX: len(g[0]) - 1,
			squareY: y,
			gridX:   old.gridX - 1,
			gridY:   old.gridY,
		}
	}
	if y < 0 {
		return &location{
			squareX: x,
			squareY: len(g) - 1,
			gridX:   old.gridX,
			gridY:   old.gridY - 1,
		}
	}
	if y >= len(g) {
		return &location{
			squareX: x,
			squareY: 0,
			gridX:   old.gridX,
			gridY:   old.gridY + 1,
		}
	}
	if x >= len(g[0]) {
		return &location{
			squareX: 0,
			squareY: y,
			gridX:   old.gridX + 1,
			gridY:   old.gridY,
		}
	}
	return &location{
		squareX: x,
		squareY: y,
		gridX:   old.gridX,
		gridY:   old.gridY,
	}
}

func findStart(g []string) [2]int {
	for y, s := range g {
		for x, r := range s {
			if r == 'S' {
				return [2]int{x, y}
			}
		}
	}
	panic(g)
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	grid := make([]string, 0)
	for scanner.Scan() {
		t := scanner.Text()
		grid = append(grid, t)
	}

	return grid
}
