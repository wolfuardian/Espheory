using NSubstitute;
using NUnit.Framework;
using Zenject;

namespace Espheory.Player.EditModeTests
{
    public class ActionControllerTests : ZenjectUnitTestFixture
    {
        #region Private Variables

        private ActionController actionController;

        #endregion

        #region Test Methods

        [Test]
        public void Should_Succeed_When_Select()
        {
            // arrange // given
            // act // when
            Select(1);
            // assert // then
            Should_State_Equal(ActionState.Select);
        }

        [Test]
        public void Given_Select_State_Should_Did_Not_Succeed_When_Tick()
        {
            // arrange // given
            Select(1);
            // act // when
            TickActionController();
            // assert // then
            Should_State_Equal(ActionState.SelectCooldown);
        }

        [Test]
        public void Should_Succeed_When_Init()
        {
            // arrange // given
            // act // when
            // assert // then
            Should_State_Equal(ActionState.Idle);
        }

        #endregion

        #region Public Methods

        public override void Setup()
        {
            base.Setup();

            Container.Bind<ActionController>().AsSingle();

            actionController = Container.Resolve<ActionController>();
        }

        #endregion

        #region Private Methods

        private void Select(int value)
        {
            actionController.Select(value);
        }

        private void TickActionController()
        {
            actionController.Tick();
        }

        private void Should_State_Equal(ActionState exceptState)
        {
            Assert.AreEqual(exceptState, actionController.State, "State is not equal");
        }

        #endregion
    }
}