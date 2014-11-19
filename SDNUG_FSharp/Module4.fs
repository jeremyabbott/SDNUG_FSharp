module Module4
    
    let point = 1, 2 // int * int
    let x = fst point // get the first value
    let y = snd point // get the second value

    printfn "x coord: %i; y coord: %i" x y

    // A tuple pattern lets you assign 
    // explicit values from a tuple 
    let x', y' = point

    printfn "x' coord: %i; y' coord: %i" x' y'


    let triple = (1, 2, 3)
    let _, _, z = triple

    printfn "the third value is: %i" z

    // *********************************
    // Record Types
    // *********************************
    type pointRecord = { XCoord : int; YCoord : int}
                        override x.ToString() =
                            sprintf "x coord: %i; y coord: %i" x.XCoord x.YCoord
                        member x.CalculateDistance(otherCoord : pointRecord) =
                            let xDiff = otherCoord.XCoord - x.XCoord
                            let yDiff = otherCoord.YCoord - x.YCoord
                            let result =  ((xDiff * xDiff) + (yDiff * yDiff))
                            int (System.Math.Sqrt(float result))
    
    let thePoint = { XCoord = 5; YCoord = 8 }
    printfn "%s" (thePoint.ToString())

    // let's copy the coordinate
    let theOtherPoint = { thePoint with YCoord = -8 }
    printfn "%s" (theOtherPoint.ToString())

    printfn "%d" <| thePoint.CalculateDistance(theOtherPoint)

    let demoRecordType () =
        let thePoint = { XCoord = 5; YCoord = 8 }
        
        // let's copy the coordinate
        let theOtherPoint = { thePoint with YCoord = -8 }
        printfn "%s" "Record Type Info:"
        printfn "%s" (thePoint.ToString())
        printfn "%s" (theOtherPoint.ToString())
        printfn "%d" <| thePoint.CalculateDistance(theOtherPoint)

    // *********************************
    // Discriminated Unions
    // *********************************

    // This compiles down to an enumeration
    type Color =
    | Red = 0
    | Blue = 1
    | Green = 2

    printfn "%i" (int Color.Red)

    // note that named union type fields is part of F# 3.1
    // prior to this named union types used tuple syntax

    // This compiles down to an abstract class with 
    // three inner classes inheriting from it
    type Shape =
    | Circle of Radius : float
    | Triangle of Base : float * Height : float
    | Rectangle of Length : float * Height : float
        member x.getArea () = 
            match x with // pattern matching
            | Circle (r) -> (r ** 2.0) * System.Math.PI 
            | Triangle (b, h) -> 0.5 * (b * h)
            | Rectangle (l, h) -> l * h

    let demoShape () =

        printfn "%s" "Discriminated Unnion (Shape) Info:"
        
        let circle = Shape.Circle(4.0)
        printfn "%A" (circle.getArea())

        let triangle = Shape.Triangle(3.0, 4.0)
        printfn "%A" (triangle.getArea())

        let rectangle = Shape.Rectangle(3.0, 4.0)
        printfn "%A" (rectangle.getArea())
