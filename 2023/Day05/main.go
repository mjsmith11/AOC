package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"strconv"
	"strings"
	"unicode"
)

func main() {
	fmt.Println("Part 1 ", part1())
}

func part1() int {
	input := readInput()
	mapping := make(map[int]int, len(input.seeds))
	for _, v := range input.seeds {
		mapping[v] = v
	}
	for _, v := range input.rules {
		mapping = doMap(mapping, v)
	}
	min := math.MaxInt32
	for _, v := range mapping {
		if v < min {
			min = v
		}
	}
	return min
}

func readInput() *input {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	scanner := bufio.NewScanner(f)

	// read seeds
	mySeeds := make([]int, 0)
	scanner.Scan()
	seedStr := scanner.Text()
	numsStr := strings.Split(seedStr, ": ")[1]
	splitNumStr := strings.Split(numsStr, " ")
	for _, n := range splitNumStr {
		intN, err := strconv.Atoi(n)
		if err != nil {
			panic(err)
		}
		mySeeds = append(mySeeds, intN)
	}

	// eat the blank space after seeds
	scanner.Scan()

	// rules
	rulesets := make([]mappingRuleset, 0)
	thisRuleSet := make([]mappingRule, 0)

	for scanner.Scan() {
		s := scanner.Text()
		if len(s) == 0 {
			// ruleset complete
			rulesets = append(rulesets, thisRuleSet)
			thisRuleSet = make([]mappingRule, 0)
		} else if unicode.IsNumber(rune(s[0])) {
			parts := strings.Split(s, " ")
			dest, err := strconv.Atoi(parts[0])
			if err != nil {
				panic(err)
			}
			src, err := strconv.Atoi(parts[1])
			if err != nil {
				panic(err)
			}
			length, err := strconv.Atoi(parts[2])
			if err != nil {
				panic(err)
			}
			thisRuleSet = append(thisRuleSet, mappingRule{
				destinationStart: dest,
				sourceStart:      src,
				windowLength:     length,
			})
		} else if unicode.IsLetter(rune(s[0])) {
			// ruleset header
			continue
		} else {
			fmt.Println("shit")
		}
	}
	// append the last ruleset
	rulesets = append(rulesets, thisRuleSet)
	thisRuleSet = make([]mappingRule, 0)
	return &input{
		seeds: mySeeds,
		rules: rulesets,
	}
}

func doMap(in map[int]int, rules mappingRuleset) map[int]int {
	out := make(map[int]int, len(in))
	for k, v := range in {
		matched := false
		for _, r := range rules {
			rMax := r.sourceStart + r.windowLength
			if v >= r.sourceStart && v < rMax {
				out[k] = r.destinationStart + (v - r.sourceStart)
				matched = true
				break
			}
		}
		if !matched {
			out[k] = v
		}
	}
	return out
}

type input struct {
	seeds []int
	rules []mappingRuleset
}
type mappingRule struct {
	destinationStart int
	sourceStart      int
	windowLength     int
}
type mappingRuleset []mappingRule
