<div align="center">
  <img src="Screenshots/github-intro-banner.svg" width="100%" alt="Intro Banner"/>
</div>

<p align="center">
  <img src="Screenshots/Thumbnail.png" alt="Jetpack Journey Thumbnail">
</p>

# Jetpack Journey

<p align="center">
  <em>A 3D Platformer built in Unreal Engine 5 featuring dynamic jetpack movement, fuel-based flight mechanics, and a fully drivable Chaos Vehicle with on-foot ↔ vehicle transitions.</em>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Unreal%20Engine-5.6-blue?style=for-the-badge&logo=unrealengine&logoColor=white" alt="UE5.6"/>
  <img src="https://img.shields.io/badge/Plugin-Chaos%20Vehicles-purple?style=for-the-badge" alt="Chaos Vehicles"/>
  <img src="https://img.shields.io/badge/Input-Enhanced%20Input-green?style=for-the-badge" alt="Enhanced Input"/>
  <img src="https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white" alt="Windows"/>
</p>

---

## 📖 Description

**Jetpack Journey** is a 3D platformer where the player navigates through complex levels using a mix of traditional walking and a dynamic jetpack thruster system. The game focuses on precise platforming, strategic fuel management, and interacting with dynamic level elements like pressure plates and moving platforms.

The project also features a fully functional **4-wheel AWD automatic vehicle** built from scratch using the **Chaos Vehicles Plugin**. Players can discover the vehicle in the world, board it, drive around, and exit back to on-foot gameplay — with seamless possession switching, camera blending, and input context management handled entirely through Blueprints.

Built using Unreal Engine 5.6, the project leverages advanced animation systems, blueprint logic, and optimized level design techniques.

---

## 🎮 Inputs & Controls

### On-Foot Controls

| Action | Key / Input | Description |
| :--- | :--- | :--- |
| **Move Forward** | `W` | Moves the character forward. |
| **Move Backward** | `S` | Moves the character backward. |
| **Move Left** | `A` | Moves the character left. |
| **Move Right** | `D` | Moves the character right. |
| **Look / Camera** | `Mouse` | Controls the camera pitch and yaw. |
| **Thruster / Fly** | `Shift` (Hold) | Activates the jetpack, consuming fuel and propelling the character upwards. |
| **Interact** | `E` | Interact with objects in the world (e.g., board a vehicle). |
| **Pause Game** | `Esc` | Opens the in-game pause menu. |

### Vehicle Controls

Both **keyboard + mouse** and **gamepad/controller** inputs are fully supported while driving.

| Action | Keyboard | Controller | Description |
| :--- | :--- | :--- | :--- |
| **Throttle** | `W` | `Right Trigger (RT)` | Accelerate forward. |
| **Brake / Reverse** | `S` | `Left Trigger (LT)` | Brake (or reverse when stopped). |
| **Steer** | `A` / `D` | `Left Stick X-Axis` | Turn wheels left / right. |
| **Handbrake** | `Space` | `Left Face Special Button` | Engage handbrake / drift. |
| **Free Look** | `Mouse` | `Right Stick (2D Axis)` | Look around the vehicle freely. |
| **Exit Vehicle** | `E` | — | Deboard and return to on-foot controls. |

---

## 🕹️ Gameplay Logic & Mechanics

### Character Movement
The core of the game relies on a versatile **Character Movement Component**, seamlessly blending two distinct states:
*   **Walking Mode:** Standard ground traversal. When grounded, the character's rotation automatically aligns with the direction of movement (Velocity), while the camera remains independently controlled by the mouse for a better view of the surroundings.
*   **Flying Mode:** Engaged via the jetpack thruster. While in the air, the character's rotation locks to follow the camera's rotation (Control Rotation). This allows the player to aim their trajectory precisely using the mouse while navigating mid-air platforming challenges.

### Fuel System
Flight is strictly governed by a resource management system:
*   **Consumption:** Holding the thruster input drains fuel over time.
*   **Collection:** Players must actively seek out and collect fuel pickups scattered throughout the level to maintain their ability to fly and clear larger gaps.

### Dynamic Platforming
The levels are built with interactive obstacles to test the player's movement skills:
*   **Floating Platforms:** Static platforms suspended in the air.
*   **Ping-Pong Platforms:** Moving platforms that continuously travel back and forth between defined waypoints.
*   **Pressure Plates:** Interactive triggers placed in the environment. Stepping on a pressure plate will send a signal to activate specific dormant platforms, adding a puzzle element to traversal.

### Level Progression
*   **End Goal:** The primary objective of each level is to successfully navigate the environment, manage fuel, and reach the final platform to complete the stage.

---

## 🚗 Chaos Vehicle System

The project includes a fully configured **4-wheel All-Wheel-Drive (AWD) automatic transmission vehicle** built from the ground up using the **Chaos Vehicles Plugin** — UE5's physics-based vehicle simulation system powered by the Chaos physics engine.

### Vehicle Features

| Feature | Details |
| :--- | :--- |
| **Drivetrain** | All-Wheel Drive (AWD) with automatic transmission |
| **Wheels** | Separate front and rear wheel blueprints with independent configurations |
| **Physics** | Full Chaos Vehicle physics with custom torque curve and physics asset |
| **Skeletal Mesh** | Hand-rigged from static mesh with manually placed wheel bones and skin weights |
| **Animation** | Animation Blueprint for wheel spin, steering rotation, and suspension movement |
| **Rendering** | Lumen GI, ray tracing, virtual shadow maps, SM6 shaders (DX12) |

### 🚶 Boarding & Deboarding

Players can discover the vehicle in the world and interact with it to transition between on-foot and driving gameplay:

*   **Interaction Detection** — An interaction prompt appears when the player character is within range of the vehicle, using the Enhanced Input `IA_Interact` action.
*   **Boarding** — Pressing the interact key boards the vehicle, transferring control from the character pawn to the vehicle pawn.
*   **Deboarding** — Pressing interact again while driving exits the vehicle, placing the character at a dedicated exit location and restoring full on-foot controls.

### 🎮 Possession & Input Switching

Seamless control handoff is managed through UE5's possession system and Enhanced Input mapping contexts:

*   **Possess / Unpossess** — On boarding, the Player Controller unpossesses the character and possesses the vehicle pawn. On exit, possession is returned to the character.
*   **Input Mapping Context Swap** — The character's `IMC_KixMovement` context is removed and replaced with `IMC_Vehicle` on boarding, and vice versa on deboarding, ensuring controls never conflict.
*   **Control Restoration** — After exiting, all character movement and camera controls are fully restored to their pre-boarding state.

### 📷 Camera Management

Camera transitions between character and vehicle are handled with smooth blending:

*   **Character Camera** — Third-person spring arm camera attached to the character pawn.
*   **Vehicle Camera** — Independent spring arm camera on the vehicle pawn with free-look support.
*   **Smooth Blending** — Camera blending is used during possession transitions so the view smoothly interpolates between the character and vehicle perspectives, avoiding jarring cuts.

### 👤 Visibility & Collision Management

To prevent visual and physical conflicts while the player is inside the vehicle:

*   **Character Hiding** — The character mesh is hidden when boarding and shown again when deboarding.
*   **Collision Disabling** — The character's collision is disabled while inside the vehicle to prevent unwanted physics interactions between the character and vehicle.
*   **Safe Exit Positioning** — On deboarding, the character is placed at a predefined exit point on the vehicle to avoid spawning inside geometry.

---

## 🖥️ UI & Menus

The game features a complete, self-contained UI flow to handle game states:
1.  **Start Menu:** The initial screen providing entry into the game level.
2.  **Pause Menu:** Accessible during gameplay to pause the action, allowing the player to resume or quit.
3.  **End Menu:** A victory screen that triggers when the player successfully steps on the final goal platform.
4.  **Interact Widget:** A context-sensitive prompt that appears when the player is near an interactable object (e.g., the vehicle).

---

## 🛠️ Technical Implementation Details

The project utilizes several key Unreal Engine 5 features to achieve its functionality:

### Blueprint Logic & Interfaces
*   **Core Systems:** Character movement, fuel management, vehicle boarding, and UI logic are entirely scripted using Unreal Blueprints.
*   **Blueprint Interfaces (BPI):** Used extensively for decoupled communication between actors. For example, pressure plates use an interface to communicate with moving platforms, and the interact system uses `BPI_PlayerInteract` and `BPI_Interactables` for character ↔ vehicle communication without hard-coded references.

### Chaos Vehicle Setup
*   **`BP_Vehicle`** — The main vehicle pawn containing the skeletal mesh component, spring arm camera, and the Chaos Vehicle Movement Component.
*   **`BP_FrontWheel` / `BP_RearWheel`** — Derived from `ChaosVehicleWheel`, defining per-axle properties: wheel radius & width, suspension stiffness & damping, friction force multiplier, and steering angle (front wheels only).
*   **`PHYS_Vehicle`** — Physics Asset defining collision bodies for the chassis and each wheel bone.
*   **`CF_Torque`** — Float Curve asset defining the engine's torque output across the RPM range.
*   **`ABP_Vehicle`** — Animation Blueprint driving wheel rotation, steering, and suspension offsets at runtime.

### Skeletal Mesh Pipeline (Done In-Editor)
The vehicle's skeletal mesh was created entirely within the Unreal Editor — no external DCC tools were needed:
1.  Started with the static mesh `SM_Vehicle`
2.  Created a Skeleton (`SKEL_Vehicle`) with a root bone and four wheel bones positioned at each wheel location
3.  Generated the Skeletal Mesh (`SKM_Vehicle`) from the static mesh
4.  Manually painted skin weights to bind the wheel geometry to their respective bones

### Animation Systems
*   **Animation Blueprints:** Drives the character's skeletal mesh animations.
*   **Blendspaces:** Smoothly interpolates between idle, walking, and running animations based on the character's speed and direction.
*   **State Machines:** Manages the logical transitions between distinct animation states (e.g., Grounded -> Airborne -> Thruster Active).

### Level Design & Optimization
*   **Packed Level Actors (PLAs) / Instances:** Used to create reusable, optimized environmental prefabs. This ensures that repeating elements (like specific platform groupings or structures) are highly performant and easy to iterate upon across different levels.

### Audio
*   **Sound Design:** Integrated sound effects for thruster activation, item collection (fuel), UI interaction, and ambient environment sounds to enhance game feel.

---

## 🔌 Plugins Used

| Plugin | Purpose |
| :--- | :--- |
| **ChaosVehiclesPlugin** | Core vehicle physics simulation (Chaos-based wheeled vehicle system) |
| **ModelingToolsEditorMode** | Used during development for mesh editing and geometry operations |
| **RawInput** | Raw input device support |

---

## 📸 Screenshots

<p align="center">
  <img src="Screenshots/Splash%20Screen.png" width="800" alt="Splash Screen">
</p>

**Gameplay Gallery:**

<p align="center">
  <img src="Screenshots/SS%201.png" width="400" alt="Screenshot 1">
  <img src="Screenshots/SS%202.png" width="400" alt="Screenshot 2">
</p>
<p align="center">
  <img src="Screenshots/SS%203.png" width="400" alt="Screenshot 3">
  <img src="Screenshots/SS%204.png" width="400" alt="Screenshot 4">
</p>
<p align="center">
  <img src="Screenshots/SS%205.png" width="400" alt="Screenshot 5">
  <img src="Screenshots/SS%206.png" width="400" alt="Screenshot 6">
</p>


---

<div align="center">
<img src="Screenshots/github-readme-banner.svg" alt="Creator Signature Banner"/>
</div>