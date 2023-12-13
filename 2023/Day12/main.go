package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1", run(readInput))
	fmt.Println("Part 2", run(readInput2))
}

var (
	cache map[string]int
)

func run(readFunc func() []*springs) int {
	total := 0
	cache = make(map[string]int, 0)
	mySprings := readFunc()
	for _, s := range mySprings {
		amt := countWays(s.pattern, s.groupSizes)
		total += amt
	}
	return total
}

func countWays(s string, groups []int) int {
	if ans, ok := cache[getKey(s, groups)]; ok {
		return ans
	}
	if s == "" {
		if len(groups) == 0 {
			cache[getKey(s, groups)] = 1
			return 1
		} else {
			cache[getKey(s, groups)] = 0
			return 0
		}
	}
	if s[0] == '.' {
		amt := countWays(s[1:], groups)
		cache[getKey(s, groups)] = amt
		return amt
	} else if s[0] == '?' {
		new1 := "." + s[1:]
		new2 := "#" + s[1:]
		amt := countWays(new1, groups) + countWays(new2, groups)
		cache[getKey(s, groups)] = amt
		return amt
	} else if s[0] == '#' {
		if len(groups) == 0 {
			cache[getKey(s, groups)] = 0
			return 0
		}
		if len(s) < groups[0] {
			cache[getKey(s, groups)] = 0
			return 0
		}
		for i := 0; i < groups[0]; i++ {
			if s[i] == '.' {
				cache[getKey(s, groups)] = 0
				return 0
			}
		}
		if len(s) > groups[0] && s[groups[0]] == '#' {
			cache[getKey(s, groups)] = 0 // cannot have a damaged one immediately after a group
			return 0
		}
		newStr := s[groups[0]:]
		if len(newStr) > 0 && newStr[0] == '?' {
			newStr = "." + newStr[1:] // cannot have a damaged one immediately after a group
		}
		amt := countWays(newStr, groups[1:])
		cache[getKey(s, groups)] = amt
		return amt
	} else {
		fmt.Println("Unexpected else")
		cache[getKey(s, groups)] = 0
		return 0
	}
}

func getKey(s string, groups []int) string {
	return fmt.Sprint(s, groups)
}

func readInput() []*springs {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	springsArr := make([]*springs, 0)
	for scanner.Scan() {
		text := scanner.Text()
		parts := strings.Split(text, " ")
		numStrs := strings.Split(parts[1], ",")
		nums := make([]int, len(numStrs))
		for i, s := range numStrs {
			num, err := strconv.Atoi(s)
			if err != nil {
				panic(err)
			}
			nums[i] = num
		}
		springsArr = append(springsArr, &springs{
			pattern:    parts[0],
			groupSizes: nums,
		})
	}
	return springsArr
}

func readInput2() []*springs {
	springs1 := readInput()
	newSprings := make([]*springs, 0)
	for _, s := range springs1 {
		newPattern := strings.Join([]string{s.pattern, s.pattern, s.pattern, s.pattern, s.pattern}, "?")
		newGroups := make([]int, 0)
		for i := 0; i < 5; i++ {
			newGroups = append(newGroups, s.groupSizes...)
		}
		newSprings = append(newSprings, &springs{
			pattern:    newPattern,
			groupSizes: newGroups,
		})
	}
	return newSprings
}

type springs struct {
	pattern    string
	groupSizes []int
}
