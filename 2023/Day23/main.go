package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	fmt.Println("Part 1:", run(false))
	fmt.Println("Part 2:", part2())
}
func part2() int {
	g := buildGraph()
	/*for k, v := range g.adj {
		fmt.Print(k, "->")
		for _, n := range v {
			fmt.Print(n.n.String(), ":", n.weight, ", ")
		}
		fmt.Println()
	}*/
	grid := readInput()
	goalX := len(grid[0]) - 2
	goalY := len(grid) - 1
	initVisited := make(map[string]bool, 0)
	initVisited[fmt.Sprint(1, 0)] = true
	initialState := &state2{
		n: &Node{
			x: 1,
			y: 0,
		},
		visited: initVisited,
	}
	q := make([]*state2, 0)
	q = append(q, initialState)
	done := make([]*state2, 0)
	for len(q) > 0 {
		current := q[0]
		q = q[1:]
		if current.n.x == goalX && current.n.y == goalY {
			done = append(done, current)
		} else {
			for _, n := range g.adj[current.n.String()] {
				if _, ok := current.visited[n.n.String()]; !ok {
					newVisited := make(map[string]bool, 0)
					for k, v := range current.visited {
						newVisited[k] = v
					}
					newVisited[n.n.String()] = true
					q = append(q, &state2{
						n:       n.n,
						steps:   current.steps + n.weight,
						visited: newVisited,
					})
				}
			}
		}
	}
	max := 0
	for _, s := range done {
		if s.steps > max {
			max = s.steps
		}
	}
	return max
}

type state2 struct {
	n       *Node
	visited map[string]bool
	steps   int
}

func run(steepOk bool) int {
	grid := readInput()
	goalX := len(grid[0]) - 2
	goalY := len(grid) - 1
	initVisited := make(map[string]bool, 0)
	initVisited[fmt.Sprint(1, 0)] = true
	initialState := &state{
		x:       1,
		y:       0,
		visited: initVisited,
	}
	q := make([]*state, 0)
	q = append(q, initialState)
	done := make([]*state, 0)

	for len(q) > 0 {
		current := q[0]
		q = q[1:]
		if current.x == goalX && current.y == goalY {
			done = append(done, current)
		} else {
			next := current.tryStep(grid, current.x+1, current.y, steepOk)
			if next != nil {
				q = append(q, next)
			}
			next = current.tryStep(grid, current.x-1, current.y, steepOk)
			if next != nil {
				q = append(q, next)
			}
			next = current.tryStep(grid, current.x, current.y+1, steepOk)
			if next != nil {
				q = append(q, next)
			}
			next = current.tryStep(grid, current.x, current.y-1, steepOk)
			if next != nil {
				q = append(q, next)
			}
		}
	}
	max := 0
	for _, s := range done {
		if s.stepsTaken() > max {
			max = s.stepsTaken()
		}
	}
	return max
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

type state struct {
	x       int
	y       int
	visited map[string]bool
}

func (s *state) stepsTaken() int {
	return len(s.visited) - 1
}

func (s *state) tryStep(grid []string, newX, newY int, steepOk bool) *state {
	if newX < 0 {
		return nil
	}
	if newY < 0 {
		return nil
	}
	if newX >= len(grid[0]) {
		return nil
	}
	if newY >= len(grid) {
		return nil
	}
	if grid[newY][newX] == '#' {
		return nil
	}
	if _, ok := s.visited[fmt.Sprint(newX, newY)]; ok {
		return nil
	}
	if grid[s.y][s.x] == '^' && (newX != s.x || newY != s.y-1) && !steepOk {
		return nil
	}
	if grid[s.y][s.x] == 'v' && (newX != s.x || newY != s.y+1) && !steepOk {
		return nil
	}
	if grid[s.y][s.x] == '<' && (newX != s.x-1 || newY != s.y) && !steepOk {
		return nil
	}
	if grid[s.y][s.x] == '>' && (newX != s.x+1 || newY != s.y) && !steepOk {
		return nil
	}
	newVisited := make(map[string]bool, len(s.visited))
	for k, v := range s.visited {
		newVisited[k] = v
	}
	newVisited[fmt.Sprint(newX, newY)] = true
	return &state{
		x:       newX,
		y:       newY,
		visited: newVisited,
	}
}

type Node struct {
	x int
	y int
}

func (n *Node) String() string {
	return fmt.Sprint(n.x, n.y)
}

type Adjacency struct {
	n      *Node
	weight int
}

type Graph struct {
	adj map[string][]Adjacency
}

func (g *Graph) AddAdjacency(n1, n2 *Node, w int) {
	if _, ok := g.adj[n1.String()]; !ok {
		g.adj[n1.String()] = make([]Adjacency, 0)
	}
	if _, ok := g.adj[n2.String()]; !ok {
		g.adj[n2.String()] = make([]Adjacency, 0)
	}
	if g.ContainsAdj(n1, n2, w) {
		return
	}
	g.adj[n1.String()] = append(g.adj[n1.String()], Adjacency{
		n:      n2,
		weight: w,
	})
	g.adj[n2.String()] = append(g.adj[n2.String()], Adjacency{
		n:      n1,
		weight: w,
	})
}

func (g *Graph) ContainsAdj(n1, n2 *Node, w int) bool {
	for _, a := range g.adj[n1.String()] {
		if a.weight == w && a.n.x == n2.x && a.n.y == n2.y {
			return true
		}
	}
	return false
}

func buildGraph() *Graph {
	graph := &Graph{
		adj: make(map[string][]Adjacency, 0),
	}
	grid := readInput()
	initVisited := make(map[string]bool, 0)
	initVisited[fmt.Sprint(1, 0)] = true
	initialState := &state{
		x:       1,
		y:       0,
		visited: initVisited,
	}
	q := make([]*state, 0)
	q = append(q, initialState)
	nodesVisited := make(map[string]bool, 0)
	for len(q) > 0 {
		current := q[0]
		lastNode := current
		q = q[1:]
		if _, ok := nodesVisited[fmt.Sprint(current.x, current.y)]; ok {
			continue
		}
		nodesVisited[fmt.Sprint(current.x, current.y)] = true
		outs := make([]*state, 0)
		next := current.tryStep(grid, current.x+1, current.y, true)
		if next != nil {
			outs = append(outs, next)
		}
		next = current.tryStep(grid, current.x-1, current.y, true)
		if next != nil {
			outs = append(outs, next)
		}
		next = current.tryStep(grid, current.x, current.y+1, true)
		if next != nil {
			outs = append(outs, next)
		}
		next = current.tryStep(grid, current.x, current.y-1, true)
		if next != nil {
			outs = append(outs, next)
		}
		for _, out := range outs {
			steps := 0
			current := out
			opts := 1
			for opts == 1 {
				options := make([]*state, 0)
				next := current.tryStep(grid, current.x+1, current.y, true)
				if next != nil {
					options = append(options, next)
				}
				next = current.tryStep(grid, current.x-1, current.y, true)
				if next != nil {
					options = append(options, next)
				}
				next = current.tryStep(grid, current.x, current.y+1, true)
				if next != nil {
					options = append(options, next)
				}
				next = current.tryStep(grid, current.x, current.y-1, true)
				if next != nil {
					options = append(options, next)
				}
				steps++
				opts = len(options)
				if len(options) == 1 {
					current = options[0]
				} else {
					q = append(q, current)
				}
			}
			graph.AddAdjacency(&Node{
				x: lastNode.x,
				y: lastNode.y,
			}, &Node{
				x: current.x,
				y: current.y,
			}, steps)
		}
	}
	return graph
}
