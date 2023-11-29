using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;
        [SetUp]
        public void Setup()
        {
            factory = new("TestFactory", 2);
        }

        [Test]
        public void ConstructorInitializingProperly()
        {
            Assert.IsNotNull(factory);
            Assert.AreEqual(factory.Name, "TestFactory");
            Assert.AreEqual(factory.Capacity, 2);
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
        }

        [Test]
        public void SuccessfullyProduceRobotWhenCapacityIsNotReached()
        {
            Assert.AreEqual(factory.ProduceRobot("Robot1", 10, 1), "Produced --> Robot model: Robot1 IS: 1, Price: 10.00");
        }
        [Test]
        public void ProducingARobbotAddsItToTheCollection()
        {
            factory.ProduceRobot("Robot1", 10, 1);
            Assert.AreEqual(1, factory.Robots.Count);
        }
        [Test]
        public void NotAddingRobotToCollectionIfCapacityIsReached()
        {
            factory.ProduceRobot("Robot1", 10, 1);
            factory.ProduceRobot("Robot2", 12, 1);
            factory.ProduceRobot("Robot3", 13, 1);
            factory.ProduceRobot("Robot4", 14, 1);

            Assert.AreEqual(2, factory.Robots.Count);
        }

        [Test]
        public void CorrectMessageShowsIfCapacityIsReached()
        {
            factory.ProduceRobot("Robot1", 10, 1);
            factory.ProduceRobot("Robot2", 12, 1);

            Assert.AreEqual(factory.ProduceRobot("Robot3", 10, 1), "The factory is unable to produce more robots for this production day!");
        }
        [Test]
        public void AddingSupplementToCollectionWhenCapacityIsNotReached()
        {
            factory.ProduceSupplement("Supplement1", 1);

            Assert.AreEqual(1, factory.Supplements.Count);
        }
        [Test]
        public void CorrectMessageShowsWhenSupplementIsAdded()
        { 
            Assert.AreEqual(factory.ProduceSupplement("Supplement1", 1), "Supplement: Supplement1 IS: 1");
        }

        [Test]
        public void SellRobotShowsTheCorrectRobot()
        {

            factory.ProduceRobot("Robot1",20, 1);
            factory.ProduceRobot("Robot2", 3, 1);
            Robot robot = factory.Robots[1];

            Assert.AreEqual(factory.SellRobot(10), robot);
        }
        [Test]
        public void UpgradingARobotReturnsFalseIfContainsSupplement()
        {
            Robot robot = new("Robot1", 20, 1);
            Supplement supplement = new("Supplement1", 1);

            robot.Supplements.Add(supplement);

            Assert.AreEqual(factory.UpgradeRobot(robot, supplement), false);
        }
        [Test]
        public void UpgradingARobotReturnsFalseIfInterfaceStandartDoesNotMatch()
        {
            Robot robot = new("Robot1", 20, 1);
            Supplement supplement = new("Supplement1", 2);


            Assert.AreEqual(factory.UpgradeRobot(robot, supplement), false);
        }
        [Test]
        public void UpgradingARobotReturnsTrueAndUpdatesCollection()
        {
            Robot robot = new("Robot1", 20, 1);
            Supplement supplement = new("Supplement1", 1);


            Assert.AreEqual(factory.UpgradeRobot(robot, supplement), true);
            Assert.AreEqual(robot.Supplements.Count, 1);
        }

    }
}