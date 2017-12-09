package main

import (
	"fmt"
	"io/ioutil"
)

func main() {
	dat, _ := ioutil.ReadFile("day9input.txt")
	fmt.Println(scoreGroup(string(dat)))
}
