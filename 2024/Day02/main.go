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
	lines := readInput()
	safe := 0
	for _, line := range lines {
		if isOk(line) {
			safe++
		}
	}
	return safe
}

func part2() int {
	lines := readInput()
	safe := 0
	for _, line := range lines {

		if isOk(line) {
			safe++
		} else {
			for i := 0; i < len(line); i++ {
				newArr := make([]int, 0)
				for j := 0; j < len(line); j++ {
					if j != i {
						newArr = append(newArr, line[j])
					}
				}
				if isOk(newArr) {
					safe++
					break
				}
			}
		}
	}
	return safe
}

func isOk(line []int) bool {
	increasing := (line[1] > line[0])
	for i := 1; i < len(line); i++ {
		var diff int
		if increasing {
			diff = line[i] - line[i-1]
		} else {
			diff = line[i-1] - line[i]
		}
		if diff <= 0 {
			return false
		}
		if diff > 3 {
			return false
		}
	}
	return true
}

func readInput() [][]int {
	arr := make([][]int, 0)
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		pieces := strings.Split(scanner.Text(), " ")
		lineArr := make([]int, 0)
		for _, s := range pieces {
			n, err := strconv.Atoi(s)
			if err != nil {
				panic(err)
			}
			lineArr = append(lineArr, n)
		}
		arr = append(arr, lineArr)
	}
	return arr

}
