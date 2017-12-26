package main

import (
	"bufio"
	"os"
)

const (
	file22   = "day22/input.txt"
	size     = 2000
	inpSize  = 25
	inpStart = 1000
)

func day22part1() int {
	net := make([][]*node, size)
	for i := range net {
		net[i] = make([]*node, size)
	}

	for y := 0; y < size; y++ {
		for x := 0; x < size; x++ {
			net[y][x] = new(node)
			net[y][x].status = "C"
		}
	}

	file, err := os.Open(file22)
	if err != nil {
		panic(err)
	}
	defer func() {
		if err := file.Close(); err != nil {
			panic(err)
		}
	}()
	scanner := bufio.NewScanner(file)
	dy := inpStart
	for scanner.Scan() {
		dx := inpStart
		line := scanner.Text()
		for _, v := range line {
			if v == '#' {
				net[dy][dx].status = "I"
			}
			dx++
		}
		dy++
	}

	dy = inpStart + inpSize/2
	dx := inpStart + inpSize/2
	dir := "up"

	bursts := 10000000
	infectionsCaused := 0
	for i := 0; i < bursts; i++ {
		if net[dy][dx].status == "C" {
			dir = turn(dir, "left")
			net[dy][dx].status = "W"
		} else if net[dy][dx].status == "W" {
			net[dy][dx].status = "I"
			infectionsCaused++
		} else if net[dy][dx].status == "I" {
			dir = turn(dir, "right")
			net[dy][dx].status = "F"
		} else { // flagged
			dir = reverse(dir)
			net[dy][dx].status = "C"
		}
		dx, dy = netMove(dx, dy, dir)

	}
	return infectionsCaused
}
func reverse(curDir string) string {
	switch curDir {
	case "up":
		return "down"
	case "down":
		return "up"
	case "left":
		return "right"
	case "right":
		return "left"
	default:
		panic("bad reverse")
	}
}
func netMove(x, y int, dir string) (int, int) {
	if dir == "up" {
		return x, y - 1
	} else if dir == "down" {
		return x, y + 1
	} else if dir == "left" {
		return x - 1, y
	} else if dir == "right" {
		return x + 1, y
	}
	panic("bad move")
}
func turn(curDir, turnDir string) string {
	if curDir == "up" {
		return turnDir
	} else if curDir == "down" {
		if turnDir == "left" {
			return "right"
		} else if turnDir == "right" {
			return "left"
		}
	} else if curDir == "left" {
		if turnDir == "left" {
			return "down"
		} else if turnDir == "right" {
			return "up"
		}
	} else if curDir == "right" {
		if turnDir == "left" {
			return "up"
		} else if turnDir == "right" {
			return "down"
		}
	}
	panic("Bad Turn Params")
}

type node struct {
	status string
}
