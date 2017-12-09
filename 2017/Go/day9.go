package main

func scoreGroup(group string) (int, int) {
	score := 0
	groupLevel := 0
	cancelNext := false
	inGarbage := false
	garbageChars := 0

	for _, c := range group {
		if cancelNext {
			cancelNext = false
		} else if c == '!' {
			cancelNext = true
		} else if inGarbage {
			if c == '>' {
				inGarbage = false
			} else {
				garbageChars++
			}
		} else if c == '<' {
			inGarbage = true
		} else if c == '{' {
			groupLevel++
			score += groupLevel
		} else if c == '}' {
			groupLevel--
		}
	}
	return score, garbageChars
}
