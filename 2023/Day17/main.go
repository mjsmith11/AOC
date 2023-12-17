package main

import (
	"bufio"
	"container/heap"
	"fmt"
	"math"
	"os"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1", part1())
	fmt.Println("Part 2", part2())
}
func part1() int {
	grid := readInput()

	src := &Item{
		value: state{
			x:      0,
			y:      0,
			dlast:  'N',
			dlast2: 'N',
			dlast3: 'N',
		},
		priority: 0,
	}

	q := make(PriorityQueue, 0)
	heap.Init(&q)
	heap.Push(&q, src)

	sptSet := make(map[string]bool, 0)
	dist := make(map[string]int, 0)

	dist[src.value.String()] = 0
	for len(q) > 0 {
		u := heap.Pop(&q).(*Item)
		if _, ok := sptSet[u.value.String()]; ok {
			continue
		}

		sptSet[u.value.String()] = true

		adj := findAdjacent(&u.value, len(grid[0]), len(grid))
		for _, st := range adj {
			if _, ok := sptSet[st.String()]; !ok {
				var distSt int
				if n, ok := dist[st.String()]; ok {
					distSt = n
				} else {
					distSt = math.MaxInt32
				}
				if grid[st.y][st.x]+dist[u.value.String()] < distSt {
					dist[st.String()] = grid[st.y][st.x] + dist[u.value.String()]
					heap.Push(&q, &Item{
						value:    *st,
						priority: dist[st.String()],
					})
				}
			}
		}
	}
	min := math.MaxInt32
	xS := len(grid[0])
	yS := len(grid)
	for k, v := range dist {
		if strings.HasPrefix(k, fmt.Sprint(xS-1, yS-1)) {
			if v < min {
				min = v
			}
		}
	}
	return min
}

func findAdjacent(current *state, width, height int) []*state {
	nextStates := make([]*state, 0)
	l := getLeft(current)
	if checkCoords(l.x, l.y, width, height) {
		nextStates = append(nextStates, l)
	}
	r := getRight(current)
	if checkCoords(r.x, r.y, width, height) {
		nextStates = append(nextStates, r)
	}
	if (current.dlast != current.dlast2 || current.dlast != current.dlast3) || current.dlast == 'N' {
		s := getStraight(current)
		if checkCoords(s.x, s.y, width, height) {
			nextStates = append(nextStates, s)
		}
	}
	return nextStates
}

func checkCoords(x, y, width, height int) bool {
	if x < 0 {
		return false
	}
	if y < 0 {
		return false
	}
	if x >= width {
		return false
	}
	if y >= height {
		return false
	}
	return true
}

func getStraight(current *state) *state {
	if current.dlast == 'U' {
		return &state{
			x:      current.x,
			y:      current.y - 1,
			dlast:  'U',
			dlast2: 'U',
			dlast3: current.dlast2,
		}
	} else if current.dlast == 'D' {
		return &state{
			x:      current.x,
			y:      current.y + 1,
			dlast:  'D',
			dlast2: 'D',
			dlast3: current.dlast2,
		}
	} else if current.dlast == 'L' {
		return &state{
			x:      current.x - 1,
			y:      current.y,
			dlast:  'L',
			dlast2: 'L',
			dlast3: current.dlast2,
		}
	} else { // R or N
		return &state{
			x:      current.x + 1,
			y:      current.y,
			dlast:  'R',
			dlast2: current.dlast,
			dlast3: current.dlast2,
		}
	}
}

func getRight(current *state) *state {
	if current.dlast == 'U' {
		return &state{
			x:      current.x + 1,
			y:      current.y,
			dlast:  'R',
			dlast2: 'U',
			dlast3: current.dlast2,
		}
	} else if current.dlast == 'D' {
		return &state{
			x:      current.x - 1,
			y:      current.y,
			dlast:  'L',
			dlast2: 'D',
			dlast3: current.dlast2,
		}
	} else if current.dlast == 'L' {
		return &state{
			x:      current.x,
			y:      current.y - 1,
			dlast:  'U',
			dlast2: 'L',
			dlast3: current.dlast2,
		}
	} else { // R or N
		return &state{
			x:      current.x,
			y:      current.y + 1,
			dlast:  'D',
			dlast2: current.dlast,
			dlast3: current.dlast2,
		}
	}
}

func getLeft(current *state) *state {
	if current.dlast == 'U' {
		return &state{
			x:      current.x - 1,
			y:      current.y,
			dlast:  'L',
			dlast2: 'U',
			dlast3: current.dlast2,
		}
	} else if current.dlast == 'D' {
		return &state{
			x:      current.x + 1,
			y:      current.y,
			dlast:  'R',
			dlast2: 'D',
			dlast3: current.dlast2,
		}
	} else if current.dlast == 'L' {
		return &state{
			x:      current.x,
			y:      current.y + 1,
			dlast:  'D',
			dlast2: 'L',
			dlast3: current.dlast2,
		}
	} else { // R or N
		return &state{
			x:      current.x,
			y:      current.y - 1,
			dlast:  'U',
			dlast2: current.dlast,
			dlast3: current.dlast2,
		}
	}
}

type state struct {
	x      int
	y      int
	dlast  rune
	dlast2 rune
	dlast3 rune
}

func (s *state) String() string {
	return fmt.Sprint(s.x, s.y, string(s.dlast), string(s.dlast2), string(s.dlast3))
}

func readInput() [][]int {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	grid := make([][]int, 0)
	scanner := bufio.NewScanner(f)
	defer f.Close()

	for scanner.Scan() {
		row := make([]int, 0)
		t := scanner.Text()
		for _, r := range t {
			num, err := strconv.Atoi(string(r))
			if err != nil {
				panic(err)
			}
			row = append(row, num)
		}
		grid = append(grid, row)
	}

	return grid
}

// An Item is something we manage in a priority queue.
type Item struct {
	value    state // The value of the item; arbitrary.
	priority int   // The priority of the item in the queue.
	// The index is needed by update and is maintained by the heap.Interface methods.
	index int // The index of the item in the heap.
}

// A PriorityQueue implements heap.Interface and holds Items.
type PriorityQueue []*Item

func (pq PriorityQueue) Len() int { return len(pq) }

func (pq PriorityQueue) Less(i, j int) bool {
	return pq[i].priority < pq[j].priority
}

func (pq PriorityQueue) Swap(i, j int) {
	pq[i], pq[j] = pq[j], pq[i]
	pq[i].index = i
	pq[j].index = j
}

func (pq *PriorityQueue) Push(x any) {
	n := len(*pq)
	item := x.(*Item)
	item.index = n
	*pq = append(*pq, item)
}

func (pq *PriorityQueue) Pop() any {
	old := *pq
	n := len(old)
	item := old[n-1]
	old[n-1] = nil  // avoid memory leak
	item.index = -1 // for safety
	*pq = old[0 : n-1]
	return item
}

// update modifies the priority and value of an Item in the queue.
func (pq *PriorityQueue) update(item *Item, value state, priority int) {
	item.value = value
	item.priority = priority
	heap.Fix(pq, item.index)
}

func part2() int {
	grid := readInput()

	src := &Item2{
		value: state2{
			x:         0,
			y:         0,
			dlast:     'N',
			lastTimes: 0,
		},
		priority: 0,
	}

	q := make(PriorityQueue2, 0)
	heap.Init(&q)
	heap.Push(&q, src)

	sptSet := make(map[string]bool, 0)
	dist := make(map[string]int, 0)

	dist[src.value.String()] = 0
	for len(q) > 0 {
		u := heap.Pop(&q).(*Item2)
		if _, ok := sptSet[u.value.String()]; ok {
			continue
		}

		sptSet[u.value.String()] = true

		adj := findAdjacent2(&u.value, len(grid[0]), len(grid))
		for _, st := range adj {
			if _, ok := sptSet[st.String()]; !ok {
				var distSt int
				if n, ok := dist[st.String()]; ok {
					distSt = n
				} else {
					distSt = math.MaxInt32
				}
				if grid[st.y][st.x]+dist[u.value.String()] < distSt {
					dist[st.String()] = grid[st.y][st.x] + dist[u.value.String()]
					heap.Push(&q, &Item2{
						value:    *st,
						priority: dist[st.String()],
					})
				}
			}
		}
	}
	min := math.MaxInt32
	xS := len(grid[0])
	yS := len(grid)
	for k, v := range dist {
		if strings.HasPrefix(k, fmt.Sprint(xS-1, yS-1)) {
			// at the goal
			splits := strings.Split(k, " ")
			// must have traveled >= 4 blocks to be able to stop
			blocksTraveled, err := strconv.Atoi(splits[len(splits)-1])
			if err != nil {
				panic(err)
			}
			if v < min && blocksTraveled >= 4 {
				min = v
			}
		}
	}
	return min
}

// An Item is something we manage in a priority queue.
type Item2 struct {
	value    state2 // The value of the item; arbitrary.
	priority int    // The priority of the item in the queue.
	// The index is needed by update and is maintained by the heap.Interface methods.
	index int // The index of the item in the heap.
}

type state2 struct {
	x         int
	y         int
	dlast     rune
	lastTimes int
}

func (s *state2) String() string {
	return fmt.Sprint(s.x, s.y, string(s.dlast), " ", s.lastTimes)
}

// A PriorityQueue implements heap.Interface and holds Items.
type PriorityQueue2 []*Item2

func (pq PriorityQueue2) Len() int { return len(pq) }

func (pq PriorityQueue2) Less(i, j int) bool {
	return pq[i].priority < pq[j].priority
}

func (pq PriorityQueue2) Swap(i, j int) {
	pq[i], pq[j] = pq[j], pq[i]
	pq[i].index = i
	pq[j].index = j
}

func (pq *PriorityQueue2) Push(x any) {
	n := len(*pq)
	item := x.(*Item2)
	item.index = n
	*pq = append(*pq, item)
}

func (pq *PriorityQueue2) Pop() any {
	old := *pq
	n := len(old)
	item := old[n-1]
	old[n-1] = nil  // avoid memory leak
	item.index = -1 // for safety
	*pq = old[0 : n-1]
	return item
}

func findAdjacent2(current *state2, width, height int) []*state2 {
	nextStates := make([]*state2, 0)
	if current.lastTimes >= 4 { // can only turn >=4 blocks
		l := getLeft2(current)
		if checkCoords(l.x, l.y, width, height) {
			nextStates = append(nextStates, l)
		}
		r := getRight2(current)
		if checkCoords(r.x, r.y, width, height) {
			nextStates = append(nextStates, r)
		}
	}
	if current.lastTimes < 10 {
		s := getStraight2(current)
		if checkCoords(s.x, s.y, width, height) {
			nextStates = append(nextStates, s)
		}
	}
	return nextStates
}

func getStraight2(current *state2) *state2 {
	if current.dlast == 'U' {
		return &state2{
			x:         current.x,
			y:         current.y - 1,
			dlast:     'U',
			lastTimes: current.lastTimes + 1,
		}
	} else if current.dlast == 'D' {
		return &state2{
			x:         current.x,
			y:         current.y + 1,
			dlast:     'D',
			lastTimes: current.lastTimes + 1,
		}
	} else if current.dlast == 'L' {
		return &state2{
			x:         current.x - 1,
			y:         current.y,
			dlast:     'L',
			lastTimes: current.lastTimes + 1,
		}
	} else { // R or N
		return &state2{
			x:         current.x + 1,
			y:         current.y,
			dlast:     'R',
			lastTimes: current.lastTimes + 1,
		}
	}
}

func getRight2(current *state2) *state2 {
	if current.dlast == 'U' {
		return &state2{
			x:         current.x + 1,
			y:         current.y,
			dlast:     'R',
			lastTimes: 1,
		}
	} else if current.dlast == 'D' {
		return &state2{
			x:         current.x - 1,
			y:         current.y,
			dlast:     'L',
			lastTimes: 1,
		}
	} else if current.dlast == 'L' {
		return &state2{
			x:         current.x,
			y:         current.y - 1,
			dlast:     'U',
			lastTimes: 1,
		}
	} else { // R or N
		return &state2{
			x:         current.x,
			y:         current.y + 1,
			dlast:     'D',
			lastTimes: 1,
		}
	}
}

func getLeft2(current *state2) *state2 {
	if current.dlast == 'U' {
		return &state2{
			x:         current.x - 1,
			y:         current.y,
			dlast:     'L',
			lastTimes: 1,
		}
	} else if current.dlast == 'D' {
		return &state2{
			x:         current.x + 1,
			y:         current.y,
			dlast:     'R',
			lastTimes: 1,
		}
	} else if current.dlast == 'L' {
		return &state2{
			x:         current.x,
			y:         current.y + 1,
			dlast:     'D',
			lastTimes: 1,
		}
	} else { // R or N
		return &state2{
			x:         current.x,
			y:         current.y - 1,
			dlast:     'U',
			lastTimes: 1,
		}
	}
}
