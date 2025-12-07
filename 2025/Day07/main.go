package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}
func part1() int {
	q := make([]point, 0)
	done := make(map[string]bool, 0)
	splits := 0
	inp := readInput()
	for y, s := range inp {
		for x, r := range s {
			if r == 'S' {
				q = append(q, point{
					x: x,
					y: y,
				})
				break
			}
		}
		if len(q) > 0 {
			break
		}
	}

	for len(q) > 0 {
		p := q[0]
		q = q[1:]

		if _, ok := done[p.String()]; ok {
			continue
		}
		if p.y == len(inp)-1 {
			// bottom
			continue
		} else if inp[p.y+1][p.x] == '.' {
			// straight down
			q = append(q, point{
				x: p.x,
				y: p.y + 1,
			})
		} else if inp[p.y+1][p.x] == '^' {
			// split
			splits++
			q = append(q, point{
				x: p.x - 1,
				y: p.y + 1,
			})
			q = append(q, point{
				x: p.x + 1,
				y: p.y + 1,
			})
		} else {
			panic(p)
		}
		done[p.String()] = true
	}

	return splits
}

func part2() int {
	inp := readInput()
	inProgress := make(map[string]int, 0)
	done := make(map[string]int, 0)

	for y, s := range inp {
		for x, r := range s {
			if r == 'S' {
				inProgress[fmt.Sprintf("%v,%v", x, y)] = 1
				break
			}
		}
		if len(inProgress) > 0 {
			break
		}
	}
	for len(inProgress) > 0 {
		next := make(map[string]int, 0)
		for k, v := range inProgress {
			p := pointFromString(k)
			if p.y == len(inp)-1 {
				// bottom
				done[k] += v
			} else if inp[p.y+1][p.x] == '.' {
				// straight down
				next[fmt.Sprintf("%v,%v", p.x, p.y+1)] += v
			} else if inp[p.y+1][p.x] == '^' {
				// split
				next[fmt.Sprintf("%v,%v", p.x-1, p.y+1)] += v
				next[fmt.Sprintf("%v,%v", p.x+1, p.y+1)] += v
			} else {
				panic(p)
			}
		}
		inProgress = next
	}
	ans := 0
	for _, v := range done {
		ans += v
	}
	return ans
}

type point struct {
	x int
	y int
}

func pointFromString(s string) point {
	splits := strings.Split(s, ",")
	x, err := strconv.ParseInt(splits[0], 10, 64)
	if err != nil {
		panic(err)
	}
	y, err := strconv.ParseInt(splits[1], 10, 64)
	if err != nil {
		panic(err)
	}
	return point{
		x: int(x),
		y: int(y),
	}
}
func (p *point) String() string {
	return fmt.Sprintf("%v,%v", p.x, p.y)
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([]string, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		a = append(a, scanner.Text())
	}

	return a
}
