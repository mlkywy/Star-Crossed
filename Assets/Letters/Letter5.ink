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
Many people are saying a drought is coming along. I don't believe so, but the neighbors are preparing by fattening up their animals more than usual. 
[...] I want to leave this planet. I want to see the universe with you. With our child.
    + [ball]
        -> letter5Option1Knot
    + [veil]
        -> letter5Option2Knot

=== letter4Option2Knot ===
Don't you think it’s time for us to move somewhere else? This planet is draining us. Asks too much of us. [...] Dinner was fine today. Mashed potatoes, boiled grains, and stewed beef. All that's missing is you. 
    + [cheese]
        -> letter5Option3Knot
    + [games]
        -> letter5Option4Knot
        
=== letter5Option1Knot ===
~ letter5Picked = true
~ letter5Option1 = true
~ sendLetter = true
RE: I was hit in the face today with a ball. One quick one hour session in the medbay had me feeling as right as rain again. 
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter5Option2Knot ===
~ letter5Picked = true
~ letter5Option2 = true
~ sendLetter = true
RE: Not many people understand why we're veiled. Sometimes my fellow cadets ask. The only times I get annoyed is when they demand to see how I appear underneath the fabrics. 
RE: That sight is only for you, my love. 
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
=== letter5Option3Knot ===
~ letter5Picked = true
~ letter5Option3 = true
~ sendLetter = true
RE: I just found out I'm lactose intolerant. The cheese at home are lactose free, which is why I never had a hard time eating local cheese. 
RE: This is the most excruciating pain I’ve dealt with so far. Pray for me please.
    + [yes]
        -> DONE
    + [no]
        -> DONE

=== letter5Option4Knot ===
~ letter5Picked = true
~ letter5Option4 = true
~ sendLetter = true
RE: Many different games get played in the parlor hall. Today, I spotted a few older officers playing dice. 
RE: They play for money, and although its a regulation to gamble, they attracted a large crowd with their banter and passion.
    + [yes]
        -> DONE
    + [no]
        -> DONE
        
-> END