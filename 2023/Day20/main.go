package main

import (
	"bufio"
	"fmt"
	"os"
	"slices"
	"strings"
)

var (
	high       int
	low        int
	pulseQueue []pulse
)

func main() {
	fmt.Println("Part 1", part1())
	// use part2() to get numbers to LCM.  See comments in function
	fmt.Println("Part 2", LCM(3923, 3929, []int{4007, 4091}))
}

func part1() int {
	modules := readInput()
	high, low = 0, 0
	pulseQueue = make([]pulse, 0)

	for i := 0; i < 1000; i++ {
		pulseQueue = append(pulseQueue, pulse{
			src:    "button",
			dest:   "broadcaster",
			isHigh: false,
		})

		for len(pulseQueue) > 0 {
			p := pulseQueue[0]
			pulseQueue = pulseQueue[1:]
			if m, ok := modules[p.dest]; ok {
				m.processPulse(p)
			} else {
				baseProcessPulse(p)
			}
		}
	}
	return (low) * (high)
}

func part2() int {
	// mostly like part1() see comment near print statement
	modules := readInput()
	high, low = 0, 0
	pulseQueue = make([]pulse, 0)
	presses := 0
	for i := 0; i < 10000; i++ { // loop needs to run "enough" times.  10k works
		pulseQueue = append(pulseQueue, pulse{
			src:    "button",
			dest:   "broadcaster",
			isHigh: false,
		})
		presses++
		for len(pulseQueue) > 0 {
			p := pulseQueue[0]
			pulseQueue = pulseQueue[1:]
			if m, ok := modules[p.dest]; ok {
				m.processPulse(p)
				// The goal is to find a number of button presses to deliver a low pulse to rx
				// rx has 1 source in my input: tg
				// tg is a conjunction with 4 inputs.
				// each input to tg usually emits high pulses but emits low pulses on a cycle
				// use this output to determine the cycle length for each input to tg
				// Then LCM the cycle lengths.
				if p.isHigh && p.dest == "tg" {
					fmt.Printf("%+v %d\n", p, presses)
				}
			} else {
				baseProcessPulse(p)
			}
		}
	}
	return presses
}

func baseProcessPulse(p pulse) {
	if p.isHigh {
		high++
	} else {
		low++
	}
}

type module interface {
	processPulse(p pulse)
	hasDest(d string) bool
}

type pulse struct {
	isHigh bool
	dest   string
	src    string
}

type flipFlopModule struct {
	memory bool
	dests  []string
}

func newFlipFlopModule(dests []string) *flipFlopModule {
	return &flipFlopModule{
		dests:  dests,
		memory: false,
	}
}

func (m *flipFlopModule) hasDest(d string) bool {
	return slices.Contains(m.dests, d)
}

func (m *flipFlopModule) processPulse(p pulse) {
	baseProcessPulse(p)
	if !p.isHigh {
		m.memory = !m.memory
		for _, d := range m.dests {
			pulseQueue = append(pulseQueue, pulse{
				isHigh: m.memory,
				dest:   d,
				src:    p.dest,
			})
		}
	}
}

type broadcasterModule struct {
	dests []string
}

func newBroadcasterModule(dests []string) *broadcasterModule {
	return &broadcasterModule{
		dests: dests,
	}
}

func (m *broadcasterModule) processPulse(p pulse) {
	baseProcessPulse(p)
	for _, d := range m.dests {
		pulseQueue = append(pulseQueue, pulse{
			isHigh: p.isHigh,
			dest:   d,
			src:    p.dest,
		})
	}
}

func (m *broadcasterModule) hasDest(d string) bool {
	return slices.Contains(m.dests, d)
}

type conjunctionModule struct {
	memory map[string]bool
	dests  []string
}

func newConjunctionModule(dests []string) *conjunctionModule {
	return &conjunctionModule{
		dests:  dests,
		memory: make(map[string]bool, 0),
	}
}

func (m *conjunctionModule) hasDest(d string) bool {
	return slices.Contains(m.dests, d)
}

func (m *conjunctionModule) processPulse(p pulse) {
	baseProcessPulse(p)
	m.memory[p.src] = p.isHigh
	allHigh := true
	for _, v := range m.memory {
		if !v {
			allHigh = false
			break
		}
	}
	for _, d := range m.dests {
		pulseQueue = append(pulseQueue, pulse{
			isHigh: !allHigh,
			dest:   d,
			src:    p.dest,
		})
	}
}

func readInput() map[string]module {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	config := make(map[string]module)
	conjunctions := make([]string, 0)
	for scanner.Scan() {
		t := scanner.Text()
		splits := strings.Split(t, " -> ")
		moduleInfo := splits[0]
		dests := splits[1]
		splitDests := strings.Split(dests, ", ")
		if moduleInfo[0] == 'b' {
			config[moduleInfo] = newBroadcasterModule(splitDests)
		} else if moduleInfo[0] == '%' {
			config[moduleInfo[1:]] = newFlipFlopModule(splitDests)
		} else if moduleInfo[0] == '&' {
			config[moduleInfo[1:]] = newConjunctionModule(splitDests)
			conjunctions = append(conjunctions, moduleInfo[1:])
		} else {
			panic(moduleInfo)
		}
	}
	for _, c := range conjunctions {
		for k, m := range config {
			if m.hasDest(c) {
				config[c].(*conjunctionModule).memory[k] = false
			}
		}
	}

	return config
}

func GCD(a, b int) int {
	for b != 0 {
		t := b
		b = a % b
		a = t
	}
	return a
}

func LCM(a, b int, integers []int) int {
	result := a * b / GCD(a, b)

	for i := 0; i < len(integers); i++ {
		result = LCM(result, integers[i], make([]int, 0))
	}
	return result
}
