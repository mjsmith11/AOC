package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

var (
	towels []string
	mem    map[string]bool
	mem2   map[string]int
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	t, patterns := readInput()
	towels = t
	possible := 0
	mem = make(map[string]bool)
	for _, p := range patterns {
		if isPossible(p, 0) {
			possible++
		}
	}
	return possible
}

func part2() int {
	t, patterns := readInput()
	towels = t
	ways := 0
	mem2 = make(map[string]int)
	for _, p := range patterns {
		ways += findWays(p, 0)
	}
	return ways
}

func String(pattern string, start int) string {
	return fmt.Sprintf("%v,%v", pattern, start)
}

func isPossible(pattern string, start int) bool {
	if v, ok := mem[String(pattern, start)]; ok {
		return v
	}
	if start == len(pattern) {
		mem[String(pattern, start)] = true
		return true
	}
	found := false
	for _, t := range towels {
		if start+len(t) <= len(pattern) {
			substr := pattern[start : start+len(t)]
			if substr == t {
				found = found || isPossible(pattern, start+len(t))
			}
			if found {
				mem[String(pattern, start)] = true
				return true
			}
		}
	}
	mem[String(pattern, start)] = false
	return false
}

func findWays(pattern string, start int) int {
	if v, ok := mem2[String(pattern, start)]; ok {
		return v
	}
	if start == len(pattern) {
		mem[String(pattern, start)] = true
		return 1
	}
	ways := 0
	for _, t := range towels {
		if start+len(t) <= len(pattern) {
			substr := pattern[start : start+len(t)]
			if substr == t {
				ways += findWays(pattern, start+len(t))
			}
		}
	}
	mem2[String(pattern, start)] = ways
	return ways
}

func readInput() ([]string, []string) {
	f, err := os.Open("towels.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	scanner.Scan()
	towels := strings.Split(scanner.Text(), ", ")

	f, err = os.Open("patterns.txt")
	if err != nil {
		panic(err)
	}
	scanner = bufio.NewScanner(f)
	defer f.Close()

	patterns := make([]string, 0)
	for scanner.Scan() {
		patterns = append(patterns, scanner.Text())
	}
	return towels, patterns
}
