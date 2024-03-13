#region

using NSubstitute;
using NUnit.Framework;
using Zenject;

#endregion

namespace Espheory.Player.EditModeTests
{
    public class PlayerControllerTests : ZenjectUnitTestFixture
    {
        #region Private Variables

        private IInputReader     inputReader;
        private IActionService   service;
        private PlayerController playerController;

        #endregion

        #region Test Methods

        [Test]
        public void Given_Select_Key_Down_Should_Did_Not_Receive_Select_When_Tick()
        {
            // arrange // given
            Given_Select_Key_Down(true);
            // act // when
            Tick_PlayerController();
            // assert // then
            Did_Not_Select();
        }

        [Test]
        public void Given_Select_Key_Push_Should_Receive_Select_When_Tick()
        {
            // arrange // given
            Given_Select_Key_Push(true);
            // act // when
            Tick_PlayerController();
            // assert // then
            Should_Select();
        }

        [Test]
        public void Given_Select_Key_Push_Should_Did_Not_Receive_When_Tick()
        {
            // arrange // given
            Given_Select_Key_Push(false);
            // act // when
            Tick_PlayerController();
            // assert // then
            Did_Not_Select();
        }

        [Test]
        public void Given_Select_Key_Down_Should_Did_Not_Detect_Floor_When_Tick()
        {
            // arrange // given
            Given_Select_Key_Down(true);
            // act // when
            Tick_PlayerController();
            // assert // then
            Did_Not_Select();
        }

        [Test]
        public void Given_Select_Key_Push_Should_Detect_Floor_When_Tick()
        {
            // arrange // given
            Given_Select_Key_Push(true);
            // act // when
            Tick_PlayerController();
            // assert // then
            Should_Select();
        }

        #endregion

        #region Public Methods

        public override void Setup()
        {
            base.Setup();

            Container.Bind<IInputReader>().FromSubstitute().AsSingle();
            Container.Bind<IActionService>().FromSubstitute().AsSingle();
            Container.Bind<PlayerController>().AsSingle();

            inputReader      = Container.Resolve<IInputReader>();
            service          = Container.Resolve<IActionService>();
            playerController = Container.Resolve<PlayerController>();
        }

        #endregion

        #region Private Methods

        private void Given_Select_Key_Down(bool keyDown)
        {
            inputReader.IsSelectKeyDown().Returns(keyDown);
        }

        private void Given_Select_Key_Push(bool keyDown)
        {
            inputReader.IsSelectKeyPush().Returns(keyDown);
        }

        private void Tick_PlayerController()
        {
            playerController.Tick();
        }

        private void Should_Select()
        {
            service.Received(1).Select();
        }

        private void Did_Not_Select()
        {
            service.DidNotReceiveWithAnyArgs().Select();
        }

        #endregion
    }
}