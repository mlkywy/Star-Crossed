INCLUDE globals.ink

{ letter3Option1 && !letter4Picked: -> letter3Option1Knot  }
{ letter3Option2 && !letter4Picked: -> letter3Option2Knot  }
{ letter3Option3 && !letter4Picked: -> letter3Option1Knot  }
{ letter3Option4 && !letter4Picked: -> letter3Option2Knot  }

{ letter4Option1 && letter4Picked: -> letter4Option1Knot }
{ letter4Option2 && letter4Picked: -> letter4Option2Knot }
{ letter4Option3 && letter4Picked: -> letter4Option3Knot }
{ letter4Option4 && letter4Picked: -> letter4Option4Knot }

=== letter3Option1Knot ===
Dear Alina, this is a letter about asteroids and sleeping. 
Write back soon!
    + [pillow]
        -> letter4Option1Knot
    + [scary]
        -> letter4Option2Knot

=== letter3Option2Knot ===
Dear Alina, this is a letter about the sun and being tired. 
Write back soon!
    + [blinded]
        -> letter4Option3Knot
    + [stressed]
        -> letter4Option4Knot
        
=== letter4Option1Knot ===
~ letter4Picked = true
~ letter4Option1 = true
RE: This letter will be about pillows!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter4Option2Knot ===
~ letter4Picked = true
~ letter4Option2 = true
RE: This letter will be about being scared!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
=== letter4Option3Knot ===
~ letter4Picked = true
~ letter4Option3 = true
RE: This letter will be about being blinded!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter4Option4Knot ===
~ letter4Picked = true
~ letter4Option4 = true
RE: This letter will be about being stressed!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END