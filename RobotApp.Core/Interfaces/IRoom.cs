using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Core.Interfaces
{
    public interface IRoom
    {
        bool IsPositionWithinTable(Position position);
        void SetDimensions();
    }
}
