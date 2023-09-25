INCLUDE globals.ink

~ sendLetter = false

{ letter1Picked:
    { letter1Option1: -> letter1Option1Knot }
    { letter1Option2: -> letter1Option2Knot }
}
-> main

=== main ===
There was a firebug that fly a bit too close to our bundle of joy and frightened them. They calmed down but something tells me they just had their very first grudge. 
[...] Space is no place for you. They should just let you come home already.
    + [fork]
        -> letter1Option1Knot
    + [ear]
        -> letter1Option2Knot

=== letter1Option1Knot ===
~ letter1Picked = true
~ letter1Option1 = true
~ sendLetter = true
RE: The food was boring again. Nutri-gruel and red tea with honey milk jelly as dessert. The dessert was good but I close my eyes and pretend the gruel is your spiced stew. 
RE: I dreamed of us again. With the child. It was ridiculous as well, I was asleep in my own dream but I could feel our baby against my chest.
RE: I could feel my arm wrapped around their body.Chest to chest. Hearts beating together.
RE: And then I wake up and it’s back to my station. I know I wasn't there to see her come into this world. But when I return, we will never part again.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter1Option2Knot ===
~ letter1Picked = true
~ letter1Option2 = true
~ sendLetter = true
RE: Bugs. Within the ear. Even in space, we have to be vigilant, I only exaggerate because it recently happened to me. 
RE: Never going to sleep near some vent ever again. No matter how tired I am.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END