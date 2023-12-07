package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strconv"
	"strings"
)

var (
	HighCard     rank = 1
	Pair         rank = 2
	TwoPair      rank = 3
	ThreeOfAKind rank = 4
	FullHouse    rank = 5
	FourOfAKind  rank = 6
	FiveOfAKind  rank = 7
)

func main() {
	fmt.Println("Part 1: ", run(getRank1, breakTie1))
	fmt.Println("Part 2: ", run(getRank2, breakTie2))
}
func run(getRank func(*hand) rank, breakTie func(string, string) bool) int {
	hands := readInput()
	sort.Slice(hands, func(i, j int) bool {
		// true if i is before j
		iRank := getRank(hands[i])
		jRank := getRank(hands[j])
		if iRank < jRank {
			return true
		} else if jRank < iRank {
			return false
		} else {
			return breakTie(hands[i].cards, hands[j].cards)
		}
	})

	payouts := 0
	for i := 0; i < len(hands); i++ {
		payouts += (i + 1) * hands[i].bid
	}
	return payouts
}

func breakTie1(h1, h2 string) bool {
	// true for h2 and false for h1
	chMap := map[byte]int{
		'2': 2,
		'3': 3,
		'4': 4,
		'5': 5,
		'6': 6,
		'7': 7,
		'8': 8,
		'9': 9,
		'T': 10,
		'J': 11,
		'Q': 12,
		'K': 13,
		'A': 14,
	}
	for i := 0; i < 5; i++ {
		if chMap[h2[i]] > chMap[h1[i]] {
			return true
		}
		if chMap[h1[i]] > chMap[h2[i]] {
			return false
		}
	}
	fmt.Println("Not expected")
	return false
}

func breakTie2(h1, h2 string) bool {
	// true for h2 and false for h1
	chMap := map[byte]int{
		'2': 2,
		'3': 3,
		'4': 4,
		'5': 5,
		'6': 6,
		'7': 7,
		'8': 8,
		'9': 9,
		'T': 10,
		'J': 1,
		'Q': 12,
		'K': 13,
		'A': 14,
	}
	for i := 0; i < 5; i++ {
		if chMap[h2[i]] > chMap[h1[i]] {
			return true
		}
		if chMap[h1[i]] > chMap[h2[i]] {
			return false
		}
	}
	fmt.Println("Not expected")
	return false
}

func getRank1(h *hand) rank {
	cards := make(map[rune]int, 5)
	for _, c := range h.cards {
		if _, ok := cards[c]; ok {
			cards[c]++
		} else {
			cards[c] = 1
		}
	}
	if len(cards) == 1 {
		return FiveOfAKind
	} else if len(cards) == 2 {
		if cards[rune(h.cards[0])] == 1 || cards[rune(h.cards[0])] == 4 {
			return FourOfAKind
		} else {
			return FullHouse
		}
	} else if len(cards) == 3 {
		for _, v := range cards {
			if v == 3 {
				return ThreeOfAKind
			}
		}
		return TwoPair
	} else if len(cards) == 4 {
		return Pair
	} else {
		return HighCard
	}
}

func getRank2(h *hand) rank {
	cards := make(map[rune]int, 5)
	jokers := 0
	for _, c := range h.cards {
		if c == 'J' {
			jokers++
		} else {
			if _, ok := cards[c]; ok {
				cards[c]++
			} else {
				cards[c] = 1
			}
		}
	}
	if len(cards) == 0 {
		// all jokers
		return FiveOfAKind
	}
	if len(cards) == 1 {
		// jokers and one other thing
		return FiveOfAKind
	} else if len(cards) == 2 {
		// two things and jokers
		for _, v := range cards {
			if v+jokers == 4 {
				return FourOfAKind
			}
		}
		return FullHouse
	} else if len(cards) == 3 {
		// 3 things and jokers
		for _, v := range cards {
			if v+jokers == 3 {
				return ThreeOfAKind
			}
		}
		return TwoPair
	} else if len(cards) == 4 {
		return Pair
	} else {
		return HighCard
	}
}

type rank int

func readInput() []*hand {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	hands := make([]*hand, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		s := scanner.Text()
		parts := strings.Split(s, " ")
		bid, _ := strconv.Atoi(parts[1])
		hands = append(hands, &hand{
			bid:   bid,
			cards: parts[0],
		})
	}
	return hands
}

type hand struct {
	bid   int
	cards string
}
