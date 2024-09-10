using NSubstitute;
using NUnit.Framework;
using Zenject;

namespace Espheory.Player.EditModeTests
{
    public class ActionServiceTests : ZenjectUnitTestFixture
    {
        #region Private Variables

        private ActionService actionService;
        private IAction       action;

        #endregion

        #region Test Methods

        [Test]
        public void Should_Do_Select()
        {
            // arrange // given
            GivenActionState(ActionState.Idle);
            // act // when
            Select();
            // assert // then
            ShouldSelect();
        }

        [Test]
        public void Should_Did_Not_Select()
        {
            // arrange // given
            GivenActionState(ActionState.Select);
            // act // when
            Select();
            // assert // then
            DidNotSelect();
        }

        #endregion

        #region Public Methods

        public override void Setup()
        {
            base.Setup();
            Container.Bind<ActionService>().AsSingle();
            Container.Bind<IAction>().FromSubstitute();
            actionService = Container.Resolve<ActionService>();
            action        = Container.Resolve<IAction>();
        }

        #endregion

        #region Private Methods

        private void GivenActionState(ActionState state)
        {
            action.State.Returns(state);
        }

        private void Select()
        {
            actionService.Select();
        }

        private void ShouldSelect()
        {
            action.Received().Select(1);
        }

        private void DidNotSelect()
        {
            action.DidNotReceiveWithAnyArgs().Select(1);
        }

        #endregion
    }
}