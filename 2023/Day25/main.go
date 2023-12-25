package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {

	printEdges() // put result into graphviz and visual identify 3 to cut.  I could only get it to do about half of the real input without a memory error, but it was enough

	g := makeGraph()

	// count from each side of one of the cuts
	fmt.Println(g.countFrom("hvm") * g.countFrom("grd"))

}

func printEdges() {
	// sample graphviz input
	/*digraph G {
		fontname="Helvetica,Arial,sans-serif"
		node [fontname="Helvetica,Arial,sans-serif"]
		edge [fontname="Helvetica,Arial,sans-serif"]
		layout=neato
		center=""
		node[width=.25,height=.375,fontsize=9]
	jqt -> rhn;
	jqt -> xhk;
	jqt -> nvd;
	rsh -> frs;
	rsh -> pzl;
	rsh -> lsr;
	xhk -> hfx;
	cmg -> qnr;

	}*/
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	for scanner.Scan() {
		t := scanner.Text()
		lAndR := strings.Split(t, ": ")
		connections := strings.Split(lAndR[1], " ")
		for _, v := range connections {
			fmt.Printf("%s -> %s;\n", lAndR[0], v)
		}
	}
}

func makeGraph() *Graph {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	g := newGraph()
	// add edges to cut based on visual
	g.AddNotAllowed("hvm", "grd")
	g.AddNotAllowed("pmn", "kdc")
	g.AddNotAllowed("jmn", "zfk")
	scanner := bufio.NewScanner(f)
	defer f.Close()
	for scanner.Scan() {
		t := scanner.Text()
		lAndR := strings.Split(t, ": ")
		connections := strings.Split(lAndR[1], " ")
		for _, v := range connections {
			g.AddAdjacency(v, lAndR[0])
		}
	}
	return g
}

type Graph struct {
	adjacency     map[string][]string
	nonAllowedAdj []stringPair
}

func newGraph() *Graph {
	return &Graph{
		adjacency:     make(map[string][]string, 0),
		nonAllowedAdj: make([]stringPair, 0),
	}
}

func (g *Graph) AddAdjacency(a, b string) {
	for _, v := range g.nonAllowedAdj {
		if a == v.s1 && b == v.s2 || b == v.s1 && a == v.s2 {
			return
		}
	}
	if _, ok := g.adjacency[a]; !ok {
		g.adjacency[a] = make([]string, 0)
	}
	if _, ok := g.adjacency[b]; !ok {
		g.adjacency[b] = make([]string, 0)
	}
	g.adjacency[a] = append(g.adjacency[a], b)
	g.adjacency[b] = append(g.adjacency[b], a)
}

func (g *Graph) AddNotAllowed(a, b string) {
	g.nonAllowedAdj = append(g.nonAllowedAdj, stringPair{
		s1: a,
		s2: b,
	})
}

func (g *Graph) countFrom(start string) int {
	expl := make([]string, 0)
	expl = append(expl, start)
	visited := make(map[string]bool)
	for len(expl) > 0 {
		current := expl[0]
		expl = expl[1:]
		visited[current] = true
		for _, v := range g.adjacency[current] {
			if _, ok := visited[v]; !ok {
				expl = append(expl, v)
			}
		}
	}
	return len(visited)
}

type stringPair struct {
	s1 string
	s2 string
}
