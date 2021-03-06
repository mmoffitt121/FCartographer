/*

///////////////////////////////////////////////////////////////////////////////

MIT License

Copyright (c) 2019 Sebastian Lague

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

///////////////////////////////////////////////////////////////////////////////

Modified for the needs of FCartogropher.

*/

using System;
using System.Diagnostics;

namespace FCartographer.ErosionSimulation
{
    internal class Erosion
    {
        public int seed;
        public int erosionRadius = 3;
        public float inertia = .05f; // At zero, water will instantly change direction to flow downhill. At 1, water will never change direction. 
        public float sedimentCapacityFactor = 4; // Multiplier for how much sediment a droplet can carry
        public float minSedimentCapacity = .01f; // Used to prevent carry capacity getting too close to zero on flatter terrain
        public float erodeSpeed = .3f;
        public float depositSpeed = .3f;
        public float evaporateSpeed = .01f;
        public float gravity = 4;
        public int maxDropletLifetime = 30;

        public float initialWaterVolume = 1;
        public float initialSpeed = 1;

        // Indices and weights of erosion brush precomputed for every node
        int[][] erosionBrushIndices;
        float[][] erosionBrushWeights;
        System.Random prng;

        int currentSeed;
        int currentErosionRadius;
        int currentMapSize;

        // Initialization creates a System.Random object and precomputes indices and weights of erosion brush
        private void Initialize(int xSize, int ySize, bool resetSeed)
        {
            if (resetSeed || prng == null || currentSeed != seed)
            {
                prng = new System.Random(seed);
                currentSeed = seed;
            }

            if (erosionBrushIndices == null || currentErosionRadius != erosionRadius || currentMapSize != xSize * ySize)
            {
                InitializeBrushIndices(xSize, ySize, erosionRadius);
                currentErosionRadius = erosionRadius;
                currentMapSize = xSize * ySize;
            }
        }

        public void SetSeed(int _seed)
        {
            seed = _seed;
        }

        public float[] Erode(float[] inputmap, int xSize, int ySize, int numIterations = 1, bool resetSeed = false)
        {
            Initialize(xSize, ySize, resetSeed);

            int mapSize = xSize;
            
            float[] map = new float[xSize * ySize];

            for (int i = 0; i < xSize * ySize; i++)
            {
                map[i] = inputmap[i];
            }
            
            for (int iteration = 0; iteration < numIterations; iteration++)
            {
                // Create water droplet at random point on map
                float posX = prng.Next(0, xSize - 1);
                float posY = prng.Next(0, ySize - 1);
                float dirX = 0;
                float dirY = 0;
                float speed = initialSpeed;
                float water = initialWaterVolume;
                float sediment = 0;

                for (int lifetime = 0; lifetime < maxDropletLifetime; lifetime++)
                {
                    int nodeX = (int)posX;
                    int nodeY = (int)posY;
                    int dropletIndex = nodeY * xSize + nodeX;
                    // Calculate droplet's offset inside the cell (0,0) = at NW node, (1,1) = at SE node
                    float cellOffsetX = posX - nodeX;
                    float cellOffsetY = posY - nodeY;

                    // Calculate droplet's height and direction of flow with bilinear interpolation of surrounding heights
                    HeightAndGradient heightAndGradient = CalculateHeightAndGradient(map, xSize, posX, posY);

                    // Update the droplet's direction and position (move position 1 unit regardless of speed)
                    dirX = (dirX * inertia - heightAndGradient.gradientX * (1 - inertia));
                    dirY = (dirY * inertia - heightAndGradient.gradientY * (1 - inertia));
                    // Normalize direction
                    float len = MathF.Sqrt(dirX * dirX + dirY * dirY);
                    if (len != 0)
                    {
                        dirX /= len;
                        dirY /= len;
                    }
                    posX += dirX;
                    posY += dirY;

                    // Stop simulating droplet if it's not moving or has flowed over edge of map
                    if ((dirX == 0 && dirY == 0) || posX < 0 || posX >= xSize - 1 || posY < 0 || posY >= ySize - 1)
                    {
                        break;
                    }

                    // Find the droplet's new height and calculate the deltaHeight
                    float newHeight = CalculateHeightAndGradient(map, xSize, posX, posY).height;
                    float deltaHeight = newHeight - heightAndGradient.height;

                    // Calculate the droplet's sediment capacity (higher when moving fast down a slope and contains lots of water)
                    float sedimentCapacity = MathF.Max(-deltaHeight * speed * water * sedimentCapacityFactor, minSedimentCapacity);

                    // If carrying more sediment than capacity, or if flowing uphill:
                    if (sediment > sedimentCapacity || deltaHeight > 0)
                    {
                        // If moving uphill (deltaHeight > 0) try fill up to the current height, otherwise deposit a fraction of the excess sediment
                        float amountToDeposit = (deltaHeight > 0) ? MathF.Min(deltaHeight, sediment) : (sediment - sedimentCapacity) * depositSpeed;
                        sediment -= amountToDeposit;

                        // Add the sediment to the four nodes of the current cell using bilinear interpolation
                        // Deposition is not distributed over a radius (like erosion) so that it can fill small pits
                        map[dropletIndex] += amountToDeposit * (1 - cellOffsetX) * (1 - cellOffsetY);
                        map[dropletIndex + 1] += amountToDeposit * cellOffsetX * (1 - cellOffsetY);
                        map[dropletIndex + xSize] += amountToDeposit * (1 - cellOffsetX) * cellOffsetY;
                        map[dropletIndex + xSize + 1] += amountToDeposit * cellOffsetX * cellOffsetY;
                    }
                    else
                    {
                        // Erode a fraction of the droplet's current carry capacity.
                        // Clamp the erosion to the change in height so that it doesn't dig a hole in the terrain behind the droplet
                        float amountToErode = MathF.Min((sedimentCapacity - sediment) * erodeSpeed, -deltaHeight);

                        // Use erosion brush to erode from all nodes inside the droplet's erosion radius
                        for (int brushPointIndex = 0; brushPointIndex < erosionBrushIndices[dropletIndex].Length; brushPointIndex++)
                        {
                            int nodeIndex = erosionBrushIndices[dropletIndex][brushPointIndex];
                            float weighedErodeAmount = amountToErode * erosionBrushWeights[dropletIndex][brushPointIndex];
                            float deltaSediment = (map[nodeIndex] < weighedErodeAmount) ? map[nodeIndex] : weighedErodeAmount;
                            map[nodeIndex] -= deltaSediment;
                            sediment += deltaSediment;
                        }
                    }

                    // Update droplet's speed and water content
                    speed = MathF.Sqrt(speed * speed + deltaHeight * gravity);
                    water *= (1 - evaporateSpeed);
                }
            }
            return map;
        }

        private static HeightAndGradient CalculateHeightAndGradient(float[] nodes, int mapSize, float posX, float posY)
        {
            int coordX = (int)posX;
            int coordY = (int)posY;

            // Calculate droplet's offset inside the cell (0,0) = at NW node, (1,1) = at SE node
            float x = posX - coordX;
            float y = posY - coordY;

            // Calculate heights of the four nodes of the droplet's cell
            int nodeIndexNW = coordY * mapSize + coordX;
            float heightNW = nodes[nodeIndexNW];
            float heightNE = nodes[nodeIndexNW + 1];
            float heightSW = nodes[nodeIndexNW + mapSize];
            float heightSE = nodes[nodeIndexNW + mapSize + 1];

            // Calculate droplet's direction of flow with bilinear interpolation of height difference along the edges
            float gradientX = (heightNE - heightNW) * (1 - y) + (heightSE - heightSW) * y;
            float gradientY = (heightSW - heightNW) * (1 - x) + (heightSE - heightNE) * x;

            // Calculate height with bilinear interpolation of the heights of the nodes of the cell
            float height = heightNW * (1 - x) * (1 - y) + heightNE * x * (1 - y) + heightSW * (1 - x) * y + heightSE * x * y;

            return new HeightAndGradient() { height = height, gradientX = gradientX, gradientY = gradientY };
        }

        private void InitializeBrushIndices(int xSize, int ySize, int radius)
        {
            erosionBrushIndices = new int[xSize * ySize][];
            erosionBrushWeights = new float[xSize * ySize][];

            int[] xOffsets = new int[radius * radius * 4];
            int[] yOffsets = new int[radius * radius * 4];
            float[] weights = new float[radius * radius * 4];
            float weightSum = 0;
            int addIndex = 0;

            for (int i = 0; i < erosionBrushIndices.GetLength(0); i++)
            {
                int centreX = i % xSize;
                int centreY = i / xSize;

                if (centreY <= radius || centreY >= ySize - radius || centreX <= radius + 1 || centreX >= xSize - radius)
                {
                    weightSum = 0;
                    addIndex = 0;
                    for (int y = -radius; y <= radius; y++)
                    {
                        for (int x = -radius; x <= radius; x++)
                        {
                            float sqrDst = x * x + y * y;
                            if (sqrDst < radius * radius)
                            {
                                int coordX = centreX + x;
                                int coordY = centreY + y;

                                if (coordX >= 0 && coordX < xSize && coordY >= 0 && coordY < ySize)
                                {
                                    float weight = 1 - MathF.Sqrt(sqrDst) / radius;
                                    weightSum += weight;
                                    weights[addIndex] = weight;
                                    xOffsets[addIndex] = x;
                                    yOffsets[addIndex] = y;
                                    addIndex++;
                                }
                            }
                        }
                    }
                }

                int numEntries = addIndex;
                erosionBrushIndices[i] = new int[numEntries];
                erosionBrushWeights[i] = new float[numEntries];

                for (int j = 0; j < numEntries; j++)
                {
                    erosionBrushIndices[i][j] = (yOffsets[j] + centreY) * xSize + xOffsets[j] + centreX;
                    erosionBrushWeights[i][j] = weights[j] / weightSum;
                }
            }
        }

        private struct HeightAndGradient
        {
            public float height;
            public float gradientX;
            public float gradientY;
        }
    }
}
