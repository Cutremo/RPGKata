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

## Iteration Four
- [X] Characters may belong to one or more Factions.
- [X] Newly created Characters belong to no Faction.
- [X] Characters can Join one or more factions
- [X] Players belonging to the same Faction are considered allies
  - [X] Unaligned characters are enemies
- [X] Allies cannot deal damage to one another
- [X] Allies can heal one another

## Iteration Five
- [X] Characters can damage non-character things (props)
- [X] These things cannot be healed and they do not deal damage
- [X These things do not belong to factions, they are neutral
- [ ] When reduced to 0 health, things are destroyed
- [ ] Things may have any max health


## Fun List
- [ ] Precondition amounts to be positive, natural by creating structs...
- [X] Name 1000 to max health.
- [ ] Cover edge cases
- [ ] Test the queries that are used as contracts.
- [X] Name meters
- [ ] Build characters in tests semantically
- [ ] Attack class?

