package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

// +---+---+---+
// | 7 | 8 | 9 |
// +---+---+---+
// | 4 | 5 | 6 |
// +---+---+---+
// | 1 | 2 | 3 |
// +---+---+---+
//     | 0 | A |
//     +---+---+

//     +---+---+
//     | ^ | A |
// +---+---+---+
// | < | v | > |
// +---+---+---+

func main() {
	fmt.Println("Part 1:", run(2))
	fmt.Println("Part 2:", run(25))
}

func run(intermediates int) int {
	codes := readInput()
	seqCache = make(map[string]int)
	ans := 0
	for _, c := range codes {
		seq := getSequenceLength(c, intermediates+1)
		num, err := strconv.Atoi(c[:3])
		if err != nil {
			panic(err)
		}
		ans += (seq * num)
	}
	return ans
}

func getSequenceLength(target string, depth int) int {
	cacheKey := fmt.Sprintf("%v,%v", target, depth)
	if v, ok := seqCache[cacheKey]; ok {
		return v
	}
	length := 0
	if depth == 0 {
		return len(target)
	} else {
		current := 'A'
		for _, next := range target {
			len := getMoveCount(current, next, depth)
			current = next
			length += len
		}
	}
	seqCache[cacheKey] = length
	return length
}

func getMoveCount(current, next rune, depth int) int {
	if current == next {
		return 1
	}
	newSeq := paths[buttonPair{first: current, second: next}]
	return getSequenceLength(newSeq, depth-1)
}

func readInput() []string {
	lines := make([]string, 0)

	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}
	return lines
}

type buttonPair struct {
	first  rune
	second rune
}

var (
	seqCache map[string]int
	paths    = map[buttonPair]string{
		{'A', '0'}: "<A",
		{'0', 'A'}: ">A",
		{'A', '1'}: "^<<A",
		{'1', 'A'}: ">>vA",
		{'A', '2'}: "<^A",
		{'2', 'A'}: "v>A",
		{'A', '3'}: "^A",
		{'3', 'A'}: "vA",
		{'A', '4'}: "^^<<A",
		{'4', 'A'}: ">>vvA",
		{'A', '5'}: "<^^A",
		{'5', 'A'}: "vv>A",
		{'A', '6'}: "^^A",
		{'6', 'A'}: "vvA",
		{'A', '7'}: "^^^<<A",
		{'7', 'A'}: ">>vvvA",
		{'A', '8'}: "<^^^A",
		{'8', 'A'}: "vvv>A",
		{'A', '9'}: "^^^A",
		{'9', 'A'}: "vvvA",
		{'0', '1'}: "^<A",
		{'1', '0'}: ">vA",
		{'0', '2'}: "^A",
		{'2', '0'}: "vA",
		{'0', '3'}: "^>A",
		{'3', '0'}: "<vA",
		{'0', '4'}: "^<^A",
		{'4', '0'}: ">vvA",
		{'0', '5'}: "^^A",
		{'5', '0'}: "vvA",
		{'0', '6'}: "^^>A",
		{'6', '0'}: "<vvA",
		{'0', '7'}: "^^^<A",
		{'7', '0'}: ">vvvA",
		{'0', '8'}: "^^^A",
		{'8', '0'}: "vvvA",
		{'0', '9'}: "^^^>A",
		{'9', '0'}: "<vvvA",
		{'1', '2'}: ">A",
		{'2', '1'}: "<A",
		{'1', '3'}: ">>A",
		{'3', '1'}: "<<A",
		{'1', '4'}: "^A",
		{'4', '1'}: "vA",
		{'1', '5'}: "^>A",
		{'5', '1'}: "<vA",
		{'1', '6'}: "^>>A",
		{'6', '1'}: "<<vA",
		{'1', '7'}: "^^A",
		{'7', '1'}: "vvA",
		{'1', '8'}: "^^>A",
		{'8', '1'}: "<vvA",
		{'1', '9'}: "^^>>A",
		{'9', '1'}: "<<vvA",
		{'2', '3'}: ">A",
		{'3', '2'}: "<A",
		{'2', '4'}: "<^A",
		{'4', '2'}: "v>A",
		{'2', '5'}: "^A",
		{'5', '2'}: "vA",
		{'2', '6'}: "^>A",
		{'6', '2'}: "<vA",
		{'2', '7'}: "<^^A",
		{'7', '2'}: "vv>A",
		{'2', '8'}: "^^A",
		{'8', '2'}: "vvA",
		{'2', '9'}: "^^>A",
		{'9', '2'}: "<vvA",
		{'3', '4'}: "<<^A",
		{'4', '3'}: "v>>A",
		{'3', '5'}: "<^A",
		{'5', '3'}: "v>A",
		{'3', '6'}: "^A",
		{'6', '3'}: "vA",
		{'3', '7'}: "<<^^A",
		{'7', '3'}: "vv>>A",
		{'3', '8'}: "<^^A",
		{'8', '3'}: "vv>A",
		{'3', '9'}: "^^A",
		{'9', '3'}: "vvA",
		{'4', '5'}: ">A",
		{'5', '4'}: "<A",
		{'4', '6'}: ">>A",
		{'6', '4'}: "<<A",
		{'4', '7'}: "^A",
		{'7', '4'}: "vA",
		{'4', '8'}: "^>A",
		{'8', '4'}: "<vA",
		{'4', '9'}: "^>>A",
		{'9', '4'}: "<<vA",
		{'5', '6'}: ">A",
		{'6', '5'}: "<A",
		{'5', '7'}: "<^A",
		{'7', '5'}: "v>A",
		{'5', '8'}: "^A",
		{'8', '5'}: "vA",
		{'5', '9'}: "^>A",
		{'9', '5'}: "<vA",
		{'6', '7'}: "<<^A",
		{'7', '6'}: "v>>A",
		{'6', '8'}: "<^A",
		{'8', '6'}: "v>A",
		{'6', '9'}: "^A",
		{'9', '6'}: "vA",
		{'7', '8'}: ">A",
		{'8', '7'}: "<A",
		{'7', '9'}: ">>A",
		{'9', '7'}: "<<A",
		{'8', '9'}: ">A",
		{'9', '8'}: "<A",
		{'<', '^'}: ">^A",
		{'^', '<'}: "v<A",
		{'<', 'v'}: ">A",
		{'v', '<'}: "<A",
		{'<', '>'}: ">>A",
		{'>', '<'}: "<<A",
		{'<', 'A'}: ">>^A",
		{'A', '<'}: "v<<A",
		{'^', 'v'}: "vA",
		{'v', '^'}: "^A",
		{'^', '>'}: "v>A",
		{'>', '^'}: "<^A",
		{'^', 'A'}: ">A",
		{'A', '^'}: "<A",
		{'v', '>'}: ">A",
		{'>', 'v'}: "<A",
		{'v', 'A'}: "^>A",
		{'A', 'v'}: "<vA",
		{'>', 'A'}: "^A",
		{'A', '>'}: "vA",
	}
)
