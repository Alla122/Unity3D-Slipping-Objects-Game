# Setup Instructions for Unity 3D Slipping Objects Game

## Prerequisites
- Unity 2021 LTS or newer
- Visual Studio or JetBrains Rider (recommended)

## Initial Setup Steps

### 1. Open Project in Unity
- Launch Unity Hub
- Open this project directory
- Allow Unity to import all assets

### 2. Create Scenes and Basic Level
- Right-click in Assets/Scenes folder → Create → Scene
- Name it "Level1"
- Save it

### 3. Setup the Game Scene (Level1)
1. Create GameObject hierarchy:
   - `Board` (Cube, scaled to be large flat surface) - This is where objects will slide
   - `Player` (Camera with PlayerController script attached)
   - `SlipperObject` (multiple cubes) - Objects to move
   - `Goal` (Cube or special marker) - Destination for objects
   - `Obstacles` (Various cube/wall shapes)

2. Add Components:
   - SlipperObject: Add Rigidbody (Body Type: Dynamic, Mass: 1, Drag: 0.5)
   - SlipperObject: Add Box Collider (Is Trigger: OFF)
   - Goal: Add Box Collider (Is Trigger: ON) and tag it "Goal"

3. Assign Scripts:
   - Attach GameManager to empty GameObject named "GameController"
   - Attach PlayerController to the Player/Camera
   - Attach UIManager to Canvas
   - Attach ObstacleManager to Obstacles parent

### 4. Create UI
1. Create → UI → Canvas
2. Add Text elements:
   - Timer display (top left)
   - Object counter (top right)
   - Level complete overlay
   - Level failed overlay

### 5. Configure Physics
- Edit → Project Settings → Physics
- Set Gravity to (0, 0, 0) or (-9.8, 0, 0) depending on board orientation
- Adjust Drag and Angular Drag defaults

### 6. Test the Game
- Press Play in Editor
- Move objects using mouse toward the goal
- Avoid obstacles

## Level Design Tips

- Create varied obstacle layouts (walls, ramps, narrow passages)
- Use moving platforms for extra challenge
- Position the goal strategically
- Add visual feedback (particle effects, colors)

## Troubleshooting

**Objects moving too fast:**
- Increase drag value in SlipperObject
- Reduce push force in PlayerController

**Objects not slipping enough:**
- Decrease dynamic/static friction in SlipperMaterial
- Decrease mass of objects

**Goal detection not working:**
- Ensure Goal has "Goal" tag
- Check that Goal collider is set to "Is Trigger"

**Camera not detecting objects:**
- Verify colliders are on objects
- Check interaction range in PlayerController
