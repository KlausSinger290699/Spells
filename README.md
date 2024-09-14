Code Architecture of the Spells Assembly:

->Second column of the first screenshot - Casting: Casting of the spells, which contains the logic for casting everything that should happen in the game when the player casts a spell (e.g. cooldown and mana consumption, etc).

->Third coloum of the first screenshot - Decorator: It's intended use was for buffing spells dynamically (e.g. Damage Buff, Cooldown Reduction Buff).

->First coloum of the first screenshot - Composite: This has not yet been implemented but left open for extension. It's intended future use is for modifying the Spell's behaviour dynamically (e.g. Shoot 3 fireballs instead of 1 when upgrading the skill enough times). 

![CodeStructure](https://github.com/user-attachments/assets/37c72144-2604-4716-9f4a-11e52adb458e) 

Legend: Describes what each component of the flowchart represents.

![CodeStructure Legend](https://github.com/user-attachments/assets/50c32e59-930a-4d18-82e8-0ed4dea0eece)
