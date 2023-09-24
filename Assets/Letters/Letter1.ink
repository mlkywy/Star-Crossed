INCLUDE globals.ink

~ sendLetter = false

{ letter1Option1 && letter1Picked: -> letter1Option1Knot | -> main }
{ letter1Option2 && letter1Picked: -> letter1Option2Knot | -> main }

=== main ===
Dear Alina, you are such a cool developer and I think you should get some sleep now. Just wanted to let you know because your sleep cycle is already fucked. 
Write back soon!
    + [stars]
        -> letter1Option1Knot
    + [moon]
        -> letter1Option2Knot

=== letter1Option1Knot ===
~ letter1Picked = true
~ letter1Option1 = true
~ sendLetter = true
RE: This letter will be about the stars!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter1Option2Knot ===
~ letter1Picked = true
~ letter1Option2 = true
~ sendLetter = true
RE: This letter will be about the the moon!
This is just more text.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END