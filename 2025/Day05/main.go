package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	fresh := 0
	ranges, ingredients := readInput()
	for _, ingredient := range ingredients {
		for _, r := range ranges {
			if r.isInRange(ingredient) {
				fresh++
				break
			}
		}
	}
	return fresh
}

func part2() int {
	data, _ := readInput()
	sort.Slice(data, func(i, j int) bool {
		return data[i].start < data[j].start
	})
	fresh := 0
	var maxSeen int64
	maxSeen = 0
	for _, r := range data {
		if r.end > maxSeen {
			addStart := maxSeen + 1
			if r.start > addStart {
				addStart = r.start
			}
			fresh += int(r.end - addStart + 1)
			maxSeen = r.end
		}
	}
	return fresh
}

type intRange struct {
	start int64
	end   int64
}

func (r *intRange) isInRange(n int64) bool {
	if n >= r.start && n <= r.end {
		return true
	}
	return false
}

func readInput() ([]intRange, []int64) {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([]intRange, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		if str == "" {
			break
		}
		splits := strings.Split(str, "-")
		low, err := strconv.ParseInt(splits[0], 10, 64)
		if err != nil {
			panic(err)
		}
		high, err := strconv.ParseInt(splits[1], 10, 64)
		if err != nil {
			panic(err)
		}
		a = append(a, intRange{
			start: low,
			end:   high,
		})
	}

	b := make([]int64, 0)
	for scanner.Scan() {
		n, err := strconv.ParseInt(scanner.Text(), 10, 64)
		if err != nil {
			panic(err)
		}
		b = append(b, n)
	}

	return a, b
}
