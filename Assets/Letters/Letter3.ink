INCLUDE globals.ink

~ sendLetter = false

{ letter2Option1 && !letter3Picked: -> letter2Option1Knot  }
{ letter2Option2 && !letter3Picked: -> letter2Option2Knot  }
{ letter2Option3 && !letter3Picked: -> letter2Option1Knot  }
{ letter2Option4 && !letter3Picked: -> letter2Option2Knot  }

{ letter3Option1 && letter3Picked: -> letter3Option1Knot }
{ letter3Option2 && letter3Picked: -> letter3Option2Knot }
{ letter3Option3 && letter3Picked: -> letter3Option3Knot }
{ letter3Option4 && letter3Picked: -> letter3Option4Knot }

=== letter2Option1Knot ===
Dear Alina, this is a letter about the cats and birds in space. 
Write back soon!
    + [asteroid]
        -> letter3Option1Knot
    + [sun]
        -> letter3Option2Knot

=== letter2Option2Knot ===
Dear Alina, this is a letter about the dogs and fish in dreams. 
Write back soon!
    + [sleep]
        -> letter3Option3Knot
    + [tired]
        -> letter3Option4Knot
        
=== letter3Option1Knot ===
~ letter3Picked = true
~ letter3Option1 = true
~ sendLetter = true
RE: This letter will be about asteroids!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter3Option2Knot ===
~ letter3Picked = true
~ letter3Option2 = true
~ sendLetter = true
RE: This letter will be about the sun!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
=== letter3Option3Knot ===
~ letter3Picked = true
~ letter3Option3 = true
~ sendLetter = true
RE: This letter will be about sleeping!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter3Option4Knot ===
~ letter3Picked = true
~ letter3Option4 = true
~ sendLetter = true
RE: This letter will be about being tired!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END