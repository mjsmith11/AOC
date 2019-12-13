// docker container run -v $(pwd):/app --rm zenika/kotlin kotlinc /app -include-runtime -d /app/app.jar
// java -jar app.jar
import kotlin.math.abs 
class Moon(var px: Int, var py: Int, var pz: Int, var vx: Int, var vy: Int, var vz: Int) {
    fun greet() {
        println("Hello, ($px,$py,$pz) ($vx,$vy,$vz)")
    }
    fun move() {
        px = px + vx
        py = py + vy
        pz = pz + vz
    }
    fun applyGravity(other: Moon) {
        if (other.px > px) { vx = vx + 1}
        else if (other.px < px) { vx = vx -1}

        if (other.py > py) { vy = vy + 1}
        else if (other.py < py) { vy = vy -1}

        if (other.pz > pz) { vz = vz + 1}
        else if (other.pz < pz) { vz = vz -1}
    }
    fun getEnergy(): Int {
        return (abs(px) + abs(py) + abs(pz)) * (abs(vx) + abs(vy) + abs(vz))
    }
    fun xEqual(other: Moon): kotlin.Boolean {
        return ((other.px == px) && (other.vx == vx))
    }
    fun yEqual(other: Moon): kotlin.Boolean {
        return ((other.py == py) && (other.vy == vy))
    }
    fun zEqual(other: Moon): kotlin.Boolean {
        return ((other.pz == pz) && (other.vz == vz))
    }

}

fun main(args: Array<String>) {
    var m1 = Moon(-17,9,-5,0,0,0)
    var m2 = Moon(-1,7,13,0,0,0)
    var m3 = Moon(-19,12,5,0,0,0)
    var m4 = Moon(-6,-6,-4,0,0,0)
    var m10 = Moon(-17,9,-5,0,0,0)
    var m20 = Moon(-1,7,13,0,0,0)
    var m30 = Moon(-19,12,5,0,0,0)
    var m40 = Moon(-6,-6,-4,0,0,0)
    var xPeriod = 0
    var yPeriod = 0
    var zPeriod = 0
    var counter = 0
    while (xPeriod==0 || yPeriod==0 || zPeriod == 0) {
        m1.applyGravity(m2)
        m1.applyGravity(m3)
        m1.applyGravity(m4)

        m2.applyGravity(m1)
        m2.applyGravity(m3)
        m2.applyGravity(m4)

        m3.applyGravity(m1)
        m3.applyGravity(m2)
        m3.applyGravity(m4)

        m4.applyGravity(m1)
        m4.applyGravity(m2)
        m4.applyGravity(m3)

        m1.move()
        m2.move()
        m3.move()
        m4.move()
        
        // increment the counter and check for stuff
        counter = counter + 1
        if (counter==1000) {
            val energy = m1.getEnergy() + m2.getEnergy() + m3.getEnergy() + m4.getEnergy()
            println("Part 1 : $energy")
        }
        // part 2 strategy it is periodic on a smaller period for each axis, find the lcm of these
        if (xPeriod == 0) {
            if (m1.xEqual(m10) && m2.xEqual(m20) && m3.xEqual(m30) && m4.xEqual(m40)) {
                xPeriod = counter
            }
        }
        if (yPeriod == 0) {
            if (m1.yEqual(m10) && m2.yEqual(m20) && m3.yEqual(m30) && m4.yEqual(m40)) {
                yPeriod = counter
            }
        }
        if (zPeriod == 0) {
            if (m1.zEqual(m10) && m2.zEqual(m20) && m3.zEqual(m30) && m4.zEqual(m40)) {
                zPeriod = counter
            }
        }   
    }
    // use something external to compute the lcm like wolframalpha.com
    println("Part 2 : lcm($xPeriod,$yPeriod,$zPeriod)")
}