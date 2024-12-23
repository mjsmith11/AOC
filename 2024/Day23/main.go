package main

import (
	"bufio"
	"fmt"
	"os"
	"slices"
	"strings"
)

var adj map[string][]string

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	readInput()
	ans := 0
	keys := make([]string, 0)
	for k, _ := range adj {
		keys = append(keys, k)
	}
	for i := 0; i < len(keys)-2; i++ {
		for j := i + 1; j < len(keys)-1; j++ {
			for k := j + 1; k < len(keys); k++ {
				k1 := keys[i]
				k2 := keys[j]
				k3 := keys[k]
				if k1[0] == 't' || k2[0] == 't' || k3[0] == 't' {
					if contains(adj[k1], k2) && contains(adj[k1], k3) && contains(adj[k2], k3) {
						ans++
					}
				}
			}
		}
	}
	return ans
}

func part2() string {
	readInput()
	cliques := make([][]string, 0)
	used := make(map[string]bool)
	keys := make([]string, 0)
	for k, _ := range adj {
		keys = append(keys, k)
	}
	// start by finding all cliques of size 3
	dedup := make(map[string]bool)
	for i := 0; i < len(keys)-2; i++ {
		for j := i + 1; j < len(keys)-1; j++ {
			for k := j + 1; k < len(keys); k++ {
				k1 := keys[i]
				k2 := keys[j]
				k3 := keys[k]
				if contains(adj[k1], k2) && contains(adj[k1], k3) && contains(adj[k2], k3) {
					used[k1] = true
					used[k2] = true
					used[k3] = true
					myC := []string{k1, k2, k3}
					myCS := strarrToString(myC)
					if !dedup[myCS] {
						cliques = append(cliques, []string{k1, k2, k3})
						dedup[myCS] = true
					}
				}
			}
		}
	}

	// keep trying to add 1 more to every clique until there's only 1 possible clique that's big enough
	cliqueSize := 3
	for len(cliques) > 1 {
		dedup := make(map[string]bool)
		newCliques := make([][]string, 0)
		for _, c := range cliques {
			for _, k := range keys {
				ok := true
				for _, member := range c {
					if !contains(adj[member], k) {
						ok = false
						break
					}
				}
				if ok {
					newClique := make([]string, 0)
					newClique = append(newClique, c...)
					newClique = append(newClique, k)
					newCliqueS := strarrToString(newClique)
					if !dedup[newCliqueS] {
						newCliques = append(newCliques, newClique)
						dedup[newCliqueS] = true
					}
				}
			}
		}

		cliques = newCliques
		cliqueSize++
	}
	return strarrToString(cliques[0])
}

func strarrToString(arr []string) string {
	slices.Sort(arr)
	return strings.Join(arr, ",")
}
func contains(arr []string, s string) bool {
	for _, v := range arr {
		if v == s {
			return true
		}
	}
	return false
}

func readInput() {

	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	adj = make(map[string][]string)

	for scanner.Scan() {
		splits := strings.Split(scanner.Text(), "-")
		adj[splits[0]] = append(adj[splits[0]], splits[1])
		adj[splits[1]] = append(adj[splits[1]], splits[0])
	}
}
