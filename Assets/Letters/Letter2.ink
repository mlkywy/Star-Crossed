INCLUDE globals.ink

~ sendLetter = false

{ letter1Option1 && !letter2Picked: -> letter1Option1Knot  }
{ letter1Option2 && !letter2Picked: -> letter1Option2Knot  }

{ letter2Option1 && letter2Picked: -> letter2Option1Knot }
{ letter2Option2 && letter2Picked: -> letter2Option2Knot }
{ letter2Option3 && letter2Picked: -> letter2Option3Knot }
{ letter2Option4 && letter2Picked: -> letter2Option4Knot }

=== letter1Option1Knot ===
Dear Alina, I really like stars. 
Write back soon!
    + [cats]
        -> letter2Option1Knot
    + [dogs]
        -> letter2Option2Knot

=== letter1Option2Knot ===
Dear Alina, I really like the moon. 
Write back soon!
    + [birds]
        -> letter2Option3Knot
    + [fish]
        -> letter2Option4Knot
        
=== letter2Option1Knot ===
~ letter2Picked = true
~ letter2Option1 = true
~ sendLetter = true
RE: This letter will be about cats!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter2Option2Knot ===
~ letter2Picked = true
~ letter2Option2 = true
~ sendLetter = true
RE: This letter will be about dogs!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
=== letter2Option3Knot ===
~ letter2Picked = true
~ letter2Option3 = true
~ sendLetter = true
RE: This letter will be about birds!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter2Option4Knot ===
~ letter2Picked = true
~ letter2Option4 = true
~ sendLetter = true
RE: This letter will be about the fish!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END