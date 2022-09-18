using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using RobotController.Core.Interfaces;
using RobotController.Core;
using RobotController;
namespace Simulator.Tests
{
    [TestClass]
    public class Tests
    {
        IUI UI = new MyUI();
        IRobot Robot = new MyRobot();
        IRoom Room = new MyRoom();

        StringBuilder StringBuilder = new StringBuilder();
        string FinalOutput
        {
            get
            {
                string fullString = StringBuilder.ToString();
                string[] arrayOfString = fullString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                string finalOutPut = arrayOfString[^1];
                return finalOutPut;
            }
        }
       
        void RedirectStdOut()
        {

            TextWriter writer = new StringWriter(StringBuilder);
            Console.SetOut(writer);
        }

        void RedirectStdIn(string roomWidthAndDepth, string robotStartPoistionAndFacingDirection, string commands)
        {
            var testData = String.Join(Environment.NewLine, new[] { roomWidthAndDepth, robotStartPoistionAndFacingDirection, commands });
            Console.SetIn(new System.IO.StringReader(testData));
        }

        void DoBasicArrangements(string commands, string roomWidthAndDepth = "2 2" , string robotStartPoistionAndFacingDirection = "1 1 N")
        {
            RedirectStdOut();
            RedirectStdIn(roomWidthAndDepth, robotStartPoistionAndFacingDirection, commands);
        }

        [TestMethod]
        public void Check_If_Robot_Starts_With_Assigned_Facing_Direction()
        {
            //arrange
            string commands = "";
            string expectedFinalPosition = "1 1 E";
            DoBasicArrangements(commands, robotStartPoistionAndFacingDirection: "1 1 E");

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }


        [TestMethod]
        public void Check_If_Robot_Moves_To_Adjacent_Position_Left()
        {
            //arrange
            string commands = "LF";
            string expectedFinalPosition = "0 1 W";
            DoBasicArrangements(commands);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }


        [TestMethod]
        public void Check_If_Robot_Moves_To_Adjacent_Position_Right()
        {
            //arrange
            string commands = "LF";
            string expectedFinalPosition = "0 1 W";
            DoBasicArrangements(commands);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Moves_To_Adjacent_Position_Down()
        {
            //arrange

            string commands = "RRF";
            string expectedFinalPosition = "1 2 S";
            DoBasicArrangements(commands);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }


        [TestMethod]
        public void Check_If_Robot_Moves_To_Adjacent_Position_Up()
        {
            //arrange

            string commands = "F";
            string expectedFinalPosition = "1 0 N";
            DoBasicArrangements(commands);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Moves_Full_Circle_Clockwise()
        {
            //arrange

            string commands = "RRRRF";
            string expectedFinalPosition = "1 0 N";
            DoBasicArrangements(commands);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Moves_Full_Circle_Counter_Clockwise()
        {
            //arrange

            string commands = "LLLLF";
            string expectedFinalPosition = "1 0 N";
            DoBasicArrangements(commands);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Hits_The_Wall_North()
        {
            //arrange
            string commands = "F";
            string roomWidthAndDepth = "1 1";
            string robotStartPoistionAndFacingDirection = "0 0 N";
            string expectedFinalPosition = "0 0 N";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Hits_The_Wall_East()
        {
            //arrange
            string commands = "RF";
            string roomWidthAndDepth = "1 1";
            string robotStartPoistionAndFacingDirection = "0 0 N";
            string expectedFinalPosition = "0 0 E";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }


        [TestMethod]
        public void Check_If_Robot_Hits_The_Wall_South()
        {
            //arrange
            string commands = "RRF";
            string roomWidthAndDepth = "1 1";
            string robotStartPoistionAndFacingDirection = "0 0 N";
            string expectedFinalPosition = "0 0 S";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Hits_The_Wall_West()
        {
            //arrange
            string commands = "RRRF";
            string roomWidthAndDepth = "1 1";
            string robotStartPoistionAndFacingDirection = "0 0 N";
            string expectedFinalPosition = "0 0 W";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            Controller.TurnOn(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedFinalPosition, FinalOutput);
        }

    }
}
