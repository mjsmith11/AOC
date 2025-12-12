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
}

func part1() int {
	ct := 0
	areas := readInput()
	for _, a := range areas {
		if a.presentArea() <= a.getArea() { // is there enough area for all the presents
			if a.getTotalPresents()*9 <= a.getArea() { // is there enough room if they are all a 3x3 tile
				ct++
			} // nothing in the input would hit this else :-)
		}

	}
	return ct
}

type area struct {
	l    int
	w    int
	reqs []int
}

func (a *area) getArea() int {
	return a.l * a.w
}

func (a *area) presentArea() int {
	return 7*a.reqs[0] + 7*a.reqs[1] + 6*a.reqs[2] + 5*a.reqs[3] + 7*a.reqs[4] + 7*a.reqs[5]
}

func (a *area) getTiles() int {
	return (a.l / 3) * (a.w / 3)
}

func (a *area) getTotalPresents() int {
	p := 0
	for _, v := range a.reqs {
		p += v
	}
	return p
}

func readInput() []area {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	areas := make([]area, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		parts := strings.Split(str, ": ")
		dims := strings.Split(parts[0], "x")
		length, err := strconv.ParseInt(dims[0], 10, 64)
		if err != nil {
			panic(err)
		}
		width, err := strconv.ParseInt(dims[1], 10, 64)
		if err != nil {
			panic(err)
		}
		reqStrs := strings.Split(parts[1], " ")
		reqs := make([]int, len(reqStrs))
		for i, s := range reqStrs {
			n, err := strconv.ParseInt(s, 10, 64)
			if err != nil {
				panic(err)
			}
			reqs[i] = int(n)
		}
		areas = append(areas, area{
			l:    int(length),
			w:    int(width),
			reqs: reqs,
		})
	}
	return areas
}
