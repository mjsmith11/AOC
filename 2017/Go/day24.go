package main

import (
	"bufio"
	"os"
	"strconv"
	"strings"
)

const (
	file24 = "day24/input.txt"
)

type component struct {
	port1 int
	port2 int
	used  bool
}

var max int

func day24Part1() int {
	components := day24readFile()
	max = 0
	buildChain(components, 0)
	return max
}

func buildChain(components []*component, need int) {
	addedALink := false
	for k, v := range components {
		if (v.port1 == need || v.port2 == need) && !v.used {
			addedALink = true
			components[k].used = true
			var next int
			if v.port1 == need {
				next = v.port2
			} else {
				next = v.port1
			}
			buildChain(components, next)

			components[k].used = false
		}
	}

	if !addedALink {
		weight := 0
		for _, v := range components {
			if v.used {
				weight += v.port1
				weight += v.port2
			}
		}
		if weight > max {
			max = weight
		}
	}

}

func day24readFile() []*component {
	file, err := os.Open(file24)
	if err != nil {
		panic(err)
	}
	defer func() {
		if err := file.Close(); err != nil {
			panic(err)
		}
	}()
	scanner := bufio.NewScanner(file)
	arr := make([]*component, 57, 57)
	index := 0
	for scanner.Scan() {
		ports := strings.Split(scanner.Text(), "/")
		arr[index] = new(component)
		arr[index].port1, _ = strconv.Atoi(ports[0])
		arr[index].port2, _ = strconv.Atoi(ports[1])
		arr[index].used = false

		index++
	}
	return arr
}
