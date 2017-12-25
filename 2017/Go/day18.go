package main

import (
	"bufio"
	"fmt"
	"strconv"
	"strings"
	"time"
)

func execute(inst []string, pid int, in, out chan int) (valuesSent int) {
	fmt.Println("Running " + strconv.Itoa(pid))
	pc := 0
	reg := make(map[string]int, 26)
	reg["p"] = pid
	valuesSent = 0
	for pc >= 0 && pc < len(inst) {
		parts := strings.Split(inst[pc], " ")
		if parts[0] == "snd" {
			/*out <- getValue(reg, parts[1])
			valuesSent++
			fmt.Println(strconv.Itoa(pid) + " has sent " + strconv.Itoa(valuesSent) + " " + strconv.Itoa(getValue(reg, parts[1])))*/
			select {
			case out <- getValue(reg, parts[1]):
				fmt.Println("send", getValue(reg, parts[1]), "from", pid)
				valuesSent++
			case <-time.After(1 * time.Second):
				return
			}
		} else if parts[0] == "set" {
			reg[parts[1]] = getValue(reg, parts[2])
		} else if parts[0] == "add" {
			reg[parts[1]] = getValue(reg, parts[1]) + getValue(reg, parts[2])
		} else if parts[0] == "mul" {
			reg[parts[1]] = getValue(reg, parts[1]) * getValue(reg, parts[2])
		} else if parts[0] == "mod" {
			reg[parts[1]] = getValue(reg, parts[1]) % getValue(reg, parts[2])
		} else if parts[0] == "rcv" {
			/*val := <-in
			reg[parts[1]] = val
			fmt.Println(strconv.Itoa(pid) + " Received " + strconv.Itoa(val))*/
			select {
			case reg[parts[1]] = <-in:
				fmt.Println("got", getValue(reg, parts[1]), "at", pid)

			case <-time.After(1 * time.Second):
				return
			}
		} else if parts[0] == "jgz" {
			if getValue(reg, parts[1]) > 0 {
				pc += getValue(reg, parts[2])
				pc--
			}
		} else {
			panic(parts[0])
		}
		pc++
	}
	return
}

func getValue(reg map[string]int, s string) int {
	s = strings.TrimSpace(s)
	if value, err := strconv.Atoi(s); err == nil {
		return value
	}
	if value, exists := reg[s]; exists {
		return value
	}
	return 0
}

func getInst() []string {
	raw := `set i 31
	set a 1
	mul p 17
	jgz p p
	mul a 2
	add i -1
	jgz i -2
	add a -1
	set i 127
	set p 622
	mul p 8505
	mod p a
	mul p 129749
	add p 12345
	mod p a
	set b p
	mod b 10000
	snd b
	add i -1
	jgz i -9
	jgz a 3
	rcv b
	jgz b -1
	set f 0
	set i 126
	rcv a
	rcv b
	set p a
	mul p -1
	add p b
	jgz p 4
	snd a
	set a b
	jgz 1 3
	snd b
	set f 1
	add i -1
	jgz i -11
	snd a
	jgz f -16
	jgz a -19`
	instructions := make([]string, 41, 41)
	scanner := bufio.NewScanner(strings.NewReader(raw))
	index := 0
	for scanner.Scan() {
		instructions[index] = strings.Trim(scanner.Text(), "\t")
		index++
	}
	return instructions
}
