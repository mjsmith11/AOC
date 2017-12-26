package main

const (
	tapeSize   = 100000
	startState = "A"
	steps      = 12317297
)

func turing() int {
	tape := make([]bool, tapeSize)
	state := startState
	slot := tapeSize / 2
	for i := 0; i < steps; i++ {
		if state == "A" {
			if !tape[slot] {
				tape[slot] = true
				slot++
				state = "B"
			} else {
				tape[slot] = false
				slot--
				state = "D"
			}
		} else if state == "B" {
			if !tape[slot] {
				tape[slot] = true
				slot++
				state = "C"
			} else {
				tape[slot] = false
				slot++
				state = "F"
			}
		} else if state == "C" {
			if !tape[slot] {
				tape[slot] = true
				slot--
				state = "C"
			} else {
				tape[slot] = true
				slot--
				state = "A"
			}
		} else if state == "D" {
			if !tape[slot] {
				tape[slot] = false
				slot--
				state = "E"
			} else {
				tape[slot] = true
				slot++
				state = "A"
			}
		} else if state == "E" {
			if !tape[slot] {
				tape[slot] = true
				slot--
				state = "A"
			} else {
				tape[slot] = false
				slot++
				state = "B"
			}
		} else if state == "F" {
			if !tape[slot] {
				tape[slot] = false
				slot++
				state = "C"
			} else {
				tape[slot] = false
				slot++
				state = "E"
			}
		} else {
			panic("")
		}
	}
	checksum := 0
	for _, v := range tape {
		if v {
			checksum++
		}
	}
	return checksum
}
