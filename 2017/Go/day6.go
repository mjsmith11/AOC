package main

import (
	"fmt"
	"strings"
)

func day6() int {
	memory := getInput6()
	seenStates := make(map[string]int, 5000)
	cycle := 0

	for {
		fmt.Println(join(memory, ","))
		max, loc := findMax(memory)
		memory[loc] = 0
		index := loc + 1

		for i := 0; i < max; i++ {
			if index >= len(memory) {
				index = 0
			}
			memory[index] = memory[index] + 1
			index++
		}

		if _, exists := seenStates[join(memory, ",")]; exists {
			break
		} else {
			seenStates[join(memory, ",")] = cycle
			cycle++
		}

	}

	return cycle - seenStates[join(memory, ",")]
}

func getInput6() []int {
	input := make([]int, 16, 16)
	input[0] = 0
	input[1] = 5
	input[2] = 10
	input[3] = 0
	input[4] = 11
	input[5] = 14
	input[6] = 13
	input[7] = 4
	input[8] = 11
	input[9] = 8
	input[10] = 8
	input[11] = 7
	input[12] = 1
	input[13] = 4
	input[14] = 12
	input[15] = 11
	return input
}

func findMax(slice []int) (int, int) {
	max := 0
	loc := 0
	for i, v := range slice {
		if v > max {
			max = v
			loc = i
		}
	}

	return max, loc
}

func join(s []int, delim string) string {
	return strings.Trim(strings.Replace(fmt.Sprint(s), " ", delim, -1), "[]")
}
