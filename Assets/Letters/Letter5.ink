INCLUDE globals.ink

~ sendLetter = false

{ letter4Option1 && !letter5Picked: -> letter4Option1Knot  }
{ letter4Option2 && !letter5Picked: -> letter4Option2Knot  }
{ letter4Option3 && !letter5Picked: -> letter4Option1Knot  }
{ letter4Option4 && !letter5Picked: -> letter4Option2Knot  }

{ letter5Option1 && letter5Picked: -> letter5Option1Knot }
{ letter5Option2 && letter5Picked: -> letter5Option2Knot }
{ letter5Option3 && letter5Picked: -> letter5Option3Knot }
{ letter5Option4 && letter5Picked: -> letter5Option4Knot }

=== letter4Option1Knot ===
Dear Alina, this is a letter about pillows and darkness. 
Write back soon!
    + [peaceful]
        -> letter5Option1Knot
    + [anxiety]
        -> letter5Option2Knot

=== letter4Option2Knot ===
Dear Alina, this is a letter about being scared and stressed. 
Write back soon!
    + [comfort]
        -> letter5Option3Knot
    + [despair]
        -> letter5Option4Knot
        
=== letter5Option1Knot ===
~ letter5Picked = true
~ letter5Option1 = true
~ sendLetter = true
RE: This letter will be about peacefulness!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter5Option2Knot ===
~ letter5Picked = true
~ letter5Option2 = true
~ sendLetter = true
RE: This letter will be about anxiety!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
=== letter5Option3Knot ===
~ letter5Picked = true
~ letter5Option3 = true
~ sendLetter = true
RE: This letter will be about being comforted!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter5Option4Knot ===
~ letter5Picked = true
~ letter5Option4 = true
~ sendLetter = true
RE: This letter will be about feeling despair!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END