Note: The Objective of sharing this code is not to make the reader understand what each piece of code does. It is to show that I am familiar - but not perfect -  with clean Code standards and architecture principles. The reader will be able to recognize software architectural patterns that they are familiar with, such as: Factories (static & using Reflection), Inheritance, Composition,  DI (Dependency Injection) and SOLID as well as coding guidelines in general.

Code Architecture of the Spells Assembly:

->Second column of the first screenshot - Casting: Casting of the spells, which contains the logic for casting everything that should happen in the game when the player casts a spell (e.g. cooldown and mana consumption, etc).

->Third coloum of the first screenshot - Decorator: This has not yet been implemented but left open for extension. It's intended future use is for modifying the Spell's behaviour dynamically (e.g. Shoot 3 fireballs instead of 1 when upgrading the skill enough times). 

->First coloum of the first screenshot - Composite: It's intended use was for buffing spells dynamically (e.g. Damage Buff, Cooldown Reduction Buff). Here I admit that I ended up overengineering the code architecture, as I ended up using a better solution to solve this problem - described in the "Buffing Spells Solution" screenshot.

![CodeStructure](https://github.com/user-attachments/assets/37c72144-2604-4716-9f4a-11e52adb458e) 


Buffing Spells Solution:

-> This is the system that replaced the initial idea of the composite pattern. It uses Scriptable Objects - a reusable Data Container that is very unity specific. 

I will not go into detail as how it works, because it is very unity specific, but if you were to describe it in one sentece: 

The upgrade system consists of two lists in StatsManager.cs. One List "List<SpellStatsSO> _statsList" contains all data specific to each individual spell, while the other list "List StatsUpgradeDicSO _upgradeDics" contains a Dictionary of upgrades intended for each spell that can be easily modified by the game designer.

![image](https://github.com/user-attachments/assets/bfedd401-8a53-4fb9-9e4d-dd8244409108)



Legend: Describes what each component of the flowchart represents.

![CodeStructure Legend](https://github.com/user-attachments/assets/50c32e59-930a-4d18-82e8-0ed4dea0eece)
