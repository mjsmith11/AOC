package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", run(extrapolateForward))
	fmt.Println("Part 2:", run(extrapolateBackward))
}
func run(extrapolate func([]int) int) int {
	seqs := readInput()
	total := 0
	for _, v := range seqs {
		total += extrapolate(v)
	}
	return total
}
func extrapolateForward(seq []int) int {
	if allZero(seq) {
		return 0
	}
	diffs := make([]int, len(seq)-1)
	for i := 0; i < len(seq)-1; i++ {
		diffs[i] = seq[i+1] - seq[i]
	}
	return extrapolateForward(diffs) + seq[len(seq)-1]
}
func extrapolateBackward(seq []int) int {
	if allZero(seq) {
		return 0
	}
	diffs := make([]int, len(seq)-1)
	for i := 0; i < len(seq)-1; i++ {
		diffs[i] = seq[i+1] - seq[i]
	}
	return seq[0] - extrapolateBackward(diffs)
}
func allZero(seq []int) bool {
	for _, v := range seq {
		if v != 0 {
			return false
		}
	}
	return true
}
func readInput() [][]int {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	lists := make([][]int, 0)
	for scanner.Scan() {
		s := scanner.Text()
		l := make([]int, 0)
		splits := strings.Split(s, " ")
		for _, v := range splits {
			n, err := strconv.Atoi(v)
			if err != nil {
				panic(err)
			}
			l = append(l, n)
		}
		lists = append(lists, l)
	}
	return lists
}
