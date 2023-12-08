package main

import (
	"bufio"
	"fmt"
	"os"
	"regexp"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	dirs, nodes := readInput()
	return findZ("AAA", nodes, dirs)
}

func findZ(start string, nodes map[string]*node, dirs string) int {
	current := start
	steps := 0
	dirsIndex := 0

	for current[2] != 'Z' {
		if dirs[dirsIndex] == 'L' {
			current = nodes[current].left
		} else if dirs[dirsIndex] == 'R' {
			current = nodes[current].right
		}
		steps++
		dirsIndex++
		dirsIndex %= len(dirs)
	}
	return steps
}

func part2() int {
	dirs, nodes := readInput()
	As := make([]string, 0)
	for k := range nodes {
		if k[2] == 'A' {
			As = append(As, k)
		}
	}
	cycleLengths := make([]int, 0)
	for _, start := range As {
		cycleLengths = append(cycleLengths, findZ(start, nodes, dirs))
	}
	return LCM(cycleLengths[0], cycleLengths[1], cycleLengths[2:])
}

func GCD(a, b int) int {
	for b != 0 {
		t := b
		b = a % b
		a = t
	}
	return a
}

func LCM(a, b int, integers []int) int {
	result := a * b / GCD(a, b)

	for i := 0; i < len(integers); i++ {
		result = LCM(result, integers[i], make([]int, 0))
	}
	return result
}

func done(currents []string) bool {
	for _, s := range currents {
		if s[2] != 'Z' {
			return false
		}
	}
	return true
}

func readInput() (string, map[string]*node) {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	nodes := make(map[string]*node, 0)
	re := regexp.MustCompile("^(?P<node>[A-Z0-9]{3}) = \\((?P<left>[A-Z0-9]{3}), (?P<right>[A-Z0-9]{3})\\)$")
	scanner := bufio.NewScanner(f)

	// get directions
	scanner.Scan()
	directions := scanner.Text()
	//eat the empty ling
	scanner.Scan()

	for scanner.Scan() {
		s := scanner.Text()
		parsed := re.FindStringSubmatch(s)
		nodes[parsed[1]] = &node{
			left:  parsed[2],
			right: parsed[3],
		}
	}
	return directions, nodes
}

type node struct {
	left  string
	right string
}
