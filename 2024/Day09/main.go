package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	input := readInput()
	disk := make([]*int, 0)
	isFile := true
	fileIndex := 0
	for _, r := range input {
		n, err := strconv.Atoi(string(r))
		if err != nil {
			panic(err)
		}
		fi := fileIndex
		for i := 0; i < n; i++ {
			if isFile {
				disk = append(disk, &fi)
			} else {
				disk = append(disk, nil)
			}
		}
		isFile = !isFile
		if isFile {
			fileIndex++
		}
	}
	freePtr := 0
	for disk[freePtr] != nil {
		freePtr++
	}
	movePtr := len(disk) - 1
	for disk[movePtr] == nil {
		movePtr--
	}

	for freePtr < movePtr {
		disk[freePtr] = disk[movePtr]
		disk[movePtr] = nil
		freePtr++
		for disk[freePtr] != nil {
			freePtr++
		}
		movePtr--
		for disk[movePtr] == nil {
			movePtr--
		}
	}
	cs := 0
	for i, v := range disk {
		if v == nil {
			break
		}
		cs += (i * *v)
	}
	return cs
}

type block struct {
	startInd int
	endInd   int
	id       *int
}

func (b block) length() int {
	return b.endInd - b.startInd
}

func part2() int {
	input := readInput()
	free := make([]block, 0)
	files := make([]block, 0)
	isFile := true
	fileIndex := 0
	diskIndex := 0
	for _, r := range input {
		n, err := strconv.Atoi(string(r))
		if err != nil {
			panic(err)
		}
		fi := fileIndex
		if isFile {
			files = append(files, block{
				startInd: diskIndex,
				endInd:   diskIndex + n,
				id:       &fi,
			})
		} else {
			free = append(free, block{
				startInd: diskIndex,
				endInd:   diskIndex + n,
				id:       nil,
			})
		}
		isFile = !isFile
		if isFile {
			fileIndex++
		}
		diskIndex += n
	}

	for file := len(files) - 1; file >= 0; file-- {
		for fr := 0; fr < len(free); fr++ {
			if free[fr].startInd > files[file].startInd {
				break
			}
			if free[fr].length() >= files[file].length() {
				fileLen := files[file].length()
				files[file].startInd = free[fr].startInd
				files[file].endInd = files[file].startInd + fileLen
				free[fr].startInd = free[fr].startInd + fileLen
			}
		}
	}
	cs := 0
	for _, f := range files {
		for i := f.startInd; i < f.endInd; i++ {
			cs += (i * *f.id)
		}
	}
	return cs
}

func readInput() string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	scanner := bufio.NewScanner(f)
	scanner.Scan()
	return scanner.Text()
}
