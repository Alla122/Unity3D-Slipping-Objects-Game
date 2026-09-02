#!/bin/bash
# Build script for Unity 3D Slipping Objects Game

echo "Building Slipping Objects Game..."

# Check if Unity is installed
if ! command -v unity &> /dev/null; then
    echo "Error: Unity is not installed or not in PATH"
    echo "Please install Unity 2021 LTS or newer"
    exit 1
fi

echo "Unity found: $(unity --version)"

# Build for Windows
echo "Building for Windows..."
unity -quit -batchmode -projectPath . -executeMethod BuildScript.BuildWindows64

echo "Build complete!"
echo "Output: Builds/Windows/SlippingObjects.exe"
