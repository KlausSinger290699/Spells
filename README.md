Note: The Objective of sharing this code is not to make the reader understand what each piece of code does. It is to show evidence that I am familiar - but not perfect -  with clean Code standards and SOLID architecture principles. The reader will be able to recognize software architectural patterns, such as: Factories (static & using Reflection), Inheritance, Composition, Dependency Injection and SOLID principles as well as coding guidelines.

Code Architecture of the Spells Assembly:

-> Second column of the first screenshot - Casting: Casting of the spells, which contains the logic for casting everything that should happen in the game when the player casts a spell (e.g. cooldown and mana consumption, etc).

-> Third column of the first screenshot - Decorator: This has not yet been implemented but left open for extension. It's intended future use is for modifying the Spell's behaviour dynamically (e.g. Shoot 3 fireballs instead of 1 when upgrading the skill enough times). 

-> First column of the first screenshot - Composite: It's intended use was for buffing spells dynamically (e.g. Damage Buff, Cooldown Reduction Buff). Here I admit that I ended up overengineering the code structure, as I ended up using a better suited unity specific solution to solve this problem - described in  the"Buffing Spells Solution" section.

![image](https://github.com/user-attachments/assets/9cbc96f3-a6e3-4810-a0ec-89d92556d2f1)


Buffing Spells Solution:

This is the system that replaced the initial idea of the composite pattern. It uses Scriptable Objects - a reusable Data Container that is very unity specific. 

I will not go into detail as how it works, as it is very unity specific, but if you were to describe it in one sentece: 

The upgrade system consists of two lists in StatsManager.cs. One List "List SpellStatsSO _statsList" contains all data specific to each individual spell, while the other list "List StatsUpgradeDicSO _upgradeDics" contains a Dictionary of upgrades intended for each spell that can be easily modified by the game designer.

![image](https://github.com/user-attachments/assets/38a7b10e-06eb-4731-9517-d0cbe7b54694)



Legend: Describes what each component of the flowchart represents.

![image](https://github.com/user-attachments/assets/2e99d5ec-4242-4e6d-87f7-c47825bd0cfe)


