package main

import (
	"bufio"
	"fmt"
	"os"
	"regexp"
	"strconv"
)

var re = regexp.MustCompile("^p=(?P<px>-?\\d+),(?P<py>-?\\d+) v=(?P<vx>-?\\d+),(?P<vy>-?\\d+)$")

func main() {
	fmt.Println("Part 1:", part1(101, 103))
	part2()
}

func part2() {
	// dump the drawings to a file and Ctrl+F for a long string of #
	robots := readInput()
	for i := 1; i < 10000; i++ {
		locations := make(map[string]bool, 0)
		for _, r := range robots {
			r.move(1, 101, 103)
			locations[str(r.px, r.py)] = true
		}
		drawGrid(locations, i)
	}
}

func drawGrid(robots map[string]bool, secs int) {
	fmt.Println("After ", secs)
	for y := 0; y < 103; y++ {
		for x := 0; x < 101; x++ {
			if robots[str(x, y)] {
				fmt.Print("#")
			} else {
				fmt.Print(".")
			}
		}
		fmt.Println()
	}
	fmt.Println()
}

func str(x, y int) string {
	return fmt.Sprintf("%v,%v", x, y)
}

func part1(xSize, ySize int) int {
	robots := readInput()
	yMid := ySize / 2
	xMid := xSize / 2
	q1 := 0
	q2 := 0
	q3 := 0
	q4 := 0

	for _, r := range robots {
		r.move(100, xSize, ySize)
		if r.px > xMid {
			if r.py > yMid {
				q1++
			} else if r.py < yMid {
				q4++
			}
		} else if r.px < xMid {
			if r.py > yMid {
				q3++
			} else if r.py < yMid {
				q2++
			}
		}
	}
	return q1 * q2 * q3 * q4
}

type robot struct {
	px int
	py int
	vx int
	vy int
}

func (r *robot) move(amt, xSize, ySize int) {
	r.px = r.px + amt*r.vx
	r.py = r.py + amt*r.vy

	r.px = r.px % xSize
	r.py = r.py % ySize

	if r.px < 0 {
		r.px = xSize + r.px
	}
	if r.py < 0 {
		r.py = ySize + r.py
	}
}

func robotFromString(s string) *robot {
	match := re.FindStringSubmatch(s)
	px, err := strconv.Atoi(match[1])
	if err != nil {
		panic(err)
	}
	py, err := strconv.Atoi(match[2])
	if err != nil {
		panic(err)
	}
	vx, err := strconv.Atoi(match[3])
	if err != nil {
		panic(err)
	}
	vy, err := strconv.Atoi(match[4])
	if err != nil {
		panic(err)
	}
	return &robot{
		px: px,
		py: py,
		vx: vx,
		vy: vy,
	}
}

func readInput() []*robot {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	robots := make([]*robot, 0)

	for scanner.Scan() {
		robots = append(robots, robotFromString(scanner.Text()))
	}

	return robots
}
