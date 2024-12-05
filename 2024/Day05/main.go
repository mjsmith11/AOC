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
	rules, updates := readInput()
	ans := 0
	for _, update := range updates {
		if checkAllRules(update, rules) {
			ans += update[len(update)/2]
		}
	}
	return ans
}

func part2() int {
	rules, updates := readInput()
	ans := 0
	for _, update := range updates {
		if !checkAllRules(update, rules) {
			u := order(update, rules)
			ans += update[len(u)/2]
		}
	}
	return ans
}

func order(update []int, rules []rule) []int {
	var swapped bool
	for ok := true; ok; ok = swapped {
		swapped = false
		for _, r := range rules {
			var s bool
			update, s = swapIfBad(update, r)
			swapped = swapped || s
		}
	}
	return update
}

func swapIfBad(update []int, r rule) ([]int, bool) {
	bIndex := indexOf(update, r.before)
	aIndex := indexOf(update, r.after)
	if bIndex == -1 {
		return update, false
	}
	if aIndex == -1 {
		return update, false
	}
	if aIndex > bIndex {
		return update, false
	} else {
		temp := update[aIndex]
		update[aIndex] = update[bIndex]
		update[bIndex] = temp
		return update, true
	}
}

func checkAllRules(update []int, rs []rule) bool {
	for _, r := range rs {
		if !checkOneRule(update, r) {
			return false
		}
	}
	return true
}

func checkOneRule(update []int, r rule) bool {
	bIndex := indexOf(update, r.before)
	aIndex := indexOf(update, r.after)
	if bIndex == -1 {
		return true
	}
	if aIndex == -1 {
		return true
	}
	return aIndex > bIndex
}

func indexOf(arr []int, n int) int {
	for k, v := range arr {
		if v == n {
			return k
		}
	}
	return -1
}

type rule struct {
	before int
	after  int
}

func readInput() ([]rule, [][]int) {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	rules := make([]rule, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		t := scanner.Text()
		if t == "" {
			break
		}
		splits := strings.Split(t, "|")
		b, err := strconv.Atoi(splits[0])
		if err != nil {
			panic(err)
		}
		a, err := strconv.Atoi(splits[1])
		if err != nil {
			panic(err)
		}
		rules = append(rules, rule{before: b, after: a})
	}
	updates := make([][]int, 0)
	for scanner.Scan() {
		nums := scanner.Text()
		splitNums := strings.Split(nums, ",")
		update := make([]int, 0)
		for _, n := range splitNums {
			ni, err := strconv.Atoi(n)
			if err != nil {
				panic(err)
			}
			update = append(update, ni)
		}
		updates = append(updates, update)
	}
	return rules, updates
}
