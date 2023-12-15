package main

import (
	"bufio"
	"container/list"
	"fmt"
	"os"
	"regexp"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1", part1())
	fmt.Println("Part 2", part2())
}

func part1() int {
	strs := readInput()
	total := 0
	for _, s := range strs {
		total += hash(s)
	}
	return total
}
func part2() int {
	instructions := readInput()
	boxes := make(map[int]*list.List, 0)
	re := regexp.MustCompile("^(?P<label>[a-z]+)(?P<symbol>=|-)(?P<num>\\d+)?$")
	for i := 0; i < 256; i++ {
		boxes[i] = list.New()
	}
	for _, s := range instructions {
		parsed := re.FindStringSubmatch(s)
		label := parsed[1]
		symbol := parsed[2]
		box := hash(label)
		if symbol == "=" {
			num, err := strconv.Atoi(parsed[3])
			if err != nil {
				panic(err)
			}
			current := boxes[box].Front()
			replaced := false
			for current != nil {
				if current.Value.(*lens).label == label {
					current.Value.(*lens).focalLength = num
					replaced = true
					break // assuming all labels are unique here
				}
				current = current.Next()
			}
			if !replaced {
				boxes[box].PushBack(&lens{
					label:       label,
					focalLength: num,
				})
			}
		} else if symbol == "-" {
			current := boxes[box].Front()
			for current != nil {
				if current.Value.(*lens).label == label {
					boxes[box].Remove(current)
					break // assuming all labels are unique here
				}
				current = current.Next()
			}
		} else {
			fmt.Println("unexpected")
		}
	}
	total := 0
	for n, b := range boxes {
		current := b.Front()
		slot := 1
		for current != nil {
			focalLength := current.Value.(*lens).focalLength
			power := (1 + n) * slot * focalLength
			total += power

			current = current.Next()
			slot++
		}
	}
	return total
}

type lens struct {
	label       string
	focalLength int
}

func hash(s string) int {
	currentValue := 0
	for _, r := range s {
		currentValue += int(r)
		currentValue *= 17
		currentValue %= 256
	}
	return currentValue
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	scanner.Scan()

	return strings.Split(scanner.Text(), ",")
}
