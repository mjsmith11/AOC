package main

import "fmt"

func main() {
	nodes, edges := createGraph()
	fmt.Println(traverse(0, nodes, edges))
}
