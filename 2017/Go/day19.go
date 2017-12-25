package main

import (
	"bufio"
	"fmt"
	"os"
)

const (
	file = "day19/input.txt"
)

func d19part1() {
	file, err := os.Open(file)
	if err != nil {
		panic(err)
	}
	defer func() {
		if err := file.Close(); err != nil {
			panic(err)
		}
	}()

	board := make([][]rune, 205)
	for i := range board {
		board[i] = make([]rune, 205)
	}

	dy := 0
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		line := []rune(scanner.Text())
		for dx := 0; dx < len(line); dx++ {
			board[dy][dx] = line[dx]
		}
		dy++
	}

	x := 0
	y := 0
	dir := "down"

	//find starting spot
	for k, v := range board[y] {
		if v == '|' {
			x = k
			break
		}
	}
	steps := 1

	for true {
		//fmt.Println("loop", x, y)
		if board[y][x] > 64 && board[y][x] < 91 {
			fmt.Println(string(board[y][x]), steps)
		}
		if board[y][x] == '+' {
			if dir != "down" && board[y-1][x] == '|' {
				dir = "up"
			} else if dir != "up" && board[y+1][x] == '|' {
				dir = "down"
			} else if dir != "left" && board[y][x+1] == '-' {
				dir = "right"
			} else if dir != "right" && board[y][x-1] == '-' {
				dir = "left"
			}
		}

		x, y = move(x, y, dir)
		steps++
	}
}

func move(curx, cury int, direction string) (int, int) {
	var x, y int
	if direction == "up" {
		x = curx
		y = cury - 1
	} else if direction == "down" {
		x = curx
		y = cury + 1
	} else if direction == "left" {
		x = curx - 1
		y = cury
	} else if direction == "right" {
		x = curx + 1
		y = cury
	}

	return x, y

}
