using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using RobotController.Core.Interfaces;
using RobotController.Core;
using RobotController;
namespace RobotController.Tests
{
    [TestClass]
    public class OutputTests
    {
        IUI UI = new MyUI();
        IMovingObject Robot = new MyRobot();
        IEnviroment Room = new MyRoom();

        StringBuilder StringBuilder = new StringBuilder();
        string ActualOutput
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
            string expectedOutput = "1 1 E";
            DoBasicArrangements(commands, robotStartPoistionAndFacingDirection: "1 1 E");

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }


        [TestMethod]
        public void Check_If_Robot_Moves_To_Adjacent_Position_Left()
        {
            //arrange
            string commands = "LF";
            string expectedOutput = "0 1 W";
            DoBasicArrangements(commands);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }


        [TestMethod]
        public void Check_If_Robot_Moves_To_Adjacent_Position_Right()
        {
            //arrange
            string commands = "LF";
            string expectedOutput = "0 1 W";
            DoBasicArrangements(commands);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Moves_To_Adjacent_Position_Down()
        {
            //arrange

            string commands = "RRF";
            string roomWidthAndDepth = "3 3";
            string expectedOutput = "1 2 S";
            DoBasicArrangements(commands,roomWidthAndDepth);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }


        [TestMethod]
        public void Check_If_Robot_Moves_To_Adjacent_Position_Up()
        {
            //arrange

            string commands = "F";
            string expectedOutput = "1 0 N";
            DoBasicArrangements(commands);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Rotates_Full_Circle_Clockwise()
        {
            //arrange

            string commands = "RRRR";
            string expectedOutput = "1 1 N";
            DoBasicArrangements(commands);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Rotates_Full_Circle_Counter_Clockwise()
        {
            //arrange

            string commands = "LLLL";
            string expectedOutput = "1 1 N";
            DoBasicArrangements(commands);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Hits_The_Wall_North()
        {
            //arrange
            string commands = "F";
            string roomWidthAndDepth = "1 1";
            string robotStartPoistionAndFacingDirection = "0 0 N";
            string expectedOutput = "0 0 N";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Hits_The_Wall_East()
        {
            //arrange
            string commands = "RF";
            string roomWidthAndDepth = "1 1";
            string robotStartPoistionAndFacingDirection = "0 0 N";
            string expectedOutput = "0 0 E";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }


        [TestMethod]
        public void Check_If_Robot_Hits_The_Wall_South()
        {
            //arrange
            string commands = "RRF";
            string roomWidthAndDepth = "1 1";
            string robotStartPoistionAndFacingDirection = "0 0 N";
            string expectedOutput = "0 0 S";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

        [TestMethod]
        public void Check_If_Robot_Hits_The_Wall_West()
        {
            //arrange
            string commands = "RRRF";
            string roomWidthAndDepth = "1 1";
            string robotStartPoistionAndFacingDirection = "0 0 N";
            string expectedOutput = "0 0 W";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

        [TestMethod]
        public void ExampleTest1()
        {
            //arrange
            string commands = "RFRFFRFRF";
            string roomWidthAndDepth = "5 5";
            string robotStartPoistionAndFacingDirection = "1 2 N";
            string expectedOutput = "1 3 N";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

        [TestMethod]
        public void ExampleTest2()
        {
            //arrange
            string commands = "RFLFFLRF";
            string roomWidthAndDepth = "5 5";
            string robotStartPoistionAndFacingDirection = "0 0 E";
            string expectedOutput = "3 1 E";
            DoBasicArrangements(commands, roomWidthAndDepth, robotStartPoistionAndFacingDirection);

            //act
            App.Run(UI, Room, Robot);

            //assert
            Assert.AreEqual<string>(expectedOutput, ActualOutput);
        }

    }
}
