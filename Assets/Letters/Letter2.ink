INCLUDE globals.ink

~ sendLetter = false

{ letter1Option1 && !letter2Picked: -> letter1Option1Knot  }
{ letter1Option2 && !letter2Picked: -> letter1Option2Knot  }

{ letter2Option1 && letter2Picked: -> letter2Option1Knot }
{ letter2Option2 && letter2Picked: -> letter2Option2Knot }
{ letter2Option3 && letter2Picked: -> letter2Option3Knot }
{ letter2Option4 && letter2Picked: -> letter2Option4Knot }

=== letter1Option1Knot ===
[...] The child speaks your name. The stories of your travels make me wonder about stars out there — [...]
Do you ever feel like that vast ocean of stars is isolating? Almost like a great barrier but no wall. Just distance.
    + [tech]
        -> letter2Option1Knot
    + [deer]
        -> letter2Option2Knot

=== letter1Option2Knot ===
The neighbor's often invite us for dinner. Those arguments over land disputes seem so far behind us now [...] We had to leave early to finish our chores but I will join them again.
    + [mug]
        -> letter2Option3Knot
    + [toilet]
        -> letter2Option4Knot
        
=== letter2Option1Knot ===
~ letter2Picked = true
~ letter2Option1 = true
~ sendLetter = true
RE: It's amazing what we can do with technology. I saw a room of projectors turn into a picturesque landscape outside of our house... straight from my memory. I could even smell the autumn air. 
RE: My favorite time of year. Not too hot. Not too cold. And the sun's rays are welcomed like a warm, soft hug from above. 
RE: Oh, before I forget! We're on track to see a star whale pod!. Can you imagine it? Such rare and celestial beasts, travelling the cosmos. 
RE: I only wish you and the little one were here as well to see it.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter2Option2Knot ===
~ letter2Picked = true
~ letter2Option2 = true
~ sendLetter = true
RE: The planetary fauna of this one system are all just deer. They take many different forms but ultimately those forms resemble deer like the ones back home. 
RE: I would not be surprised if I were to catch a bird in the shape of a deer flying by.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
=== letter2Option3Knot ===
~ letter2Picked = true
~ letter2Option3 = true
~ sendLetter = true
RE: I often see my fellow colleagues offer me a spot at their drinking table. I know they mean well, but the only reason they ask is to see if I'll falter in my cultural vows of abstinence. 
RE: Besides, the taste of alcohol is disgusting. I much prefer club soda with rose syrup.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter2Option4Knot ===
~ letter2Picked = true
~ letter2Option4 = true
~ sendLetter = true
RE: For some reason, there’s toilet graffiti in the public restrooms. Some have... less than polite words to say about certain cadets within the ship's sector but others are just poetry. 
RE: Makes you wonder about the duality of us sentient beings.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END