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
}

fun main(args: Array<String>) {
    var m1 = Moon(-17,9,-5,0,0,0)
    var m2 = Moon(-1,7,13,0,0,0)
    var m3 = Moon(-19,12,5,0,0,0)
    var m4 = Moon(-6,-6,-4,0,0,0)

    for (i in 1..1000) {
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
    }

    val energy = m1.getEnergy() + m2.getEnergy() + m3.getEnergy() + m4.getEnergy()
    println("$energy")

}