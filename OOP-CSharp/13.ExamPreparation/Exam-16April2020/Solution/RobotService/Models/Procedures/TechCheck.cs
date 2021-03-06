using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public TechCheck()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= 8;

            if (robot.IsChecked == true)
            {
                robot.Energy -= 8;
            }
            else
            {
                robot.IsChecked = true;
            }

            this.Robots.Add(robot);
        }
    }
}
