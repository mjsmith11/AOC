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
	fmt.Println("Part 2 ", part2())
}

func part1() int64 {
	input := readInput()
	mapping := make(map[int64]int64, len(input.seeds))
	for _, v := range input.seeds {
		mapping[v] = v
	}
	for _, v := range input.rules {
		mapping = doMap(mapping, v)
	}
	min := int64(math.MaxInt64)
	for _, v := range mapping {
		if v < min {
			min = v
		}
	}
	return min
}

func part2() int64 {
	input := readInput2()
	// map block to beginning of mapping
	mapping := make(map[seedBlock]int64, len(input.seeds))
	var leftover map[seedBlock]int64
	for _, v := range input.seeds {
		mapping[v] = v.blockStart
	}
	for _, v := range input.rules {
		mapping, leftover = doMap2(mapping, v)
		var m1 map[seedBlock]int64
		for len(leftover) > 0 {
			m1, leftover = doMap2(leftover, v)
			for k, v := range m1 {
				mapping[k] = v
			}
		}
	}
	min := int64(math.MaxInt64)
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
	mySeeds := make([]int64, 0)
	scanner.Scan()
	seedStr := scanner.Text()
	numsStr := strings.Split(seedStr, ": ")[1]
	splitNumStr := strings.Split(numsStr, " ")
	for _, n := range splitNumStr {
		int64N, err := strconv.ParseInt(n, 10, 64)
		if err != nil {
			panic(err)
		}
		mySeeds = append(mySeeds, int64N)
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
			dest, err := strconv.ParseInt(parts[0], 10, 64)
			if err != nil {
				panic(err)
			}
			src, err := strconv.ParseInt(parts[1], 10, 64)
			if err != nil {
				panic(err)
			}
			length, err := strconv.ParseInt(parts[2], 10, 64)
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
			fmt.Println("Not expected")
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

func readInput2() *input2 {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	scanner := bufio.NewScanner(f)

	// read seeds
	mySeeds := make([]seedBlock, 0)
	scanner.Scan()
	seedStr := scanner.Text()
	numsStr := strings.Split(seedStr, ": ")[1]
	splitNumStr := strings.Split(numsStr, " ")
	for i := 0; i < len(splitNumStr); i += 2 {
		start, err := strconv.ParseInt(splitNumStr[i], 10, 64)
		if err != nil {
			panic(err)
		}
		length, err := strconv.ParseInt(splitNumStr[i+1], 10, 64)
		if err != nil {
			panic(err)
		}
		mySeeds = append(mySeeds, seedBlock{
			blockStart:  start,
			blockLength: length,
		})
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
			dest, err := strconv.ParseInt(parts[0], 10, 64)
			if err != nil {
				panic(err)
			}
			src, err := strconv.ParseInt(parts[1], 10, 64)
			if err != nil {
				panic(err)
			}
			length, err := strconv.ParseInt(parts[2], 10, 64)
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
			fmt.Println("Not expected 2")
		}
	}
	// append the last ruleset
	rulesets = append(rulesets, thisRuleSet)
	thisRuleSet = make([]mappingRule, 0)
	return &input2{
		seeds: mySeeds,
		rules: rulesets,
	}
}

func doMap(in map[int64]int64, rules mappingRuleset) map[int64]int64 {
	out := make(map[int64]int64, len(in))
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

func doMap2(in map[seedBlock]int64, rules mappingRuleset) (map[seedBlock]int64, map[seedBlock]int64) {
	leftover := make(map[seedBlock]int64, 2*len(in))
	out := make(map[seedBlock]int64, 2*len(in))
	for k, v := range in {
		appliedRule := false
		if k.blockLength == 0 {
			continue
		}
		for _, r := range rules {
			seedStop := k.blockStart + k.blockLength
			ruleStop := r.sourceStart + r.windowLength

			if k.blockStart <= r.sourceStart && seedStop > r.sourceStart && seedStop < ruleStop {
				// seed |--------|
				// rule     |---------|
				leftover[seedBlock{
					blockStart:  k.blockStart,
					blockLength: r.sourceStart - k.blockStart,
				}] = v
				out[seedBlock{
					blockStart:  r.destinationStart,
					blockLength: seedStop - r.sourceStart,
				}] = r.destinationStart
				appliedRule = true
			} else if k.blockStart > r.sourceStart && k.blockStart < ruleStop && seedStop >= ruleStop {
				// seed     |--------|
				// rule |---------|
				out[seedBlock{
					blockStart:  r.destinationStart + (k.blockStart - r.sourceStart),
					blockLength: ruleStop - k.blockStart,
				}] = r.destinationStart + (k.blockStart - r.sourceStart)
				leftover[seedBlock{
					blockStart:  ruleStop,
					blockLength: seedStop - ruleStop,
				}] = ruleStop
				appliedRule = true
			} else if k.blockStart > r.sourceStart && seedStop < ruleStop {
				// seed     |--|
				// rule |---------|
				out[seedBlock{
					blockStart:  r.destinationStart + (k.blockStart - r.sourceStart),
					blockLength: k.blockLength,
				}] = r.destinationStart + (k.blockStart - r.sourceStart)
				appliedRule = true
			} else if r.sourceStart > k.blockStart && ruleStop < seedStop {
				// seed |---------|
				// rule    |----|
				leftover[seedBlock{
					blockStart:  k.blockStart,
					blockLength: r.sourceStart - k.blockStart,
				}] = v
				out[seedBlock{
					blockStart:  r.destinationStart,
					blockLength: r.windowLength,
				}] = r.destinationStart
				leftover[seedBlock{
					blockStart:  ruleStop,
					blockLength: seedStop - ruleStop,
				}] = v + ruleStop
				appliedRule = true
			}
		}
		if !appliedRule {
			out[seedBlock{
				blockStart:  k.blockStart,
				blockLength: k.blockLength,
			}] = v
		}
	}
	return out, leftover
}

type input struct {
	seeds []int64
	rules []mappingRuleset
}
type mappingRule struct {
	destinationStart int64
	sourceStart      int64
	windowLength     int64
}
type mappingRuleset []mappingRule

type seedBlock struct {
	blockStart  int64
	blockLength int64
}

type input2 struct {
	seeds []seedBlock
	rules []mappingRuleset
}
