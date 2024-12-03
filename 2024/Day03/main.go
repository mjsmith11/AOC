package main

import (
	"bufio"
	"fmt"
	"os"
	"regexp"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	str := readInput()
	re := regexp.MustCompile("mul\\((?P<n1>\\d{0,3}),(?P<n2>\\d{0,3})\\)")
	matches := re.FindAllStringSubmatch(str, -1)
	total := 0
	for _, m := range matches {
		n1, err := strconv.Atoi(m[1])
		if err != nil {
			panic(err)
		}
		n2, err := strconv.Atoi(m[2])
		if err != nil {
			panic(err)
		}
		total += (n1 * n2)
	}
	return total
}

func part2() int {
	str := readInput()
	re := regexp.MustCompile("mul\\((?P<n1>\\d{0,3}),(?P<n2>\\d{0,3})\\)")
	mulMatches := re.FindAllStringSubmatch(str, -1)
	mulIndices := re.FindAllStringIndex(str, -1)

	re = regexp.MustCompile("do\\(\\)")
	doIndices := re.FindAllStringIndex(str, -1)

	re = regexp.MustCompile("don't\\(\\)")
	dontIndices := re.FindAllStringIndex(str, -1)

	mulPtr := 0
	doPtr := 0
	dontPtr := 0
	enabled := true
	total := 0

	for mulPtr < len(mulIndices) || doPtr < len(doIndices) || dontPtr < len(dontIndices) {
		// try to do
		if doPtr < len(doIndices) && ((dontPtr == len(dontIndices)) || (doIndices[doPtr][0] < dontIndices[dontPtr][0])) && ((mulPtr == len(mulIndices)) || (doIndices[doPtr][0] < mulIndices[mulPtr][0])) {
			enabled = true
			doPtr++
		} else if dontPtr < len(dontIndices) && ((doPtr == len(doIndices)) || dontIndices[dontPtr][0] < doIndices[doPtr][0]) && ((mulPtr == len(mulIndices)) || dontIndices[dontPtr][0] < mulIndices[mulPtr][0]) {
			// dont
			enabled = false
			dontPtr++
		} else {
			if enabled {
				n1, err := strconv.Atoi(mulMatches[mulPtr][1])
				if err != nil {
					panic(err)
				}
				n2, err := strconv.Atoi(mulMatches[mulPtr][2])
				if err != nil {
					panic(err)
				}
				total += (n1 * n2)
			}
			mulPtr++
		}
	}
	return total
}

func readInput() string {
	var sb strings.Builder
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		sb.WriteString(scanner.Text())
	}
	return sb.String()
}
