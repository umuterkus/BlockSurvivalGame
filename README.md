# BlockSurvive: Modular Survivor Prototype

A scalable "Vampire Survivors" clone built with Unity. The primary focus of this project is to demonstrate Clean Code principles, Dependency Injection, and a performance-driven architecture.

--Core Architecture & Features--

This prototype utilizes Zenject for dependency management and UniTask for efficient asynchronous operations, ensuring a modular and highly maintainable codebase.

* Dependency Injection: Centralized service and interface management via `GameInstaller` to ensure loose coupling and high testability.
* Performance Optimization: Extensive use of Memory Pools for heavily instantiated objects (Projectiles, Enemies, and XP Crystals) to eliminate Garbage Collection spikes.
* Event-Driven Design: Integrated SignalBus (`EnemyDeathSignal`, `XPCollectedSignal`) to decouple game logic, progression, and UI updates.
* Scalable Systems: Modular design for Leveling (`QuadraticLevelCalculator`), Enemy Spawning, and Weapon mechanics, adhering strictly to the Open-Closed Principle.

--Tech Stack
* **Unity 3D** (C#)
* **Zenject** (DI, Object Pooling, SignalBus)
* **UniTask** (Zero-allocation Asynchronous Programming)

!!Developer Note!!

This repository represents the absolute foundation of the project. I am currently actively developing it further with much more advanced and diverse mechanics in a separate private repository. The purpose of this public version is specifically to showcase a solid architectural baseline and my approach to clean code.
