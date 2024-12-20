package main

import (
	"bufio"
	"fmt"
	"os"
)

var (
	size    = 71
	q       []*state
	visited map[string]int
	last    map[string]string
)

func main() {
	fmt.Println("Part 1:", run(2))
	fmt.Println("Part 2:", run(20))
}

func run(shortCutMaxSize int) int {
	grid := readInput()
	findPathCost(grid)
	cheats := make(map[int]int)
	for scStartY, line := range grid {
		for scStartX, _ := range line {
			for scEndY := scStartY - shortCutMaxSize; scEndY <= scStartY+shortCutMaxSize; scEndY++ {
				for scEndX := scStartX - shortCutMaxSize; scEndX <= scStartX+shortCutMaxSize; scEndX++ {
					if ok, length := isValidShortcut(scStartX, scStartY, scEndX, scEndY, grid, shortCutMaxSize); ok {
						endState := state{
							x: scEndX,
							y: scEndY,
						}
						startState := state{
							x: scStartX,
							y: scStartY,
						}
						oldCost := visited[endState.String()]
						newCost := visited[startState.String()] + length
						cheats[oldCost-newCost]++
					}
				}
			}
		}
	}
	ans := 0
	for k, v := range cheats {
		if k >= 100 {
			ans += v
		}
	}
	return ans
}

func isValidShortcut(startX, startY, endX, endY int, grid [][]rune, shortcutMaxSize int) (bool, int) {
	if startX < 0 || startX >= len(grid[0]) {
		return false, 0
	}
	if startY < 0 || startY >= len(grid) {
		return false, 0
	}
	if endX < 0 || endX >= len(grid[0]) {
		return false, 0
	}
	if endY < 0 || endY >= len(grid) {
		return false, 0
	}
	if grid[startY][startX] == '#' {
		return false, 0
	}
	if grid[endY][endX] == '#' {
		return false, 0
	}
	xLen := startX - endX
	if xLen < 0 {
		xLen *= -1
	}
	yLen := startY - endY
	if yLen < 0 {
		yLen *= -1
	}
	if xLen+yLen > shortcutMaxSize {
		return false, 0
	}
	return true, xLen + yLen
}

type state struct {
	x int
	y int
}

func (s *state) String() string {
	return fmt.Sprintf("%v,%v", s.x, s.y)
}

func findRune(grid [][]rune, char rune) *state {
	for y, line := range grid {
		for x, r := range line {
			if r == char {
				return &state{
					x: x,
					y: y,
				}
			}
		}
	}
	return nil
}

func findPathCost(grid [][]rune) int {
	s := findRune(grid, 'S')
	q = append(q, s)
	visited = make(map[string]int)
	last = make(map[string]string)
	visited[s.String()] = 0
	last[s.String()] = "nil"
	for len(q) > 0 {
		startState := q[0]
		q = q[1:]
		cost := visited[startState.String()]

		var newState *state
		newState = &state{
			x: startState.x + 1,
			y: startState.y,
		}
		if grid[newState.y][newState.x] != '#' {
			newCost := cost + 1
			if oldCost, ok := visited[newState.String()]; !ok || newCost < oldCost {
				q = append(q, newState)
				visited[newState.String()] = newCost
				last[newState.String()] = startState.String()
			}
		}

		newState = &state{
			x: startState.x - 1,
			y: startState.y,
		}
		if grid[newState.y][newState.x] != '#' {
			newCost := cost + 1
			if oldCost, ok := visited[newState.String()]; !ok || newCost < oldCost {
				q = append(q, newState)
				visited[newState.String()] = newCost
				last[newState.String()] = startState.String()
			}
		}

		newState = &state{
			x: startState.x,
			y: startState.y + 1,
		}
		if grid[newState.y][newState.x] != '#' {
			newCost := cost + 1
			if oldCost, ok := visited[newState.String()]; !ok || newCost < oldCost {
				q = append(q, newState)
				visited[newState.String()] = newCost
				last[newState.String()] = startState.String()
			}
		}

		newState = &state{
			x: startState.x,
			y: startState.y - 1,
		}
		if grid[newState.y][newState.x] != '#' {
			newCost := cost + 1
			if oldCost, ok := visited[newState.String()]; !ok || newCost < oldCost {
				q = append(q, newState)
				visited[newState.String()] = newCost
				last[newState.String()] = startState.String()
			}
		}

	}
	goalState := findRune(grid, 'E')
	if cost, ok := visited[goalState.String()]; ok {
		return cost
	} else {
		return -1
	}
}

func readInput() [][]rune {
	grid := make([][]rune, 0)

	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	for scanner.Scan() {
		line := make([]rune, 0)
		for _, r := range scanner.Text() {
			line = append(line, r)
		}
		grid = append(grid, line)
	}
	return grid
}
