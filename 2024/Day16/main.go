package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

// 112376 too high
var (
	q       []*state
	visited map[string]int
	last    map[string]map[string]bool
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	grid := readInput()
	s := getStart(grid)
	q = append(q, s)
	visited = make(map[string]int)
	visited[s.String()] = 0
	for len(q) > 0 {
		startState := q[0]
		q = q[1:]
		cost := visited[startState.String()]

		// walk forward
		var newState *state
		if startState.dir == 'N' {
			newState = &state{
				x:   startState.x,
				y:   startState.y - 1,
				dir: 'N',
			}
		} else if startState.dir == 'S' {
			newState = &state{
				x:   startState.x,
				y:   startState.y + 1,
				dir: 'S',
			}
		} else if startState.dir == 'E' {
			newState = &state{
				x:   startState.x + 1,
				y:   startState.y,
				dir: 'E',
			}
		} else if startState.dir == 'W' {
			newState = &state{
				x:   startState.x - 1,
				y:   startState.y,
				dir: 'W',
			}
		} else {
			panic(string(startState.dir))
		}
		if grid[newState.y][newState.x] != '#' {
			newCost := cost + 1
			if oldCost, ok := visited[newState.String()]; !ok || newCost < oldCost {
				q = append(q, newState)
				visited[newState.String()] = newCost
			}
		}
		// clockwise turn
		newState = &state{
			x: startState.x,
			y: startState.y,
		}
		if startState.dir == 'N' {
			newState.dir = 'E'
		} else if startState.dir == 'E' {
			newState.dir = 'S'
		} else if startState.dir == 'S' {
			newState.dir = 'W'
		} else if startState.dir == 'W' {
			newState.dir = 'N'
		}
		newCost := cost + 1000
		if oldCost, ok := visited[newState.String()]; !ok || newCost < oldCost {
			q = append(q, newState)
			visited[newState.String()] = newCost
		}

		// counter-clockwise turn
		newState = &state{
			x: startState.x,
			y: startState.y,
		}
		if startState.dir == 'N' {
			newState.dir = 'W'
		} else if startState.dir == 'E' {
			newState.dir = 'N'
		} else if startState.dir == 'S' {
			newState.dir = 'E'
		} else if startState.dir == 'W' {
			newState.dir = 'S'
		}
		newCost = cost + 1000
		if oldCost, ok := visited[newState.String()]; !ok || newCost < oldCost {
			q = append(q, newState)
			visited[newState.String()] = newCost
		}
	}
	return findAnswer(grid)
}

func addToLast(prev, cur *state) {
	if _, ok := last[cur.String()]; !ok {
		last[cur.String()] = make(map[string]bool)
	}
	last[cur.String()][prev.String()] = true
}

func part2() int {
	opt := part1()
	grid := readInput()
	s := getStart(grid)
	q = append(q, s)
	goal := getEnd(grid)
	visited = make(map[string]int)
	visited[s.String()] = 0
	last = make(map[string]map[string]bool)
	for len(q) > 0 {
		startState := q[0]
		q = q[1:]
		cost := visited[startState.String()]

		// walk forward
		var newState *state
		if startState.dir == 'N' {
			newState = &state{
				x:   startState.x,
				y:   startState.y - 1,
				dir: 'N',
			}
		} else if startState.dir == 'S' {
			newState = &state{
				x:   startState.x,
				y:   startState.y + 1,
				dir: 'S',
			}
		} else if startState.dir == 'E' {
			newState = &state{
				x:   startState.x + 1,
				y:   startState.y,
				dir: 'E',
			}
		} else if startState.dir == 'W' {
			newState = &state{
				x:   startState.x - 1,
				y:   startState.y,
				dir: 'W',
			}
		} else {
			panic(string(startState.dir))
		}
		if grid[newState.y][newState.x] != '#' {
			newCost := cost + 1
			if oldCost, ok := visited[newState.String()]; !ok || newCost <= oldCost {
				if newCost < oldCost {
					last[newState.String()] = make(map[string]bool)
				}
				q = append(q, newState)
				visited[newState.String()] = newCost
				addToLast(startState, newState)
				if newState.x == goal.x && newState.y == goal.y && newCost == opt {
					grid = markPath(grid, newState)
				}
			}
		}
		// clockwise turn
		newState = &state{
			x: startState.x,
			y: startState.y,
		}
		if startState.dir == 'N' {
			newState.dir = 'E'
		} else if startState.dir == 'E' {
			newState.dir = 'S'
		} else if startState.dir == 'S' {
			newState.dir = 'W'
		} else if startState.dir == 'W' {
			newState.dir = 'N'
		}
		newCost := cost + 1000
		if oldCost, ok := visited[newState.String()]; !ok || newCost <= oldCost {
			q = append(q, newState)
			visited[newState.String()] = newCost
			if newCost < oldCost {
				last[newState.String()] = make(map[string]bool)
			}
			addToLast(startState, newState)
		}

		// counter-clockwise turn
		newState = &state{
			x: startState.x,
			y: startState.y,
		}
		if startState.dir == 'N' {
			newState.dir = 'W'
		} else if startState.dir == 'E' {
			newState.dir = 'N'
		} else if startState.dir == 'S' {
			newState.dir = 'E'
		} else if startState.dir == 'W' {
			newState.dir = 'S'
		}
		newCost = cost + 1000
		if oldCost, ok := visited[newState.String()]; !ok || newCost <= oldCost {
			q = append(q, newState)
			visited[newState.String()] = newCost
			if newCost < oldCost {
				last[newState.String()] = make(map[string]bool)
			}
			addToLast(startState, newState)
		}
	}
	// for _, s := range grid {
	// 	fmt.Println(s)
	// }
	return countO(grid)
}

func countO(grid []string) int {
	count := 0
	for _, l := range grid {
		for _, r := range l {
			if r == 'O' {
				count++
			}
		}
	}
	return count
}

func findAnswer(grid []string) int {
	s := state{}
	for y, l := range grid {
		for x, r := range l {
			if r == 'E' {
				s.x = x
				s.y = y
			}
		}
	}
	s.dir = 'N'
	min := visited[s.String()]
	s.dir = 'S'
	if c := visited[s.String()]; c < min {
		min = c
	}
	s.dir = 'E'
	if c := visited[s.String()]; c < min {
		min = c
	}
	s.dir = 'W'
	if c := visited[s.String()]; c < min {
		min = c
	}
	return min
}
func markPath(grid []string, finalState *state) []string {
	myMap := make([][]rune, 0)
	for _, s := range grid {
		line := make([]rune, 0)
		for _, r := range s {
			line = append(line, r)
		}
		myMap = append(myMap, line)
	}
	q := make([]*state, 0)
	q = append(q, finalState)
	for len(q) > 0 {
		cur := q[0]
		q = q[1:]
		if cur.x != -1 {
			myMap[cur.y][cur.x] = 'O'
			for k, _ := range last[cur.String()] {
				splits := strings.Split(k, ",")
				x, err := strconv.Atoi(splits[0])
				if err != nil {
					panic(err)
				}
				y, err := strconv.Atoi(splits[1])
				if err != nil {
					panic(err)
				}
				dir, err := strconv.Atoi(splits[2])
				if err != nil {
					panic(err)
				}
				q = append(q, &state{
					x:   x,
					y:   y,
					dir: rune(dir),
				})
			}
		}
	}

	newGrid := make([]string, 0)
	for _, line := range myMap {
		var sb strings.Builder
		for _, r := range line {
			sb.WriteRune(r)
		}
		newGrid = append(newGrid, sb.String())
	}
	return newGrid
}

func getStart(grid []string) *state {
	for y, l := range grid {
		for x, r := range l {
			if r == 'S' {
				return &state{
					x:   x,
					y:   y,
					dir: 'E',
				}
			}
		}
	}
	return &state{}
}

func getEnd(grid []string) *state {
	for y, l := range grid {
		for x, r := range l {
			if r == 'E' {
				return &state{
					x:   x,
					y:   y,
					dir: 'E',
				}
			}
		}
	}
	return &state{}
}

type state struct {
	x   int
	y   int
	dir rune
}

func (s *state) String() string {
	return fmt.Sprintf("%v,%v,%v", s.x, s.y, s.dir)
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
		grid = append(grid, scanner.Text())
	}
	return grid
}
