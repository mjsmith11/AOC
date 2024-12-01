package main

import (
	"bufio"
	"fmt"
	"math"
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
	left, right := readInput()
	sort.Slice(left, func(i, j int) bool {
		return left[i] < left[j]
	})
	sort.Slice(right, func(i, j int) bool {
		return right[i] < right[j]
	})
	totalDist := 0
	for i, v := range left {
		totalDist += int(math.Abs(float64(v - right[i])))
	}
	return totalDist
}

func part2() int {
	left, right := readInput()
	freq := make(map[int]int, 0)
	for _, n := range right {
		if f, ok := freq[n]; ok {
			freq[n] = f + 1
		} else {
			freq[n] = 1
		}
	}
	sim := 0
	for _, n := range left {
		if f, ok := freq[n]; ok {
			sim += (f * n)
		}
	}
	return sim
}

func readInput() ([]int, []int) {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([]int, 0)
	b := make([]int, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		pieces := strings.Split(scanner.Text(), "   ")
		numA, err := strconv.Atoi(pieces[0])
		if err != nil {
			panic(err)
		}
		numB, err := strconv.Atoi(pieces[1])
		if err != nil {
			panic(err)
		}
		a = append(a, numA)
		b = append(b, numB)
	}
	return a, b
}
