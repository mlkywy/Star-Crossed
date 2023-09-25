INCLUDE globals.ink

~ sendLetter = false

{ letter3Option1 && !letter4Picked: -> letter3Option1Knot  }
{ letter3Option2 && !letter4Picked: -> letter3Option2Knot  }
{ letter3Option3 && !letter4Picked: -> letter3Option1Knot  }
{ letter3Option4 && !letter4Picked: -> letter3Option2Knot  }

{ letter4Option1 && letter4Picked: -> letter4Option1Knot }
{ letter4Option2 && letter4Picked: -> letter4Option2Knot }
{ letter4Option3 && letter4Picked: -> letter4Option3Knot }
{ letter4Option4 && letter4Picked: -> letter4Option4Knot }

=== letter3Option1Knot ===
[...] The cookies came from the oven as bricks of black carbon. Perhaps with some fortune, I'll be able to use this for barbecue?
    + [orange]
        -> letter4Option1Knot
    + [asteroid]
        -> letter4Option2Knot

=== letter3Option2Knot ===
Nothing eventful today. A letter came, however, one from a military university far in the North. [...] It annoys me to such a great extent that they keep asking for donations from lovers of soldiers...
    + [glass]
        -> letter4Option3Knot
    + [car]
        -> letter4Option4Knot
        
=== letter4Option1Knot ===
~ letter4Picked = true
~ letter4Option1 = true
~ sendLetter = true
RE: Oranges. The natives of the space station had oranges. Our oranges. Apparently they have a massive seed bank. I've already sent a petition to reintroduce them back home. 
RE: You have a friend at the Ecologist Union, right? Maybe they can pull a few strings?
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter4Option2Knot ===
~ letter4Picked = true
~ letter4Option2 = true
~ sendLetter = true
RE: A few free-floating asteroid storms stopped our path. A few conductive veins and an electric current can truly ruin some ship's days. 
RE: It gave us quite a show, though, branches of lightning so large and wide you would think it was a tree made of light.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
=== letter4Option3Knot ===
~ letter4Picked = true
~ letter4Option3 = true
~ sendLetter = true
RE: The Admiralty takes shattered glass aboard gravity-less ship or room to be serious enough to warrant additional training. Shards of glass... just menacing us. Its rather funny, isn't it? 
RE: I guess the goal was to ensure we’re prepared for anything that gets thrown at us.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter4Option4Knot ===
~ letter4Picked = true
~ letter4Option4 = true
~ sendLetter = true
RE: The Car Belt. A large region of space where cars are used. Cars are these massive hulls of aluminum and steel that utilize fuel derived from petroleum. 
RE: Primitives use that weird technology. Strange to such methods still used...
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END