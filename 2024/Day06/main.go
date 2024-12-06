package main

import (
	"bufio"
	"fmt"
	"os"
	"sync"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	grid := readInput()
	dir := 'U'
	x, y := findGuard(grid)
	grid[y][x] = 'X'
	for {
		if dir == 'U' {
			if y == 0 {
				// off grid
				break
			} else if grid[y-1][x] == '#' {
				// obstacle
				dir = 'R'
			} else {
				// walk
				y--
				grid[y][x] = 'X'
			}
		} else if dir == 'R' {
			if x == len(grid[0])-1 {
				// off grid
				break
			} else if grid[y][x+1] == '#' {
				// obstacle
				dir = 'D'
			} else {
				// walk
				x++
				grid[y][x] = 'X'
			}
		} else if dir == 'D' {
			if y == len(grid)-1 {
				// off grid
				break
			} else if grid[y+1][x] == '#' {
				// obstacle
				dir = 'L'
			} else {
				// walk
				y++
				grid[y][x] = 'X'
			}
		} else {
			// L
			if x == 0 {
				// off grid
				break
			} else if grid[y][x-1] == '#' {
				// obstacle
				dir = 'U'
			} else {
				// walk
				x--
				grid[y][x] = 'X'
			}
		}
	}
	return countX(grid)
}

func part2() int {
	wg := &sync.WaitGroup{}
	ans := 0
	results := make(chan bool)
	grid := readInput()
	for y := 0; y < len(grid); y++ {
		for x := 0; x < len(grid[0]); x++ {
			if grid[y][x] == '.' {
				newGrid := make([][]rune, 0)
				for iy := 0; iy < len(grid); iy++ {
					line := make([]rune, 0)
					for ix := 0; ix < len(grid[0]); ix++ {
						if x == ix && y == iy {
							line = append(line, '#')
						} else {
							line = append(line, grid[iy][ix])
						}
					}
					newGrid = append(newGrid, line)
				}
				wg.Add(1)
				go func() {
					defer wg.Done()
					hasCycle(newGrid, results)
				}()
			}
		}
	}
	go monitor(wg, results)

	for v := range results {
		if v {
			ans++
		}
	}
	return ans
}

func monitor(wg *sync.WaitGroup, ch chan bool) {
	wg.Wait()
	close(ch)
}

func stateToString(x, y int, dir rune) string {
	return fmt.Sprintf("%v,%v,%v", x, y, dir)
}
func hasCycle(grid [][]rune, c chan bool) {
	seen := make(map[string]bool, 0)
	dir := 'U'
	x, y := findGuard(grid)
	seen[stateToString(x, y, dir)] = true
	for {
		if dir == 'U' {
			if y == 0 {
				// off grid
				break
			} else if grid[y-1][x] == '#' {
				// obstacle
				dir = 'R'
			} else {
				// walk
				y--
				state := stateToString(x, y, dir)
				if _, ok := seen[state]; ok {
					c <- true
					return
				} else {
					seen[state] = true
				}
			}
		} else if dir == 'R' {
			if x == len(grid[0])-1 {
				// off grid
				break
			} else if grid[y][x+1] == '#' {
				// obstacle
				dir = 'D'
			} else {
				// walk
				x++
				state := stateToString(x, y, dir)
				if _, ok := seen[state]; ok {
					c <- true
					return
				} else {
					seen[state] = true
				}
			}
		} else if dir == 'D' {
			if y == len(grid)-1 {
				// off grid
				break
			} else if grid[y+1][x] == '#' {
				// obstacle
				dir = 'L'
			} else {
				// walk
				y++
				state := stateToString(x, y, dir)
				if _, ok := seen[state]; ok {
					c <- true
					return
				} else {
					seen[state] = true
				}
			}
		} else {
			// L
			if x == 0 {
				// off grid
				break
			} else if grid[y][x-1] == '#' {
				// obstacle
				dir = 'U'
			} else {
				// walk
				x--
				state := stateToString(x, y, dir)
				if _, ok := seen[state]; ok {
					c <- true
					return
				} else {
					seen[state] = true
				}
			}
		}
	}
	c <- false
}

func countX(grid [][]rune) int {
	c := 0
	for y := 0; y < len(grid); y++ {
		for x := 0; x < len(grid[y]); x++ {
			if grid[y][x] == 'X' {
				c++
			}
		}
	}
	return c
}

func findGuard(grid [][]rune) (int, int) {
	for y := 0; y < len(grid); y++ {
		for x := 0; x < len(grid[y]); x++ {
			if grid[y][x] == '^' {
				return x, y
			}
		}
	}
	return -1, -1
}

func readInput() [][]rune {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	strs := make([][]rune, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		line := make([]rune, 0)
		for _, r := range scanner.Text() {
			line = append(line, r)
		}
		strs = append(strs, line)
	}
	return strs
}
