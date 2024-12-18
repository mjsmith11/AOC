package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

var (
	size    = 71
	q       []*state
	visited map[string]int
	last    map[string]map[string]bool
)

func main() {
	p1, _ := part1(1024)
	fmt.Println("Part 1:", p1)
	fmt.Println("Part 2:", part2())
}

type state struct {
	x int
	y int
}

func (s *state) String() string {
	return fmt.Sprintf("%v,%v", s.x, s.y)
}

func part2() string {
	for i := 1; true; i++ {
		_, possible := part1(i)
		if !possible {
			_, ans := readInput(i)
			return ans
		}

	}
	return ""
}

func part1(numBytes int) (int, bool) {
	grid, _ := readInput(numBytes)
	s := &state{
		x: 1,
		y: 1,
	}
	q = append(q, s)
	visited = make(map[string]int)
	visited[s.String()] = 0
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
			}
		}

	}
	goalState := &state{
		x: size,
		y: size,
	}
	if cost, ok := visited[goalState.String()]; ok {
		return cost, true
	} else {
		return 0, false
	}
}

func readInput(stop int) ([][]rune, string) {
	grid := make([][]rune, 0)
	horizBorder := make([]rune, 0)
	for i := 0; i < size+2; i++ {
		horizBorder = append(horizBorder, '#')
	}
	grid = append(grid, horizBorder)
	for i := 0; i < size; i++ {
		line := make([]rune, 0)
		line = append(line, '#')
		for j := 0; j < size; j++ {
			line = append(line, '.')
		}
		line = append(line, '#')
		grid = append(grid, line)
	}
	grid = append(grid, horizBorder)

	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	dropped := 0
	var line string
	for scanner.Scan() && dropped < stop {
		line = scanner.Text()
		splits := strings.Split(scanner.Text(), ",")
		x, err := strconv.Atoi(splits[0])
		if err != nil {
			panic(err)
		}
		y, err := strconv.Atoi(splits[1])
		if err != nil {
			panic(err)
		}
		grid[y+1][x+1] = '#'
		dropped++
	}
	return grid, line
}
