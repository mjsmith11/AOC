// docker run -it --rm -v $PWD:/app -w /app mozilla/sbt sbt shell
// run
object HelloWorld {
    def main(args: Array[String]): Unit = {
        var metCriteria1 = 0
        var metCriteria2 = 0
        for (w <- 152085 to 670283) {
            var num = w
            var dig0 = num % 10;
            num = num / 10;
            var dig1 = num % 10;
            num = num / 10;
            var dig2 = num % 10;
            num = num / 10;
            var dig3 = num % 10;
            num = num / 10;
            var dig4 = num % 10;
            num = num / 10;
            var dig5 = num;
            if ((dig0 == dig1) || (dig1 == dig2) || (dig2 == dig3) || (dig3 <= dig4) || (dig4 == dig5)) {
                if ((dig5 <= dig4) && (dig4 <= dig3) && (dig3 <= dig2) && (dig2 <= dig1) && (dig1 <= dig0)) {
                    metCriteria1 = metCriteria1 + 1
                    if (checkPart2(dig0, dig1, dig2, dig3, dig4, dig5)) {
                        metCriteria2 = metCriteria2 + 1
                    }
                }
            }
        }
        println("Part 1: " + metCriteria1)
        println("Part 2: " + metCriteria2)
    }
    def checkPart2(dig0: Int, dig1: Int, dig2: Int, dig3: Int, dig4: Int, dig5: Int): Boolean = {
        var digits = Array(dig0, dig1, dig2, dig3, dig4, dig5)
        var last = dig5
        var size = 1
        
        if (dig4 == dig5) {
            size = size + 1
        } else {
            if (size == 2) {
                return true
            }
            size = 1
            last = dig4
        }

        if (dig3 == dig4) {
            size = size + 1
        } else {
            if (size == 2) {
                return true
            }
            size = 1
            last = dig3
        }

        if (dig2 == dig3) {
            size = size + 1
        } else {
            if (size == 2) {
                return true
            }
            size = 1
            last = dig2
        }

        if (dig1 == dig2) {
            size = size + 1
        } else {
            if (size == 2) {
                return true
            }
            size = 1
            last = dig1
        }

        if (dig0 == dig1) {
            size = size + 1
        } else {
            if (size == 2) {
                return true
            }
            size = 1
            last = dig0
        }

        return (size == 2)

    }
}