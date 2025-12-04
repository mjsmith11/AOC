package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}
func part1() int {
	inp := readInput()
	res, _ := run(inp)
	return res
}

func part2() int {
	inp := readInput()
	total := 0
	moved, inp := run(inp)
	for moved > 0 {
		total += moved
		moved, inp = run(inp)
	}
	return total
}
func run(data [][]bool) (int, [][]bool) {
	accessible := 0
	newMap := make([][]bool, 0)
	topBottom := make([]bool, 0)
	for i := 0; i < len(data[0]); i++ {
		topBottom = append(topBottom, false)
	}
	newMap = append(newMap, topBottom)
	for y := 1; y < len(data)-1; y++ {
		newline := make([]bool, 0)
		newline = append(newline, false)
		for x := 1; x < len(data[y])-1; x++ {
			if !data[y][x] {
				newline = append(newline, false)
				continue
			}
			taken := 0
			if data[y-1][x-1] {
				taken++
			}
			if data[y-1][x] {
				taken++
			}
			if data[y-1][x+1] {
				taken++
			}
			if data[y][x-1] {
				taken++
			}
			if data[y][x+1] {
				taken++
			}
			if data[y+1][x-1] {
				taken++
			}
			if data[y+1][x] {
				taken++
			}
			if data[y+1][x+1] {
				taken++
			}
			if taken < 4 {
				accessible++
				newline = append(newline, false)
			} else {
				newline = append(newline, true)
			}
		}
		newline = append(newline, false)
		newMap = append(newMap, newline)
	}
	newMap = append(newMap, topBottom)
	return accessible, newMap
}

func readInput() [][]bool {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([]string, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		a = append(a, str)
	}
	b := make([][]bool, 0)
	topBottom := make([]bool, 0)
	for i := 0; i < len(a[0])+2; i++ {
		topBottom = append(topBottom, false)
	}
	b = append(b, topBottom)
	for _, s := range a {
		line := make([]bool, 0)
		line = append(line, false)
		for _, r := range s {
			line = append(line, (r == '@'))
		}
		line = append(line, false)

		b = append(b, line)
	}
	b = append(b, topBottom)
	return b
}
