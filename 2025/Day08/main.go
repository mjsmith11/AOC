package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"sort"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", part1(1000))
	fmt.Println("Part 2:", part2())
}

func part1(limit int) int {
	n, e := readInput()
	dsu := NewDSU(len(n))
	count := 0

	for _, edge := range e {
		if dsu.Find(edge.a.id) != dsu.Find(edge.b.id) {
			dsu.Union(edge.a.id, edge.b.id)
		}
		count++
		if count == limit {
			break
		}
	}
	return dsu.FindTop3Prod()
}

func part2() int {
	n, e := readInput()
	dsu := NewDSU(len(n))
	count := 0

	var lastEdge *edge

	for _, edge := range e {
		if dsu.Find(edge.a.id) != dsu.Find(edge.b.id) {
			dsu.Union(edge.a.id, edge.b.id)
			lastEdge = &edge
			count++
			if count == len(n)-1 {
				break
			}
		}
	}
	return int(lastEdge.a.x) * int(lastEdge.b.x)
}

type DSU struct {
	parent []int
	rank   []int
}

func NewDSU(size int) *DSU {
	parent := make([]int, size)
	rank := make([]int, size)

	for i := 0; i < size; i++ {
		parent[i] = i
		rank[i] = 1
	}
	return &DSU{
		parent: parent,
		rank:   rank,
	}
}

func (d *DSU) Find(i int) int {
	if d.parent[i] != i {
		d.parent[i] = d.Find(d.parent[i])
	}
	return d.parent[i]
}

func (d *DSU) Union(x, y int) {
	s1 := d.Find(x)
	s2 := d.Find(y)

	if s1 != s2 {
		if d.rank[s1] < d.rank[s2] {
			d.parent[s1] = s2
		} else if d.rank[s1] > d.rank[s2] {
			d.parent[s2] = s1
		} else {
			d.parent[s2] = s1
			d.rank[s1]++
		}
	}
}

func (d *DSU) FindTop3Prod() int {
	sizes := make(map[int]int, 0)
	for i := 0; i < len(d.parent); i++ {
		parent := d.Find(i)
		sizes[parent]++
	}
	sizesArr := make([]int, 0)
	for _, v := range sizes {
		sizesArr = append(sizesArr, v)
	}
	sort.Ints(sizesArr)

	return sizesArr[len(sizesArr)-1] * sizesArr[len(sizesArr)-2] * sizesArr[len(sizesArr)-3]

}

type node struct {
	x  int64
	y  int64
	z  int64
	id int
}

func (n *node) dist(n2 *node) float64 {
	return math.Sqrt(math.Pow(float64(n.x-n2.x), 2) + math.Pow(float64(n.y-n2.y), 2) + math.Pow(float64(n.z-n2.z), 2))
}

type edge struct {
	a *node
	b *node
}

func readInput() ([]node, []edge) {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	nodes := make([]node, 0)

	id := 0

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		splits := strings.Split(str, ",")
		x, err := strconv.ParseInt(splits[0], 10, 64)
		if err != nil {
			panic(err)
		}
		y, err := strconv.ParseInt(splits[1], 10, 64)
		if err != nil {
			panic(err)
		}
		z, err := strconv.ParseInt(splits[2], 10, 64)
		if err != nil {
			panic(err)
		}
		nodes = append(nodes, node{
			x:  x,
			y:  y,
			z:  z,
			id: id,
		})
		id++
	}

	edges := make([]edge, 0)
	for i := 0; i < len(nodes); i++ {
		for j := i + 1; j < len(nodes); j++ {
			edges = append(edges, edge{
				a: &nodes[i],
				b: &nodes[j],
			})
		}
	}
	sort.Slice(edges, func(i, j int) bool {
		return edges[i].a.dist(edges[i].b) < edges[j].a.dist(edges[j].b)
	})
	return nodes, edges
}
