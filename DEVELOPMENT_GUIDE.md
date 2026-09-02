# Complete Development Guide

## Project Setup

### Prerequisites
- Unity 2021 LTS or newer
- Visual Studio Code or JetBrains Rider
- Git installed

### Installation Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Alla122/Unity3D-Slipping-Objects-Game.git
   cd Unity3D-Slipping-Objects-Game
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Open Project"
   - Select the cloned directory
   - Wait for assets to import

3. **Create Project Structure**
   - In Assets folder, create these directories:
     - Scripts (already has files)
     - Scenes
     - Prefabs
     - Materials
     - Audio
     - Particles

## Scene Setup Guide

### Creating Level1 Scene

1. **Create Scene File**
   - Right-click in Assets/Scenes
   - Select "New Scene"
   - Name it "Level1"
   - Save it

2. **Add Scene to Build Settings**
   - File → Build Settings
   - Drag Level1 scene to "Scenes In Build"
   - MainMenu should be scene 0, Level1 should be scene 1

3. **Using SceneBuilder (Automatic Setup)**
   - Create empty GameObject in scene
   - Add SceneBuilder script to it
   - Set "buildOnStart" to true
   - Play scene once to build
   - Save the scene
   - Delete the SceneBuilder GameObject
   - Save again

### Manual Scene Setup

If you prefer manual setup:

1. **Create Board**
   - GameObject → 3D Object → Cube
   - Name: "Board"
   - Position: (0, -0.5, 20)
   - Scale: (40, 1, 50)
   - Add PhysicMaterial with friction 0.3

2. **Create Walls**
   - Create 4 wall cubes around the board
   - Tag them as "Wall"

3. **Create Obstacles**
   - Scatter cubes on board as obstacles
   - Color them differently

4. **Create Slippery Objects** (3 objects)
   - Cube prefab with:
     - Rigidbody (mass 1, drag 0.3)
     - SlipperObject script
     - StartPosition set to initial position
     - Color: Orange

5. **Create Goal Area**
   - Cube at (0, 0.5, 40)
   - Scale: (8, 1, 8)
   - BoxCollider set to "Is Trigger"
   - Tag: "Goal"
   - Color: Green (semi-transparent)

6. **Create Player**
   - Empty GameObject "Player"
   - Position: (0, 1, -5)
   - Add Camera component
   - Add AudioListener component
   - Add PlayerController script
   - Add AudioSource component

## Game Flow

### MainMenu Scene
1. Create Canvas with UI buttons
2. Attach MainMenuManager script
3. "Start" button → Level1
4. "Quit" button → Exit game

### Level1 Scene
1. Player pushes/pulls objects toward goal
2. Objects must navigate obstacles
3. Slippery physics makes it challenging
4. All objects must reach goal to complete

### Level Progression
1. Complete Level1 → Level2
2. Complete Level2 → Level3
3. Complete Level3 → MainMenu

## Scripts Overview

- **GameManager**: Controls game state, time limit, goal detection
- **PlayerController**: Handles input (push/pull/reset)
- **SlipperObject**: Physics and goal detection for moveable objects
- **UIManager**: HUD, pause menu, level completion screens
- **ObstacleManager**: Dynamic obstacles and platforms
- **SoundManager**: Audio feedback
- **ParticleEffectManager**: Visual effects
- **LevelManager**: Scene transitions
- **MainMenuManager**: Menu navigation
- **SceneBuilder**: Automatic level generation

## Physics Configuration

### Recommended Settings
- Gravity: (0, -9.81, 0)
- Default Drag: 0.5
- Default Angular Drag: 0.05
- Solver Iterations: 6
- Solver Velocity Iterations: 2

### Slippery Material
- Static Friction: 0.1
- Dynamic Friction: 0.1
- Bounciness: 0.2
- Friction Combine: Minimum

## Controls

- **Left Click**: Push object
- **Right Click**: Pull object
- **R**: Reset nearest object
- **ESC**: Pause game

## Creating Additional Levels

1. Duplicate Level1 scene as Level2
2. Modify obstacle positions and count
3. Increase time pressure if desired
4. Add to Build Settings

## Troubleshooting

**Objects falling through floor:**
- Check BoxCollider on board
- Verify Rigidbody constraints

**Objects too fast/slow:**
- Adjust drag value in SlipperObject
- Modify push/pull force in PlayerController

**Goal not detecting objects:**
- Ensure "Goal" tag exists
- BoxCollider must have "Is Trigger" enabled
- Rigidbody must be on object

**Player can't move camera:**
- Verify PlayerController is on Player object
- Check Camera component exists

## Performance Tips

- Use object pooling for particles
- Limit physics updates per frame
- Use LOD groups for complex visuals
- Optimize particle effects

## Future Enhancements

- Multiple difficulty levels
- Power-ups and special items
- Sound effects and music
- Mobile controls support
- Leaderboard system
- More visual polish
