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

func part1() int64 {
	sets := readInput()
	var invalidSum int64
	for _, s := range sets {
		for i := s.start; i <= s.stop; i++ {
			nStr := fmt.Sprint(i)
			if len(nStr)%2 != 0 {
				continue
			}
			s1 := nStr[:len(nStr)/2]
			s2 := nStr[len(nStr)/2:]
			if s1 == s2 {
				invalidSum += i
			}
		}
	}
	return invalidSum
}

func part2() int64 {
	sets := readInput()
	var invalidSum int64
	for _, s := range sets {
		for i := s.start; i <= s.stop; i++ {
			nStr := fmt.Sprint(i)
			foundGoodLength := false
			for patternLength := 1; patternLength <= len(nStr)/2; patternLength++ {
				if len(nStr)%patternLength != 0 {
					continue
				}
				firstStr := nStr[:patternLength]
				good := true
				for j := 1; j < len(nStr)/patternLength; j++ {
					jStr := nStr[j*patternLength : (j+1)*(patternLength)]
					if firstStr != jStr {
						good = false
						break
					}
				}
				if good {
					foundGoodLength = true
					break
				}
			}
			if foundGoodLength {
				invalidSum += i
			}
		}
	}
	return invalidSum
}

type idSet struct {
	start int64
	stop  int64
}

func readInput() []idSet {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([]idSet, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		ranges := strings.Split(str, ",")
		for _, r := range ranges {
			nums := strings.Split(r, "-")
			start, err := strconv.ParseInt(nums[0], 10, 64)
			if err != nil {
				panic(err)
			}
			end, err := strconv.ParseInt(nums[1], 10, 64)
			if err != nil {
				panic(err)
			}
			a = append(a, idSet{
				start: start,
				stop:  end,
			})
		}
	}
	return a
}
