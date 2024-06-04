## Iteration One
- [X] All Characters, when created, have:
  - [X] Health, starting at 1000
  - [X] Level, starting at 1
  - [X] May be Alive or Dead, starting Alive (Alive may be a true/false)
- [X] Characters can Deal Damage to Characters.
  - [X] A character can die
- [X] A character can heal a Character
    - [X] Dead characters cannot be healed
    - [X] Healing cannot raise health above 1000

## Iteration Two
- [X] Characters cannot attack themselves
- [X] Characters can only heal themselves
- [X] If target is 5 or more levels above the attacker, damage done is reduced by 50%
- [X] If target is 5 or more levels below the attacker, damage done is increased by 50%

## Iteration Three
- [X] Characters have an attack Max Range
- [X] Characters cannot attack targets that are out of range
- [X] Melee fighters have a range of 2 meters.
- [X] Ranged fighters have a range of 20 meters.

## Fun List
- [ ] Precondition amounts to be positive, natural...
- [ ] Levels struct
- [X] Name 1000 to max health.
- [ ] Cover edge cases
- [ ] Name meters