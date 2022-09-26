using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Core.Interfaces
{
    public interface IEnviroment
    {
        bool IsPositionWithinEnviroment(Position position);
        void SetDimensions(string value);
    }
}
