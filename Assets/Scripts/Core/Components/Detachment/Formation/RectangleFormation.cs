using System.Collections.Generic;
using UnityEngine;

namespace Core.Components.Detachment.Formation
{
    public struct RectangleFormation
    {
        private int _columnCount;
        private float _spacing;
        
        public RectangleFormation(int columnCount, float spacing)
        {
            _columnCount = columnCount;
            _spacing = spacing;
        }

        public List<Vector3> GetPositions(int unitCount)
        {
            var unitPositions = new List<Vector3>();
            var unitsPerRow = Mathf.Min(_columnCount, unitCount);
            var offset = (unitsPerRow - 1) * _spacing / 2f;
            float x, y, column;

            for (int row = 0; unitPositions.Count < unitCount; row++)
            {
                var firstIndexInRow = row * _columnCount;
                if (row != 0 && firstIndexInRow + _columnCount > unitCount)
                {
                    var emptySlots = firstIndexInRow + _columnCount - unitCount;
                    offset -= emptySlots / 2f * _spacing;
                }

                for (column = 0; column < _columnCount; column++)
                {
                    if (firstIndexInRow + column < unitCount)
                    {
                        x = column * _spacing - offset;
                        y = row * _spacing;
                        unitPositions.Add(new Vector3(x, 0, -y));
                    }
                    else
                    {
                        return unitPositions;
                    }
                }
            }

            return unitPositions;
        }

    }

}