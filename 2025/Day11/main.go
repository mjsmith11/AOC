package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {
	fmt.Println("Part 1:", runDfs(readInput(), "you", "out", make(map[string]int, 0)))
	fmt.Println("Part 2:", part2())
}

type node struct {
	name string
}

func part2() int {
	inp := readInput()
	a1 := runDfs(inp, "svr", "fft", make(map[string]int, 0))
	b1 := runDfs(inp, "fft", "dac", make(map[string]int, 0))
	c1 := runDfs(inp, "dac", "out", make(map[string]int, 0))

	a2 := runDfs(inp, "svr", "dac", make(map[string]int, 0))
	b2 := runDfs(inp, "dac", "fft", make(map[string]int, 0))
	c2 := runDfs(inp, "fft", "out", make(map[string]int, 0))

	return a1*b1*c1 + a2*b2*c2

}

func runDfs(inp map[string][]*node, cur, target string, memiozation map[string]int) int {
	if cur == target {
		return 1
	}
	if v, ok := memiozation[cur]; ok {
		return v
	}

	sum := 0
	for _, n := range inp[cur] {
		sum += runDfs(inp, n.name, target, memiozation)
	}
	memiozation[cur] = sum
	return sum
}

func readInput() map[string][]*node {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	nodes := make(map[string]node, 0)
	adj := make(map[string][]*node, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		parts := strings.Split(str, ": ")
		var thisNode node
		if v, ok := nodes[parts[0]]; ok {
			thisNode = v
		} else {
			thisNode = node{
				name: parts[0],
			}
			nodes[thisNode.name] = thisNode
			adj[thisNode.name] = make([]*node, 0)
		}

		adjacents := strings.Split(parts[1], " ")
		for _, a := range adjacents {
			if _, ok := nodes[a]; !ok {
				nodes[a] = node{
					name: a,
				}
				adj[a] = make([]*node, 0)
			}
			adjNode := nodes[a]
			adj[thisNode.name] = append(adj[thisNode.name], &adjNode)
		}
	}
	return adj
}
