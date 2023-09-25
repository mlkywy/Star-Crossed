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
The silo was destroyed a few days ago. I saw it happen in person with our child. [...] 
I think they'll grow up to become an architect or a demolitionist in the Engineering Corps. Their eyes truly lit up at the destruction.
    + [love]
        -> letter3Option1Knot
    + [meat]
        -> letter3Option2Knot

=== letter2Option2Knot ===
My veil almost torn open today! Some visitor from the stars thought it wise to try and rip it off me. Fortunately, I didn't drop our beloved child. [...] I saw the police drag the sorry criminal away...
    + [machine]
        -> letter3Option3Knot
    + [pilot]
        -> letter3Option4Knot
        
=== letter3Option1Knot ===
~ letter3Picked = true
~ letter3Option1 = true
~ sendLetter = true
RE: Strange things happen even in the logic-heavy warships. Not with the machinery, those rarely fail. Strange things with my fellow cadets. Some dumb dating game for single cadets. 
RE: You are assigned a random transponder ID without camera privileges per day and pray you eventually find someone you like.
RE: Sessions are recorded and edited for the pleasure of the rest of the warship's cadets and honestly? It makes me super glad I'm with you. That I've found you.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter3Option2Knot ===
~ letter3Picked = true
~ letter3Option2 = true
~ sendLetter = true
RE: The nutri-gruel is different today! We stopped in the orbit of a habitable planet to wait for a resupply vessel. Some of the cadets went AWOL for an hour and returned with so much game. 
RE: They were reprimanded but eventually, it was added to the nutri-gruel processor and it was just a smidgen better...
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
=== letter3Option3Knot ===
~ letter3Picked = true
~ letter3Option3 = true
~ sendLetter = true
RE: The machinery within the nutri-gruel dispenser broke today. We were all happy because for once we'd be given proper rations. 
RE: I know that the dispenser is this really complex machine that can rearrange atoms so we just throw whatever inside of it but couldn't we program it to taste better?
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter3Option4Knot ===
~ letter3Picked = true
~ letter3Option4 = true
~ sendLetter = true
RE: Pilots don't pilot ships anymore, did you know that? Most of the long-distance navigation is done by AIs now. Only time they take control is when close-range precision is required. 
RE: An AI can't do those minute, quick-second judgements without jumbling the rest of itself.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END