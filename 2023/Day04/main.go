package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"strings"
)

func main() {
	fmt.Println("Part 1 ", part1())
	fmt.Println("Part 2 ", part2())
}

func part1() int {
	lines := readInput()
	totalPoints := 0
	for _, s := range lines {
		parts := strings.Split(s, ": ")
		numParts := strings.Split(parts[1], " | ")

		winning := make(map[string]string, 0)
		for i := 0; i < len(numParts[0]); i += 3 {
			substr := numParts[0][i : i+2]
			winning[substr] = ""
		}
		matches := 0
		for i := 0; i < len(numParts[1]); i += 3 {
			substr := numParts[1][i : i+2]
			if _, ok := winning[substr]; ok {
				matches++
			}
		}
		if matches > 0 {
			totalPoints += int(math.Pow(2, float64(matches-1)))
		}
	}
	return totalPoints
}

func part2() int {
	lines := readInput()
	inventory := make(map[int]int, len(lines))
	for i, _ := range lines {
		inventory[i] = 1
	}
	for i, s := range lines {
		parts := strings.Split(s, ": ")
		numParts := strings.Split(parts[1], " | ")

		winning := make(map[string]string, 0)
		for i := 0; i < len(numParts[0]); i += 3 {
			substr := numParts[0][i : i+2]
			winning[substr] = ""
		}
		matches := 0
		for i := 0; i < len(numParts[1]); i += 3 {
			substr := numParts[1][i : i+2]
			if _, ok := winning[substr]; ok {
				matches++
			}
		}
		for j := 1; j <= matches; j++ {
			inventory[i+j] += inventory[i]
		}
	}
	totalCards := 0
	for _, v := range inventory {
		totalCards += v
	}
	return totalCards
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	lines := make([]string, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		s := scanner.Text()
		lines = append(lines, s)
	}
	return lines
}
